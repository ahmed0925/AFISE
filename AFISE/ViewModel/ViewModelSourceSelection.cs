using AFISE.Helpers;
using System;
using System.Data;
using System.IO;
using System.Linq;
using DevExpress.Mvvm.DataAnnotations;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Common.Model;


namespace AFISE.ViewModel
{
    [POCOViewModel]
    class ViewModelSourceSelection : ViewModelBase
    {

        public RelayCommand LoadFileCommand { get; set; }
        public RelayCommand SelectedColumnCommand { get; set; }
        public RelayCommand LoadDelimitedFileCommand { get; set; }
        public RelayCommand ConnectServerCommand { get; set; }
        public RelayCommand ClosePopUpCommand { get; set; }
        public RelayCommand resetColumnCommand { get; set; }
        public RelayCommand StoreDataCommand { get; set; }
        public RelayCommand LoadMappingFileCommand { get; set; }
        public RelayCommand CreateStagingAreaCommand { get; set; }
        int i = 0;
        DataTable datatable = new DataTable();
        
        string _SelectedText;
        string _TextProperty1;
        string _TextProperty2;



        DataTable _dataTable2;
        public DataTable TblData2
        {
            get { return _dataTable2; }
            set
            {
                _dataTable2 = value;
                RaisePropertyChanged("TblData2");
            }
        }
        DataTable _MappingTable;
        public DataTable MappingTable
        {
            get { return _MappingTable; }
            set
            {
                _MappingTable = value;
                RaisePropertyChanged("MappingTable");
            }
        }
        public string TextProperty2
        {
            get
            {
                return _TextProperty2;
            }
            set
            {
                if (_TextProperty2 != value)
                {
                    _TextProperty2 = value;
                    RaisePropertyChanged("TextProperty2");
                }
            }
        }
        public string SelectedText
        {
            get
            {
                return _SelectedText;
            }
            set
            {
                if (_SelectedText != value)
                {
                    _SelectedText = value;
                    RaisePropertyChanged("SelectedText");
                }
            }
        }
        public string TextProperty1
        {
            get
            {
                return _TextProperty1;
            }
            set
            {
                if (_TextProperty1 != value)
                {
                    _TextProperty1 = value;
                    RaisePropertyChanged("TextProperty1");
                }
            }
        }

        private bool _isOpen;
        public bool IsOpen
        {
            get { return _isOpen; }
            set
            {
                if (_isOpen == value) return;
                _isOpen = value;
                RaisePropertyChanged("IsOpen");
            }
        }

        List<int> lst = new List<int>();



        void LoadFile(object parameter)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                // Set filter for file extension and default file extension 
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents (.txt)|*.txt";
                // Display OpenFileDialog by calling ShowDialog method 
                Nullable<bool> result = dlg.ShowDialog();
                // Open document 
                string filename = dlg.FileName;
                Global.filename = filename;


