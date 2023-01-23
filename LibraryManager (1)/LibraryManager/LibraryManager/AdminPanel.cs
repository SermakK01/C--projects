using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using Microsoft.IdentityModel;

namespace LibraryManager
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataContainer.adminPanel.Dispose();
            if (DataContainer.loginForm == null || DataContainer.loginForm.IsDisposed)
            {
                DataContainer.loginForm = new LoginForm();
            }
            else
            {
                DataContainer.loginForm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Author VALUES('" + textBox1.Text + "')", con);
                con.Open();
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Author has been added");

                }


            }
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM Author", con);
                con.Open();
                cmd1.Connection = con;
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sdr1.Fill(dt1);
                comboBox5.DataSource = dt1;
                comboBox5.ValueMember = dt1.Columns[0].ColumnName;
                comboBox5.DisplayMember = dt1.Columns[1].ColumnName;


            }



            // for (int item=0; item<dataGridView1.Rows.Count; item++)
            //  {
            //    if (textBox1.Text == dataGridView1.Rows[item].Cells[0].Value.ToString())
            //     {
            //        MessageBox.Show("This author already exists!");
            //        return;
            //     }
            //   }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Title VALUES('" + textBox3.Text + "')", con);
                con.Open();
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
            }
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                
                SqlCommand cmd1 = new SqlCommand("INSERT INTO Pages VALUES('" + textBox2.Text + "')", con);
                con.Open();
                cmd1.Connection = con;
                int j = cmd1.ExecuteNonQuery();

            }
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd2 = new SqlCommand("INSERT INTO Price VALUES('" + textBox4.Text + "')", con);
                con.Open();
                cmd2.Connection = con;
                int k = cmd2.ExecuteNonQuery();
            }
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd3 = new SqlCommand("INSERT INTO Book (Id_Author,Id_Title,Id_Type,Id_Pages, Id_Price, Id_Currency) SELECT Author.Id, Title.Id, Type.Id, Pages.Id, Price.Id, Currency.Id FROM Author, Title, Type, Pages, Price, Currency WHERE Author='" + comboBox5.Text + "' AND Title='" + textBox3.Text + "' AND Type='" + comboBox1.Text + "' AND Pages='" + textBox2.Text + "' AND Price='" + textBox4.Text + "' AND Currency='" + comboBox2.Text + "'", con);
                con.Open();
                cmd3.Connection = con;
                int l = cmd3.ExecuteNonQuery();
                if (l != 0)
                {
                    MessageBox.Show("New book has been added to the library");
                }
            }


        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDBDataSet.Currency' table. You can move, or remove it, as needed.
            this.currencyTableAdapter.Fill(this.libraryDBDataSet.Currency);
            // TODO: This line of code loads data into the 'libraryDBDataSet.Type' table. You can move, or remove it, as needed.
            this.typeTableAdapter.Fill(this.libraryDBDataSet.Type);
            // TODO: This line of code loads data into the 'libraryDBDataSet.Author' table. You can move, or remove it, as needed.
            this.authorTableAdapter.Fill(this.libraryDBDataSet.Author);
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Orders",con);
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                sdr1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataContainer.adminPanel.Dispose();
            if (DataContainer.libraryAdmin == null || DataContainer.libraryAdmin.IsDisposed)
            {
                DataContainer.libraryAdmin = new LibraryAdmin();
            }
            else
            {
                DataContainer.libraryAdmin.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
