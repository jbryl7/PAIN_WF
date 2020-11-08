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
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateItems();
            Document.AddSongEvent += Document_AddSongEvent;
        }

        private void Document_AddSongEvent(Song student)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = student;
            UpdateItem(item);
            studentsListView.Items.Add(item);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongForm studentForm = new SongForm(null, Document.students);
            if( studentForm.ShowDialog() == DialogResult.OK)
            {
                Song newSong = new Song(studentForm.SongName, studentForm.SongIndex, studentForm.SongBirthDay, studentForm.SongAuthor, studentForm.SongGenre);

                Document.AddSong(newSong);

                //ListViewItem item = new ListViewItem();
                //item.Tag = newSong;
                //UpdateItem(item);
                //studentsListView.Items.Add(item);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( studentsListView.SelectedItems.Count == 1)
            {
                Song student = (Song)studentsListView.SelectedItems[0].Tag;
                SongForm studentForm = new SongForm(student, Document.students);
                if (studentForm.ShowDialog() == DialogResult.OK)
                {
                    student.Name = studentForm.SongName;
                    student.Index = studentForm.SongIndex;
                    student.BirthDate = studentForm.SongBirthDay;
                    student.Genre = studentForm.SongGenre;
                    student.Author= studentForm.SongAuthor;
                    Document.UpdateSong(student);

                    //UpdateItem(studentsListView.SelectedItems[0]);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            foreach( Song student in Document.students)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = student;
                UpdateItem(item);
                studentsListView.Items.Add(item);
            }
        }

        private void SongsForm_Activated(object sender, EventArgs e)
        {
            ToolStripManager.Merge(toolStrip1, ((MainForm)MdiParent).toolStrip1);
        }

        private void SongsForm_Deactivate(object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MainForm)MdiParent).toolStrip1, toolStrip1);
        }
    }
}
