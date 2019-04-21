using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.ConfigWindow
{
    class ConfigWindowController
    {
        public ConfigWindowController()
        {
            
        }

        internal bool CheckConnection(Config config)
        {
            string sslM = "none";
            string connectionString = connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", config.DatabaseUrl, config.Port, config.User, config.Password, "club", sslM);
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                con.Close(); // just in case
                return true;
            }
            catch(MySqlException ex) // just for testing purpos, so we do nothing
            {
                return false;
            }
        }
    }
}
