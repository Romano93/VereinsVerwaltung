using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using VV.Interfaces;
using VV.Tools;

namespace VV.ConfigWindow 
{
    [Serializable]
    public class Config
    {
        public string User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
        public string Password                      { get { return password; } set { password = value; } } // from user input
        public string SetAllreadyEncryptedPassword  { set { password = value; } } // Is needed to read the configs
        public string Name                          { get { return name; } set { name = value; } }
        public string DatabaseUrl                   { get { return databaseUrl; } set { databaseUrl = value; } }
        public string Port                          { get { return port; } set { port = value; } }

        private String user = "root";
        private String password = "test";
        private String name;
        private String databaseUrl;
        private String port;

        internal void Save()
        {
            String configDirectory = $"{Directory.GetCurrentDirectory()}\\Config";
            if(!Directory.Exists(configDirectory))
            {
                Directory.CreateDirectory(configDirectory);
            }
            FileStream fs = new FileStream($"{configDirectory}\\{Name}.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, this);
            }
            catch (SerializationException e)
            {
                LoggingTool lt = new LoggingTool();
                lt.Write($"Failed To Serialize: {e.Message}");
            }
        }
    }
}
