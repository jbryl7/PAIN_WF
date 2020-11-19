using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;



namespace MDIApp
{
   
    public partial class UserControl1 : UserControl
    {
        public enum PictureGenre { Rock, Metal, Rap }
        PictureGenre state;
        public event Action UpdatePictureGenreEvent;

        [EditorAttribute(typeof(UserControlEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Category("Custom Genre Options")]
        [BrowsableAttribute(true)]
        public PictureGenre Picture_
        {
            get
            { return state; }
            set
            { state = value; setImage(); }
        }

        public UserControl1()
        {
            state = Picture_;
            InitializeComponent();
            setImage();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            state = (PictureGenre)(((int)state + 1) % 3);
            ChangePictureGenre();
        }

        public void setImage()
        {
            if (state == PictureGenre.Rock)
            {
                pictureBox1.Image = global::MDIApp.Properties.Resources.rock;
            }
            else if (state == PictureGenre.Metal)
            {
                pictureBox1.Image = global::MDIApp.Properties.Resources.metal;
            }
            else if (state == PictureGenre.Rap)
            {
                pictureBox1.Image = global::MDIApp.Properties.Resources.rap;
            }
        }

        public PictureGenre getEnumFromString(string genre)
        {
            if (genre == "rock")
            {
                return PictureGenre.Rock;
            }
            else if (genre == "metal")
            {
                return PictureGenre.Metal;
            }
            else if (genre == "rap")
            {
                return PictureGenre.Rap;
            }

            return PictureGenre.Rock;
        }
        public string getStateAsString()
        {
            if (state == PictureGenre.Rock)
            {
                return "rock";
            }
            else if (state == PictureGenre.Metal)
            {
                return "metal";
            }
            else //if (state == PictureGenre.rap)
            {
                return "rap";
            }
        }
        public void ChangePictureGenre()
        {
            setImage();
            UpdatePictureGenreEvent?.Invoke();
        }

    }
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class UserControlEditor : System.Drawing.Design.UITypeEditor
    {
        public UserControlEditor()
        {
        }

        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                UserControl1 userControl = new UserControl1();
                edSvc.DropDownControl(userControl);

                return userControl.Picture_;
            }
            return null;
        }

    }

}
