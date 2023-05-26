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

namespace Main.Parsers
{
    internal class ModuleFileParser : IFileScheduleParser
    {
        public Task<ParseResult> Parse(byte[] fileData, FileType fileType, string scheduleName)  
        {
            try
            {
                if (scheduleName.Contains("МК"))
                {
                IWorkbook workbook = null;
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
                int rowCount = 74;
                Class[] subjects = new Class[rowCount / 15 * colums];
                int countSubject = 0;
                Group group;
                //int startColumn = 0;
                    if (sheet != null)
                    {
                        for (int columnindex = 2; columnindex < colums; columnindex += 2)
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

                            for (int i = 0; i < list.Count; i += rowCount)
                            {
                                string str = list[i].StringCellValue;
                                string[] groups = str.Split('\n');
                                group = new Group(groups[0], groups[1]);

                                for (int j = i + 1; j < rowCount && j + 5 < rowCount; j += 5)
                                {
                                    if (j + 6 > list.Count)
                                        break;

                                    if (list[j] == null || list[j + 1] == null ||
                                        list[j + 2] == null || list[j + 3] == null ||
                                        list[j + 4] == null) continue;
                                    else
                                    {
                                        if (list[j + 2].StringCellValue != "")
                                        {
                                            subjects[countSubject] = new Class();
                                            subjects[countSubject].ScheduleName = scheduleName;
                                            subjects[countSubject].Subject = list[j + 2].StringCellValue;
                                            subjects[countSubject].Group = group;
                                            subjects[countSubject].Teacher = new Teacher(list[j + 3].StringCellValue);
                                            subjects[countSubject].Room = null;
                                            if (list[j + 1].StringCellValue == "Консультація")
                                                subjects[countSubject].SubType = SubType.Consultation;
                                            else subjects[countSubject].SubType = SubType.Exam;

                                            subjects[countSubject].Date = new DateTime(list[j].DateCellValue.Year, list[j].DateCellValue.Month, list[j].DateCellValue.Day,
                                                                                ConvertOurs(list[j + 4].StringCellValue), ConvertMinutes(list[j + 4].StringCellValue), 0);
                                            subjects[countSubject].WeekDay = DayWeek(subjects[countSubject].Date.DayOfWeek.ToString());
                                            subjects[countSubject].Number = Number(list[j + 4].StringCellValue);
                                            countSubject++;
                                        }
                                    }

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
        public static int ConvertOurs(string str)
        {
            string[] time = str.Split('-');
            int ours = int.Parse(time[0]);
            return ours;
        }
        public static int ConvertMinutes(string str)
        {
            string[] time = str.Split('-');
            int min = int.Parse(time[1]);
            return min;
        }
        public static int DayWeek(string str)
        {
            switch (str)
            {
                case "Monday":
                    return 1;
                case "Tuesday":
                    return 2;
                case "Wednesday":
                    return 3;
                case "Thursday":
                    return 4;
                case "Friday":
                    return 5;
                default:
                    return 0;
            }
        }
        public static int Number(string str)
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