
using SPCoreGenerator;
//using SPGenerator.DAL;
using Common.Model;
//using SPGenerator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using AFISE.comman;
namespace AFISE.Model
{

    internal class MainWinModel
    {
        public/* List<DBTableColumnInfo>*/ void GetDBTColumnInfoList()
        {
            var t = App.Current.Windows;
            Debug.WriteLine(t.Count);

        }
        internal void RefreshSettings()
        {
            BaseSPGenerator.SetSettings(AFISE.comman.Settings.GetSettings());
        }
        public void GenerateSp(string tableName, string nodeName, ref StringBuilder sb, List<DBTableColumnInfo> selectedFields, List<DBTableColumnInfo> whereConditionFields)
        {
            BaseSPGenerator spGenerator = SPFactory.GetSpGeneratorObject(nodeName);
            spGenerator.GenerateSp(tableName, sb, selectedFields, whereConditionFields);
        }
        /* private IDataBase GetDataBaseObject(string connectionString)
         {
             return new SqlDataBase(connectionString);
         }*/
    }
}
