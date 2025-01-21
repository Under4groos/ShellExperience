using ShellExperience.Helper.Stuctures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellExperience.Helper.Delegates
{
    public delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);


    public delegate void MonitirsChangedEvent(NativeBackgroundScreenWorker screenWorker , ObservableCollection<MONITORINFOEX> monitors);
}
