using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalendarzKontrolka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>() { "fri15301600#fryzjer#Low", "wed16301700#zakupy#Medium", "wed17301800#Szkola#High"};
            scheduleControl1.data(list);
            scheduleControl1.remindIn = -67;
        }

        private void scheduleControl1_eventIn15Minutes_1(object sender, EventArgs e)
        {
            MessageBox.Show(scheduleControl1.eventIn15MinutesName);
        }
    }
}
