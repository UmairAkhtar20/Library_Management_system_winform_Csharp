﻿using Lib_Mang_Sys.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lib_Mang_Sys
{
    /// <summary>
    /// Interaction logic for Admin_Login.xaml
    /// </summary>
    public partial class Admin_Login : Window
    {
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void admin_login_Click(object sender, RoutedEventArgs e)
        {
            string User = admin_user.Text;
            string Pass = admin_pass.Password;
            DAL dAL = new DAL();
            dAL.checkadmin(User, Pass);
           

        }

        
    }
}
