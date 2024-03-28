using Library.Canvas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Library.Canvas.Database
{
    public static class FakeDatabase
    {
        private static List<Person> people = new List<Person>();
        public static List<Person> People { 
            get {
                return people;
            }
        }
        public static List<Course> Courses
        {
            get
            {
                return new List<Course>();
            }
        }
    }
}
