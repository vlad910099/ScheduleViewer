using Domain.PersistenceInterfaces;
using System;

namespace Mobile.iOS
{
    public class iOSDbPathProvider : IDbPathProvider
    {
        public string Path => System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library", "schedules.db3");
    }
}