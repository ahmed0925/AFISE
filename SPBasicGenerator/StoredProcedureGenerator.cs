using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCoreGenerator
{
    public class StoredProcedureGenerator
    {
        public StoredProcedureGenerator()
        {

        }

        public string VariableDeclaration(DataTable datatable, StringBuilder builder)
        {
            foreach (DataRow dr in datatable.Rows)
            {
                builder.AppendLine("DECLARE @" + dr[0].ToString() + " as NVARCHAR(100)           DECLARE @" + dr[0].ToString() + "_error as NVARCHAR(100)");
            }
            return builder.ToString();
        }

        public string ConstantsDeclaration(DataTable datatable, StringBuilder builder)
        {
            foreach (DataRow dr in datatable.Rows)
            {
                builder.AppendLine("SET @" + dr[0].ToString() + "_error      ='" + dr[0].ToString() + " is invalid |'");
            }
            return builder.ToString();
        }

        public string CursorDeclaration(DataTable datatable, StringBuilder builder, string stagingtable)
        {
            builder.AppendLine("DECLARE cur_StagingArea CURSOR FOR");
            builder.AppendLine("SELECT");
            foreach (DataRow dr in datatable.Rows)
            {
                if (datatable.Rows.IndexOf(dr) == 0)
                {
                    builder.AppendLine("cr.[" + dr[0].ToString() + "]");
                }
                else
                {
                    builder.AppendLine(",cr.[" + dr[0].ToString() + "] ");
                }

            }
            builder.AppendLine("FROM " + stagingtable + " cr");
            builder.AppendLine("where Is_interfaced !=1 ");
            builder.AppendLine("OPEN cur_StagingArea");
            builder.AppendLine("FETCH NEXT FROM cur_StagingArea INTO");
            foreach (DataRow dr in datatable.Rows)
            {
                if (datatable.Rows.IndexOf(dr) == 0)
                {
                    builder.AppendLine("@" + dr[0].ToString());
                }
                else
                {
                    builder.AppendLine(",@" + dr[0].ToString());
                }
            }
            return builder.ToString();
        }

        public string NullValuesControl(DataTable datatable, StringBuilder builder)
        {

            builder.AppendLine("SET @MSG = ''");
            foreach (DataRow dr in datatable.Rows)
            {
                builder.AppendLine("IF (" + dr[0].ToString() + " is null  ) BEGIN SET @MSG= @MSG+@" + dr[0].ToString() + "_error  END");
            }
            return builder.ToString();

        }

        public string Insertion(DataTable datatable, StringBuilder builder)
        {

            builder.AppendLine("INSERT INTO " + datatable.Rows[1][1].ToString());
            builder.AppendLine("(");
            foreach (DataRow dr in datatable.Rows)
            {
                if (datatable.Rows.IndexOf(dr) == 0)
                {
                    builder.AppendLine(dr[2].ToString());
                }
                else
                {
                    builder.AppendLine("," + dr[2].ToString());
                }
            }
            builder.AppendLine(")");
            builder.AppendLine("VALUES");
            builder.AppendLine("(");
            foreach (DataRow dr in datatable.Rows)
            {
                if (datatable.Rows.IndexOf(dr) == 0)
                {
                    builder.AppendLine("@" + dr[0].ToString());
                }
                else
                {
                    builder.AppendLine(",@" + dr[0].ToString());
                }
            }
            builder.AppendLine(")");
            return builder.ToString();
        }

        public string UpdateSetEror(StringBuilder builder, string stagingtable)
        {
            builder.AppendLine("UPDATE " + stagingtable + "  set error_msg = @MSG + ERROR_MESSAGE(), interfaced=0 WHERE CURRENT OF cur_StagingArea");
            return builder.ToString();

        }

        public string UpdateNoteInterfaced(StringBuilder builder, string stagingTable)
        {
            builder.AppendLine("UPDATE " + stagingTable + "  set error_msg = @MSG + ERROR_MESSAGE(), Is_interfaced=0 WHERE CURRENT OF cur_StagingArea");
            return builder.ToString();
        }

        public string UpdateInterfaced(StringBuilder builder, string stagingtable)
        {
            builder.AppendLine(" UPDATE " + stagingtable + "   set interface_date=GETDATE(), Is_interfaced=1 WHERE CURRENT OF cur_StagingArea");
            return builder.ToString();
        }

        public string FetchingCursor(DataTable datatable, StringBuilder builder)
        {
            builder.AppendLine("FETCH NEXT FROM cur_StagingArea INTO");
            foreach (DataRow dr in datatable.Rows)
            {
                if (datatable.Rows.IndexOf(dr) == 0)
                {
                    builder.AppendLine("@" + dr[0].ToString());
                }
                else
                {
                    builder.AppendLine(",@" + dr[0].ToString());
                }
            }
            return builder.ToString();
        }
    }
}
