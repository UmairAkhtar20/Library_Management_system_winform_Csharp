using Lib_Mang_Sys.Properties;
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
    public partial class Cancel_Member : Form
    {
        public Cancel_Member()
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
                    string query = "Select ID,Name,FatherName,DOR from dbo.NewMember where IsMember='1'";
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
            if (e.ColumnIndex == 4)

            {
                
                var id =(int)dataGridView1.CurrentRow.Cells[0].Value;

                DAL dAL = new DAL();
                dAL.CancelMember(id);
            }
        }
    }
}
