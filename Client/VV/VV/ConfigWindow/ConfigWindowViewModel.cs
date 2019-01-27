using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VV.Tools;

namespace VV.ConfigWindow
{
    class ConfigWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Config activeCfg;
        private bool canExecute = true;
        private ConfigWindow myView;

        private ICommand closeClick;
        public ICommand CloseClick
        {
            get
            {
                return closeClick ?? (closeClick = new CustomCommand(() => CloseWindow(), canExecute));
            }
        }

        private ICommand testConnection;
        public ICommand TestConnection
        {
            get
            {
                return testConnection ?? (testConnection = new CustomCommand(() => GetServerResponce(), canExecute));
            }
        }


        public ConfigWindowViewModel(ConfigWindow view, Config selectedConfig)
        {
            myView = view;
            activeCfg = selectedConfig;
        }

        public ConfigWindowViewModel(ConfigWindow view)
        {
            myView = view;
            activeCfg = new Config();
        }

        private void GetServerResponce()
        {
            // TODO: trigger any Server responce to check if the server is here
            // may check if the db exist --> nah build it in the LoginScreen
        }

        private void CloseWindow()
        {
            myView.Close();
        }
    }
}
