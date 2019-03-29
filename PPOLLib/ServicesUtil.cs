using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPOL
{
    class ServicesUtil
    {

        string PPOLUrl = "";
        string ppolAccount = "";
        string userName = "";
        string password = "";
        Properties.Settings settings;

        public ServicesUtil()
        {
            settings = new Properties.Settings();
            settings.Reload();
            PPOLUrl = settings.PPOLURL;
            ppolAccount = settings.Account;
            userName = settings.UserName;
            password = settings.Password;

        }


        public string getPpolURL()
        {
            return PPOLUrl;

        }

        public string getPpolAccount()
        {
            return ppolAccount;
        }

        public string getUserName()
        {
            return userName;
        }

        public string getPassword()
        {
            return password;
        }
  

    
    }


}
