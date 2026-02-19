using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tavugras
{
    public partial class Form1 : Form
    {
        List<Student> students;
        List<Student> filtered;

        public Form1()
        {
            InitializeComponent();
            students = new List<Student>();
            //{
            //    new Student("a","g", "a"),
            //    new Student("a","c", "a"),
            //    new Student("a","f", "a"),
            //    new Student("a","h", "a"),
            //    new Student("a","z", "a"),
            //};
            UpdateListBox(students);
        }

        private void UpdateListBox(List<Student> a)
        {
            contestantsListBox.SelectionMode = SelectionMode.None;
            contestantsListBox.DataSource = null;
            contestantsListBox.DataSource = a;
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
            UpdateListBox(students);
        }

        private void fiterTextBox_TextChanged(object sender, EventArgs e)
        {
            filtered = new List<Student>();
            foreach (var item in students)
            {
                if (item.ToString().Contains(filterTextBox.Text))
                { 
                    filtered.Add(item);

                }
            }
           UpdateListBox(filtered);
        }

        private void winnersNum_ValueChanged(object sender, EventArgs e)
        {

            List<Student> a = filtered.Take((int)winnersNum.Value).ToList();

            UpdateListBox(a);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Szüveges fájl|*.txt";
            DialogResult result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            students.Clear();
            using (StreamReader sr = new StreamReader(openFileDialog.FileName)) 
            {
                while (!sr.EndOfStream)
                {
                    string[] temp = sr.ReadLine().Split(';');
                    string jumps = "";
                    for (int i = 2; i < temp.Length; i++)
                    {
                        jumps += $";{temp[i]}";
                    }
                    Student s = new Student(temp[0], temp[1], jumps);
                    students.Add(s);
                }
                
            }
            MessageBox.Show(students.Count.ToString());
            UpdateListBox(students);
        }
    }
}
