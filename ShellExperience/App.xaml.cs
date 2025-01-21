using Newtonsoft.Json;
using ShellExperience.Model;
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
        public static VMListApplications dataContextListApplications = new VMListApplications();
        public static string jsonDataPath = "AppnOption.json";

        public static AppSetting Options = new AppSetting();
        

        public static void Loaded()
        {
            try
            {
                if (!File.Exists(jsonDataPath))
                    App.Save();
                var json_obj = JsonConvert.DeserializeObject<AppSetting>(File.ReadAllText(jsonDataPath));
                dataContextListApplications.Applications = json_obj.ListApplications;
                Options.SizeWindow = json_obj.SizeWindow;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
        }
        public static void Save()
        {
            try
            {

                Options.ListApplications = dataContextListApplications.Applications;



                string json = JsonConvert.SerializeObject(Options);
                File.WriteAllText(jsonDataPath, json);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                 
            }
            
        }
        
        protected override void OnExit(ExitEventArgs e)
        {
            App.Save();
             
            Debug.WriteLine("OnExit");
            base.OnExit(e);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            App.Loaded();
            Debug.WriteLine("OnStartup");
            base.OnStartup(e);
        }
    }

}
