using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lib_Mang_Sys.Properties
{
    class DAL
    {
        public void checkadmin(string user, string pass)
        {
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\umair\source\repos\Lib Mang Sys\Lib Mang Sys\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    string query = "Select * from dbo.Admin";
                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string username = reader.GetString(reader.GetOrdinal("Name"));
                        string password = reader.GetString(reader.GetOrdinal("Password"));
                        if (user == username && pass == password)
                        {
                           
                            Admin_Login a = new Admin_Login();
                            a.Hide();
                            Admin_Panel b = new Admin_Panel();
                            b.Show();

                       

                        }
                        else
                        {
                            MessageBox.Show("wrong");
                        }
                    }


                }
                catch (Exception )
                {

                }
            }
        }
        public void AddnewMember(string membername,
           string memberfather, string memberphone , string memberemail, string memberpassword, string memberpicture, string membercnic)
        {
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\umair\source\repos\Lib Mang Sys\Lib Mang Sys\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    string query =string.Format(@"INSERT INTO dbo.NewMember(Name,FatherName,Email,Phone,Cnic,Password,Picture,DOR,IsMember) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')"
                                ,membername,memberfather,memberemail,memberphone,membercnic,memberpassword,memberpicture,DateTime.Now.ToString(),1);
                    SqlCommand command = new SqlCommand(query, conn);
                    int  recordeff= command.ExecuteNonQuery();
                    MessageBox.Show("Data Is saveed");
               


                }
                catch (Exception )
                {

                }
            }
        }
        public void Addbooks(string name,string authorname,string isbn,string publishdate,string category)
        {
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\umair\source\repos\Lib Mang Sys\Lib Mang Sys\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    string query = string.Format(@"INSERT INTO dbo.Books(Name,AuthorName,ISBN,PublishDAte,Category,DOE) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')"
                                ,name,authorname,isbn,publishdate,category,DateTime.Now.ToString());
                    SqlCommand command = new SqlCommand(query, conn);
                    int recordeff = command.ExecuteNonQuery();
                    MessageBox.Show("Data Is saveed");



                }
                catch (Exception)
                {

                }
            }

        }
        public void CancelMember(int id)
        {
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\umair\source\repos\Lib Mang Sys\Lib Mang Sys\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    string query = string.Format(@"UPDATE dbo.NewMember SET IsMember='{0}' WHERE ID='{1}'", 0, id);
                    SqlCommand command = new SqlCommand(query, conn);
                    int recordeff = command.ExecuteNonQuery();
                    MessageBox.Show("MemberShip is Cancelled");



                }
                catch (Exception)
                {

                }
            }
        }
        public void checkuser(string user,string pass)
        {
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\umair\source\repos\Lib Mang Sys\Lib Mang Sys\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    string query =string.Format( "Select * from dbo.NewMember where Name='{0}' ",user);
                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string username = reader.GetString(reader.GetOrdinal("Name"));
                        string password = reader.GetString(reader.GetOrdinal("Password"));
                        if (user == username && pass == password)
                        {

                            Admin_Login a = new Admin_Login();
                            a.Hide();
                            Member_Panel b = new Member_Panel();
                            b.Show();



                        }
                        else
                        {
                           MessageBox.Show("wrong");
                       }
                    }


                }
                catch (Exception)
                {

                }
            }
        }
        public void loaddatainupdatemember()
        {

        }
        public void updatemember()
        {

        }
    }
}
