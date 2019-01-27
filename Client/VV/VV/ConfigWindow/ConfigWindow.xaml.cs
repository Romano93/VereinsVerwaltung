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
using VV.Tools;
using VV.ViewModels;

namespace VV.ConfigWindow
{
    /// <summary>
    /// Interaktionslogik für ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {
        private LoginWindowViewModel loginWindowviewModel;        
        private Config currentConfig;

        public ConfigWindow(LoginWindowViewModel LoginWindow)
        {
            InitializeComponent();
            loginWindowviewModel = LoginWindow;
            Config activeConfig = LoginWindow.GetSelectedConfig();            
            if(activeConfig == null)
            {
                this.DataContext = new ConfigWindowViewModel(this);
            }
            else
            {
                this.DataContext = new ConfigWindowViewModel(this, activeConfig);
            }
            this.Show();
        }

        public ConfigWindow() // default ctor --> not used, just in case
        {
            InitializeComponent();
        }

        public void SaveBtnPressed()
        {
            SerializeConfig(currentConfig);
        }

        /// <summary>
        /// Serializes any given config objekt to binary
        /// </summary>
        /// <param name="cfg">given config</param>
        private void SerializeConfig(Config cfg)
        {
            // Logging
            LoggingTool log = new LoggingTool();
            log.Write("Initialize to serialize a config");

            String configLocation = $"{Directory.GetCurrentDirectory()}\\Configs";
            String fileWithLocation = $"{configLocation}\\{cfg.Name}";

            FileStream fs = new FileStream(fileWithLocation, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, cfg);
            }
            catch (SerializationException e)
            {
                log.Write(e.ToString());
                throw;
            }
            finally
            {
                fs.Close();
            }
            log.Write("Config serialized");
        }
    }
}
