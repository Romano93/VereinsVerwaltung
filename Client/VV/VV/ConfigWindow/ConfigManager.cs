using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VV.Interfaces;

namespace VV.ConfigWindow
{
    public class ConfigManager : IObservable
    {
        List<IObserver> observers;
        List<Config> configs;


        public void NotifyAll()
        {
            foreach(IObserver observer in observers)
            {
                observer.Update(configs);
            }
        }
    }
}
