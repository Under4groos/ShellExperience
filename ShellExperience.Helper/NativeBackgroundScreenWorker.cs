using ShellExperience.Helper.Delegates;
using ShellExperience.Helper.Stuctures;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShellExperience.Helper
{
    public class NativeBackgroundScreenWorker : IDisposable 
    {
        [Range(10,10000)]
        public int TimeSleep
        {
            get; set;
        } = 1000;

        public ObservableCollection<MONITORINFOEX> listMonitors = new ObservableCollection<MONITORINFOEX>();

        public event MonitirsChangedEvent? PropertyChanged;
        public event MonitirsChangedEvent? Loaded;

        private Task backgroundScreenTask;
        public List<RECT> Monitors = new List<RECT>();
        public NativeBackgroundScreenWorker()
        {
            this.backgroundScreenTask = new Task(_MainThread);
            this.backgroundScreenTask.Start();
        }
        void _MainThread()
        {
            NativeMethods.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, 
                (IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData) => 
                {
                    Loaded?.Invoke(this, listMonitors);
                    return false; 
                }, 
                IntPtr.Zero);
          
            while (true)
            {
                NativeMethods.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, OnEnumDisplayMonitors, IntPtr.Zero);

                PropertyChanged?.Invoke(this, listMonitors);
                Thread.Sleep(TimeSleep);
            }
        }

        private bool OnEnumDisplayMonitors(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData)
        {
            MONITORINFOEX mi = new MONITORINFOEX();
            mi.Size = Marshal.SizeOf(typeof(MONITORINFOEX));
            if (NativeMethods.GetMonitorInfo(hMonitor, ref mi))
            {
                listMonitors.Add(mi);
                
            }
            return false;
        }

        public void Dispose()
        {
            this.backgroundScreenTask.Dispose();


        }
    }
}
