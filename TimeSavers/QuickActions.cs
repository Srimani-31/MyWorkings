using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSavers
{
    class QuickActions
    {
    }
    public class Student
    {
        private string name;
        private string course;

        public string Course { get => course; set => course = value; }

        public Student(string course)
        {
            if (string.IsNullOrEmpty(course))
            {
                throw new ArgumentException($"'{nameof(course)}' cannot be null or empty.", nameof(course));
            }

            Course = course;
        }

        //create constructor via qucik actions menu 

    }
}
