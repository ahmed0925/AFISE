using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using AFISE.ViewModel;
using System.Data;
using System.IO;
using MahApps.Metro.Controls;
using Common.Model;

namespace AFISE.View
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    internal sealed partial class BIMLGeneration : MetroWindow
    {
        public BIMLGeneration()
        {
            InitializeComponent();
            if (Global.combo == 0)
            {
                buildBIMLFromSimpleTextFile();
            }
        }




        private void buildBIMLFromSimpleTextFile()
        {


            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<Biml xmlns=\"http://schemas.varigence.com/biml.xsd\">");
            builder.AppendLine("<FileFormats>");
            builder.AppendLine("<FlatFileFormat Name=\"FlatFileFormatCurrency\" RowDelimiter=\"CRLF\" FlatFileType=\"RaggedRight\"  ColumnNamesInFirstDataRow=\"false\" IsUnicode=\"false\">");
            builder.AppendLine("<Columns>");
            foreach (DataColumn dtc in Global.datatable1.Columns)
            {
                int x = dtc.Ordinal;
                if (dtc.Ordinal != Global.datatable1.Columns.Count - 1)
                {
                    builder.AppendLine("<Column Name=\"" + dtc.ColumnName + "\" ColumnType=\"FixedWidth\" DataType=\"AnsiString\" Length=\"" + Global.columnLength[x] + "\" TextQualified=\"false\" Delimiter=\"\" CodePage=\"1252\"/>");
                }
                else
                {
                    builder.AppendLine("<Column Name=\"" + dtc.ColumnName + "\"  DataType=\"AnsiString\" Length=\"" + Global.columnLength[x] + "\" TextQualified=\"false\" Delimiter=\"CRLF\" />");
                }

            }

            builder.AppendLine("</Columns>");
            builder.AppendLine("</FlatFileFormat>");
            builder.AppendLine("</FileFormats>");
            builder.AppendLine("<Connections >");
            builder.AppendLine("<Connection Name =\"OLEDB_Counterparty\" ConnectionString=\"Data Source=.;User ID=axecreditportal;Password=axefinance;Provider=SQLNCLI11.1;Auto Translate=False;Database=Axe_Credit;\">");
            builder.AppendLine("<Expressions>");
            builder.AppendLine("<Expression PropertyName=\"ConnectionString\">      \"Data Source=\"+ @[User::DataSource] + \";User ID=\"+ @[User::UserName] + \";Provider=SQLNCLI11.1;Auto Translate=False;Password=\" + @[User::Password] +\";Database=\"+ @[User::Database]  </Expression>");
            builder.AppendLine("</Expressions>");
            builder.AppendLine("</Connection>");
            builder.AppendLine("<FlatFileConnection Name=\"FF_Counterparty\"           FilePath=\"D:\\Templates\\Template_Counterparty.txt\"           FileFormat=\"FlatFileFormatCurrency\">");
            builder.AppendLine("<Expressions>");
            builder.AppendLine("<Expression PropertyName=\"ConnectionString\">		@[User::sFullFilePath]	  </Expression>");
            builder.AppendLine("</Expressions>");
            builder.AppendLine("</FlatFileConnection>");
            builder.AppendLine("</Connections>");
            builder.AppendLine("<Packages>");
            builder.AppendLine("<Package Name=\"IN_Package_Counterparty\" ConstraintMode=\"Linear\">");
            builder.AppendLine("<Variables>");
            builder.AppendLine("<Variable Name=\"sFullFilePath\"  DataType=\"String\">D:\\Templates\\Template_Counterparty.txt</Variable>");
            builder.AppendLine("<Variable Name=\"DataSource\"     DataType=\"String\">.</Variable>");
            builder.AppendLine("<Variable Name=\"UserName\"		  DataType=\"String\">axecreditportal</Variable>");
            builder.AppendLine("<Variable Name=\"Password\"		  DataType=\"String\">axefinance</Variable>");
            builder.AppendLine("<Variable Name=\"Database\"	      DataType=\"String\">Axe_Credit</Variable>");
            builder.AppendLine("</Variables>");
            builder.AppendLine("<Tasks>");
            builder.AppendLine("<Dataflow Name=\"(DFT) Import Counterparty File\">");
            builder.AppendLine("<Transformations>");
            builder.AppendLine("<FlatFileSource Name=\"(FF_SRC) Read Counterparty File\"  ConnectionName=\"FF_Counterparty\"  RetainNulls=\"true\"/>");
            builder.AppendLine("<OleDbDestination Name=\"(OLEDB_DST) Write Data to DB\"   ConnectionName=\"OLEDB_Counterparty\"  UseFastLoadIfAvailable=\"true\">");
            builder.AppendLine("<ExternalTableOutput Table=\"inter.load_Counterparty\"/>");
            builder.AppendLine("<Columns>");
            builder.AppendLine("<Column SourceColumn=\"CodeClient\" TargetColumn=\"TypeEnregistrement\"/>");
            builder.AppendLine("<Column SourceColumn=\"Nom\" TargetColumn=\"CodeImplantation\"/>");
            builder.AppendLine("<Column SourceColumn=\"CodeClient\" TargetColumn=\"TypeEnregistrement\"/>");
            builder.AppendLine("</Columns>");
            builder.AppendLine("</OleDbDestination>");
            builder.AppendLine("</Transformations>");
            builder.AppendLine("</Dataflow>");
            builder.AppendLine("<ExecuteSQL Name=\"(SQL) Execute Stored Procedure\" ConnectionName=\"OLEDB_Counterparty\">");
            builder.AppendLine("<DirectInput>");
            builder.AppendLine("insert into " + Global.SelectedTable[0].ToString() + "(");
            foreach (string line in Global.sourcecolumns)
            {
                if (Global.sourcecolumns.IndexOf(line) != Global.sourcecolumns.Count - 1)
                {
                    builder.AppendLine(line + ",");
                }
                else
                {
                    builder.AppendLine(line);
                }
            }
            builder.AppendLine(")");
            builder.AppendLine("select");
            builder.AppendLine("col1,");
            builder.AppendLine("col2,");
            builder.AppendLine("col3");
            builder.AppendLine("from");
            builder.AppendLine("");
            builder.AppendLine("</DirectInput>");
            builder.AppendLine("</ExecuteSQL>");
            builder.AppendLine("</Tasks>");
            builder.AppendLine("</Package>");
            builder.AppendLine("</Packages>");
            builder.AppendLine("</Biml>"); ;

            var now = DateTime.Now;
            var timestamp = "" + now.Hour + now.Minute + now.Second;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.AppendAllText(string.Format("{0}\\{1}.xml", path, timestamp), builder.ToString());
            txtCode.Load(string.Format("{0}\\{1}.xml", path, timestamp));
            txtCode.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(System.IO.Path.GetExtension(string.Format("{0}\\{1}.xml", path, timestamp)));
            txtCode.ShowLineNumbers = true;
            txtCode.Background = System.Windows.Media.Brushes.White;
        }
        private void buildBIMLFromExcel()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<Biml xmlns=\"http://schemas.varigence.com/biml.xsd\">");
            builder.AppendLine("<Connections >");
            builder.AppendLine("<Connection Name =\"OLEDB_Counterparty\" ConnectionString=\"Data Source=.;User ID=axecreditportal;Password=axefinance;Provider=SQLNCLI11.1;Auto Translate=False;Database=Axe_Credit;\">");
            builder.AppendLine("<Expressions>");
            builder.AppendLine("<Expression PropertyName=\"ConnectionString\">      \"Data Source=\"+ @[User::DataSource] + \";User ID=\"+ @[User::UserName] + \";Provider=SQLNCLI11.1;Auto Translate=False;Password=\" + @[User::Password] +\";Database=\"+ @[User::Database]  </Expression>");
            builder.AppendLine("</Expressions>");
            builder.AppendLine("</Connection>");
            builder.AppendLine("<FlatFileConnection Name=\"FF_Counterparty\"           FilePath=\"D:\\Templates\\Template_Counterparty.txt\"           FileFormat=\"FlatFileFormatCurrency\">");
            builder.AppendLine("<Expressions>");
            builder.AppendLine("<Expression PropertyName=\"ConnectionString\">		@[User::sFullFilePath]	  </Expression>");
            builder.AppendLine("</Expressions>");
            builder.AppendLine("</FlatFileConnection>");
            builder.AppendLine("</Connections>");
            builder.AppendLine("<Packages>");
            builder.AppendLine("<Package Name=\"IN_Package_Counterparty\" ConstraintMode=\"Linear\">");
            builder.AppendLine("<Variables>");
            builder.AppendLine("<Variable Name=\"sFullFilePath\"  DataType=\"String\">D:\\Templates\\Template_Counterparty.txt</Variable>");
            builder.AppendLine("<Variable Name=\"DataSource\"     DataType=\"String\">.</Variable>");
            builder.AppendLine("<Variable Name=\"UserName\"		  DataType=\"String\">axecreditportal</Variable>");
            builder.AppendLine("<Variable Name=\"Password\"		  DataType=\"String\">axefinance</Variable>");
            builder.AppendLine("<Variable Name=\"Database\"	      DataType=\"String\">Axe_Credit</Variable>");
            builder.AppendLine("</Variables>");
            builder.AppendLine("<Tasks>");
            builder.AppendLine("<Dataflow Name=\"(DFT) Import Counterparty File\">");
            builder.AppendLine("<Transformations>");
            builder.AppendLine("<FlatFileSource Name=\"(FF_SRC) Read Counterparty File\"  ConnectionName=\"FF_Counterparty\"  RetainNulls=\"true\"/>");
            builder.AppendLine("<OleDbDestination Name=\"(OLEDB_DST) Write Data to DB\"   ConnectionName=\"OLEDB_Counterparty\"  UseFastLoadIfAvailable=\"true\">");
            builder.AppendLine("<ExternalTableOutput Table=\"inter.load_Counterparty\"/>");
            builder.AppendLine("<Columns>");
            builder.AppendLine("<Column SourceColumn=\"CodeClient\" TargetColumn=\"TypeEnregistrement\"/>");
            builder.AppendLine("<Column SourceColumn=\"Nom\" TargetColumn=\"CodeImplantation\"/>");
            builder.AppendLine("<Column SourceColumn=\"CodeClient\" TargetColumn=\"TypeEnregistrement\"/>");
            builder.AppendLine("</Columns>");
            builder.AppendLine("</OleDbDestination>");
            builder.AppendLine("</Transformations>");
            builder.AppendLine("</Dataflow>");
            builder.AppendLine("<ExecuteSQL Name=\"(SQL) Execute Stored Procedure\" ConnectionName=\"OLEDB_Counterparty\">");
            builder.AppendLine("<DirectInput> EXEC inter.spLoadTest  GO   </DirectInput>");
            builder.AppendLine("</ExecuteSQL>");
            builder.AppendLine("</Tasks>");
            builder.AppendLine("</Package>");
            builder.AppendLine("</Packages>");
            builder.AppendLine("</Biml>"); ;

            var now = DateTime.Now;
            var timestamp = "" + now.Hour + now.Minute + now.Second;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.AppendAllText(string.Format("{0}\\{1}.xml", path, timestamp), builder.ToString());
            txtCode.Load(string.Format("{0}\\{1}.xml", path, timestamp));
            txtCode.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(System.IO.Path.GetExtension(string.Format("{0}\\{1}.xml", path, timestamp)));
            txtCode.ShowLineNumbers = true;
            txtCode.Background = System.Windows.Media.Brushes.White;
        }
    }
}

