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
    public partial class SongsForm : Form
    {



        private Document Document { get; set; }

        public SongsForm( Document document )
        {
            InitializeComponent();
            Document = document;
            genreFilterToolStripComboBox1.Items.AddRange(new object[] { "All", "Rock", "Rap", "Metal"});
            genreFilterToolStripComboBox1.SelectedIndex = 0;
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateItems();
            Document.AddSongEvent += Document_AddSongEvent;
            Document.DeleteSongEvent += Document_DeleteSongEvent;
            Document.UpdateSongEvent += Document_UpdateSongEvent;
        }

        private void Document_AddSongEvent(Song student)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = student;
            UpdateItem(item);
            studentsListView.Items.Add(item);
        }
        private void Document_UpdateSongEvent(Song student)
        {
            // change to update specifc entry
            ListViewItem item = new ListViewItem();
            item.Tag = student;
            UpdateItem(item);
            studentsListView.Items.Add(item);
        }
        private void Document_DeleteSongEvent(Song student)
        {
            UpdateItems();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongForm studentForm = new SongForm(null, Document.students);
            if( studentForm.ShowDialog() == DialogResult.OK)
            {
                Song newSong = new Song(studentForm.SongName, studentForm.SongIndex, studentForm.SongBirthDay, studentForm.SongAuthor, studentForm.SongGenre);
                Document.AddSong(newSong);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (studentsListView.SelectedItems.Count == 1)
            {
                Song student = (Song)studentsListView.SelectedItems[0].Tag;
                SongForm studentForm = new SongForm(student, Document.students);
                if (studentForm.ShowDialog() == DialogResult.OK)
                {
                    student.Name = studentForm.SongName;
                    student.Index = studentForm.SongIndex;
                    student.BirthDate = studentForm.SongBirthDay;
                    student.Genre = studentForm.SongGenre;
                    student.Author = studentForm.SongAuthor;
                    Document.UpdateSong(student);
                }
            }
        }
        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (studentsListView.SelectedItems.Count == 1)
            {
                Song song = (Song)studentsListView.SelectedItems[0].Tag;
                Document.DeleteSong(song);
            }
        }
        private void UpdateItem( ListViewItem item)
        {
            Song student = (Song)item.Tag;
            while (item.SubItems.Count < 5)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = student.Index.ToString();
            item.SubItems[1].Text = student.Name;
            item.SubItems[2].Text = student.BirthDate.ToShortDateString();
            item.SubItems[3].Text = student.Author;
            item.SubItems[4].Text = student.Genre;
        }

        private void UpdateItems()
        {
            studentsListView.Items.Clear();
            string genreChoice = genreFilterToolStripComboBox1.SelectedText; 
            foreach( Song student in Document.students)
            {
                if (genreChoice == "All" || student.Genre == genreChoice)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = student;
                    UpdateItem(item);
                    studentsListView.Items.Add(item);
                }
            }
        }

        private void SongsForm_Activated(object sender, EventArgs e)
        {
            toolStrip1.Visible = true;
            ToolStripManager.Merge(toolStrip1, ((MainForm)MdiParent).toolStrip1);
            
        }

        private void SongsForm_Deactivate(object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MainForm)MdiParent).toolStrip1, toolStrip1);
            toolStrip1.Visible = false;
        }



        private void genreFilterToolStripComboBox1_Click(object sender, EventArgs e)
        {
            UpdateItems();
        }
    }
}
