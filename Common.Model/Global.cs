using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public static class Global
    {
        public static DataTable datatable1 { get; set; }
        public static DataRowView SelectedTable { get; set; }
        public static DataTable TblData4 { get; set; }
        public static char Delimiter { get; set; }
        public static List<int> columnLength { get; set; }
        public static int combo { get; set; }
        public static string filename { get; set; }
        private static List<string> _sourcecolumns = new List<string>();
        public static List<string> sourcecolumns { get { return _sourcecolumns; } set { _sourcecolumns = value; } }

        private static List<string> _destcolumns = new List<string>();

        private static List<string> _datatypedest = new List<string>();
        public static List<string> datatypedest { get { return _datatypedest; } set { _datatypedest = value; } }
        public static string StagingTable { get; set; }
        public static DataTable SpDataTable { get; set; }
        public static bool ischeked { get; set; }
        public static string Connection { get; set; }
        public static string CurrentBase { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }
        public static string DataSource { get; set; }
        public static int ConnectionType { get; set; }
        public static string stagingTable { get; set; }
        public static string sptest { get; set; }
        public static string sourceunique { get; set; }
        public static string destunique { get; set; }
         public static string spName { get; set; }
         public static string TableSP { get; set; }
    }
}
