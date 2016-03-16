using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPCoreGenerator
{
    public class CreateSpGenerator : BaseSPGenerator
    {

        protected override string GetSpName(string tableName)
        {
            return prefixCreateSp + tableName;
        }

        public override void GenerateStatement(string tableName, StringBuilder sb, List<DBTableColumnInfo> selectedFields, List<DBTableColumnInfo> whereConditionFields)
        {
            StringBuilder sbFields = new StringBuilder();
            //StringBuilder sbValues = new StringBuilder();
            foreach (DBTableColumnInfo colInf in selectedFields)
            {
                string primaryconstraint;
                if (colInf.Exclude)
                    continue;
                //sbValues.Append(prefixInputParameter + colInf.ColumnName + ",");

                if (colInf.IsIdentity == true)
                    primaryconstraint = " NOT NULL IDENTITY(1, 1) PRIMARY KEY";
                else primaryconstraint = "";
                if (colInf.DefaultValue == null)
                {
                    if (colInf.DataType == SqlTtypes.nvarchar)
                        sbFields.Append(WrapIfKeyWord(colInf.ColumnName) + " " + colInf.DataType + "(" + colInf.CharacterMaximumLength + ")" + primaryconstraint + "," + Environment.NewLine);

                    else
                        sbFields.Append(WrapIfKeyWord(colInf.ColumnName) + " " + colInf.DataType + primaryconstraint + "," + Environment.NewLine);
                }
                else
                {
                    if (colInf.DataType == SqlTtypes.nvarchar)
                        sbFields.Append(WrapIfKeyWord(colInf.ColumnName) + " " + colInf.DataType + "(" + colInf.CharacterMaximumLength + ")" + " DEFAULT(" + colInf.DefaultValue + ")" + "," + Environment.NewLine);

                    else
                        sbFields.Append(WrapIfKeyWord(colInf.ColumnName) + " " + colInf.DataType + " DEFAULT(" + colInf.DefaultValue + ")" + "," + Environment.NewLine);
                }


            }
            sb.Append(Environment.NewLine + "\tCreate TABLE " + WrapIfKeyWord(tableName) + " (" + Environment.NewLine + sbFields.ToString().TrimEnd(',') + ")");
            //sb.Append(Environment.NewLine + "\tvalues(" + sbValues.ToString().TrimEnd(',') + ")");
        }
        protected override void GenerateInputParameters(List<DBTableColumnInfo> tableFields, StringBuilder sb)
        { }
    }
}
