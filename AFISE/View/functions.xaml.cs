using AFISE.ViewModel;
using Common.Model;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

namespace AFISE.View
{
    /// <summary>
    /// Interaction logic for functions.xaml
    /// </summary>
    internal sealed partial class functions : MetroWindow, INotifyPropertyChanged
    {
       
        private List<String> List_Function;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<String> functions_list ;
       public List<String> Sp_list ;
       public List<String> functions_para;
       private int selecteditem;
       
        
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public functions()
        {
            InitializeComponent();
            List_Function = new List<string>();
       
            
            Popup2.IsOpen = false;
            Popup3.IsOpen = false;

            string connection=null;
            if (Global.ConnectionType == 0)
            {
                SqlConnectionStringBuilder sqlcon = new SqlConnectionStringBuilder();
                sqlcon.DataSource = Global.DataSource;
                sqlcon.InitialCatalog = Global.CurrentBase;
                sqlcon.IntegratedSecurity = true;
                 connection = sqlcon.ToString();
                
                
            }
            if (Global.ConnectionType == 1)
            {
                SqlConnectionStringBuilder sqlcon = new SqlConnectionStringBuilder();
                sqlcon.DataSource = Global.DataSource;
                sqlcon.InitialCatalog = Global.CurrentBase;
                sqlcon.UserID = Global.username;
                sqlcon.Password = Global.password;
                 connection = sqlcon.ToString();
                 
                
            }
              SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select o.name, type_desc FROM sys.sql_modules m  JOIN sys.objects o ON m.object_id=o.object_id  join sys.schemas p ON o.schema_id=p.schema_id where type_desc like '%function%'  and p.name like '%inter%' ", conn);
                


                SqlDataReader rdr = cmd.ExecuteReader();
                functions_list = new List<String>();
             
                functions_para = new List<String>();
            
            while(rdr.Read())
                {
                    if (rdr["type_desc"].ToString().Contains("FUN"))
                    {
                        functions_list.Add(rdr["name"].ToString());
                    }
                }


            parameter.DataContext = Global.TblData4;
            function.DataContext = functions_list;
        
           
        }

        private void L_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public int SourceselectedIndex { get { return _SourceSelectedIndex; } set { _SourceSelectedIndex = value; } }
        int _SourceSelectedIndex ;
        private void L2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SourceselectedIndex = function.SelectedIndex;
            OnPropertyChanged("SourceselectedIndex");
            
        }

        private void Add_btn(object sender, RoutedEventArgs e)
        {
            try
            {


                String Func = null;
                Func += function.SelectedItem.ToString() + "(";
                foreach (var para in parameter.SelectedItems)
                    Func += para.ToString() + ",";

                Func = Func.Substring(0, Func.Length - 1);

                Func += ")";
                List_Function.Add(Func);
                Popup3.IsOpen = true;
            }
            catch
            {
                Popup2.IsOpen = true;
            }
          
          
        }

        private void L3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MappingGenerationbtn(object sender, RoutedEventArgs e)
        {
            MappingWindow mp = new MappingWindow(List_Function);
            mp.Show();
            this.Close();


        }

        private void ResetMappingBtn(object sender, RoutedEventArgs e)
        {
            SourceSelection sr = new SourceSelection();
            sr.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Popup2.IsOpen = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Popup3.IsOpen = false;
        }
    }
}
