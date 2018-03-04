using Day1Training.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Day1Training.UWP.SQLiteService
{
    public class SqliteService : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SQLiteEx.db3";
            var path=  Path.Combine(ApplicationData.Current.LocalFolder.Path, "");
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}
