using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.ConfigWindow
{
    [Serializable]
    class Config
    {
        public String User                          { get { return user; } set { user = value; } }
        public String Password                      { get { return password; } set { EncryptPassword(value); } } // from user input
        public String SetAllreadyEncryptedPassword  { set { password = value; } } // Is needed to read the configs
        public String Name                          { get { return name; } set { name = value; } }
        public String DatabaseUrl                   { get { return databaseUrl; } set { databaseUrl = value; } }
        public String Port                          { get { return port; } set { port = value; } }

        private String user;
        private String password;
        private String name;
        private String databaseUrl;
        private String port;

        /// <summary>
        /// THis function hashes the userinput with the following method: 
        /// </summary>
        /// <param name="password">user input (password)</param>
        private void EncryptPassword(String password)
        {
            String hashedPassword = "";
            // TODO: Hash it / Salt it
            password = hashedPassword;
        }
    }
}
