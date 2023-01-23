using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataContainer.registerForm.Dispose();
            if (DataContainer.loginForm == null || DataContainer.loginForm.IsDisposed)
            {
                DataContainer.loginForm = new LoginForm();
            }
            else
            {
                DataContainer.loginForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                
                if (textBox1.Text == "")
                {
                    MessageBox.Show("User name is required!");
                    return;
                }
                else if (textBox2.Text =="")
                {
                    MessageBox.Show("Password is required!");
                    return;
                }
                else if(textBox3.Text == "")
                {
                    MessageBox.Show("Please repeat the password!");
                    return;
                }
                else if(textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("Passwords do not match!");
                    return;
                }
                if (textBox1.Text != "" && textBox2.Text == textBox3.Text && textBox2.Text != "" && textBox3.Text != "")
                {
                    

                    string sqlquery = "INSERT INTO Users VALUES (@user,@password,2)";
                    con.Open();
                    SqlCommand cmd= new SqlCommand(sqlquery, con);
                    cmd.Parameters.AddWithValue("user",textBox1.Text);
                    cmd.Parameters.AddWithValue("password",textBox2.Text);

                    int i = cmd.ExecuteNonQuery();
                    if (i!=0)
                    {
                        MessageBox.Show("User has been added");
                    }
                }
            }
        }
    }
}
