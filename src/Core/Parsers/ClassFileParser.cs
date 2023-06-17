using Domain.Enums;
using Domain.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Parsers
{
    public class ClassFileParser : IFileScheduleParser
    {
        public Task<ParseResult> Parse(byte[] fileData, FileType fileType, string scheduleName)
        {
            if (fileType == FileType.NotSupported || !scheduleName.Contains("Розклад занять"))
            {
                return Task.FromResult(ParseResult.NotSupportedFile());
            }

            var result = ParseFile(fileData, fileType);
            return Task.FromResult(result);
        }

        private ParseResult ParseFile(byte[] fileData, FileType fileType)
        {
            try
            {
                using (var ms = new MemoryStream(fileData))
                {
                    var workbook = fileType == FileType.Xls ? new HSSFWorkbook(ms) : (IWorkbook)new XSSFWorkbook(ms);
                    var sheet = workbook.GetSheetAt(0);
                    var columnsCount = sheet.GetRow(3).Count();
                    var rowCount = sheet.LastRowNum;

                    var classes = new List<Class>();

                    for (int columnindex = 2; columnindex < columnsCount; columnindex++)
                    {
                        var cells = new List<ICell>();

                        for (var rowIndex = 3; rowIndex <= rowCount; rowIndex++)
                        {
                            var row = sheet.GetRow(rowIndex);

                            if (row == null)
                            {
                                rowCount = rowIndex - 1;
                                break;
                            }

                            var cell = row.GetCell(columnindex);
                            cells.Add(cell);
                        }

                        var weekDayCounter = 1;
                        var numberCounter = 1;

                        for (var cellIndex = 0; cellIndex < cells.Count; cellIndex += rowCount)
                        {
                            string groupName = string.Empty, groupAlternativeName = string.Empty;

                            if (cells[cellIndex].StringCellValue != "")
                            {
                                if (cells[cellIndex].IsMergedCell)
                                {
                                    var stringValue = cells[cellIndex].StringCellValue;
                                    var groupNameParts = stringValue.Split('\n');

                                    groupName = groupNameParts[0];
                                    groupAlternativeName = groupNameParts[1];
                                }
                                else
                                {
                                    groupName = cells[cellIndex].StringCellValue;
                                    groupAlternativeName = cells[cellIndex + 1].StringCellValue;
                                }
                            }
                            else 
                                continue;

                            var group = new Group(groupName, groupAlternativeName);

                            for (var index = cellIndex + 2; index < rowCount && index + 4 < rowCount; index += 4)
                            {
                                if (index + 5 > cells.Count)
                                {
                                    break;
                                }

                                if (numberCounter > 8)
                                {
                                    weekDayCounter++;
                                    numberCounter = 1;
                                }

                                if (cells[index] == null)
                                {
                                    continue;
                                }

                                if (cells[index].IsMergedCell)
                                {
                                    if (!string.IsNullOrEmpty(cells[index].StringCellValue))
                                    {
                                        var teacher = !string.IsNullOrEmpty(cells[index + 3].StringCellValue) ? new Teacher(cells[index + 3].StringCellValue) : new Teacher("-");
                                        var @class = new Class(cells[index].StringCellValue, group, teacher, null, weekDayCounter, numberCounter, WeekType.None);

                                        classes.Add(@class);
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(cells[index].StringCellValue) )
                                    {
                                        var teacher = !string.IsNullOrEmpty(cells[index + 1].StringCellValue) ? new Teacher(cells[index + 1].StringCellValue) : new Teacher("-");
                                        var @class = new Class(cells[index].StringCellValue, group, teacher, null, weekDayCounter, numberCounter, WeekType.Numerator);

                                        classes.Add(@class);
                                    }
                                    
                                    if (cells[index + 2] == null)
                                    {
                                        continue;
                                    }

                                    if (!string.IsNullOrEmpty(cells[index + 2].StringCellValue))
                                    {
                                        var teacher = cells[index + 3].StringCellValue != "" ? new Teacher(cells[index + 3].StringCellValue) : new Teacher("-");
                                        var @class = new Class(cells[index + 2].StringCellValue, group, teacher, null, weekDayCounter, numberCounter, WeekType.Denominator);

                                        classes.Add(@class);
                                    }
                                }
                                numberCounter++;
                            }
                        }
                    }
                    var res = new ParseResult(classes.ToArray(), null);
                    return new ParseResult(classes.ToArray(), null);
                }
            }
            catch (Exception e)
            {
                return ParseResult.ParseFailed(e.Message);
            }
        }
    }
}