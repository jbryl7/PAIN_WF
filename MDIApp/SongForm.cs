using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace MDIApp
{
    public partial class SongForm : Form
    {
        private Song song;

        public string SongName
        {
            get { return nameTextBox.Text; }
        }
        public string SongGenre
        {
            get { return genreTextBox.Text; }
        }
        public string SongAuthor
        {
            get { return authorTextBox.Text; }
        }


        public DateTime SongReleaseDate
        {
            get { return birthDayDateTimePicker.Value; }
        }

        public SongForm(Song song, List<Song> songs)
        {
            InitializeComponent();
            this.song = song;
        }

        private void SongForm_Load(object sender, EventArgs e)
        {
            userControl11.UpdatePictureGenreEvent += UserControl1_ChangePictureGenreEvent;

            if (song != null)
            {
                nameTextBox.Text = song.Name;
                genreTextBox.Text = song.Genre;
                userControl11.Picture_ = userControl11.getEnumFromString(song.Genre);
                authorTextBox.Text = song.Author;
                birthDayDateTimePicker.Value = song.ReleaseDate;
            }
            else
            {
                nameTextBox.Text = "Jan";
                authorTextBox.Text = "Jan";
                birthDayDateTimePicker.Value = new DateTime(1980, 1, 1);
                genreTextBox.Text = userControl11.getStateAsString();
            }
        }
        private void UserControl1_ChangePictureGenreEvent()
        {
            genreTextBox.Text = userControl11.getStateAsString();
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

        private void authorTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (authorTextBox.TextLength == 0)
                    throw new Exception("Empty textBox"); 
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                errorProvider.SetError(authorTextBox, exception.Message);
            }
        }
        private void nameTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (nameTextBox.TextLength == 0)
                    throw new Exception("Empty textBox");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                errorProvider.SetError(nameTextBox, exception.Message);
            }
        }
        private void releaseDateTimePicker_TextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (DateTime.Parse(birthDayDateTimePicker.Text) > DateTime.Now)
                 throw new Exception("Release Date in future"); 
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                errorProvider.SetError(birthDayDateTimePicker, exception.Message);
            }
        }
        private void nameTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(nameTextBox, "");
        }

        private void authorTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(authorTextBox, "");
        }

        private void releaseDateTimePicker_TextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(birthDayDateTimePicker, "");
        }
        public void setGenre()
        {
            genreTextBox.Text = userControl11.getStateAsString();
        }
    }
}
