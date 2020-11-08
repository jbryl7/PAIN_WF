namespace MDIApp
{
    partial class SongsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongsForm));
            this.studentsListView = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBirthDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGenre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.edycjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodajToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.genreFilterToolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.contextMenuStrip.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentsListView
            // 
            this.studentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderIndex,
            this.columnHeaderBirthDay,
            this.columnHeaderGenre,
            this.columnHeaderAuthor});
            this.studentsListView.ContextMenuStrip = this.contextMenuStrip;
            this.studentsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentsListView.HideSelection = false;
            this.studentsListView.Location = new System.Drawing.Point(0, 0);
            this.studentsListView.Name = "studentsListView";
            this.studentsListView.Size = new System.Drawing.Size(607, 212);
            this.studentsListView.TabIndex = 2;
            this.studentsListView.UseCompatibleStateImageBehavior = false;
            this.studentsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.DisplayIndex = 1;
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 117;
            // 
            // columnHeaderIndex
            // 
            this.columnHeaderIndex.DisplayIndex = 0;
            this.columnHeaderIndex.Text = "Index";
            this.columnHeaderIndex.Width = 64;
            // 
            // columnHeaderBirthDay
            // 
            this.columnHeaderBirthDay.Text = "Release Date";
            this.columnHeaderBirthDay.Width = 137;
            // 
            // columnHeaderGenre
            // 
            this.columnHeaderGenre.Text = "Genre";
            // 
            // columnHeaderAuthor
            // 
            this.columnHeaderAuthor.Text = "Author";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(108, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.studentsListView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(607, 212);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(607, 261);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.editToolStripButton,
            this.deleteToolStripButton,
            this.genreFilterToolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(259, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(42, 22);
            this.addToolStripButton.Text = "Dodaj";
            this.addToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addToolStripButton.ToolTipText = "Dodaj";
            this.addToolStripButton.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripButton.Image")));
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(44, 22);
            this.editToolStripButton.Text = "Edytuj";
            this.editToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.editToolStripButton.ToolTipText = "Edytuj";
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(38, 22);
            this.deleteToolStripButton.Text = "Usuń";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edycjaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 25);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(607, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // edycjaToolStripMenuItem
            // 
            this.edycjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajToolStripMenuItem});
            this.edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            this.edycjaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.edycjaToolStripMenuItem.Text = "Edycja";
            // 
            // dodajToolStripMenuItem
            // 
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.dodajToolStripMenuItem.Text = "Dodaj";
            this.dodajToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 26);
            // 
            // dodajToolStripMenuItem1
            // 
            this.dodajToolStripMenuItem1.Name = "dodajToolStripMenuItem1";
            this.dodajToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.dodajToolStripMenuItem1.Text = "Dodaj";
            this.dodajToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // genreFilterToolStripComboBox1
            // 
            this.genreFilterToolStripComboBox1.Name = "genreFilterToolStripComboBox1";
            this.genreFilterToolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.genreFilterToolStripComboBox1.ToolTipText = "Filtruj wg. gatunku";
            // 
            // SongsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 261);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SongsForm";
            this.Text = "Songs";
            this.Activated += new System.EventHandler(this.SongsForm_Activated);
            this.Deactivate += new System.EventHandler(this.SongsForm_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView studentsListView;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderIndex;
        private System.Windows.Forms.ColumnHeader columnHeaderBirthDay;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem edycjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private System.Windows.Forms.ColumnHeader columnHeaderGenre;
        private System.Windows.Forms.ColumnHeader columnHeaderAuthor;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripComboBox genreFilterToolStripComboBox1;
    }
}

