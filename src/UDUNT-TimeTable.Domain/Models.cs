using Android.Content;
using Org.Apache.Http.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UDUNT_TimeTable.Domain
{
    internal class Models
    {
        public class Schedule //модель розкладу
        {
            public string Name { get; }
            public DateTime CreatedDT { get; }
            public DateTime ModifiedDT { get; }
            public IEnumerable<Class> Classes { get; }
            public int Year { get; }
            public int Semester { get; }
        }

        public class Class //модель порядку дисципліни у розкладі
        {
            public int Number;
            public Subject Subject;
            public Group[] Groups;
        }

        public class Subject //модель дисципліни
        {
            public string Name;
            public string Description;
        }

        public interface IScheduleRepository //інтрефейс списку розкладів
        {
            Task<Schedule[]> Get();
            Task<Schedule> Get(string name);
            Task Update(Schedule schedule);
        }

        public class SearchCriteria // для пошуку 
        {
            public string TeacherId { get; }
            public string GroupId { get; }
        }

        public interface IClassRepository
        {
            Task<Class[]> Search(SearchCriteria searchCriteria);
        }

        public class InMemoryScheduleRepository : IScheduleRepository //модель використання моків
        {
            public Task<Schedule[]> Get()
            {
                var result = new Schedule[]
                {
                    new Schedule { Name = "Розклад 1", ...},
                    new Schedule { Name = "Розклад 2", ...}
                };
                return Task.FromResult(result);
            }
        }

        public class DbScheduleRepository : IScheduleRepository //модель використання даних з БД
        {
            public Task<Schedule[]> Get()
            {
                //dbContext;
            }
        }

        public class ScheduleService //модель обробки даних
        {
            private IScheduleRepository scheduleRepository;
            private SiteParser siteParser;

            public async Task<Schedule[]> Get()
            {
                var schedules = await scheduleRepository.Get();

                if (!schedules.Any()) //оновлення даних
                {
                    siteParser.GetScheduleList();
                }

                return schedules;
            }
        }

        public class SiteParser //модель парсингу
        {
            public Task<Schedule[]> GetScheduleList()
            {
                using (HttpContext = new HttpContext("https://diit.edu.ua/student/lessons_schedule"))
                {

                }
            }
        }
    }
}
