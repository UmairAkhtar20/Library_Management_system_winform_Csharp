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
    public partial class UpDAte_Member_Acc : Form
    {
        int userid = 0;
        public UpDAte_Member_Acc()
        {
            InitializeComponent();
        }

        private void UpDAte_Member_Acc_Load(object sender, EventArgs e)
        {
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\umair\source\repos\Lib Mang Sys\Lib Mang Sys\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    string user = Username.name;
                    conn.Open();
                    string query = string.Format(@"Select * from dbo.NewMember where Name='{0}'", user);
                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userid = reader.GetInt32(reader.GetOrdinal("ID"));
                        string membername = reader.GetString(reader.GetOrdinal("Name"));
                        string memberfather = reader.GetString(reader.GetOrdinal("FatherName"));
                        string memberphone = reader.GetString(reader.GetOrdinal("Phone"));
                        string memberCnic = reader.GetString(reader.GetOrdinal("Cnic"));
                        string memberemail = reader.GetString(reader.GetOrdinal("Email"));
                        string picture = reader.GetString(reader.GetOrdinal("Picture"));

                        txt_membername.Text = membername;
                        txt_memberfather.Text = memberfather;
                        text_memberphone.Text = memberphone;
                        txt_membercnic.Text = memberCnic;
                        txt_memberemail.Text = memberemail;


                        String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                        String filePath = applicationBasePath + @"\images\" + picture;
                        pic_member.Image = Image.FromFile(filePath);

                    }



                }
                catch (Exception)
                {

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string membername = txt_membername.Text.Trim();
            string memberfathername = txt_memberfather.Text.Trim();
            string memberphone = text_memberphone.Text.Trim();
            string memebremail = txt_memberemail.Text;
            string memberpassword = membername + "123";
            string membercnic = txt_membercnic.Text;
            string picturename = "";
            if (pic_member.Image != null)
            {
                String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                String pathToSaveImage = applicationBasePath + @"\images\";

                picturename = Guid.NewGuid().ToString() + ".jpg";
                String imgPath = pathToSaveImage + picturename;

                pic_member.Image.Save(imgPath);
            }
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\umair\source\repos\Lib Mang Sys\Lib Mang Sys\Database1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    string query = string.Format(@"UPDATE dbo.NewMember SET Name='{0}',FatherName='{1}',Email='{2}',Phone='{3}',Cnic='{4}',Password='{5}',Picture='{6}',DOR='{7}',IsMember='{8}' Where ID='{9}'"
                                , membername, memberfathername, memebremail, memberphone, membercnic, memberpassword, picturename, DateTime.Now.ToString(), 1,userid );
                    SqlCommand command = new SqlCommand(query, conn);
                    int recordeff = command.ExecuteNonQuery();
                    MessageBox.Show("Data IS UPdated");



                }
                catch (Exception)
                {

                }
            }
        }
    }
}
