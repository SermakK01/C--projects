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
    public partial class LibraryUser : Form
    {
        public LibraryUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataContainer.libraryUser.Dispose();
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
            DataContainer.libraryUser.Dispose();
            if (DataContainer.borrowingForm == null || DataContainer.borrowingForm.IsDisposed)
            {
                DataContainer.borrowingForm = new BorrowingForm();
            }
            else
            {
                DataContainer.borrowingForm.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LibraryUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDBDataSet.Author' table. You can move, or remove it, as needed.
            //this.authorTableAdapter.Fill(this.libraryDBDataSet.Author);
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd = new SqlCommand("SELECT Book.Id, Author, Title, Type, Pages,Price,Currency FROM Author, Title, Type, Pages, Price, Currency,Book WHERE Author.Id = Book.Id_Author AND Title.Id = Book.Id_Title AND Type.Id = Book.Id_Type AND Pages.Id = Book.Id_Pages AND Price.Id = Book.Id_Price AND Currency.Id = Book.Id_Currency", con);
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                sdr1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }
        }
    }
}
