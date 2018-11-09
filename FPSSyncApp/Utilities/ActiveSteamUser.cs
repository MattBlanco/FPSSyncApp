using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSSyncApp.Utilities
{
    class ActiveSteamUser
    {
        public static string getId()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam\\ActiveProcess"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("ActiveUser");
                        if(o != null)
                        {
                            return o.ToString();
                        }
                        else
                        {
                            throw new Exception("Your exception here!");
                        }
                    }
                }
            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }
            return null;
        }
    }

}


