using MahApps.Metro.Controls;
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
using MahApps.Metro.Controls.Dialogs;
using AFISE.ViewModel;
using Common.Model;
namespace AFISE.View
{
    /// <summary>
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class StoredProcedureGeneration : MetroWindow
    {
        public StoredProcedureGeneration()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            showscript.Visibility = Visibility.Visible;
            await this.ShowMessageAsync("MESSAGE", "Your Script has been generated");
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            spgeneration.Visibility = Visibility.Hidden;
            await this.ShowMessageAsync("", Global.sptest);
        }


        
    }
}
