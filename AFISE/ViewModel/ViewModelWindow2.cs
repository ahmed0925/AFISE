using AFISE.Helpers;
using AFISE.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;

namespace AFISE.ViewModel
{
    class ViewModelWindow2 : ViewModelSourceSelection
    {
        public RelayCommand ValidateMappCommand { get; set; }
        public RelayCommand MappColumnCommand { get; set; }
        public RelayCommand ResetColumnCommand { get; set; }
        public RelayCommand GenerateBIMLCommand { get; set; }

        List<string> columnMapping = new List<string>();

        string mapp = "";

        string mapping = "";

        StringBuilder srtb = new StringBuilder();

        public DataTable TblData4
        {
            get
            {
                return _dataTable4;

            }
            set
            {
                _dataTable4 = value;
                RaisePropertyChanged("TblData4");



            }
        }

        DataTable _dataTable4;

        DataTable _dataTable5;
        StringBuilder builder = new StringBuilder();
        public DataTable TblData5
        {
            get { return _dataTable5; }
            set
            {
                _dataTable5 = value;
                RaisePropertyChanged("TblData5");

            }
        }
        void ValidateMapp(object parameter)
        {
            try
            {
                //// Get the DataTable 
                //DataTable dtInsertRows = Global.datatable1;
                //SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
                //connection.DataSource = Global.TextProperty3;
                //connection.InitialCatalog = Global.SelectedDatabase[0].ToString();
                //connection.IntegratedSecurity = true;
                //String strConn = connection.ToString();
                //using (SqlBulkCopy sbc = new SqlBulkCopy(strConn, SqlBulkCopyOptions.KeepIdentity))
                //{
                //    sbc.DestinationTableName = Global.SelectedTable[0].ToString();

                //    // Number of records to be processed in one go
                //    int batchSize = 5000;
                //    sbc.BatchSize = batchSize;

                //    // Add your column mappings here

                //    foreach (var mapping in columnMapping)
                //    {
                //        var split = mapping.Split(new[] { ',' });
                //        sbc.ColumnMappings.Add(split.First(), split.Last());
                //    }


                //    // Finally write to server
                //    sbc.WriteToServer(dtInsertRows);
                srtb.AppendLine("<Columns>");
                srtb.AppendLine(mapping);
                srtb.AppendLine("</Columns>");
                var now = DateTime.Now;
                var timestamp = "" + now.Hour + now.Minute + now.Second;
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                File.AppendAllText(string.Format("{0}\\{1}.xml", path, timestamp), srtb.ToString());

            }
            catch
            {

                Console.WriteLine("IOException source");

            }
        }



        void MappColumn(object parameter)
        {
            try
            {
                string CommandText = "SELECT TOP 1 " + SelectedSource[0] + " FROM " + Global.StagingTable.ToString() + "";
                string CommandText1 = "SELECT TOP 1 " + SelectedDestination[3] + " FROM " + Global.SelectedTable[0].ToString() + "";
                SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
                connection.DataSource = Global.TextProperty3;
                connection.InitialCatalog = Global.SelectedDatabase[0].ToString();
                connection.IntegratedSecurity = true;
                String strConn = connection.ToString();
                SqlConnection sqlConn = new SqlConnection(strConn);
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand(CommandText, sqlConn);
                string SourceValue = ((string)sqlCmd.ExecuteScalar());
                int length = SourceValue.Length;
                mapp = mapp + "  <Column SourceColumn=\"" + SelectedSource[0] + "\" TargetColumn=\"" + SelectedDestination[3] + "\"/>  ";
                columnMapping.Add(SelectedSource[0].ToString() + "," + SelectedDestination[3].ToString());
                Global.sourcecolumns.Add(SelectedSource[0].ToString());
                Global.destcolumns.Add(SelectedDestination[3].ToString());
                Global.datatypedest.Add(SelectedDestination[7].ToString());
                mapping = mapping + "  <Column SourceColumn=\"" + SelectedSource[0] + "\" FirstValue=\"" + SourceValue + "\" SourceLength=\"" + length + "\" TargetTable=\"" + Global.SelectedTable[0].ToString() + "\" TargetColumn=\"" + SelectedDestination[3] + "\" TargetLength=\"" + SelectedDestination[8] + "\" DataType=\"" + SelectedDestination[7].ToString() + "\"/> \n";
                TblData4.Rows.Remove(SelectedSource.Row);
                TblData5.Rows.Remove(SelectedDestination.Row);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        void ResetColumn(object parameter)
        {

            columnMapping.Clear();
            //reset source List
            DataTable dt = new DataTable();
            dt.Columns.Add("test");
            foreach (DataColumn dc in Global.datatable1.Columns)
            {
                DataRow datarow = dt.NewRow();
                datarow["test"] = dc.ColumnName;
                dt.Rows.Add(datarow);
            }
            TblData4 = dt;

            // reset destination list
            string CommandText = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + Global.SelectedTable[0].ToString() + "'";
            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
            connection.DataSource = Global.TextProperty3;
            connection.InitialCatalog = Global.SelectedDatabase[0].ToString();
            connection.IntegratedSecurity = true;
            String strConn = connection.ToString();
            SqlConnection sqlConn = new SqlConnection(strConn);
            sqlConn.Open();
            SqlCommand sqlCmd = new SqlCommand(CommandText, sqlConn);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataTable dat = new DataTable();
            da.Fill(dat);
            dat.Rows.RemoveAt(0);
            TblData5 = dat;
            mapp = "";
            mapping = "";

        }

       


        DataRowView _SelectedSource;
        DataRowView _SelectedDestination;
        public DataRowView SelectedSource
        {
            get { return _SelectedSource; }
            set
            {
                _SelectedSource = value;
                RaisePropertyChanged("SelectedSource");
            }
        }
        public DataRowView SelectedDestination
        {
            get { return _SelectedDestination; }
            set
            {
                _SelectedDestination = value;
                RaisePropertyChanged("SelectedDestination");
            }
        }



        public ViewModelWindow2()
        {
            TblData4 = Global.TblData4;
            TblData5 = Global.TblData5;
            ValidateMappCommand = new RelayCommand(ValidateMapp);
            MappColumnCommand = new RelayCommand(MappColumn);
            ResetColumnCommand = new RelayCommand(ResetColumn);
        }
    }
}
