using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VV.ConfigWindow;

namespace VV
{
    public class LoginWindowController
    {
        private ConfigWindow.ConfigWindow myConfigWindow;
        public LoginWindowController()
        {

        }
        //-----------------------------------------------------------------------------------------------------------
        internal void NewClub()
        {
            myConfigWindow = new ConfigWindow.ConfigWindow(this, null);
        }

        internal void EditClub(Config config)
        {
            myConfigWindow = new ConfigWindow.ConfigWindow(this, config);
        }

        //-----------------------------------------------------------------------------------------------------------
        internal Config GetSelectedConfig()
        {
            throw new NotImplementedException();
        }

        internal void Close()
        {
            myConfigWindow.Close();
        }
    }
}
