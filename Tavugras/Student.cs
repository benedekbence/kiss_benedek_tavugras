using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavugras
{
    internal class Student
    {
        private string name;
        private string city;
        private int result;

        public Student(string name, string city, int result)
        {
            this.name = name;
            this.city = city;
            this.result = result;
        }
    }
}
