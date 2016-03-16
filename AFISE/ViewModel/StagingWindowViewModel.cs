
using Common.Model;
//using SPGenerator.UI.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AFISE.ViewModel;
using AFISE.Helpers;
using AFISE.View;
using AFISE.Model;

//using TreeViewWithCheckBoxes;


namespace AFISE.ViewModel
{
    internal class StagingWindowViewModel : ViewModelBase
    {
        MainWinModel model;
        //string conString = @"Server=.\sqlexpress;Database=TestDb;User ID=mahesh;Password=mypassword;";
        string defaultDisplayText = "Enter Connection String Here";
        string sqlScript;
        public string SqlScript
        {
            get
            {
                return sqlScript;
            }
            set
            {
                sqlScript = value;
                RaisePropertyChanged("SqlScript");
            }
        }
        
        
        private void GenerateSps()
        {
            StringBuilder sb = new StringBuilder(1000);
            model.RefreshSettings();
         //   model.GenerateSp("tableNode", "childNode", ref sb, viewStagingTable.ToList(), viewStagingTable.ToList());
            SqlScript = sb.ToString();
        }

        


        private RelayCommand generateSPCommand;
        public ICommand GenerateSPCommand
        {
            get
            {
                if (generateSPCommand == null) generateSPCommand = new RelayCommand(param => this.GenerateSps());
                return generateSPCommand;
            }
        }

    }
}
