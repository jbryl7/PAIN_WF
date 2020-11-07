using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIApp
{
    public partial class SongForm : Form
    {
        private Song student;
        private List<Song> students;

        public string SongName
        {
            get { return nameTextBox.Text; }
        }
        public string SongGenre
        {
            get { return genreChoiceBox.Text; }
        }
        public string SongAuthor
        {
            get { return authorTextBox.Text; }
        }

        public long SongIndex
        {
            get { return long.Parse( indexTextBox.Text ); }
        }

        public DateTime SongBirthDay
        {
            get { return birthDayDateTimePicker.Value; }
        }

        public SongForm(Song student, List<Song> students)
        {
            InitializeComponent();
            this.student = student;
            this.students = students;
        }

        private void SongForm_Load(object sender, EventArgs e)
        {
            if (student != null)
            {
                nameTextBox.Text = student.Name;
                genreChoiceBox.Text = student.Genre;
                authorTextBox.Text = student.Author;
                indexTextBox.Text = student.Index.ToString();
                birthDayDateTimePicker.Value = student.BirthDate;
            }
            else
            {
                nameTextBox.Text = "Jan";
                birthDayDateTimePicker.Value = new DateTime(1980, 1, 1);
                genreChoiceBox.BeginUpdate();
                genreChoiceBox.Items.AddRange(new object[] { "Rock", "Rap", "Metal" });
                genreChoiceBox.EndUpdate();
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void IndexTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                long index = long.Parse(indexTextBox.Text);
                foreach (Song s in students)
                    if (s.Index == index && !ReferenceEquals(s, student))
                        throw new Exception( "Song already exists." );
            }
            catch( Exception exception )
            {
                e.Cancel = true;
                errorProvider.SetError(indexTextBox, exception.Message);
            }
        }

        private void IndexTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(indexTextBox, "");
        }
    }
}
