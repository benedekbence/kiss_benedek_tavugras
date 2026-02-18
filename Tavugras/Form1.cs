using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tavugras
{
    public partial class Form1 : Form
    {
        List<Student> students; 

        public Form1()
        {
            InitializeComponent();
            students = new List<Student>
            {
                new Student("a","g", "a"),
                new Student("a","c", "a"),
                new Student("a","f", "a"),
                new Student("a","h", "a"),
                new Student("a","z", "a"),
            };
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            contestantsListBox.SelectionMode = SelectionMode.None;
            contestantsListBox.DataSource = null;
            contestantsListBox.DataSource = students;
            contestantsListBox.SelectionMode = SelectionMode.One;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string city = cityTextBox.Text;
            string result = resultTextBox.Text;
            //List<double> result = new List<double>();
            //foreach (var item in temp)
            //{
            //    result.Add(Convert.ToDouble(item));
            //}
            Student student = new Student(name, city, result);
            students.Add(student);
            UpdateListBox();
        }

        private void fiterTextBox_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in students)
            {
                if (item.ToString().Contains(filterTextBox.Text))
                {
                    List<Student> temp = new List<Student>();
                    contestantsListBox.DataSource = null;
                    contestantsListBox.DataSource = temp;
                }
            }
        }
    }
}
