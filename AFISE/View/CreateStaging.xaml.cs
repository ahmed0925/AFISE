using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common.Model;
using SPCoreGenerator;
using System.Data;
using AFISE.ViewModel;
using AFISE.Model;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace AFISE.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CreateStaging : MetroWindow, INotifyPropertyChanged
    {
        // public StagingViewModel svm = new StagingViewModel();
        public DBTableInfo myStagingTable = new DBTableInfo();
        string query = "";
        private ObservableCollection<DBTableColumnInfo> _viewStagingTable = new ObservableCollection<DBTableColumnInfo>();
        public ObservableCollection<DBTableColumnInfo> viewStagingTable { get { return _viewStagingTable; } set { _viewStagingTable = value; OnPropertyChanged("viewStagingTable"); } }
        public CreateStaging()
        {
            InitializeComponent();
            // myStagingTable = svm.stagingTable;

            DataContext = this;
            DBTableColumnInfo LoadIDcol = new DBTableColumnInfo("LoadID");
            myStagingTable.Columns.Add(LoadIDcol);

            int i = 0;
            foreach (DataColumn dc in Global.datatable1.Columns)
            {
                DBTableColumnInfo C = new DBTableColumnInfo();
                C.ColumnName = dc.ColumnName;
                myStagingTable.Columns.Add(C);
                Debug.WriteLine(myStagingTable.Columns[i].ColumnName);
                i++;
            }
            viewStagingTable = myStagingTable.Columns;

            SqlConnection sqlConn = new SqlConnection(Global.Connection);
            sqlConn.Open();
            DataTable tblDatabases = sqlConn.GetSchema("Databases");
            DbCombo.ItemsSource = tblDatabases.DefaultView;

        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }



        public NotifyCollectionChangedEventHandler DataGrid_CollectionChanged { get; set; }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var model = new MainWinModel();
            model.RefreshSettings();
            var sb = new StringBuilder(10000);
            if (DropIfExistCheckBox.IsChecked == true)
                sb.Append("IF Object_ID('dbo." + TableNameTextBox.Text + "', 'U') IS NOT NULL DROP TABLE dbo." + TableNameTextBox.Text);
            // model.GenerateSp(myStagingTable.TableName, Constants.createTreeNodeText, ref sb, viewStagingTable.ToList(), new List<DBTableColumnInfo>());

            CreateSpGenerator spGenerator = new CreateSpGenerator();
            spGenerator.GenerateStatement(myStagingTable.TableName, sb, viewStagingTable.ToList(), new List<DBTableColumnInfo>());
            query = sb.ToString();
            await this.ShowMessageAsync("Insertion Script", query);
          




        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myStagingTable != null)
            {
                this.myStagingTable.TableName = TableNameTextBox.Text;
                Global.stagingTable = TableNameTextBox.Text;
            }
        }

        private void DbCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView oDataRowView = DbCombo.SelectedItem as DataRowView;

            Global.CurrentBase = oDataRowView.Row["database_name"] as string;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Global.ConnectionType == 0)
            {
                SqlConnectionStringBuilder sqlcon = new SqlConnectionStringBuilder();
                sqlcon.DataSource = Global.DataSource;
                sqlcon.InitialCatalog = Global.CurrentBase;
                sqlcon.IntegratedSecurity = true;
                string connection = sqlcon.ToString();
                SqlConnection conn = new SqlConnection(connection);
                Server server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(query.ToString());
                using (SqlBulkCopy sbc = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity))
                {
                    sbc.DestinationTableName = TableNameTextBox.Text;

                    // Number of records to be processed in one go
                    int batchSize = 5000;
                    sbc.BatchSize = batchSize;

                    // Add  column mappings here
                    foreach (DataColumn dc in Global.datatable1.Columns)
                    {
                        sbc.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                    }

                    // Finally write to server
                    sbc.WriteToServer(Global.datatable1);

                }
                MappingWindow mp = new MappingWindow();
                mp.Show();
                this.Close();
            }
            else if (Global.ConnectionType == 1)
            {
                
                    SqlConnectionStringBuilder sqlcon = new SqlConnectionStringBuilder();
                    sqlcon.DataSource = Global.DataSource;
                    sqlcon.InitialCatalog = Global.CurrentBase;
                    sqlcon.UserID = Global.username;
                    sqlcon.Password = Global.password;
                    string connection = sqlcon.ToString();
                    SqlConnection conn = new SqlConnection(connection);
                    Server server = new Server(new ServerConnection(conn));
                    server.ConnectionContext.ExecuteNonQuery(query.ToString());
                    using (SqlBulkCopy sbc = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity))
                    {
                        sbc.DestinationTableName = TableNameTextBox.Text;

                        // Number of records to be processed in one go
                        int batchSize = 5000;
                        sbc.BatchSize = batchSize;

                        // Add  column mappings here
                        foreach (DataColumn dc in Global.datatable1.Columns)
                        {
                            sbc.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                        }

                        // Finally write to server
                        sbc.WriteToServer(Global.datatable1);

                    }
                    MappingWindow mp = new MappingWindow();
                    mp.Show();
                    this.Close();
                
            }
            

            
        }


    }
}
