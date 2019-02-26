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
        #region properties

        private MainWindow myView;
        private ConfigWindow.ConfigWindow myConfigWindow;
        private bool canExecute = true;
        public event PropertyChangedEventHandler PropertyChanged;
        //-----------------------------------------------------------------------------------------------------------
        private List<Config> configList;
        public List<Config> ConfigList
        {
            get
            {
                return configList;
            }
            set
            {
                configList = value;
            }
        }
        //-----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// new club
        /// </summary>
        private ICommand cmdOpenConfigWindow;
        public ICommand CmdOpenConfigWindow
        {
            get
            {
                return cmdOpenConfigWindow ?? (cmdOpenConfigWindow = new CustomCommand(() => OpenConfigWindow(), canExecute));
            }
        }
        //-----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// open up an existing club
        /// </summary>
        private ICommand cmdOpenConfigWindowWithCfg;
        public ICommand CmdOpenConfigWindowWithCfg
        {
            get
            {
                return cmdOpenConfigWindowWithCfg ?? (cmdOpenConfigWindowWithCfg = new CustomCommand(() => OpenConfigWindow(myView.lsbClubs.SelectedIndex), canExecute));
            }
        }
        #endregion
        //-----------------------------------------------------------------------------------------------------------
        public LoginWindowViewModel(MainWindow loginScreen)
        {
            myView = loginScreen;
        }
        //-----------------------------------------------------------------------------------------------------------
        public LoginWindowViewModel()
        {
            // should not happen anyway
        }
        //-----------------------------------------------------------------------------------------------------------
        private void OpenConfigWindow()
        {
            myConfigWindow = new ConfigWindow.ConfigWindow(this, null);
        }
        //-----------------------------------------------------------------------------------------------------------
        private void OpenConfigWindow(int i)
        {
            if (i <= 0)
            {
                //normal clear cfg window
                OpenConfigWindow();
            }
            else
            {
                myConfigWindow = new ConfigWindow.ConfigWindow(this, configList[i]);
            }            
        }
        //-----------------------------------------------------------------------------------------------------------
        internal Config GetSelectedConfig()
        {
            return (Config) myView.lsbClubs.SelectedItem;
        }
    }
}
