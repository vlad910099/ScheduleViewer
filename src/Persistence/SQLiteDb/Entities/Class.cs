using SQLite;

namespace Persistence.SQLiteDb.Entities
{
    [Table(TableNames.ClassTableName)]
    public class Class
    {
        [NotNull]
        public string ScheduleName { get; set; }

        [NotNull]
        public string Subject { get; set; }

        [NotNull]
        public string GroupName { get; set; }

        public string GroupAlternativeName { get; set; }
        public string TeacherName { get; set; }
        public string Auditory { get; set; }
        public int WeekDay { get; set; }
        public int Number { get; set; }

        [NotNull]
        public string WeekType { get; set; }

        [NotNull]
        public string SubType { get; set; }

        public long? Timestamp { get; set; }
    }
}