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





        public static void Start(string path, string args = "", bool workingDirectory = false, bool isadmin = false)
        {


            try
            {
                var procInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = path,
                    Arguments = args,
                    WorkingDirectory = workingDirectory ? Path.GetDirectoryName(path) : default,


                    Verb = (isadmin && Path.GetExtension(path).ToLower() == ".exe") ? "runas" : string.Empty,
                    // && IsRunAsAdmin()
                };

                Process.Start(procInfo);
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
