using Domain.PersistenceInterfaces;
using System;

namespace Mobile.Android
{
    public class AndroidDbPathProvider : IDbPathProvider
    {
        public string Path => System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "schedules.db3");
    }
}