using Lib_Mang_Sys.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib_Mang_Sys
{
    public partial class New_member : Form
    {
        public New_member()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = picdialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var filePath = picdialog.FileName;
                pic_member.Image = Image.FromFile(filePath);
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
            DAL dAL = new DAL();
            dAL.AddnewMember(membername,memberfathername,memberphone,memebremail,memberpassword,picturename,membercnic);
           


        }

        private void New_member_Load(object sender, EventArgs e)
        {
            String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            System.IO.Directory.CreateDirectory(applicationBasePath + @"\images\");
        }
    }

      
    
}
