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
    public partial class BorrowingForm : Form
    {
        public BorrowingForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                comboBox2.SelectedIndexChanged -= comboBox2_SelectedIndexChanged;
                SqlCommand cmd1 = new SqlCommand("SELECT Id_Title, Title, Book.Id_Author FROM Book INNER JOIN Title ON Book.Id_Title = Title.Id AND Book.Id_Author = " + this.comboBox1.SelectedValue, con);
                con.Open();
                cmd1.Connection = con;
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sdr1.Fill(dt1);
                comboBox2.DataSource = dt1;
                comboBox2.ValueMember = dt1.Columns[0].ColumnName;
                comboBox2.DisplayMember = dt1.Columns[1].ColumnName;
                comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                comboBox3.SelectedIndexChanged -= comboBox3_SelectedIndexChanged;
                SqlCommand cmd1 = new SqlCommand("SELECT Id_Title, Book.Id_Author, Book.Id_Type, Type FROM Book INNER JOIN Title ON Book.Id_Title = Title.Id AND Book.Id_Author = " + this.comboBox1.SelectedValue + "INNER JOIN Type ON Book.Id_Type = Type.Id AND Book.Id_Title =" + this.comboBox2.SelectedValue, con);
                con.Open();
                cmd1.Connection = con;
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sdr1.Fill(dt1);
                comboBox3.DataSource = dt1;
                comboBox3.ValueMember = dt1.Columns[2].ColumnName;
                comboBox3.DisplayMember = dt1.Columns[3].ColumnName;
                comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                comboBox4.SelectedIndexChanged -= comboBox4_SelectedIndexChanged;
                SqlCommand cmd1 = new SqlCommand("SELECT Id_Title, Book.Id_Author, Book.Id_Type, Book.Id_Pages, Pages FROM Book INNER JOIN Title ON Book.Id_Title = Title.Id AND Book.Id_Author = " + this.comboBox1.SelectedValue + "INNER JOIN Type ON Book.Id_Type = Type.Id AND Book.Id_Title =" + this.comboBox2.SelectedValue + "INNER JOIN Pages ON Book.Id_Pages = Pages.Id AND Book.Id_Type=" + this.comboBox3.SelectedValue, con);
                con.Open();
                cmd1.Connection = con;
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sdr1.Fill(dt1);
                comboBox4.DataSource = dt1;
                comboBox4.ValueMember = dt1.Columns[3].ColumnName;
                comboBox4.DisplayMember = dt1.Columns[4].ColumnName;
                comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                comboBox5.SelectedIndexChanged -= comboBox5_SelectedIndexChanged;
                SqlCommand cmd1 = new SqlCommand("SELECT Id_Title, Book.Id_Author, Book.Id_Type, Book.Id_Pages, Book.Id_Price, Price FROM Book INNER JOIN Title ON Book.Id_Title = Title.Id AND Book.Id_Author = " + this.comboBox1.SelectedValue + "INNER JOIN Type ON Book.Id_Type = Type.Id AND Book.Id_Title =" + this.comboBox2.SelectedValue + "INNER JOIN Pages ON Book.Id_Pages = Pages.Id AND Book.Id_Type=" + this.comboBox3.SelectedValue + "INNER JOIN Price ON Book.Id_Price = Price.Id AND Book.Id_Pages=" + this.comboBox4.SelectedValue, con);
                con.Open();
                cmd1.Connection = con;
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sdr1.Fill(dt1);
                comboBox5.DataSource = dt1;
                comboBox5.ValueMember = dt1.Columns[4].ColumnName;
                comboBox5.DisplayMember = dt1.Columns[5].ColumnName;
                comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                comboBox6.SelectedIndexChanged -= comboBox6_SelectedIndexChanged;
                SqlCommand cmd1 = new SqlCommand("SELECT Id_Title, Book.Id_Author, Book.Id_Type, Book.Id_Pages, Book.Id_Price, Book.Id_Currency, Currency FROM Book INNER JOIN Title ON Book.Id_Title = Title.Id AND Book.Id_Author = " + this.comboBox1.SelectedValue + "INNER JOIN Type ON Book.Id_Type = Type.Id AND Book.Id_Title =" + this.comboBox2.SelectedValue + "INNER JOIN Pages ON Book.Id_Pages = Pages.Id AND Book.Id_Type=" + this.comboBox3.SelectedValue + "INNER JOIN Price ON Book.Id_Price = Price.Id AND Book.Id_Pages=" + this.comboBox4.SelectedValue + "INNER JOIN Currency ON Book.Id_Currency = Currency.Id AND Book.Id_Price=" + this.comboBox5.SelectedValue, con);
                con.Open();
                cmd1.Connection = con;
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sdr1.Fill(dt1);
                comboBox6.DataSource = dt1;
                comboBox6.ValueMember = dt1.Columns[4].ColumnName;
                comboBox6.DisplayMember = dt1.Columns[5].ColumnName;
                comboBox6.SelectedIndexChanged += comboBox6_SelectedIndexChanged;
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BorrowingForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDBDataSet.Currency' table. You can move, or remove it, as needed.
            this.currencyTableAdapter.Fill(this.libraryDBDataSet.Currency);
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
                SqlCommand cmd1 = new SqlCommand("SELECT DISTINCT Book.Id_Author, Author FROM Book INNER JOIN Author ON Book.Id_Author = Author.Id", con);
                con.Open();
                cmd1.Connection = con;
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sdr1.Fill(dt1);
                comboBox1.DataSource = dt1;
                comboBox1.ValueMember = dt1.Columns[0].ColumnName;
                comboBox1.DisplayMember = dt1.Columns[1].ColumnName;
                comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;


            }

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM Orders", con);
                con.Open();
                cmd1.Connection = con;
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sdr1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO Orders(Name, Last_name, Id_Book) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "'," + "(SELECT Book.Id FROM Book WHERE Book.Id_Author = " + comboBox1.SelectedValue + "AND Book.Id_Title = " + comboBox2.SelectedValue + "AND Book.Id_Type =" + comboBox3.SelectedValue + "AND Book.Id_Pages=" + comboBox4.SelectedValue + "AND Book.Id_Price=" + comboBox5.SelectedValue + "AND Book.Id_Currency=" + comboBox6.SelectedValue + "))", con);
                con.Open();
                cmd1.Connection = con;
                cmd1.ExecuteNonQuery();
                    MessageBox.Show("Book has been borrowed");

            }
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM Orders", con);
                con.Open();
                cmd1.Connection = con;
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sdr1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
    }
}
