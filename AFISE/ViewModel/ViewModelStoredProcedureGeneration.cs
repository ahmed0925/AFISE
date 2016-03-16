using AFISE.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using SPCoreGenerator;

namespace AFISE.ViewModel
{
    class ViewModelStoredProcedureGeneration : ViewModelBase
    {

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


        public ViewModelStoredProcedureGeneration()
        {
            SPMappingTable = Global.SpDataTable;
            SPStagingInsertCommand = new RelayCommand(SPStagingInsert);
        }

        public void SPStagingInsert(object parameter)
        {
            StoredProcedureGenerator sp = new StoredProcedureGenerator();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("CREATE PROCEDURE Test");
            builder.AppendLine("AS");
            builder.AppendLine("BEGIN");           
            sp.VariableDeclaration(SPMappingTable, builder);
            sp.ConstantsDeclaration(SPMappingTable, builder);
            sp.CursorDeclaration(SPMappingTable, builder, Global.stagingTable);
            builder.AppendLine("WHILE(@@fetch_status=0)");
            builder.AppendLine("BEGIN");
            sp.NullValuesControl(SPMappingTable, builder);
            builder.AppendLine("IF (@MSG = '')");
            builder.AppendLine("BEGIN");
            builder.AppendLine("BEGIN TRY");
            sp.Insertion(SPMappingTable, builder);
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
            
            Global.sptest = builder.ToString();




        }
    }
}
