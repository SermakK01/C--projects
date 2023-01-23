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
    public partial class ListOfCheckBoxes : UserControl
    {
        private PassCheck check;

        public ListOfCheckBoxes()
        {
            InitializeComponent();
            check = new PassCheck();
        }

        public void UpdateCheckboxes(string text)
        {
            check.Pass = text;
            imageCheckBox1.IsChecked = check.HasRightLenght();
            imageCheckBox2.IsChecked = check.HasSpecialChar();
            imageCheckBox3.IsChecked = check.HasUpperLetter();
            imageCheckBox4.IsChecked = check.HasNumber();
        }
        
        public bool IsPasswordValid()
        {
            return check.IsStrong();
        }

        public int MinLength
        {
            get => check.MinimumLen;
            set => check.MinimumLen = value;
        }

        public string SpecialCharacters
        {
            get => check.SpecialCHar;
            set => check.SpecialCHar = value;
        }

        private void imageCheckBox3_Load(object sender, EventArgs e)
        {

        }

        private void imageCheckBox4_Load(object sender, EventArgs e)
        {

        }
    }
}
