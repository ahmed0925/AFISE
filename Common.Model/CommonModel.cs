using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;


namespace Common.Model
{
    public enum SqlTtypes { nvarchar, varchar, datetime2, nText, Int, Bit, Bool, Float, date }
    public class DBTableColumnInfo : ObservableObject
    {
        private string _ColumnName;
        private SqlTtypes _DataType;
        private int _CharacterMaximumLength;
        private int _NumericPrecision;
        private int _NumericPrecisionRadix;
        private bool _IsIdentity;
        private bool _IsPrimaryKey;
        private bool _Exclude;
        private string _Schema;
        private string _DefaultValue;
        public string ColumnName { get { return _ColumnName; } set { _ColumnName = value; OnPropertyChanged("ColumnName"); } }
        public SqlTtypes DataType { get { return _DataType; } set { _DataType = value; OnPropertyChanged("DataType"); } }
        public int CharacterMaximumLength { get { return _CharacterMaximumLength; } set { _CharacterMaximumLength = value; OnPropertyChanged("CharacterMaximumLength"); } }
        public int NumericPrecision { get { return _NumericPrecision; } set { _NumericPrecision = value; OnPropertyChanged("NumericPrecision"); } }
        public int NumericPrecisionRadix { get { return _NumericPrecisionRadix; } set { _NumericPrecisionRadix = value; OnPropertyChanged("NumericPrecisionRadix"); } }
        public bool IsIdentity { get { return _IsIdentity; } set { _IsIdentity = value; OnPropertyChanged("IsIdentity"); } }
        public bool IsPrimaryKey { get { return _IsPrimaryKey; } set { _IsPrimaryKey = value; OnPropertyChanged("IsPrimaryKey"); } }
        public bool Exclude { get { return _Exclude; } set { _Exclude = value; OnPropertyChanged("Exclude"); } }
        public string Schema { get { return _Schema; } set { _Schema = value; OnPropertyChanged("Schema"); } }
        public string DefaultValue { get { return _DefaultValue; } set { _DefaultValue = value; OnPropertyChanged("DefaultValue"); } }
        public DBTableColumnInfo()
        {
            _DataType = SqlTtypes.nvarchar;
            _CharacterMaximumLength = 200;
            _NumericPrecision = 0;
            _NumericPrecisionRadix = 0;
            _IsIdentity = false;
            _IsPrimaryKey = false;
            _Exclude = false;
        }
        public DBTableColumnInfo(string c)
        {
            _ColumnName = c;
            _DataType = SqlTtypes.Int;
            _CharacterMaximumLength = 20;
            _NumericPrecision = 0;
            _NumericPrecisionRadix = 0;
            _IsIdentity = true;
            _IsPrimaryKey = true;
            _Exclude = false;
        }
        public DBTableColumnInfo(string c, int p)
        {
            _DataType = SqlTtypes.datetime2;
            _ColumnName = c;
            _CharacterMaximumLength = 20;
            _NumericPrecision = p;
            _NumericPrecisionRadix = 0;
            _IsIdentity = true;
            _IsPrimaryKey = false;
            _Exclude = false;
        }

        public void CreateSpecialColumn(string n, SqlTtypes t)
        {

            this.ColumnName = n;
            this.DataType = t;
            if (t == SqlTtypes.datetime2)
            {
                this.DefaultValue = "GETDATE()";
            }
            else if (t == SqlTtypes.Bit)
            {
                this.DefaultValue = "0";
            }
            else if (t == SqlTtypes.Int)
                this.DefaultValue = "0";

        }
    }


    public class DBTableInfo : ObservableCollection<DBTableColumnInfo>
    {
        public string TableName;
        public ObservableCollection<DBTableColumnInfo> Columns;
        public DBTableInfo()
        {
            Columns = new ObservableCollection<DBTableColumnInfo>();
        }
    }
    public class Settings
    {
        public string prefixWhereParameter = "@w_";
        public string prefixInputParameter = "@p_";
        public string prefixInsertSp = "sp_insert_";
        public string prefixUpdateSp = "sp_update_";
        public string prefixCreateSp = "sp_create_";
        public string errorHandling = "Yes";
    }

    public class Serializer
    {
        public static void Serialize<T>(T obj, string filePath)
        {
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(obj);
            File.WriteAllText(filePath, json);
        }

        public static T Deserialize<T>(T obj, string filePath) where T : class
        {
            //SPGenerator.DataModel.Settings settings = new DataModel.Settings();
            T objDes = null;
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                objDes = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<T>(json);
            }
            return objDes;
        }
    }
}
