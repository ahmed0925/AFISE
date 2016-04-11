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
        public string SPHeader(string currentbase, string SPName, StringBuilder builder)
        {
            builder.AppendLine("USE [" + currentbase + "]");
            builder.AppendLine("GO");
            builder.AppendLine("SET ANSI_NULLS ON");
            builder.AppendLine("GO");
            builder.AppendLine("SET QUOTED_IDENTIFIER ON");
            builder.AppendLine("GO");
            builder.AppendLine("CREATE PROCEDURE " + SPName);
            builder.AppendLine("AS");
            builder.AppendLine("BEGIN");
            builder.AppendLine("SET NOCOUNT ON;");
            return builder.ToString();
        }

        public string VariableDeclaration(DataTable datatable, StringBuilder builder)
        {
            foreach (DataRow dr in datatable.Rows)
            {
                builder.AppendLine("DECLARE @" + dr[0].ToString() + " as NVARCHAR(100)           DECLARE @" + dr[0].ToString() + "_error as NVARCHAR(100)");             
            }
            builder.AppendLine("DECLARE @MSG AS NVARCHAR(MAX) ");
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
                builder.AppendLine("IF (@" + dr[0].ToString() + " = ''  ) BEGIN SET @MSG= @MSG+@" + dr[0].ToString() + "_error  END");
            }
            return builder.ToString();

        }

        public string Insertion(string destination, DataTable datatable, StringBuilder builder)
        {

            builder.AppendLine("INSERT INTO " + destination);
            builder.AppendLine("(");
            foreach (DataRow dr in datatable.Rows)
            {
                if (dr[1].ToString() == destination)
                {
                    if (dr.ItemArray.Length >= 5)
                    {
                        if (dr[4].ToString() == "")
                        {

                            builder.AppendLine(dr[2].ToString() + ",");
                           
                                
                            
                        }
                        else
                            if (dr[4].ToString() != "")
                            {

                                builder.AppendLine(dr[4].ToString() + ",");
                                
                            }
                    }
                    else
                    {

                        builder.AppendLine(dr[2].ToString() + ",");
                       
                        
                    }
                }
            
            }

            builder.Replace(',', ' ', builder.Length - 3, 1);
            builder.AppendLine(")");
            builder.AppendLine("VALUES");
            builder.AppendLine("(");
            foreach (DataRow dr in datatable.Rows)
            {
                if (dr[1].ToString() == destination)
                {

                    builder.AppendLine("@" + dr[0].ToString() + ",");
                   
                }
            }
            builder.Replace(',', ' ', builder.Length - 3, 1);
            builder.AppendLine(")");
            return builder.ToString();
        }

        public string UpdateSetEror(StringBuilder builder, string stagingtable)
        {
            builder.AppendLine("UPDATE " + stagingtable + "  set Error_msg = @MSG + ERROR_MESSAGE(), Is_interfaced=0 WHERE CURRENT OF cur_StagingArea");
            return builder.ToString();

        }

        public string UpdateNoteInterfaced(StringBuilder builder, string stagingTable)
        {
            builder.AppendLine("UPDATE " + stagingTable + "  set Error_msg = @MSG + ERROR_MESSAGE(), Is_interfaced=0 WHERE CURRENT OF cur_StagingArea");
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

        public string UpdateIfExists(string table, DataTable datatable, StringBuilder builder, string uniquesource, string uniquedestination)
        {
            builder.AppendLine("IF EXISTS (SELECT 1 FROM " + table + " WHERE  " + uniquedestination + " = @" + uniquesource + ")");
            builder.AppendLine("UPDATE " + table + " SET");
            foreach (DataRow dr in datatable.Rows)
            {
                if (dr[1].ToString() == table)
                {
                    if (dr.ItemArray.Length >= 5)
                    {
                        if (dr[4].ToString() == "")
                        {

                            builder.AppendLine(dr[2].ToString() + "=@" + dr[0].ToString() + ",");
                          
                        }
                        else
                            if (dr[4].ToString() != "")
                            {

                                builder.AppendLine(dr[4].ToString() + "=@" + dr[0].ToString() + ",");
                                
                            }
                    }
                    else
                    {

                        builder.AppendLine(dr[2].ToString() + "=@" + dr[0].ToString() + ",");
                        
                    }

                }
            }

                builder.Replace(',', ' ', builder.Length - 3, 1);
                builder.AppendLine("WHERE " + uniquedestination + "=@" + uniquesource);
            
            return builder.ToString();
        }
       
    }
}
