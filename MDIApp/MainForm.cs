﻿using System;
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
    public partial class MainForm : Form
    {
        Document document = new Document();

        public MainForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
            statusLabel.Text = document.songs.Count.ToString();
            SongsForm songsForm = new SongsForm(document);
            songsForm.MdiParent = this;
            songsForm.Show();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongsForm songsForm = new SongsForm( document );
            songsForm.MdiParent = this;
            songsForm.Show();
        }
        public void UpdateCount(int count) 
        {
            statusLabel.Text = count.ToString();
        }
    }
}
