﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VV.Tools;
using VV.ViewModels;

namespace VV.ConfigWindow
{
    class ConfigWindowViewModel : INotifyPropertyChanged
    {
        //-----------------------------------------------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;

        private bool canExecute = true;
        private ConfigWindow myView;
        private LoginWindowViewModel loginViewModel;
        private String configLocation = $"{Directory.GetCurrentDirectory()}\\Configs";
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
        public Config activeCfg;
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
            String fileWithLocation = $"{configLocation}\\{cfg.Name}";
            if (!File.Exists(fileWithLocation))
            {
                SerializeConfig(activeCfg);
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you wanna do something?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            }            
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
