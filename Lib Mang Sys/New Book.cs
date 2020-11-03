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
    public partial class New_Book : Form
    {
        public New_Book()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txt_bookName.Text;
            string authorname = txt_AuthorName.Text;
            string isbn = txt_isbnnmbr.Text;
            string publishdate = txt_publishdate.Text;
            string category = txt_category.Text;

            DAL dAL = new DAL();
            dAL.Addbooks(name, authorname, isbn, publishdate, category);
            
        }
    }
}
