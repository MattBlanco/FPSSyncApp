using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSSyncApp.Utilities
{
    class ActiveUserSteamId
    {
        public static string getId()
        {
            try
            {
                object o = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam\\ActiveProcess\\ActiveUser");
                return o.ToString();
            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }
            return null;
        }
    }

}


