using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ShellExperience.Helper
{
    public static class Explorer
    {





        public static void Start(string path, string args = "", bool isadmin = false)
        {

            
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = path,
                    Arguments = args,

                     
                    Verb = (isadmin && Path.GetExtension(path).ToLower() == ".exe") ? "runas" : string.Empty,
                    // && IsRunAsAdmin()
                });
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }

        }
        public static bool IsRunAsAdmin()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