                TextProperty1 = filename;
                FileInfo file = new FileInfo(filename);
                string data = file.OpenText().ReadLine();
                var lines = File.ReadAllLines(filename);
                data = lines[2].ToString();
                TextProperty2 = data;
            }
            catch
            {

                Console.WriteLine("IOException source");

            }


        }
        //Delimit the file in case there is no delimiter 
        void selectColumn(object parameter)
        {

            if (TextProperty2.IndexOf(SelectedText) == 0)
            {
                try
                {
                    string selText = SelectedText;
                    if (SelectedText.Length != 0)
                    {
                        var lines = File.ReadAllLines(TextProperty1);
                        //Filling datatable with FlatFile lines 
                        try
                        {
                            if (i == 0)
                            {

                                datatable.Columns.Add("Column" + i + "");
                                //case of first and last lines contains file information
                                if ((lines[0].Length != lines[1].Length) && (lines.Last().Length != lines[1].Length))
                                {
                                    for (int j = 1; j < lines.Count() - 1; j++)
                                    {

                                        DataRow newRow = datatable.NewRow();
                                        newRow["Column" + i + ""] = lines[j].Substring(0, selText.Length).Replace(" ", "");
                                        datatable.Rows.Add(newRow);
                                    }
                                    i++;
                                }
                                //case of only first row contains file information
                                else if (lines[0].Length != lines[1].Length)
                                {
                                    for (int j = 1; j < lines.Count(); j++)
                                    {
                                        DataRow newRow = datatable.NewRow();
                                        newRow["Column" + i + ""] = lines[j].Substring(0, selText.Length).Replace(" ", "");
                                        datatable.Rows.Add(newRow);
                                    }
                                    i++;
                                }
                                else
                                    //case no row contains file information
                                    foreach (string line in lines)
                                    {
                                        DataRow newRow = datatable.NewRow();
                                        newRow["Column" + i + ""] = line.Substring(0, selText.Length).Replace(" ", "");
                                        datatable.Rows.Add(newRow);
                                    }
                                i++;

                                lst.Add(selText.Length);

                            }

                            //filling datatable with the rest of data
                            else
                            {
                                if (lines[0].Length != lines[1].Length)
                                {

                                    datatable.Columns.Add("Column" + i + "");
                                    foreach (DataRow draw in datatable.Rows)
                                    {

                                        draw["Column" + i + ""] = lines[datatable.Rows.IndexOf(draw) + 1].Substring(lines[2].IndexOf(selText), selText.Length).Replace(" ", "");
                                    }
                                    i++;
                                }
                                else
                                {
                                    datatable.Columns.Add("Column" + i + "");
                                    foreach (DataRow draw in datatable.Rows)
                                    {

                                        draw["Column" + i + ""] = lines[datatable.Rows.IndexOf(draw)].Substring(lines[2].IndexOf(selText), selText.Length).Replace(" ", "");

                                    }
                                    i++;
                                }
                                lst.Add(selText.Length);
                            }

                            Global.columnLength = lst;
                            TextProperty2 = TextProperty2.Remove(0, selText.Length);


                            //selection of columns finished, so we'll return the datatable and the global static datatable
                            if (TextProperty2.Length == 0)
                            {
                                TblData2 = datatable;
                                Global.datatable1 = TblData2;
                                DataTable dt = new DataTable();
                                dt.Columns.Add("test");
                                foreach (DataColumn dc in TblData2.Columns)
                                {
                                    DataRow datarow = dt.NewRow();
                                    datarow["test"] = dc.ColumnName;
                                    dt.Rows.Add(datarow);
                                }
                                Global.TblData4 = dt;

                            }
                        }
                        catch
                        {

                            Console.WriteLine("IOException source");

                        }
                    }
                }
                catch
                {

                    Console.WriteLine("IOException source");

                }
            }
            else
            {
                IsOpen = true;
            }

        }
        void LoadDelimitedFile(object parameter)
        {
            try
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.DefaultExt = ".txt";
                openfile.Filter = "(.txt)|*.txt";
                //openfile.ShowDialog();

                var browsefile = openfile.ShowDialog();
                DataTable dat = new DataTable("TextFile");
                string[] columns = null;

                var lines = File.ReadAllLines(openfile.FileName);
                //assuming first row conatains columns information
                if (Global.ischeked == 1)
                {



                    if (lines.Count() > 0)
                    {
                        columns = lines[0].Split(new char[] { Global.Delimiter });
                        foreach (var col in columns)
                        {
                            dat.Columns.Add(col);
                        }



                    }

                    // reading rest of the data from the text file
                    for (int i = 1; i < lines.Count(); i++)
                    {
                        DataRow dr = dat.NewRow();
                        string[] values = lines[i].Split(new char[] { Global.Delimiter });

                        for (int j = 0; j < values.Count() && j < columns.Count(); j++)
                            dr[j] = values[j];

                        dat.Rows.Add(dr);
                    }
                }
                else
                {
                    if (lines.Count() > 0)
                    {
                        columns = lines[0].Split(new char[] { Global.Delimiter });
                        // assuming the first row does not contains columns information
                        for (int i = 0; i < columns.Count(); i++)
                        {
                            dat.Columns.Add("column" + i + "");
                        }
                        for (int i = 0; i < lines.Count(); i++)
                        {
                            DataRow dr = dat.NewRow();
                            string[] values = lines[i].Split(new char[] { Global.Delimiter });

                            for (int j = 0; j < values.Count() && j < columns.Count(); j++)
                                dr[j] = values[j];

                            dat.Rows.Add(dr);
                        }
                    }
                }
                TblData2 = dat;
                Global.datatable1 = TblData2;
                //creating the datatable that we'll use to mapp
                DataTable dt = new DataTable();
                dt.Columns.Add("test");
                foreach (DataColumn dc in TblData2.Columns)
                {
                    DataRow datarow = dt.NewRow();
                    datarow["test"] = dc.ColumnName;
                    dt.Rows.Add(datarow);
                }
                Global.TblData4 = dt;
            }
            catch
            {
                Console.WriteLine("IOException source");
            }
        }
        void resetColumn(object parameter)
        {
            SourceSelection mn = new SourceSelection();
        }
        void StoreData(object parameter)
        {
            var now = DateTime.Now;
            var timestamp = "" + now.Second + now.Day + now.Month + now.Year;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("CREATE TABLE Staging_Area" + timestamp + "");
            Global.StagingTable = "Staging_Area" + timestamp + "";
            builder.AppendLine(" ( ");
            foreach (DataColumn dc in TblData2.Columns)
            {
                builder.AppendLine(dc.ColumnName + " nvarchar(max), ");
            }
            builder.AppendLine("Error_Msg nvarchar(max) default '0', ");
            builder.AppendLine("Is_Interface nvarchar(max) default '-1', ");
            builder.AppendLine("Interface_Date date default GetDate() ");
            builder.AppendLine(" ); ");
            string sqlConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=StagingTest2;Data Source=.\SQL2012";
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            Server server = new Server(new ServerConnection(conn));
            server.ConnectionContext.ExecuteNonQuery(builder.ToString());
            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
            connection.DataSource = ".\\SQL2012";
            connection.InitialCatalog = "StagingTest2";
            connection.IntegratedSecurity = true;
            String strConn = connection.ToString();
            using (SqlBulkCopy sbc = new SqlBulkCopy(strConn, SqlBulkCopyOptions.KeepIdentity))
            {
                sbc.DestinationTableName = "Staging_Area" + timestamp + "";

                // Number of records to be processed in one go
                int batchSize = 5000;
                sbc.BatchSize = batchSize;

                // Add  column mappings here
                foreach (DataColumn dc in TblData2.Columns)
                {
                    sbc.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                }

                // Finally write to server
                sbc.WriteToServer(TblData2);

            }
        }
        void LoadMappingFile(object parameter)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".xml";
            dlg.Filter = "(.xml)|*.xml";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            // Open document 
            string filename = dlg.FileName;
            DataSet ds = new DataSet();
            ds.ReadXml(filename);
            DataTable dt = ds.Tables[0];
            MappingTable = dt;
        }
        void ClosePopUp(object parameter)
        {
            IsOpen = false;
        }
        void CreateStagingArea(object parameter)
        {
            var now = DateTime.Now;
            var timestamp = "" + now.Second + now.Day + now.Month + now.Year;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("CREATE TABLE Staging_Area" + timestamp + "");
            Global.StagingTable = "Staging_Area" + timestamp + "";
            builder.AppendLine(" ( ");
            foreach (DataRow dr in MappingTable.Rows)
            {
                builder.AppendLine(dr[0].ToString() + " NVARCHAR(MAX), ");
            }
            builder.AppendLine("Error_Msg nvarchar(max) default '0', ");
            builder.AppendLine("Is_Interface nvarchar(max) default '-1', ");
            builder.AppendLine("Interface_Date date default GetDate() ");
            builder.AppendLine(" ); ");

            SqlConnectionStringBuilder sqlcon = new SqlConnectionStringBuilder();
            sqlcon.DataSource = Global.DataSource;
            sqlcon.InitialCatalog = Global.CurrentBase;
            sqlcon.IntegratedSecurity = true;
            string connection = sqlcon.ToString();
            SqlConnection conn = new SqlConnection(connection);
            Server server = new Server(new ServerConnection(conn));
            server.ConnectionContext.ExecuteNonQuery(builder.ToString());
            StringBuilder builder1 = new StringBuilder();
            Random rnd = new Random();
            builder1.AppendLine("Insert into ");
            builder1.AppendLine(Global.StagingTable);
            builder1.AppendLine(" ( ");
            foreach (DataRow dr in MappingTable.Rows)
            {
                int index = MappingTable.Rows.IndexOf(dr);
                if (index != MappingTable.Rows.Count - 1)
                {
                    builder1.AppendLine(dr[0].ToString() + " , ");
                }
                else
                {
                    builder1.AppendLine(dr[0].ToString() + ") ");
                }
            }
            builder1.AppendLine("Values");
            for (int j = 1; j <= 100; j++)
            {
                builder1.AppendLine(" ( ");

                foreach (DataRow dr in MappingTable.Rows)
                {
                    int index = MappingTable.Rows.IndexOf(dr);
                    if (index != MappingTable.Rows.Count - 1)
                    {
                        int i = int.Parse(dr[2].ToString());

                        builder1.AppendLine(GenerateNewCode(rnd, i) + ", ");

                    }
                    else
                    {
                        int i = int.Parse(dr[2].ToString());
                        //Random rnd = new Random();
                        builder1.AppendLine(GenerateNewCode(rnd, i) + "), ");
                    }


                }
            }
            builder1.AppendLine(" ( ");
            foreach (DataRow dr in MappingTable.Rows)
            {
                int index = MappingTable.Rows.IndexOf(dr);
                if (index != MappingTable.Rows.Count - 1)
                {
                    int i = int.Parse(dr[2].ToString());
                    //Random rnd = new Random();
                    builder1.AppendLine(GenerateNewCode(rnd, i) + ", ");

                }
                else
                {
                    //Random rnd = new Random();
                    int i = int.Parse(dr[2].ToString());
                    builder1.AppendLine(GenerateNewCode(rnd, i) + "); ");
                }
            }

            server.ConnectionContext.ExecuteNonQuery(builder1.ToString());



        }
        public string GenerateNewCode(Random random, int CodeLength)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < CodeLength; i++)
            {
                output.Append(random.Next(1, 9));
                output.Append("0");
            }

            return output.ToString();
        }




        public ViewModelSourceSelection()
        {
            IsOpen = false;
            LoadFileCommand = new RelayCommand(LoadFile);
            SelectedColumnCommand = new RelayCommand(selectColumn);
            LoadDelimitedFileCommand = new RelayCommand(LoadDelimitedFile);
            ClosePopUpCommand = new RelayCommand(ClosePopUp);
            resetColumnCommand = new RelayCommand(resetColumn);
            StoreDataCommand = new RelayCommand(StoreData);
            LoadMappingFileCommand = new RelayCommand(LoadMappingFile);
            CreateStagingAreaCommand = new RelayCommand(CreateStagingArea);

        }

    }
}
