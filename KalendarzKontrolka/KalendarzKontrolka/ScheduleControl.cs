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
    public partial class ScheduleControl : UserControl
    {
        Label clickedLabel;
        List<Label> labels = new List<Label>();
        string tag;
        DateTime now = DateTime.Now;
        public event EventHandler eventIn15Minutes;
        public string eventIn15MinutesName;
        List<string> risedLabelTags = new List<string>();
        public int remindIn;

        public ScheduleControl()
        {
            InitializeComponent();
            comboBox1.DataSource = new List<string>() { "Low", "Medium", "High", "Very High"};

            foreach (var control in tableLayoutPanel1.Controls)
            {
                if(control is Label)
                {
                    var label = (Label)control;
                    if(label.Name.Length == 11)
                        labels.Add((Label)control);
                }
            }

            button2.Enabled = false;
            remindIn = 15;
            timer1.Start();
        }

        public void data(List<string> data)
        {
            if (data != null)
            {
                foreach (var e in data)
                {
                    foreach (var label in labels)
                    {
                        if (label.Name == e.Split('#')[0])
                        {
                            label.Text = e.Split('#')[1];
                            label.BackColor = getColor(e.Split('#')[2]);
                            Random rnd = new Random();
                            label.Tag = rnd.Next(1000) + label.Text.Trim() + e.Split('#')[2] + rnd.Next(1000);
                        }
                    }
                }
            }
        }

        protected virtual void OnEvenInt15Minutes(EventArgs e)
        {
            eventIn15Minutes.Invoke(this, e);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private Color getColor()
        {
            if (comboBox1.Text == "Low")
                return Color.Green;
            if (comboBox1.Text == "Medium")
                return Color.Yellow;
            if (comboBox1.Text == "High")
                return Color.Orange;
            return Color.Red;
        }

        private Color getColor(string priority)
        {
            if (priority == "Low")
                return Color.Green;
            if (priority == "Medium")
                return Color.Yellow;
            if (priority == "High")
                return Color.Orange;
            return Color.Red;
        }

        private string getPriority(Color color)
        {
            if (color == Color.Green)
                return "Low";
            if (color == Color.Yellow)
                return "Medium";
            if (color == Color.Orange)
                return "High";
            return "Very High";
        }

        private void onClick(object sender, EventArgs e)
        {
            if (clickedLabel != null)
                clickedLabel.BorderStyle = BorderStyle.None;
            clickedLabel = sender as Label;
            clickedLabel.BorderStyle = BorderStyle.FixedSingle;

            if (clickedLabel.Text != "-")
            {
                if(button1.Enabled != false)
                {
                    textBox1.Text = clickedLabel.Text;
                    comboBox1.Text = getPriority(clickedLabel.BackColor);
                }
                button2.Enabled = true;
                button1.Text = "Delete";
                return;
            }
            if (!textBox1.Enabled)
            {
                clickedLabel.Tag = tag;
                clickedLabel.Text = textBox1.Text;
                clickedLabel.BackColor = getColor();
                return;
            }
            //textBox1.Clear();
            button1.Text = "Add";
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            if(clickedLabel != null)
            {
                if(button1.Text == "Delete" && clickedLabel.Text != "-")
                {
                    var tag = clickedLabel.Tag;
                    foreach(var label in labels)
                    {
                        if(label.Tag != null && tag != null && tag == label.Tag)
                        {
                            label.Text = "-";
                            label.BackColor = Color.FromArgb(255, 224, 192);
                            label.Tag = null;
                        }
                    }
                    textBox1.Clear();
                }
                else
                {
                    if(textBox1.Text != "")
                    {
                        Random rnd = new Random();
                        clickedLabel.Tag = rnd.Next(1000) + textBox1.Text.Trim() + comboBox1.Text + rnd.Next(1000);
                        clickedLabel.Text = textBox1.Text;
                        clickedLabel.BackColor = getColor();
                        textBox1.Clear();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.Text == "Extend")
            {
                button2.Text = "Done";
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                button1.Enabled = false;
                tag = clickedLabel.Tag.ToString();
            }
            else
            {
                button2.Text = "Extend";
                textBox1.Enabled = true;
                comboBox1.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            now = now.AddSeconds(1);
            foreach(var label in labels)
            {
                if(label.Text != "-")
                {
                    DateTime in15Minutes = now.AddMinutes(remindIn);
                    if(label.Name.Substring(0, 3) == now.DayOfWeek.ToString().ToLower().Substring(0, 3))
                    {
                        string timeString = in15Minutes.Hour.ToString();
                        if (in15Minutes.Minute.ToString().Length == 1)
                            timeString += "0";
                        timeString += in15Minutes.Minute.ToString();
                        if (in15Minutes.Second.ToString().Length == 1)
                            timeString += "0";
                        timeString += in15Minutes.Second.ToString();

                        Console.WriteLine(timeString + "  " + label.Name.Substring(3, 4) + "00");

                        if (label.Name.Substring(3, 4) + "00" ==  timeString)
                        {
                            if (risedLabelTags.Contains(label.Tag.ToString()))
                                return;
                            risedLabelTags.Add(label.Tag.ToString());
                            eventIn15MinutesName = label.Text + " " + label.Name.Substring(3,2) + ":" + label.Name.Substring(5, 2);
                            Console.WriteLine(eventIn15MinutesName);
                            OnEvenInt15Minutes(EventArgs.Empty);
                        }
                    }
                }
            }
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
