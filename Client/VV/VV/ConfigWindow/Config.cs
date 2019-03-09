using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VV.ConfigWindow 
{
    [Serializable]
    public class Config : INotifyPropertyChanged
    {
        public string User
        {
            get
            {
                return "user";
            }
            set
            {
                user = value;
                NotifyPropertyChanged("User");
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
