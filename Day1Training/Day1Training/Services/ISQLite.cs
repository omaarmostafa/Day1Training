using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day1Training.Services
{
    public interface ISQLite
    {
         SQLiteConnection GetConnection();
    }
}
