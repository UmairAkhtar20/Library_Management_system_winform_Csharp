using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib_Mang_Sys
{
    public partial class Issue_Book : Form
    {
        int id = 0;
        public Issue_Book()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\umair\source\repos\Lib Mang Sys\Lib Mang Sys\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    string query = "Select ID,Name,AuthorName,PublishDAte,Category from dbo.Books";
                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;

                }
                catch (Exception)
                {

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {

                 id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                string username = Username.name;
                issuebook(id, username);
            }
        }
        public void issuebook(int id,string name)
        {
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\umair\source\repos\Lib Mang Sys\Lib Mang Sys\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    string query = string.Format(@"Select ID,Name,AuthorName,PublishDAte,Category from dbo.Books where ID={0}",id);
                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string BookName= reader.GetString(reader.GetOrdinal("Name"));
                        string AuthorName= reader.GetString(reader.GetOrdinal("AuthorName"));
                        string Category= reader.GetString(reader.GetOrdinal("Category"));
                        string MemberName = name;
                        intodata(BookName, AuthorName, Category, MemberName);
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        public void intodata(string bookname,string authorname,string category,string membername)
        {
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\umair\source\repos\Lib Mang Sys\Lib Mang Sys\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    string query = string.Format(@"INSERT INTO dbo.issuebook(MemberName,BookName,AuthorName,Category,issueDAte,BookReturn,ReturnDAte) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                                , membername, bookname, authorname,category,DateTime.Now.ToString(),0,"No Return");
                    SqlCommand command = new SqlCommand(query, conn);
                    int recordeff = command.ExecuteNonQuery();
                    MessageBox.Show("BOOK Has been Issued to your account " +
                        "collect it from counter");



                }
                catch (Exception)
                {

                }
            }
        }
        
    }
}
