using Newtonsoft.Json;
using ShellExperience.Model;
using ShellExperience.View;
using ShellExperience.ViewModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ShellExperience
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static ViewMain viewMain;
        public static MainWindow mainWindow;

        public static void HideMainWindow()
        {
            App.mainWindow.Visibility = Visibility.Collapsed;
        }

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
