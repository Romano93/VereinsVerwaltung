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
    public partial class ConfigWindow : Window
    {
        private LoginWindowController loginWindowController;
        private ConfigWindowController controller;
        private Config cfg;

        public ConfigWindow(LoginWindowController LoginWindow, Config selectedCfg)
        {
            InitializeComponent();
            loginWindowController = LoginWindow;
            controller = new ConfigWindowController();
            btnSave.IsEnabled = false;

            if (selectedCfg != null) // set values of the selected config
            {
                txbClubName.Text = selectedCfg.Name;
                txbDatabaseUrl.Text = selectedCfg.DatabaseUrl;
                txbPort.Text = selectedCfg.Port;
                txbDBUser.Text = selectedCfg.User;
                txbPassword.Password = selectedCfg.Password;
            }
            this.Show();
        }

        public ConfigWindow() // default ctor --> not used, just in case
        {
            InitializeComponent();
            controller = new ConfigWindowController();
        }

        private void btnCheckConnection_Click(object sender, RoutedEventArgs e)
        {
            UpdateConfig();
            if (controller.CheckConnection(cfg))
            {
                btnSave.IsEnabled = true;
            }
        }

        private void btnAbort_Click(object sender, RoutedEventArgs e)
        {
            loginWindowController.TerminateConfigWindow();
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            UpdateConfig();
            cfg.Save();
            btnAbort_Click(null, null);
        }

        private void UpdateConfig()
        {
            cfg = new Config();
            cfg.DatabaseUrl = txbDatabaseUrl.Text;
            cfg.Name = txbClubName.Text;
            cfg.Port = txbPort.Text;
            cfg.User = txbDBUser.Text;
            cfg.Password = txbPassword.Password;
        }
    }
}
