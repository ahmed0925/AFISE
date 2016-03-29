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
using MahApps.Metro.Controls;
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
            dt.Columns.Add("Source");
            dt.Columns.Add("Destination");
            foreach (DataRow dr in Global.SpDataTable.Rows)
            {
                DataRow dtr = dt.NewRow();
                dtr["Source"] = dr[0];
                if (dr[4].ToString() != "")
                {
                    dtr["Destination"] = dr[4];
                }
                else
                    dtr["Destination"] = dr[2];
                dt.Rows.Add(dtr);
            }
            sourcecolumns.ItemsSource = dt.DefaultView;
            destinationcolumns.ItemsSource = dt.DefaultView;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            showscript.Visibility = Visibility.Visible;
            await this.ShowMessageAsync("MESSAGE", "Your Script has been generated");
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            spgeneration.Visibility = Visibility.Hidden;
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



    }
}
