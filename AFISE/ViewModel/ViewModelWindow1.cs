using AFISE.Helpers;
using AFISE.View;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;


namespace AFISE.ViewModel
{

    class ViewModelWindow1 : ViewModelSourceSelection
    {


        DataTable _dataTable;
        DataTable _dataTable1;
        string _TextProperty3;
        public string TextProperty3
        {
            get
            {
                return _TextProperty3;
            }
            set
            {
                if (_TextProperty3 != value)
                {
                    _TextProperty3 = value;
                    RaisePropertyChanged("TextProperty3");
                }
                Global.TextProperty3 = TextProperty3;
            }
        }
        public DataTable TblData
        {
            get { return _dataTable; }
            set
            {
                _dataTable = value;
                RaisePropertyChanged("TblData");
            }
        }
        public DataTable TblData1
        {
            get { return _dataTable1; }
            set
            {
                _dataTable1 = value;
                RaisePropertyChanged("TblData1");
            }
        }

        DataRowView _SelectedDataBase;
        public DataRowView SelectedDataBase
        {
            get { return _SelectedDataBase; }
            set
            {
                _SelectedDataBase = value;
                RaisePropertyChanged("SelectedDataBase");
                //First connection to get databases 
                if (SelectedDataBase != null)
                {
                    SqlConnectionStringBuilder connection1 = new SqlConnectionStringBuilder();
                    connection1.DataSource = TextProperty3;
                    connection1.IntegratedSecurity = true;
                    String strConn1 = connection1.ToString();
                    SqlConnection sqlConn1 = new SqlConnection(strConn1);
                    sqlConn1.Open();
                    DataTable tblDatabases = sqlConn1.GetSchema("Databases");

                    //second connection to get tables
                    string CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_TYPE='Base Table'";
                    SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
                    connection.DataSource = TextProperty3;
                    connection.InitialCatalog = SelectedDataBase[0].ToString();
                    connection.IntegratedSecurity = true;
                    String strConn = connection.ToString();
                    SqlConnection sqlConn = new SqlConnection(strConn);
                    sqlConn.Open();

                    //fill the list box with datatable values
                    SqlCommand sqlCmd = new SqlCommand(CommandText, sqlConn);
                    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    TblData1 = dt;
                }
                Global.SelectedDatabase = SelectedDataBase;
            }
        }

       

        DataRowView _SelectedTable;
        //Filling Source and destination tables when database table is selected
        public DataRowView SelectedTable
        {
            get { return _SelectedTable; }
            set
            {
                _SelectedTable = value;
                RaisePropertyChanged("SelectedTable");

                if (SelectedTable != null)
                {
                    
                    string CommandText = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + SelectedTable[0].ToString() + "'";
                    SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
                    connection.DataSource = TextProperty3;
                    Global.TextProperty3 = TextProperty3;
                    connection.InitialCatalog = SelectedDataBase[0].ToString();
                    connection.IntegratedSecurity = true;
                    String strConn = connection.ToString();
                    SqlConnection sqlConn = new SqlConnection(strConn);
                    sqlConn.Open();

                    //fill the list box with datatable values
                    SqlCommand sqlCmd = new SqlCommand(CommandText, sqlConn);        
                    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                   
                    dt.Rows.RemoveAt(0);
                    // case the staging area is the destination 

                    Global.DestinationAll = dt;
                    Global.TblData5 = dt;
                    Global.SelectedTable = SelectedTable;
                    Global.SelectedDatabase = SelectedDataBase;

                }
                

                //Fill Mapping table of Window2
                DataTable dtm = new DataTable();
                dtm.Columns.Add("test");

                foreach (DataRow dr in Global.TblData4.Rows)
                {
                    DataRow newrow = dtm.NewRow();
                    newrow["test"] = dr["test"];
                    dtm.Rows.Add(newrow);

                }

                Global.TblDataMapping = dtm;

            }
        }
        void ConnectToServer(object parameter)
        {
            try
            {
                SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();

                connection.DataSource = TextProperty3;
                connection.IntegratedSecurity = true;

                String strConn = connection.ToString();

                //create connection
                SqlConnection sqlConn = new SqlConnection(strConn);

                //open connection
                sqlConn.Open();

                //get databases
                DataTable tblDatabases = sqlConn.GetSchema("Databases");

                //close connection
                sqlConn.Close();

                //add to list



                TblData = tblDatabases;
            }
            catch
            {

                Console.WriteLine("IOException source");

            }

        }
       

        public ViewModelWindow1()
        {
            ConnectServerCommand = new RelayCommand(ConnectToServer);
            
        }

    }
}
