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
            Tables.ItemsSource = dt1.DefaultView;
            sourcecolumns.ItemsSource = dt.DefaultView;
            destinationcolumns.ItemsSource = dt.DefaultView;
        }

        public string othertable;
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
            if (i == 0)
            {
                Global.TableSP = oDataRowView.Row["Tables"] as string;
            }
            else
            {
                othertable = oDataRowView.Row["Tables"] as string;
            }
            i++;    
        }

        private async void ADD_TO_SCRIPT(object sender, RoutedEventArgs e)
        {

            if (i > 0)
            {
                Global.OtherTable = othertable;
            }

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





    }
}
