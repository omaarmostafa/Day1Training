using Day1Training.Model;
using Day1Training.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Day1Training.SQLite
{
   public  class DataAccess: IDataAccess
    {
        SQLiteConnection dbConn;
        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            // create the table(s)
            dbConn.CreateTable<Student>(); 
        }
        public List<Student> GetAllEmployees()
        {
            return dbConn.Query<Student>("Select * From [Student]");
        }
        public int SaveEmployee(Student student)
        {
            return dbConn.Insert(student);
        }
        public int DeleteEmployee(Student student)
        {
            return dbConn.Delete(student);
        }
        public int EditEmployee(Student student)
        {
            return dbConn.Update(student);
        }
    }
}
