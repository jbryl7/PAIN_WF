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
    public partial class UserControl1 : UserControl
    {
        public enum PictureGenre { rock, metal, rap };
        public PictureGenre state { get; set; }
        private System.ComponentModel.IContainer components = null;
        public event Action<string> UpdatePictureGenreEvent;

        public void ChangePictureGenre()
        {
            setImage();
            UpdatePictureGenreEvent?.Invoke("");
        }
        public UserControl1()
        {
            InitializeComponent();
            setImage();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            state = (PictureGenre)(((int)state + 1) % 3);
            ChangePictureGenre();
        }
        public void setState(string state_)
        {
            state = getEnumFromString(state_);
            ChangePictureGenre();
        }
        private void setImage()
        {
            if (state == PictureGenre.rock)
                pictureBox1.Image = global::MDIApp.Properties.Resources.rock;
            else if (state == PictureGenre.metal)
                pictureBox1.Image = global::MDIApp.Properties.Resources.metal;
            else if (state == PictureGenre.rap)
                pictureBox1.Image = global::MDIApp.Properties.Resources.rap;
        }

        public PictureGenre getEnumFromString(string genre)
        {
            if (genre == "rock")
            {   
                return PictureGenre.rock;
            }
            else if (genre == "metal")
            {
                return PictureGenre.metal;
            }
            else //if (genre == "rap")
            {
                return PictureGenre.rap;
            }
        }
        public string getStateAsString()
        {
            if (state == PictureGenre.rock )
            {
                return "rock";
            }
            else if (state == PictureGenre.metal)
            {
                return "metal";
            }
            else //if (state == PictureGenre.rap)
            {
                return "rap";
            }
        }
    }
}