using MahApps.Metro.Controls;
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
using MahApps.Metro.Controls.Dialogs;
using AFISE.ViewModel;
using Common.Model;
using System.Data;
using System.Collections;
using SPCoreGenerator;
using System.Data.SqlClient;
namespace AFISE.View
{
    /// <summary>
    /// Interaction logic for Window6.xaml
    /// </summary>
    internal sealed partial class StoredProcedureGeneration : MetroWindow
    {

        public StoredProcedureGeneration()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();


            dt1.Columns.Add("Tables");
            dt.Columns.Add("Source");
            dt.Columns.Add("Destination");

            foreach (DataRow dr in Global.SpDataTable.Rows)
            {
                DataRow dtr = dt.NewRow();
                dtr["Source"] = dr[0];
                dtr["Destination"] = dr[2];
                dt.Rows.Add(dtr);
            }
            foreach (DataRow dr in Global.SpDataTable.Rows)
            {
                DataRow dtr = dt1.NewRow();
                dtr["Tables"] = dr[1];
                dt1.Rows.Add(dtr);

            }
            RemoveDuplicateRows(dt1, "Tables");
            combotbl.ItemsSource = dt1.DefaultView;
            sourcecolumns.ItemsSource = dt.DefaultView;
            destinationcolumns.ItemsSource = dt.DefaultView;
            Tables.ItemsSource = dt1.DefaultView;



        }
        string validationKey;
        string validationKey1;

        StringBuilder builder = new StringBuilder();
        StoredProcedureGenerator sp = new StoredProcedureGenerator();
        int i = 0;
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("", Global.sptest);
        }

        private void sourcecolumns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView oDataRowView = sourcecolumns.SelectedItem as DataRowView;

            Global.sourceunique = oDataRowView.Row["Source"] as string;
        }

        private void destinationcolumns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView oDataRowView = destinationcolumns.SelectedItem as DataRowView;

            Global.destunique = oDataRowView.Row["Destination"] as string;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SourceSelection SR = new SourceSelection();
            SR.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BIMLGeneration bm = new BIMLGeneration();
            bm.Show();
        }

        private void Tables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView oDataRowView = Tables.SelectedItem as DataRowView;

            Global.TableSP = oDataRowView.Row["Tables"] as string;

            string connection = null;
            if (Global.ConnectionType == 0)
            {
                SqlConnectionStringBuilder sqlcon = new SqlConnectionStringBuilder();
                sqlcon.DataSource = Global.DataSource;
                sqlcon.InitialCatalog = Global.CurrentBase;
                sqlcon.IntegratedSecurity = true;
                connection = sqlcon.ToString();


            }
            if (Global.ConnectionType == 1)
            {
                SqlConnectionStringBuilder sqlcon = new SqlConnectionStringBuilder();
                sqlcon.DataSource = Global.DataSource;
                sqlcon.InitialCatalog = Global.CurrentBase;
                sqlcon.UserID = Global.username;
                sqlcon.Password = Global.password;
                connection = sqlcon.ToString();


            }
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + Global.TableSP + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            linkcombo.ItemsSource = dt2.DefaultView;
        }

        private async void ADD_TO_SCRIPT(object sender, RoutedEventArgs e)
        {
            if (chkex.IsChecked == true)
            {

                sp.UpdateIfExists(Global.TableSP, Global.SpDataTable, builder, Global.sourceunique, Global.destunique);
                builder.AppendLine("ELSE");
                sp.Insertion(Global.TableSP, Global.SpDataTable, builder);

            }
            else

                if (linkchk.IsChecked == true)
                {
                    sp.DeleteInsert(Global.TableSP, Global.SpDataTable, builder, validationKey, validationKey1);
                }
                else

                    sp.Insertion(Global.TableSP, Global.SpDataTable, builder);
            Global.TableScript = builder.ToString();
            chkex.IsChecked = false;
            linkchk.IsChecked = false;

            i++;
            await this.ShowMessageAsync("Message", "Informations were added to your script");
        }


        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            lbldest.Visibility = Visibility.Visible;
            lblsrc.Visibility = Visibility.Visible;
            sourcecolumns.Visibility = Visibility.Visible;
            destinationcolumns.Visibility = Visibility.Visible;
            linkchk.IsEnabled = false;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            lbldest.Visibility = Visibility.Hidden;
            lblsrc.Visibility = Visibility.Hidden;
            sourcecolumns.Visibility = Visibility.Hidden;
            destinationcolumns.Visibility = Visibility.Hidden;
            linkchk.IsEnabled = true;
        }

        private void linkchk_Checked(object sender, RoutedEventArgs e)
        {
            linktable.Visibility = Visibility.Visible;
            linkcombo.Visibility = Visibility.Visible;
            tablename.Visibility = Visibility.Visible;
            combotbl.Visibility = Visibility.Visible;
            chkex.IsEnabled = false;
        }

        private void linkchk_Unchecked(object sender, RoutedEventArgs e)
        {
            linktable.Visibility = Visibility.Hidden;
            linkcombo.Visibility = Visibility.Hidden;
            tablename.Visibility = Visibility.Hidden;
            combotbl.Visibility = Visibility.Hidden;
            chkex.IsEnabled = true;
        }

        private void combotbl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView oDataRowView = combotbl.SelectedItem as DataRowView;
            foreach (DataRow dr in Global.SpDataTable.Rows)
            {
                if (dr[1].ToString() == oDataRowView.Row["Tables"] as string)
                {
                    validationKey = dr[3].ToString();
                    if (Global.validationKeys.Contains(validationKey) == false)
                    {
                        Global.validationKeys.Add(validationKey);
                    }
                }
            }


        }

        private void linkcombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView oDataRowView = linkcombo.SelectedItem as DataRowView;
            validationKey1 = oDataRowView.Row["COLUMN_NAME"] as string;

        }





    }
}
