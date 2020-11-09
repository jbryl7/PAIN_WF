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
        private int Counter = 0;
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

        public int GetIndexForNewSong()
        {
            Counter += 1;
            return Counter;
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongForm songForm = new SongForm(null, Document.songs);
            if( songForm.ShowDialog() == DialogResult.OK)
            {
                Song newSong = new Song(songForm.SongName, 1, songForm.SongBirthDay, songForm.SongAuthor, songForm.SongGenre);
                Document.AddSong(newSong);
            }
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            if (songsListView.SelectedItems.Count == 1)
            {
                Song song = (Song)songsListView.SelectedItems[0].Tag;
                SongForm songForm = new SongForm(song, Document.songs);
                if (songForm.ShowDialog() == DialogResult.OK)
                {
                    song.Name = songForm.SongName;
                    song.Index = songForm.SongIndex;
                    song.BirthDate = songForm.SongBirthDay;
                    song.Genre = songForm.SongGenre;
                    song.Author = songForm.SongAuthor;
                    Document.UpdateSong(song);
                }
            }
        }
        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (songsListView.SelectedItems.Count == 1)
            {
                Song song = (Song)songsListView.SelectedItems[0].Tag;
                Document.DeleteSong(song);
            }
        }
        private void genreFilterToolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateItems();
        }

        private void UpdateItem(ListViewItem item)
        {
            Song song = (Song)item.Tag;
            while (item.SubItems.Count < 5)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = song.Index.ToString();
            item.SubItems[1].Text = song.Name;
            item.SubItems[2].Text = song.Author;
            item.SubItems[3].Text = song.Genre;
            item.SubItems[4].Text = song.BirthDate.ToShortDateString();
        }

        private void UpdateItems()
        {
            songsListView.Items.Clear();
            foreach( Song song in Document.songs)
            {
                if (checkGenre(song))
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = song;
                    UpdateItem(item);
                    songsListView.Items.Add(item);
                }
            }
            UpdateCounters();
        }

        private void Document_AddSongEvent(Song song)
        {
            if (checkGenre(song))
            {
                ListViewItem item = new ListViewItem();
                item.Tag = song;
                UpdateItem(item);
                songsListView.Items.Add(item);
                UpdateCounters();
            }
        }
        private void Document_EditSongEvent(Song song)
        {
            UpdateItems();
            /*
            if (checkGenre(song))
            {
                ListViewItem item = new ListViewItem();
                item.Tag = song;
                UpdateItem(item);
                songsListView.Items[songsListView.Items.F] = item;
            }
            else
            {
                songsListView.Items.RemoveAt(songsListView.SelectedIndices[0]);
                UpdateCounters();
            }
            */
        }
        private void Document_DeleteSongEvent(Song song)
        {
            foreach(ListViewItem item in songsListView.Items)
                if (((Song)item.Tag).Index == song.Index)
                    songsListView.Items.Remove(item);
            UpdateCounters();
        }
        private void SongsForm_Activated(object sender, EventArgs e)
        {
            toolStrip1.Visible = true;
            ToolStripManager.Merge(toolStrip1, ((MainForm)MdiParent).toolStrip1);
            UpdateCounters();
        }

        private void SongsForm_Deactivate(object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MainForm)MdiParent).toolStrip1, toolStrip1);
            toolStrip1.Visible = false;

            ((MainForm)MdiParent).UpdateCount(Document.songs.Count);
        }

        private void UpdateCounters()
        {
            if (toolStrip1.Visible)
                ((MainForm)MdiParent).UpdateCount(songsListView.Items.Count);
        }
        private bool checkGenre(Song song)
        {
            string genreChoice = genreFilterToolStripComboBox1.Text;
            return genreChoice == "All" || song.Genre == genreChoice;
        }

    }
}
