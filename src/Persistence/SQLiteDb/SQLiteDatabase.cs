using Domain.PersistenceInterfaces;
using Persistence.SQLiteDb.Entities;
using SQLite;

namespace Persistence.SQLiteDb
{
    public class SQLiteDatabase
    {
        public SQLiteAsyncConnection Connection { get; }

        public SQLiteDatabase(IDbPathProvider dbPathProvider)
        {
            Connection = new SQLiteAsyncConnection(dbPathProvider.Path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.FullMutex);

            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            // create tables if they don't exist

            Connection.CreateTableAsync<Class>().Wait();
            Connection.CreateTableAsync<Schedule>().Wait();
        }
    }
}