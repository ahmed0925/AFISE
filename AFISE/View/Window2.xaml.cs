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
using MahApps.Metro.Controls;
using AFISE.ViewModel;
using System.Data;

namespace AFISE.View
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : MetroWindow
    {
        public Window2()
        {
            InitializeComponent();
            var viewModel1 = new ViewModelWindow2();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.Show();
            this.Close();
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BIMLGeneration w4 = new BIMLGeneration();
            w4.Show();
        }
    }
}
