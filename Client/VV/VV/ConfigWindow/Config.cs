using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.ConfigWindow
{
    class Config
    {
        public String User { get { return user; } set { user = value; } }
        public String Password { get { return password; } set { EncryptPassword(value); } } // from user input
        public String SetAllreadyEncryptedPassword { set { password = value; } } // Is needed to read the configs


        private String user;
        private String password;

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
