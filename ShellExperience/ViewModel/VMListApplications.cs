using ShellExperience.Helper;
using ShellExperience.Helper.Collections;
using ShellExperience.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShellExperience.ViewModel
{
    public class VMListApplications : BaseViewModel
    {
        public ObservableRangeCollection<ExecutableApplication> Applications { get; set; }



        
        public VMListApplications()
        {
            Applications = new ObservableRangeCollection<ExecutableApplication>();
        }
    }
}
