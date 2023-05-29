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
    public class ModuleFileParser : IFileScheduleParser
    {
        public Task<ParseResult> Parse(byte[] fileData, FileType fileType, string scheduleName)
        {
            if (fileType == FileType.NotSupported || !scheduleName.Contains("МК"))
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
                     
                    int countSheet = 2; 
                    var classes = new List<Class>();
                    for (var sheetIndex = 0; sheetIndex < countSheet; sheetIndex++)
                    {
                        var sheet = workbook.GetSheetAt(sheetIndex);

                        var columnsCount = sheet.GetRow(3).Count();
                        var rowCount = sheet.LastRowNum;

                       

                        for (var columnIndex = 2; columnIndex < columnsCount; columnIndex += 2)
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

                                var cell = row.GetCell(columnIndex);
                                cells.Add(cell);
                            }

                            for (var cellIndex = 0; cellIndex < cells.Count; cellIndex += rowCount)
                            {
                                var stringValue = cells[cellIndex].StringCellValue;
                                var groupNameParts = stringValue.Split('\n');
                                var group = new Group(groupNameParts[0], groupNameParts[1]);

                                for (var index = cellIndex + 1; index < rowCount && index + 5 < rowCount; index += 5)
                                {
                                    if (index + 6 > cells.Count)
                                    {
                                        break;
                                    }

                                    if (cells[index] != null
                                        && cells[index + 1] != null
                                        && cells[index + 2] != null
                                        && cells[index + 3] != null
                                        && cells[index + 4].StringCellValue != ""
                                        && !string.IsNullOrEmpty(cells[index + 2].StringCellValue))
                                    {
                                        var subject = cells[index + 2].StringCellValue;
                                        var teacher = new Teacher(cells[index + 3].StringCellValue);
                                        var date = cells[index].DateCellValue;
                                        var timeStringValue = cells[index + 4].StringCellValue;
                                        var timeParts = timeStringValue.Split('-');
                                        var fullDate = new DateTime(date.Year, date.Month, date.Day, int.Parse(timeParts[0]), int.Parse(timeParts[1]), 0);
                                        var number = GetClassNumber(timeStringValue);
                                        var subType = cells[index + 1].StringCellValue == "Консультація" ? ClassSubType.Consultation : ClassSubType.Exam;

                                        var @class = new Class(subject, group, teacher, null, (int)date.DayOfWeek, number, WeekType.None, subType, fullDate);
                                        classes.Add(@class);
                                    }
                                }
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

        public static int GetClassNumber(string str)
        {
            switch (str)
            {
                case "8-00":
                    return 1;

                case "9-30":
                    return 2;

                case "11-00":
                    return 3;

                case "13-00":
                    return 4;

                case "14-30":
                    return 5;

                case "15-00":
                    return 6;

                default:
                    return 0;
            }
        }
    }
}