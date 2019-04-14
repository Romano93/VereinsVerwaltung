using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using VV.Interfaces;
using VV.Tools;

namespace VV.ConfigWindow
{
    public class ConfigManager : IObservable
    {
        List<IObserver> observers;
        List<Config> configs;

        public ConfigManager()
        {
            configs = new List<Config>();
            RefreshConfigList();
        }

        public void RefreshConfigList()
        {
            configs = new List<Config>();
            String configDirectory = $"{Directory.GetCurrentDirectory()}\\Config";
            if (Directory.Exists(configDirectory))
            {
                string[] files = Directory.GetFiles(configDirectory);
                foreach (string filename in files)
                {
                    FileStream fs = new FileStream(filename, FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    try
                    {
                        configs.Add((Config)bf.Deserialize(fs));
                    }
                    catch (SerializationException e)
                    {
                        LoggingTool lt = new LoggingTool();
                        lt.Write($"Failed To Deserialize: {e.Message}");
                    }
                }
                NotifyAll();
            }                       
        }

        public void NotifyAll()
        {
            foreach(IObserver observer in observers)
            {
                observer.Update();
            }
        }
    }
}
