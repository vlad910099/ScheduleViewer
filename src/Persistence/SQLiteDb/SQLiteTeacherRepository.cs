using Domain.Models;
using Domain.PersistenceInterfaces;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.SQLiteDb
{
    public class SQLiteTeacherRepository : ITeacherRepository
    {
        private readonly SQLiteAsyncConnection database;

        public SQLiteTeacherRepository(SQLiteDatabase sQLiteDatabase)
        {
            database = sQLiteDatabase.Connection;
        }

        public async Task<IEnumerable<Teacher>> Get(string scheduleName)
        {
            var teachers = await database.QueryAsync<TeacherData>($"SELECT DISTINCT {nameof(TeacherData.TeacherName)} FROM {TableNames.ClassTableName} WHERE {nameof(Entities.Class.ScheduleName)} = ?", scheduleName);
            return teachers.Select(g => new Teacher(g.TeacherName)).ToArray();
        }
    }

    public class TeacherData
    {
        public string TeacherName { get; set; }
    }
}