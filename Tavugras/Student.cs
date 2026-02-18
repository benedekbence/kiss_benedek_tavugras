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
        private string result;

        public Student(string name, string city, string result)
        {
            this.name = name;
            this.city = city;
            this.result = result;
        }

        public override string ToString()
        {
            return $"{name} ({city})";
        }
    }
}
