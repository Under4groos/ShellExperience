using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace ShellExperience
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            Debug.WriteLine("OnExit");
            base.OnExit(e);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            Debug.WriteLine("OnStartup");
            base.OnStartup(e);
        }
    }

}
