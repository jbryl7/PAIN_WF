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
        string genreChoice;
        public SongsForm( Document document )
        {
            InitializeComponent();
            Document = document;
            genreFilterToolStripComboBox1.Items.AddRange(new object[] { "All", "rock", "metal", "rap" });
            genreFilterToolStripComboBox1.SelectedIndex = 0;
            genreChoice = genreFilterToolStripComboBox1.Text;
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
                Song newSong = new Song(songForm.SongName, songForm.SongReleaseDate, songForm.SongAuthor, songForm.SongGenre);
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
                    song.ReleaseDate = songForm.SongReleaseDate;
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
            genreChoice = genreFilterToolStripComboBox1.Text;
            UpdateItems();
        }

        private void UpdateItem(ListViewItem item)
        {
            Song song = (Song)item.Tag;
            while (item.SubItems.Count < 5)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            int i = 0;
            item.SubItems[i++].Text = song.Name;
            item.SubItems[i++].Text = song.Author;
            item.SubItems[i++].Text = song.Genre;
            item.SubItems[i++].Text = song.ReleaseDate.ToShortDateString();
        }

        private void UpdateItems()
        {
            songsListView.Items.Clear();
            foreach( Song song in Document.songs)
            {
                if (checkFilters(song))
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
            if (checkFilters(song))
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
            foreach (ListViewItem it in songsListView.Items)
            {
                if (it.Tag == song)
                {
                    if (checkFilters(song))
                        UpdateItem(it);
                    else
                    {
                        songsListView.Items.Remove(it);
                        UpdateCounters();
                    }
                    return;
                }
            }
            if (checkFilters(song))
            {
                ListViewItem item = new ListViewItem();
                item.Tag = song;
                UpdateItem(item);
                songsListView.Items.Add(item);
                UpdateCounters();
            }
        }
        private void Document_DeleteSongEvent(Song song)
        {
            foreach (ListViewItem item in songsListView.Items)
                if (item.Tag == song)
                {
                    songsListView.Items.Remove(item);
                    UpdateCounters();
                    return;
                }
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
        private bool checkFilters(Song song)
        {
            return genreChoice == "All" || song.Genre == genreChoice;
        }

        private void SongsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ParentForm.MdiChildren.Length == 1 && e.CloseReason != CloseReason.MdiFormClosing)
            {
                e.Cancel = true;
            }
        }
    }
}

