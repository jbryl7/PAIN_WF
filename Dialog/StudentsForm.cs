using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dialog
{
    public partial class StudentsForm : Form
    {
        List<Student> students = new List<Student>();

        public StudentsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm(null, students);
            if( studentForm.ShowDialog() == DialogResult.OK)
            {
                Student newStudent = new Student(studentForm.StudentName, studentForm.StudentIndex, studentForm.StudentBirthDay);
                students.Add(newStudent);
                ListViewItem item = new ListViewItem();
                item.Tag = newStudent;
                UpdateItem(item);
                studentsListView.Items.Add(item);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( studentsListView.SelectedItems.Count == 1)
            {
                Student student = (Student)studentsListView.SelectedItems[0].Tag;
                StudentForm studentForm = new StudentForm(student, students);
                if (studentForm.ShowDialog() == DialogResult.OK)
                {
                    student.Name = studentForm.StudentName;
                    student.Index = studentForm.StudentIndex;
                    student.BirthDate = studentForm.StudentBirthDay;

                    UpdateItem(studentsListView.SelectedItems[0]);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UpdateItem( ListViewItem item)
        {
            Student student = (Student)item.Tag;
            while (item.SubItems.Count < 3)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = student.Name;
            item.SubItems[1].Text = student.Index.ToString();
            item.SubItems[2].Text = student.BirthDate.ToShortDateString();
        }
    }
}
