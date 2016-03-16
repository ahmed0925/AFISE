using AFISE.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Interactivity;
using MahApps.Metro.Controls;


namespace AFISE.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : MetroWindow
    {

        public Window1()
        {
            InitializeComponent();
            var viewModel = new ViewModelWindow1();
            DataContext = viewModel;
            

        }

     

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MappingWindow w2 = new MappingWindow();
            w2.Show();
            this.Close();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SourceSelection mw = new SourceSelection();
            mw.Show();
            this.Close();
        }

       


    }
}
