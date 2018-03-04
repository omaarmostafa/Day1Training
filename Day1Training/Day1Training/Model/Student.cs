using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day1Training.Model
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGreen { get; set; }
        public string Grade { get; set; }
    }
}
