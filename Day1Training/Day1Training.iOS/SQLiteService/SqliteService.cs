using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Day1Training.Services;
using Foundation;
using SQLite;
using UIKit;

namespace Day1Training.iOS.SQLiteService
{
    public class SqliteService : ISQLite
    {
        public SqliteService()
        {
        }
        #region ISQLite implementation
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SQLiteEx.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            var conn = new SQLiteConnection( path);

            // Return the database connection 
            return conn;
        }
        #endregion
    }
}