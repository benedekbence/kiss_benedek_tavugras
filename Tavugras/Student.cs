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
        private List<double> jumps;


        public Student(string name, string city, string result)
        {
            this.name = name;
            this.city = city;
            this.result = result;
            this.jumps = GetJumps();
        }
        

        private List<double>GetJumps()
        {
            string[] temp = result.Split(';');
            List<double> jumps = new List<double>();

            foreach (string item in temp)
            {
                double num = Convert.ToDouble(item);
                if (num > 0)
                {
                    jumps.Add(num);
                }
            }
            return jumps;
        }
        public override string ToString()
        {
            return $"{name} ({city})";
        }

        public int ValidJumps() 
        {
            return jumps.Count;
        }

        public double AvgValidJumps() 
        {
            return jumps.Average();
        }

        public double BestValidJumps()
        {
            return jumps.Max();
        }
    }
}
