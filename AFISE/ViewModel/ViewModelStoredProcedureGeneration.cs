using AFISE.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using SPCoreGenerator;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Windows.Input;
using AFISE.Model;
using MahApps.Metro.Controls.Dialogs;

namespace AFISE.ViewModel
{
    class ViewModelStoredProcedureGeneration : ViewModelBase
    {

        public RelayCommand ClosePopUpCommand { get; set; }
        string _spName;
        public string spName
        {
            get { return _spName; }
            set
            {
                _spName = value;
                RaisePropertyChanged("spName");
            }
        }
        DataTable _MappingTable;
        public RelayCommand SPStagingInsertCommand { get; set; }
        public DataTable SPMappingTable
        {
            get { return _MappingTable; }
            set
            {
                _MappingTable = value;
                RaisePropertyChanged("SPMappingTable");
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
        private bool _isOpen1;
        public bool IsOpen1
        {
            get { return _isOpen1; }
            set
            {
                if (_isOpen1 == value) return;
                _isOpen1 = value;
                RaisePropertyChanged("IsOpen1");
            }
        }

        void ClosePopUp(object parameter)
        {
            IsOpen = false;
            IsOpen1 = false;
        }
        public ViewModelStoredProcedureGeneration()
        {
            IsOpen1 = false;
            IsOpen = false;
            ClosePopUpCommand = new RelayCommand(ClosePopUp);
            SPMappingTable = Global.SpDataTable;
            SPStagingInsertCommand = new RelayCommand(SPStagingInsert);
        }
        

        public void SPStagingInsert(object parameter)
        {
            try
            {
                StoredProcedureGenerator sp = new StoredProcedureGenerator();
                StringBuilder builder = new StringBuilder();
                sp.SPHeader(Global.CurrentBase, spName, builder);
                sp.VariableDeclaration(SPMappingTable, builder);
                sp.ConstantsDeclaration(SPMappingTable, builder);
                sp.CursorDeclaration(SPMappingTable, builder, Global.stagingTable);
                builder.AppendLine("WHILE(@@fetch_status=0)");
                builder.AppendLine("BEGIN");
                sp.NullValuesControl(SPMappingTable, builder);
                builder.AppendLine("IF (@MSG = '')");
                builder.AppendLine("BEGIN");
                builder.AppendLine("BEGIN TRY");
                sp.UpdateIfExists(Global.TableSP,SPMappingTable, builder, Global.sourceunique, Global.destunique);
                builder.AppendLine("ELSE");
                sp.Insertion(Global.TableSP,SPMappingTable, builder);
                builder.AppendLine("END TRY");
                builder.AppendLine("BEGIN CATCH");
                sp.UpdateSetEror(builder, Global.stagingTable);
                builder.AppendLine("END CATCH;");
                builder.AppendLine("END");
                builder.AppendLine("IF (@MSG not like '')");
                sp.UpdateNoteInterfaced(builder, Global.stagingTable);
                builder.AppendLine("ELSE");
                sp.UpdateInterfaced(builder, Global.stagingTable);
                sp.FetchingCursor(SPMappingTable, builder);
                builder.AppendLine("END");
                builder.AppendLine("CLOSE cur_StagingArea");
                builder.AppendLine("DEALLOCATE cur_StagingArea");
                builder.AppendLine("END");
                Global.spName = spName;
                Global.sptest = builder.ToString();
                if (Global.ConnectionType == 0)
                {
                    SqlConnectionStringBuilder sqlcon = new SqlConnectionStringBuilder();
                    sqlcon.DataSource = Global.DataSource;
                    sqlcon.InitialCatalog = Global.CurrentBase;
                    sqlcon.IntegratedSecurity = true;
                    string connection = sqlcon.ToString();
                    SqlConnection conn = new SqlConnection(connection);
                    Server server = new Server(new ServerConnection(conn));
                    server.ConnectionContext.ExecuteNonQuery(builder.ToString());
                }
                if (Global.ConnectionType == 1)
                {
                    SqlConnectionStringBuilder sqlcon = new SqlConnectionStringBuilder();
                    sqlcon.DataSource = Global.DataSource;
                    sqlcon.InitialCatalog = Global.CurrentBase;
                    sqlcon.UserID = Global.username;
                    sqlcon.Password = Global.password;
                    string connection = sqlcon.ToString();
                    SqlConnection conn = new SqlConnection(connection);
                    Server server = new Server(new ServerConnection(conn));
                    server.ConnectionContext.ExecuteNonQuery(builder.ToString());
                }
                IsOpen1 = true;
            }
            catch
            {
                IsOpen = true;
            }
            




        }
    }
}
