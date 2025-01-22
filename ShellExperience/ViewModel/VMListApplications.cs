using ShellExperience.Helper;
using ShellExperience.Helper.Collections;
using ShellExperience.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShellExperience.ViewModel
{
    public class VMListApplications : BaseViewModel
    {
        public ObservableRangeCollection<ExecutableApplication> Applications { get; set; }

        public void Append(System.Windows.Threading.Dispatcher dispatcher, string path)
        {
            string pathIcon = string.Empty;
            string nameExe = string.Empty;

            if (NativeShell.ExtructIcon(path, ref pathIcon, ref nameExe))
            {

                dispatcher.Invoke(() =>
                {

                    Applications.Add(new Model.ExecutableApplication()
                    {
                        Name = nameExe,
                        PathIcon = pathIcon,
                        Path = path,
                    });
                });
            };
        }


        public void RemoveAt(int id)
        {
            if (Applications.Count >= id)
            {
                string pathIcon = Applications[id].PathIcon;
                Applications.RemoveAt(id);
                GC.Collect();
               

            }
        }


        public VMListApplications()
        {
            Applications = new ObservableRangeCollection<ExecutableApplication>();
        }
    }
}
