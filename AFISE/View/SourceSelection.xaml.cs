using System.Windows;
using AFISE.ViewModel;
using System.IO;
using System.Data;
using AFISE.View;
using MahApps.Metro.Controls;
using System;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Windows.Controls.Primitives;
using Common.Model;


namespace AFISE.ViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal sealed partial class SourceSelection : MetroWindow
    {

        public SourceSelection()
        {

            InitializeComponent();
            var viewModel = new ViewModelSourceSelection();
            Popup2.IsOpen = false;
            combo.SelectedIndex = 2;
            cbxdelimiter.SelectedIndex = 0;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateStaging cs = new CreateStaging();
                cs.Show();
                this.Close();
            }
            catch
            {
                Popup2.IsOpen = true;
            }
        }

        private void combo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (combo.SelectedIndex == 0)
            {
                label1.Visibility = Visibility.Visible;
                txt.Visibility = Visibility.Visible;
                Tex.Visibility = Visibility.Visible;
                DtGrid.Visibility = Visibility.Visible;
                Load.Visibility = Visibility.Visible;
                DtGrid1.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Hidden;
                txtFilePath.Visibility = Visibility.Hidden;
                ExcelButon.Visibility = Visibility.Hidden;
                GetFile.Visibility = Visibility.Hidden;
                DelimitedDataGrid.Visibility = Visibility.Hidden;
                delimiterlbl.Visibility = Visibility.Hidden;
                cbxdelimiter.Visibility = Visibility.Hidden;
                resetbtn.Visibility = Visibility.Visible;
                mapfilebtn.Visibility = Visibility.Hidden;
                MappGrid.Visibility = Visibility.Hidden;
                MappNext.Visibility = Visibility.Hidden;
                btnNext.Visibility = Visibility.Visible;
                stgareabtn.Visibility = Visibility.Hidden;
                CHECKCOL.Visibility = Visibility.Hidden;
                checkcoll.Visibility = Visibility.Hidden;


                Global.combo = 0;

            }
            else
                if (combo.SelectedIndex == 1)
                {
                    label1.Visibility = Visibility.Hidden;
                    txt.Visibility = Visibility.Hidden;
                    Tex.Visibility = Visibility.Hidden;
                    DtGrid.Visibility = Visibility.Hidden;
                    Load.Visibility = Visibility.Hidden;
                    DtGrid1.Visibility = Visibility.Visible;
                    label1.Visibility = Visibility.Hidden;
                    txtFilePath.Visibility = Visibility.Hidden;
                    ExcelButon.Visibility = Visibility.Visible;
                    GetFile.Visibility = Visibility.Hidden;
                    DelimitedDataGrid.Visibility = Visibility.Hidden;
                    delimiterlbl.Visibility = Visibility.Hidden;
                    cbxdelimiter.Visibility = Visibility.Hidden;
                    mapfilebtn.Visibility = Visibility.Hidden;
                    resetbtn.Visibility = Visibility.Hidden;
                    MappGrid.Visibility = Visibility.Hidden;
                    MappNext.Visibility = Visibility.Hidden;
                    btnNext.Visibility = Visibility.Visible;
                    stgareabtn.Visibility = Visibility.Hidden;
                    CHECKCOL.Visibility = Visibility.Hidden;
                    checkcoll.Visibility = Visibility.Hidden;



                    Global.combo = 1;
                }
                else if (combo.SelectedIndex == 2)
                {

                    label1.Visibility = Visibility.Hidden;
                    txt.Visibility = Visibility.Hidden;
                    Tex.Visibility = Visibility.Hidden;
                    DtGrid.Visibility = Visibility.Hidden;
                    Load.Visibility = Visibility.Hidden;
                    DtGrid1.Visibility = Visibility.Hidden;
                    label1.Visibility = Visibility.Hidden;
                    txtFilePath.Visibility = Visibility.Hidden;
                    ExcelButon.Visibility = Visibility.Hidden;
                    GetFile.Visibility = Visibility.Visible;
                    DelimitedDataGrid.Visibility = Visibility.Visible;
                    delimiterlbl.Visibility = Visibility.Visible;
                    cbxdelimiter.Visibility = Visibility.Visible;
                    mapfilebtn.Visibility = Visibility.Hidden;
                    resetbtn.Visibility = Visibility.Hidden;
                    MappGrid.Visibility = Visibility.Hidden;
                    MappNext.Visibility = Visibility.Hidden;
                    btnNext.Visibility = Visibility.Visible;
                    stgareabtn.Visibility = Visibility.Hidden;
                    CHECKCOL.Visibility = Visibility.Visible;
                    checkcoll.Visibility = Visibility.Visible;


                    Global.combo = 2;
                }
                else if (combo.SelectedIndex == 3)
                {

                    label1.Visibility = Visibility.Hidden;
                    txt.Visibility = Visibility.Hidden;
                    Tex.Visibility = Visibility.Hidden;
                    DtGrid.Visibility = Visibility.Hidden;
                    Load.Visibility = Visibility.Hidden;
                    DtGrid1.Visibility = Visibility.Hidden;
                    label1.Visibility = Visibility.Hidden;
                    txtFilePath.Visibility = Visibility.Hidden;
                    ExcelButon.Visibility = Visibility.Hidden;
                    GetFile.Visibility = Visibility.Hidden;
                    DelimitedDataGrid.Visibility = Visibility.Hidden;
                    delimiterlbl.Visibility = Visibility.Hidden;
                    cbxdelimiter.Visibility = Visibility.Hidden;
                    resetbtn.Visibility = Visibility.Hidden;
                    mapfilebtn.Visibility = Visibility.Visible;
                    btnNext.Visibility = Visibility.Hidden;
                    MappGrid.Visibility = Visibility.Visible;
                    MappNext.Visibility = Visibility.Visible;
                    stgareabtn.Visibility = Visibility.Visible;
                    checkcoll.Visibility = Visibility.Hidden;
                    Global.combo = 3;

                }


        }

        private void ExcelButon_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".xlsx";
            openfile.Filter = "(.xlsx)|*.xlsx";
            //openfile.ShowDialog();
            var browsefile = openfile.ShowDialog();

            if (browsefile == true)
            {
                txtFilePath.Text = openfile.FileName;

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(txtFilePath.Text.ToString(), 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1); ;
                Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

                string strCellData = "";
                double douCellData;
                int rowCnt = 0;
                int colCnt = 0;

                DataTable dt = new DataTable();
                for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                {
                    string strColumn = "";
                    strColumn = (string)(excelRange.Cells[1, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                    dt.Columns.Add(strColumn, typeof(string));
                }

                for (rowCnt = 2; rowCnt <= excelRange.Rows.Count; rowCnt++)
                {
                    string strData = "";
                    for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                    {
                        try
                        {
                            strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += strCellData + "|";
                        }
                        catch (Exception ex)
                        {
                            douCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += douCellData.ToString() + "|";
                        }
                    }
                    strData = strData.Remove(strData.Length - 1, 1);
                    dt.Rows.Add(strData.Split('|'));
                }

                DtGrid1.ItemsSource = dt.DefaultView;
                Global.datatable1 = dt;
                DataTable dit = new DataTable();
                dit.Columns.Add("test");
                foreach (DataColumn dc in dt.Columns)
                {
                    DataRow datarow = dit.NewRow();
                    datarow["test"] = dc.ColumnName;
                    Global.TblData4.Add(datarow.ToString());
                }



                excelBook.Close(true, null, null);
                excelApp.Quit();
            }
        }

        private void cbxdelimiter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbxdelimiter.SelectedIndex == 0)
            {
                Global.Delimiter = '|';
            }
            if (cbxdelimiter.SelectedIndex == 1)
            {
                Global.Delimiter = '#';
            }
            if (cbxdelimiter.SelectedIndex == 2)
            {
                Global.Delimiter = ',';
            }

        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            SourceSelection mn = new SourceSelection();
            mn.Show();
            this.Close();
        }



        private void CHECKCOL_Checked_1(object sender, RoutedEventArgs e)
        {
            Global.ischeked = true;
        }

        private void CHECKCOL_Unchecked(object sender, RoutedEventArgs e)
        {
            Global.ischeked = false;
        }

        private void Button_Click_popup(object sender, RoutedEventArgs e)
        {
            Popup2.IsOpen = false;
        }





    }

}

