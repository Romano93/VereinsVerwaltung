using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VV.ConfigWindow;
using VV.Tools;

namespace VV.ViewModels
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        private MainWindow myView;
        private ConfigWindow.ConfigWindow myConfigWindow;
        private bool canExecute = true;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public ICommand CmdOpenConfigWindow
        {
            get
            {
                return cmdOpenConfigWindow ?? (cmdOpenConfigWindow = new CustomCommand(() => OpenConfigWindow(), canExecute));
            }
        }
        private ICommand cmdOpenConfigWindow;


        public LoginWindowViewModel(MainWindow loginScreen)
        {
            myView = loginScreen;
        }

        public LoginWindowViewModel()
        {
            // should not happen anyway
        }

        private void OpenConfigWindow()
        {
            myConfigWindow = new ConfigWindow.ConfigWindow(this);
        }

        internal Config GetSelectedConfig()
        {
            return (Config) myView.lsbClubs.SelectedItem;
        }
    }
}
