using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passwordApp
{
    public partial class TestApp : Form
    {
        public TestApp()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.TextChanged += delegate { imageCheckBoxList1.UpdateCheckboxes(textBox2.Text); this.CheckIfValid(imageCheckBoxList1.IsPasswordValid()); };
        }

        private void CheckIfValid(bool isValid)
        {
            if (isValid)
            {
                label1.Text = "Password is strong";
            }
            else
            {
                label1.Text = "Password is too weak";
            }
        }







    }
}
