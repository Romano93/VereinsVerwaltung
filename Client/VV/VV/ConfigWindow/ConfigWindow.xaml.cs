using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
using VV.Interfaces;
using VV.Tools;

namespace VV.ConfigWindow
{
    /// <summary>
    /// Interaktionslogik für ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window, IObserver
    {
        private LoginWindowController loginWindowController;
        private ConfigWindowController controller;

        public ConfigWindow(LoginWindowController LoginWindow, Config selectedCfg)
        {
            InitializeComponent();
            loginWindowController = LoginWindow;
            Config activeConfig = selectedCfg;
            controller = new ConfigWindowController();
            if(activeConfig == null)
            {
                
            }
            else
            {
                
            }
            this.Show();
        }

        public ConfigWindow() // default ctor --> not used, just in case
        {
            InitializeComponent();
            controller = new ConfigWindowController();
        }

        public void Subscribe()
        {
            controller.Subscribe(this);
        }

        public void UnSubscribe()
        {
            controller.UnSubscribe(this);
        }

        public void Update(List<IObservable> observables)
        {

        }
    }
}
