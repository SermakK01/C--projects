using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passwordApp
{
    public partial class CheckBox : UserControl
    {
        private Image good = Properties.Resources.YesImage;
        private Image notGood = Properties.Resources.NoImage;

        private bool Check = false;

        public bool IsChecked
        {
            get
            { return Check; }
            set
            {
                Check = value;
                if (Check)
                {
                    this.pictureBox1.Image = good;
                }
                else
                {
                    this.pictureBox1.Image = notGood;
                }
            }
        }
        public CheckBox()
        {
            InitializeComponent();
            this.pictureBox1.Image = notGood;
        }

        public string LabelText
        {
            get => label1.Text;
            set => label1.Text = value;
        }

    }
}
