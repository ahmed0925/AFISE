using AFISE.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Common.Model;

namespace AFISE.View
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Authentication : MetroWindow
    {
        public Authentication()
        {
            InitializeComponent();
            authcbx.SelectedIndex = 0;
            Popup1.IsOpen = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (authcbx.SelectedIndex == 0)
            {
                Global.ConnectionType = 0;
                try
                {
                    SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
                    connection.DataSource = servercbx.Text;
                    Global.DataSource = servercbx.Text;
                    connection.IntegratedSecurity = true;
                    String strConn = connection.ToString();
                    Global.Connection = strConn;
                    SqlConnection sqlConn = new SqlConnection(strConn);
                    sqlConn.Open();
                    SourceSelection mn = new SourceSelection();
                    mn.Show();
                    this.Close();
                }
                catch
                {
                    Popup1.IsOpen = true;
                }
            }
            if (authcbx.SelectedIndex == 1)
            {
                Global.ConnectionType = 1;
                try
                {
                    SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
                    connection.DataSource = servercbx.Text;
                    connection.UserID = usernamecbx.Text;
                    Global.username = usernamecbx.Text;
                    connection.Password = passwcbx.Password;
                    Global.password = passwcbx.Password;
                    String strConn = connection.ToString();
                    Global.Connection = strConn;
                    SqlConnection sqlConn = new SqlConnection(strConn);
                    sqlConn.Open();
                    SourceSelection mn = new SourceSelection();
                    mn.Show();
                    this.Close();
                }
                catch
                {
                    Popup1.IsOpen = true;
                }
            }
        }

        private void authcbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(authcbx.SelectedIndex == 0)
            {
                usernamecbx.Visibility = Visibility.Hidden;
                passwcbx.Visibility = Visibility.Hidden;
                usrlbl.Visibility = Visibility.Hidden;
                pwdlbl.Visibility = Visibility.Hidden;
            }
            if (authcbx.SelectedIndex == 1)
            {
                usernamecbx.Visibility = Visibility.Visible;
                passwcbx.Visibility = Visibility.Visible;
                usrlbl.Visibility = Visibility.Visible;
                pwdlbl.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = false;
        }
       

        

       

        
    }
}
