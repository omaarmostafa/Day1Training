using Day1Training.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day1Training.SQLite
{
  public  interface IDataAccess
    {
        List<Student> GetAllEmployees();
        int SaveEmployee(Student student);
        int DeleteEmployee(Student student);
        int EditEmployee(Student student);
    }
}
