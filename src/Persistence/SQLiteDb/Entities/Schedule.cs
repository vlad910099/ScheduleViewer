using SQLite;

namespace Persistence.SQLiteDb.Entities
{
    [Table(TableNames.ScheduleTableName)]
    public class Schedule
    {
        [PrimaryKey]
        public string Name { get; set; }

        public string Year { get; set; }

        public string Url { get; set; }

        public string Checksum { get; set; }
    }
}