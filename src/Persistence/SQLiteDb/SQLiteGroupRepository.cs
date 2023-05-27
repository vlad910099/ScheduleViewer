using Domain.Models;
using Domain.PersistenceInterfaces;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.SQLiteDb
{
    public class SQLiteGroupRepository : IGroupRepository
    {
        private readonly SQLiteAsyncConnection database;

        public SQLiteGroupRepository(SQLiteDatabase sQLiteDatabase)
        {
            database = sQLiteDatabase.Connection;
        }

        public async Task<IEnumerable<Group>> Get(string scheduleName)
        {
            var groups = await database.QueryAsync<GroupData>($"SELECT DISTINCT {nameof(GroupData.GroupName)} FROM {TableNames.ClassTableName} WHERE {nameof(Entities.Class.ScheduleName)} = {scheduleName}");
            return groups.Select(g => new Group(g.GroupName, null)).ToArray();
        }
    }

    public class GroupData
    {
        public string GroupName { get; set; }
    }
}