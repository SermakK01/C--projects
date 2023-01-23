using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace LibraryManager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataContainer.loginForm.Dispose();

            if (DataContainer.registerForm == null || DataContainer.registerForm.IsDisposed)
            {
                DataContainer.registerForm = new RegisterForm();
            }
            else
            {
                DataContainer.registerForm.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataContainer.loginForm.Dispose();
            if (DataContainer.libraryNonReg == null || DataContainer.libraryNonReg.IsDisposed)
            {
                DataContainer.libraryNonReg = new LibraryNonReg();
            }
            else
            {
                DataContainer.libraryNonReg.Show();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !="" && textBox2.Text != "")
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * from Users inner join Roles on Users.Role_Id = Roles.Id WHERE Username = @User and Password = @Password", con);
                    cmd.Parameters.AddWithValue("@User", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    DataContainer.username = "@User";
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        string usertype = dt.Rows[0][5].ToString();
                        if (usertype == "Admin")
                        {
                            MessageBox.Show("Welcome Admin!");
                            DataContainer.loginForm.Dispose();
                            if (DataContainer.adminPanel == null || DataContainer.adminPanel.IsDisposed)
                            {
                                DataContainer.adminPanel = new AdminPanel();
                            }
                            else
                            {
                                DataContainer.adminPanel.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Welcome User!");
                            DataContainer.loginForm.Dispose();
                            if (DataContainer.libraryUser == null || DataContainer.libraryUser.IsDisposed)
                            {
                                DataContainer.libraryUser = new LibraryUser();
                            }
                            else
                            {
                                DataContainer.libraryUser.Show();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid login");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Please fill the form!");
            }
          
        }
    }
}
