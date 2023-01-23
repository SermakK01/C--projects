using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    static class DataContainer
    {
        public static AdminPanel adminPanel = new AdminPanel();
        public static BorrowingForm borrowingForm = new BorrowingForm();
        public static LibraryNonReg libraryNonReg = new LibraryNonReg();
        public static LibraryUser libraryUser = new LibraryUser();
        public static LoginForm loginForm = new LoginForm();
        public static RegisterForm registerForm = new RegisterForm();
        public static LibraryAdmin libraryAdmin = new LibraryAdmin();
        public static String username;
        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    }
}
