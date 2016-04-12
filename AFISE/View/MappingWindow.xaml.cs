using EFAxeCreditFull_;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AFISE.ViewModel;
using MahApps.Metro.Controls;
using System.Data;
using System.IO;
using Common.Model;

namespace AFISE.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    internal sealed partial class MappingWindow : MetroWindow, INotifyPropertyChanged
    {

        public NonNavigationProperty PK;
        public NonNavigationProperty PK2;
        private int selectedIndex_;
        DataRowView _SelectedSource;
        StringBuilder srtb = new StringBuilder();
        public DataRowView SelectedSource
        {
            get { return _SelectedSource; }
            set
            {
                _SelectedSource = value;

            }
        }
        int _SourceSelectedIndex = 0;
        string mapping = "";
        public int SourceselectedIndex { get { return _SourceSelectedIndex; } set { _SourceSelectedIndex = value; } }
        string SelectedSourceText;
        string SelectedTable;
        string SelectedColumn;
        public int selectedIndex { get { return selectedIndex_; } set { selectedIndex_ = value; } }
        private int nextselectedIndex_;
        public int nextselectedIndex { get { return nextselectedIndex_; } set { nextselectedIndex_ = value; } }
        public event PropertyChangedEventHandler PropertyChanged;
        public List<CompositeCollection> allproperties;
        public CompositeCollection currentproperties = new CompositeCollection();
        public List<string> EntiyList { get; set; }
        public MappingWindow(List<String> List_function)
        {
            allproperties = new List<CompositeCollection>();

            InitializeComponent();
            Popup2.IsOpen = false;
            MappingViewModel evm = new MappingViewModel();

            EntiyList = evm.EntiyList;
            L2.DataContext = evm.EntiyList;
            allproperties = evm.allproperties;
            //L3.DataContext = allproperties;
            L.DataContext = Global.TblData4.Concat(List_function).ToList();



        }



        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void L2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedIndex = L2.SelectedIndex;
            SelectedTable = L2.SelectedItem.ToString().Substring(16);
            L3.DataContext = allproperties[selectedIndex];
            //Set Default to Item One
            L3.SelectedIndex = 0;
            //
            currentproperties = allproperties[selectedIndex];
            OnPropertyChanged("currentproperties");
            PK = FindPrimaryKey(currentproperties);

        }

        private void L3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (L3.SelectedIndex >= 0)
            {

                nextselectedIndex = L3.SelectedIndex;
                var selectedItem = L3.Items[nextselectedIndex];
                List<string> Lii = new List<string>();
                if (selectedItem.GetType() == typeof(NavigationProperty))
                {
                    SelectedColumn = (L3.SelectedItem as NavigationProperty).NavigationName.ToString();
                    NavigationProperty inter = new NavigationProperty();
                    inter = selectedItem as NavigationProperty;


                    int EntityIndex;
                    EntityIndex = EntiyList.IndexOf("EFAxeCreditFull." + inter.NavigationName);
                    if (EntityIndex >= 0)
                    {
                        CompositeCollection h = allproperties[EntityIndex];
                        L4.DataContext = h;
                        PK2 = FindPrimaryKey(h);
                    }
                    else L4.DataContext = null;


                }
                else
                {
                    PK2 = new NonNavigationProperty("");
                    SelectedColumn = (L3.SelectedItem as NonNavigationProperty).NonNavigationName.ToString();
                    L4.DataContext = null;
                }
            }
            else
                L4.DataContext = null;
        }

        private NonNavigationProperty FindPrimaryKey(CompositeCollection CC)
        {
            NonNavigationProperty bbb = new NonNavigationProperty("");
            foreach (var bb in CC)
            {
                if (bb.GetType() == typeof(NonNavigationProperty))
                {
                    bbb = bb as NonNavigationProperty;
                    if (bbb.isPrimaryKey == true)
                    { return bbb; }
                }
            }
            return bbb;
        }
        private void L_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SourceselectedIndex = L.SelectedIndex;
            OnPropertyChanged("SourceselectedIndex");

        }

        private void Match_btn(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedSourceText = L.SelectedItem.ToString();

                L.SelectedIndex = 0;
                //  L.DataContext = Global.TblData4;
                if (L3.SelectedItem.GetType() == typeof(NonNavigationProperty))
                {
                    mapping = mapping + "  <Column SourceColumn=\"" + SelectedSourceText + "\"  DestinationTable=\"" + SelectedTable + "\"  DestinationColumn=\"" + SelectedColumn + "\"" + " PK=\"" + PK.NonNavigationName + "\"" + "/> \n";

                }
                else if (L3.SelectedItem.GetType() == typeof(NavigationProperty) && L4.SelectedItem != null)
                {
                    NavigationProperty auxL3 = new NavigationProperty();
                    auxL3 = L3.SelectedItem as NavigationProperty;
                    NonNavigationProperty auxL4 = new NonNavigationProperty("");
                    auxL4 = L4.SelectedItem as NonNavigationProperty;
                    mapping = mapping + "  <Column SourceColumn=\"" + SelectedSourceText + "\"  DestinationTable=\"" + SelectedTable + "\"  FKColumn=\"" + auxL3.KeyName + "\"  ReferencedTable=\"" + SelectedColumn + "\"" + " DestinationColumn=\"" + auxL4.NonNavigationName + "\"" + " PK=\"" + PK.NonNavigationName + "\"" + " PK2=\"" + PK2.NonNavigationName + "\"" + "/> \n";

                }
                Global.TblData4.Remove(SelectedSourceText);
            }

            catch
            {
                Popup2.IsOpen = true;
            }


        }

        private void MappingGenerationbtn(object sender, RoutedEventArgs e)
        {
            //try
            //{
            srtb.AppendLine("<Columns>");
            srtb.AppendLine(mapping);
            srtb.AppendLine("</Columns>");
            var now = DateTime.Now;
            var timestamp = "Mapping" + now.Hour + now.Minute + now.Second;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.AppendAllText(string.Format("{0}\\{1}.xml", path, timestamp), srtb.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(string.Format("{0}\\{1}.xml", path, timestamp));
            DataTable dt = ds.Tables[0];
            Global.SpDataTable = dt;
            StoredProcedureGeneration w6 = new StoredProcedureGeneration();
            w6.Show();
            this.Close();

            //catch
            //{
            //    Popup2.IsOpen = true;
            //}

        }



        private void ResetMappingBtn(object sender, RoutedEventArgs e)
        {
            SourceSelection sr = new SourceSelection();
            sr.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Popup2.IsOpen = false;

        }







    }
}
