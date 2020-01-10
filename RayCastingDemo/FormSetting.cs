using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayCastingDemo
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void button_RayColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            DialogResult dialogResult = dlg.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                this.RayColor = dlg.Color;
            }
        }

        private void button_BackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            DialogResult dialogResult = dlg.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                this.BackgroundColor = dlg.Color;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // GET RESULT ////////////////////////////////////////////////////////////////////////////////////////////////// 
        public int NumberOfRay
        {
            get { return (int)numericUpDown_NumberOfRays.Value; }
            set { numericUpDown_NumberOfRays.Value = value; }
        }

        public int RayBrightness
        {
            get { return (int)numericUpDown_RayBrightness.Value; }
            set { numericUpDown_RayBrightness.Value = value; }
        }

        public int RayThickness
        {
            get { return (int)numericUpDown_RayThickness.Value; }
            set { numericUpDown_RayThickness.Value = value; }
        }

        public Color RayColor
        {
            get { return button_RayColor.BackColor; }
            set 
            { 
                button_RayColor.BackColor = value; 

                if( Utility.IsDark(value) )
                    button_RayColor.ForeColor = Color.White;
                else
                    button_RayColor.ForeColor = Color.Black;
            }
        }

        public Color BackgroundColor
        {
            get { return button_BackgroundColor.BackColor; }
            set 
            { 
                button_BackgroundColor.BackColor = value; 
            
                if( Utility.IsDark(value) )
                    button_BackgroundColor.ForeColor = Color.White;
                else
                    button_BackgroundColor.ForeColor = Color.Black;
            }
        }
    }
}
