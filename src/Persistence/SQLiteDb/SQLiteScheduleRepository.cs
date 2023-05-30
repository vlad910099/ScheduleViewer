using Domain;
using Domain.Enums;
using Domain.Models;
using Domain.PersistenceInterfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.SQLiteDb
{
    public class SQLiteScheduleRepository : IScheduleRepository
    {
        private readonly SQLiteAsyncConnection database;

        public SQLiteScheduleRepository(SQLiteDatabase sQLiteDatabase)
        {
            database = sQLiteDatabase.Connection;
        }

        public async Task Create(Schedule schedule)
        {
            var record = new Entities.Schedule
            {
                Checksum = schedule.Info.Checksum,
                Name = schedule.Info.Name,
                Url = schedule.Info.Url?.ToString(),
                Year = schedule.Info.Year
            };

            await database.InsertAsync(record);

            var classRecords = schedule.Classes.Select(c => new Entities.Class
            {
                Auditory = c.Auditory,
                GroupAlternativeName = c.Group.AlternativeName,
                GroupName = c.Group.Name,
                Number = c.Number,
                ScheduleName = schedule.Info.Name,
                Subject = c.Subject,
                SubType = c.SubType.ToString(),
                TeacherName = c.Teacher?.Name,
                WeekDay = c.WeekDay,
                WeekType = c.WeekType.ToString(),
                Timestamp = c.Date?.Ticks
            }).ToList();

            await database.InsertAllAsync(classRecords);
        }

        public async Task Delete(string name)
        {
            await database.Table<Entities.Class>().Where(c => c.ScheduleName == name).DeleteAsync();
            await database.DeleteAsync<Entities.Schedule>(name);
        }

        public async Task<ScheduleInfo[]> Get()
        {
            var records = await database.Table<Entities.Schedule>().ToListAsync();
            return records.Select(Translate).ToArray();
        }

        public async Task<IEnumerable<Class>> GetClasses(string name)
        {
            var records = await database.Table<Entities.Class>().Where(c => c.ScheduleName == name).ToListAsync();
            return records.Select(Translate).ToArray();
        }

        public async Task<IEnumerable<Class>> GetClasses(SearchCriteria searchCriteria)
        {
            var query = database.Table<Entities.Class>().Where(c => c.ScheduleName == searchCriteria.ScheduleName);

            if (!string.IsNullOrEmpty(searchCriteria.TeacherName))
            {
                query = query.Where(c => c.TeacherName == searchCriteria.TeacherName);
            }

            if (!string.IsNullOrEmpty(searchCriteria.GroupName))
            {
                query = query.Where(c => c.GroupName == searchCriteria.GroupName);
            }

            var records = await query.ToListAsync();
            return records.Select(Translate).ToArray();
        }

        public async Task<ScheduleInfo> GetInfo(string name)
        {
            var record = await database.Table<Entities.Schedule>().FirstOrDefaultAsync(s => s.Name == name);
            return record == null ? null : Translate(record);
        }

        private Class Translate(Entities.Class @class)
        {
            return new Class(
                @class.Subject,
                new Group(@class.GroupName, @class.GroupAlternativeName),
                new Teacher(@class.TeacherName),
                @class.Auditory,
                @class.WeekDay,
                @class.Number,
                (WeekType)Enum.Parse(typeof(WeekType), @class.WeekType),
                (ClassSubType)Enum.Parse(typeof(ClassSubType), @class.SubType),
                @class.Timestamp == null ? null : new DateTime(@class.Timestamp.Value));
        }

        private ScheduleInfo Translate(Entities.Schedule schedule)
        {
            return new ScheduleInfo(schedule.Name, schedule.Year, string.IsNullOrEmpty(schedule.Url) ? null : new Uri(schedule.Url), schedule.Checksum);
        }
    }
}