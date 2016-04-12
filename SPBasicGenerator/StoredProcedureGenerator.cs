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

        public string VariableDeclaration(DataTable datatable,DataTable datatable1, StringBuilder builder)
        {
            foreach (DataColumn dr in datatable.Columns)
            {
                builder.AppendLine("DECLARE @" + dr.ColumnName.ToString() + " as NVARCHAR(100)           DECLARE @" + dr.ColumnName.ToString() + "_error as NVARCHAR(100)");             
            }
            builder.AppendLine("DECLARE @" + datatable1.Rows[0][3] + " as INT");
            builder.AppendLine("DECLARE @MSG AS NVARCHAR(MAX) ");
            return builder.ToString();
        }

        public string ConstantsDeclaration(DataTable datatable, StringBuilder builder)
        {
            foreach (DataColumn dr in datatable.Columns)
            {
                builder.AppendLine("SET @" + dr.ColumnName.ToString() + "_error      ='" + dr.ColumnName.ToString() + " is invalid |'");
            }
            return builder.ToString();
        }

        public string CursorDeclaration(DataTable datatable, StringBuilder builder, string stagingtable)
        {
            builder.AppendLine("DECLARE cur_StagingArea CURSOR FOR");
            builder.AppendLine("SELECT");
            foreach (DataColumn dr in datatable.Columns)
            {

                builder.AppendLine("cr.[" + dr.ColumnName.ToString() + "],");
 
            }
            builder.Replace(',', ' ', builder.Length - 3, 1);
            builder.AppendLine("FROM " + stagingtable + " cr");
            builder.AppendLine("where Is_interfaced !=1 ");
            builder.AppendLine("OPEN cur_StagingArea");
            builder.AppendLine("FETCH NEXT FROM cur_StagingArea INTO");
            foreach (DataColumn dr in datatable.Columns)
            {

                builder.AppendLine("@" + dr.ColumnName.ToString() + ",");

                
            }
            builder.Replace(',', ' ', builder.Length - 3, 1);
            return builder.ToString();
        }

        public string NullValuesControl(DataTable datatable, StringBuilder builder)
        {

            builder.AppendLine("SET @MSG = ''");
            foreach (DataColumn dr in datatable.Columns)
            {
                builder.AppendLine("IF (@" + dr.ColumnName.ToString() + " = ''  ) BEGIN SET @MSG= @MSG+@" + dr.ColumnName.ToString() + "_error  END");
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
                    String build = dr[0].ToString();
                    if (build.Contains("("))
                    {
                        build = build.Replace("(", "(@");
                        build = build.Replace(",", ",@");

                    }
                    else
                    {
                        build = "@" + build;
                    }
                    builder.AppendLine(build + ",");

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
            foreach (DataColumn dr in datatable.Columns)
            {

                builder.AppendLine("@" + dr.ColumnName.ToString() + ",");
              
            }
            builder.Replace(',', ' ', builder.Length - 3, 1);
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
                            String build = dr[0].ToString();
                            if (build.Contains("("))
                            {
                                build = build.Replace("(", "(@");
                                build = build.Replace(",", ",@");

                            }
                            else
                            {
                                build = "@"+build;
                            }



                            builder.AppendLine(dr[2].ToString() + "=" + build + ",");

                        }
                        else
                            if (dr[4].ToString() != "")
                            {
                                String build = dr[0].ToString();
                                if (build.Contains("("))
                                {
                                    build = build.Replace("(", "(@");
                                    build = build.Replace(",", ",@");

                                }

                                else
                                {
                                    build = "@" + build;
                                }

                                builder.AppendLine(dr[4].ToString() + "=" + build + ",");

                            }
                    }
                    else
                    {
                        String build = dr[0].ToString();
                        if (build.Contains("("))
                        {
                            build = build.Replace("(", "(@");
                            build = build.Replace(",", ",@");

                        }

                        else
                        {
                            build = "@" + build;
                        }
                        builder.AppendLine(dr[2].ToString() + "=" + build + ",");

                    }

                }
            }

                builder.Replace(',', ' ', builder.Length - 3, 1);
                builder.AppendLine("WHERE " + uniquedestination + "=@" + uniquesource);
            
            return builder.ToString();
        }

        public string DeleteInsert(string table, DataTable datatable, StringBuilder builder, string uniquesource, string uniquedestination)
        {
            
            builder.AppendLine("DELETE FROM " + table);
            builder.AppendLine("WHERE " + uniquedestination + "=@" + uniquesource);
            builder.AppendLine("INSERT INTO " + table);
            builder.AppendLine("(");
            foreach (DataRow dr in datatable.Rows)
            {
                if (dr[1].ToString() == table)
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
                if (dr[1].ToString() == table)
                {
                    String build = dr[0].ToString();
                    if (build.Contains("("))
                    {
                        build = build.Replace("(", "(@");
                        build = build.Replace(",", ",@");

                    }
                    else
                    {
                        build = "@" + build;
                    }
                    builder.AppendLine(build + ",");

                }
            }
            builder.Replace(',', ' ', builder.Length - 3, 1);
            builder.AppendLine(")");
            
            

            return builder.ToString();
        }
       
    }
}
