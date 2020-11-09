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
        private Song song;
        private List<Song> songs;

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

        public DateTime SongReleaseDate
        {
            get { return birthDayDateTimePicker.Value; }
        }

        public SongForm(Song song, List<Song> songs)
        {
            InitializeComponent();
            this.song = song;
            this.songs = songs;
        }

        private void SongForm_Load(object sender, EventArgs e)
        {
            if (song != null)
            {
                nameTextBox.Text = song.Name;
                genreChoiceBox.Items.AddRange(new object[] { "Rock", "Rap", "Metal" });
                genreChoiceBox.SelectedItem = song.Genre;
                authorTextBox.Text = song.Author;
                indexTextBox.Text = song.Index.ToString();
                birthDayDateTimePicker.Value = song.ReleaseDate;
            }
            else
            {
                nameTextBox.Text = "Jan";
                authorTextBox.Text = "Jan";
                birthDayDateTimePicker.Value = new DateTime(1980, 1, 1);
                genreChoiceBox.Items.AddRange(new object[] { "Rock", "Rap", "Metal" });
                genreChoiceBox.SelectedIndex = 0;
                indexTextBox.Text = "Will be assigned after submission";
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
           /* try
            {
                long index = long.Parse(indexTextBox.Text);
                foreach (Song s in songs)
                    if (s.Index == index && !ReferenceEquals(s, song))
                        throw new Exception( "Song already exists." );
            }
            catch( Exception exception )
            {
                e.Cancel = true;
                errorProvider.SetError(indexTextBox, exception.Message);
            }
           */
        }

        private void IndexTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(indexTextBox, "");
        }
    }
}
