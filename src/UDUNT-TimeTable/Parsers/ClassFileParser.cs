using Domain.Enums;
using Domain.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Parsers
{
    public class ClassFileParser : IFileScheduleParser
    {
        public Task<ParseResult> Parse(byte[] fileData, FileType fileType, string scheduleName)
        {
            try
            {
                if (scheduleName.Contains("Розклад занять"))
                {
                    IWorkbook workbook;
                    if (fileType == FileType.Xls) 
                    {
                        MemoryStream ms = new MemoryStream(fileData);
                        workbook = new HSSFWorkbook(ms);
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(fileData);
                        workbook = new XSSFWorkbook(ms);
                    }
                    ISheet sheet = workbook.GetSheetAt(0);

                    var colums = sheet.GetRow(3).Count();
                    int rowCount = sheet.LastRowNum;
                    Class[] subjects = new Class[rowCount / 10 * colums];
                    int countSubject = 0;
                    Group group;
                    Teacher teacher;

                    if (sheet != null)
                    {
                        for (int columnindex = 2; columnindex < colums; columnindex++)
                        {
                            List<ICell> list = new List<ICell>();
                            

                            for (int j = 3; j <= rowCount; j++)
                            {
                                IRow curRow = sheet.GetRow(j);

                                if (curRow == null)
                                {
                                    rowCount = j - 1;
                                    break;
                                }
                                ICell cell = curRow.GetCell(columnindex);
                                list.Add(cell);
                            }
                            int weekDayCounter = 1;
                            int numberCounter = 1;
                            
                            for (int i = 0; i < list.Count; i += rowCount)
                            {
                                if (list[i].IsMergedCell)
                                {
                                    string str = list[i].StringCellValue;
                                    string[] groups = str.Split('\n');
                                    group = new Group(groups[0], groups[1]);
                                }
                                else
                                    group = new Group(list[i].StringCellValue, list[i + 1].StringCellValue);
                                for (int j = i + 2; j < rowCount && j + 4 < rowCount; j += 4)
                                {
                                    if (j + 5 > list.Count)
                                        break;
                                    if (numberCounter > 8) { weekDayCounter++; numberCounter = 1; }

                                    if (list[j] == null) continue;
                                    if (list[j].IsMergedCell)
                                    {
                                        if (list[j + 3].StringCellValue != "")
                                            teacher = new Teacher(list[j + 3].StringCellValue);
                                        else teacher = new Teacher("-");

                                        subjects[countSubject] = new Class();
                                        subjects[countSubject].ScheduleName = scheduleName;
                                        subjects[countSubject].WeekDay = weekDayCounter;
                                        subjects[countSubject].Number = numberCounter;
                                        subjects[countSubject].WeekType = WeekType.None;
                                        subjects[countSubject].Subject = list[j].StringCellValue;
                                        subjects[countSubject].Group = group;
                                        subjects[countSubject].Teacher = teacher;
                                        subjects[countSubject].Room = null;
                                        countSubject++;
                                    }
                                    else
                                    {
                                        if (list[j].StringCellValue != "")
                                        {
                                            if (list[j + 1].StringCellValue != "")
                                                teacher = new Teacher(list[j + 1].StringCellValue);
                                            else teacher = new Teacher("-");

                                            subjects[countSubject] = new Class();
                                            subjects[countSubject].ScheduleName = scheduleName;
                                            subjects[countSubject].WeekDay = weekDayCounter;
                                            subjects[countSubject].Number = numberCounter;
                                            subjects[countSubject].WeekType = WeekType.Numerator;
                                            subjects[countSubject].Subject = list[j].StringCellValue;
                                            subjects[countSubject].Group = group;
                                            subjects[countSubject].Teacher = teacher;
                                            subjects[countSubject].Room = null;
                                            countSubject++;
                                        }
                                        if (list[j + 2] == null) continue;

                                        if (list[j + 2].StringCellValue != "")
                                        {
                                            if (list[j + 3].StringCellValue != "")
                                                teacher = new Teacher(list[j + 3].StringCellValue);
                                            else teacher = new Teacher("-");

                                            subjects[countSubject] = new Class();
                                            subjects[countSubject].ScheduleName = scheduleName;
                                            subjects[countSubject].WeekDay = weekDayCounter;
                                            subjects[countSubject].Number = numberCounter;
                                            subjects[countSubject].WeekType = WeekType.Denominator;
                                            subjects[countSubject].Subject = list[j + 2].StringCellValue;
                                            subjects[countSubject].Group = group;
                                            subjects[countSubject].Teacher = teacher;
                                            subjects[countSubject].Room = null;
                                            countSubject++;
                                        }
                                    }
                                    numberCounter++;
                                }
                            }
                        }
                    }
                    subjects = subjects.Where(x => x != null).ToArray();
                    var result = new ParseResult(subjects, null);
                    return Task.FromResult(result);
                }
                else
                    return Task.FromResult(ParseResult.NotSupportedFile());

            }
            catch (Exception e)
            {
                return Task.FromResult(ParseResult.ParseFailed(e.ToString()));
                throw;
            }
            throw new NotImplementedException();
        }
    }
}