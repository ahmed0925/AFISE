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
            foreach(DataRow dr in Global.SpDataTable.Rows)
            {
                DataRow dtr = dt1.NewRow();
                dtr["Tables"] = dr[1];
                dt1.Rows.Add(dtr);
                
            }
            for(int i =1; i< dt1.Rows.Count; i++)
            {
                if(dt1.Rows[i-1][0].ToString() == dt1.Rows[i][0].ToString())
                {
                    dt1.Rows.Remove(dt1.Rows[i]);
                }
            }
            Tables.ItemsSource = dt1.DefaultView;
            sourcecolumns.ItemsSource = dt.DefaultView;
            destinationcolumns.ItemsSource = dt.DefaultView;
        }



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
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            lblsrc.Visibility = Visibility.Visible;
            sourcecolumns.Visibility = Visibility.Visible;
            lbldest.Visibility = Visibility.Visible;
            destinationcolumns.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            lblsrc.Visibility = Visibility.Hidden;
            sourcecolumns.Visibility = Visibility.Hidden;
            lbldest.Visibility = Visibility.Hidden;
            destinationcolumns.Visibility = Visibility.Hidden;
        }



    }
}
