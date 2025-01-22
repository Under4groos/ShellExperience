using Newtonsoft.Json;
using ShellExperience.Helper;
using ShellExperience.Helper.Extensions;
using ShellExperience.Model;
using ShellExperience.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShellExperience.View
{
    /// <summary>
    /// Логика взаимодействия для ViewMain.xaml
    /// </summary>
    public partial class ViewMain : UserControl
    {
        string jsonPath = "VMListApplications.json";
        VMListApplications dataContextListApplications = new VMListApplications();
        public ViewMain()
        {
            InitializeComponent();
            this.Loaded += ViewMain_Loaded;
            App.viewMain = this;
            this.DataContext = dataContextListApplications;
        }

        private void ViewMain_Loaded(object sender, RoutedEventArgs eq)
        {
            try
            {
                var jsonObject = JsonConvert.DeserializeObject<VMListApplications>(File.ReadAllText(jsonPath));
                if (jsonObject != null)
                {
                    dataContextListApplications.Applications.AddRange(jsonObject.Applications);
                }
                   
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
        }

        private void fileDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (var file in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    dataContextListApplications.Append(this.Dispatcher, file);
                }
                this.Save();
            }

        }
        public void Save()
        {
            dataContextListApplications.ToFile(jsonPath);
        }
    }
}
