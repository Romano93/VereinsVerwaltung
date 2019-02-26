using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VV.Tools;
using VV.ViewModels;

namespace VV.ConfigWindow
{
    class ConfigWindowViewModel : INotifyPropertyChanged
    {
        //-----------------------------------------------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;

        public Config activeCfg;
        private bool canExecute = true;
        private ConfigWindow myView;
        private LoginWindowViewModel loginViewModel;
        //-----------------------------------------------------------------------------------------------------------
        private ICommand closeClick;
        public ICommand CloseClick
        {
            get
            {
                return closeClick ?? (closeClick = new CustomCommand(() => CloseWindow(), canExecute));
            }
        }
        //-----------------------------------------------------------------------------------------------------------
        private ICommand testConnection;
        public ICommand TestConnection
        {
            get
            {
                return testConnection ?? (testConnection = new CustomCommand(() => GetServerResponce(), canExecute));
            }
        }
        //-----------------------------------------------------------------------------------------------------------
        private ICommand saveClick;
        public ICommand SaveClick
        {
            get
            {
                return saveClick ?? (saveClick = new CustomCommand(() => SaveConfig(), canExecute));
            }            
        }
        //-----------------------------------------------------------------------------------------------------------
        public ConfigWindowViewModel(ConfigWindow view, LoginWindowViewModel login, Config selectedConfig)
        {
            myView = view;
            activeCfg = selectedConfig;
            myView.btnSave.IsEnabled = false;
            loginViewModel = login;
        }
        //-----------------------------------------------------------------------------------------------------------
        public ConfigWindowViewModel(ConfigWindow view, LoginWindowViewModel login)
        {
            myView = view;
            activeCfg = new Config();
            loginViewModel = login;
        }
        //-----------------------------------------------------------------------------------------------------------
        private void GetServerResponce()
        {
            bool availible = true;
            // TODO 
            // trigger any Server responce to check if the server is here
            // may check if the db exist --> nah build it in the LoginScreen
            myView.btnSave.IsEnabled = false;
        }
        //-----------------------------------------------------------------------------------------------------------
        private void CloseWindow()
        {
            myView.Close();
        }
        //-----------------------------------------------------------------------------------------------------------
        private void SaveConfig()
        {
            // TODO
        }
    }
}
