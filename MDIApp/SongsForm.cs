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
            genreFilterToolStripComboBox1.Items.AddRange(new object[] { "All", "Rock", "Metal", "Rap" });
            genreFilterToolStripComboBox1.SelectedIndex = 0;
            UpdateItems();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Document.AddSongEvent += Document_AddSongEvent;
            Document.DeleteSongEvent += Document_DeleteSongEvent;
            Document.UpdateSongEvent += Document_EditSongEvent;
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

        private void editToolStripButton_Click(object sender, EventArgs e)
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
        private void genreFilterToolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateItems();
        }

        private void UpdateItem(ListViewItem item)
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
            foreach( Song student in Document.students)
            {
                if (checkGenre(student))
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = student;
                    UpdateItem(item);
                    studentsListView.Items.Add(item);
                }
            }
            UpdateCounters();
        }

        private void Document_AddSongEvent(Song student)
        {
            if (checkGenre(student))
            {
                ListViewItem item = new ListViewItem();
                item.Tag = student;
                UpdateItem(item);
                studentsListView.Items.Add(item);
                UpdateCounters();
            }
        }
        private void Document_EditSongEvent(Song student)
        {
            if (checkGenre(student))
            {
                ListViewItem item = new ListViewItem();
                item.Tag = student;
                UpdateItem(item);
                studentsListView.Items[studentsListView.SelectedIndices[0]] = item;
            }
            else
            {
                studentsListView.Items.RemoveAt(studentsListView.SelectedIndices[0]);
                UpdateCounters();
            }

        }
        private void Document_DeleteSongEvent(Song student)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = student;
            UpdateItem(item);
            studentsListView.Items.Remove(item);
            UpdateCounters();
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

        private void UpdateCounters()
        {
            toolStripLabel1.Text = studentsListView.Items.Count.ToString();
            if (toolStrip1.Visible)
                ((MainForm)MdiParent).UpdateCount(studentsListView.Items.Count);
        }
        private bool checkGenre(Song song)
        {
            string genreChoice = genreFilterToolStripComboBox1.Text;
            return genreChoice == "All" || song.Genre == genreChoice;
        }

    }
}
