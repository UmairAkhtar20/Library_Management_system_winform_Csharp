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

namespace Lib_Mang_Sys
{
    public partial class Book_Return : Form
    {
        public Book_Return()
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
                    string user = Username.name;
                    conn.Open();
                    string query = string.Format(@"Select ID,BookName,AuthorName,Category,IssueDAte from dbo.issuebook where BookReturn='{0}' and MemberName='{1}' ",0,user);
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
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                returnbook(id);
            }
        }
        public void returnbook(int id)
        {
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\umair\source\repos\Lib Mang Sys\Lib Mang Sys\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    string query = string.Format(@"UPDATE dbo.issuebook SET BookReturn='{0}',ReturnDAte='{1}' Where ID='{2}'",1,DateTime.Now.ToString(),id);
                                
                    SqlCommand command = new SqlCommand(query, conn);
                    int recordeff = command.ExecuteNonQuery();
                    MessageBox.Show("Record Has been Updated" +
                        "Return Book to Counter");



                }
                catch (Exception)
                {

                }
            }
        }
    }
}
