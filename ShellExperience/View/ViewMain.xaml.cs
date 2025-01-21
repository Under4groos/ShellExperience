using ShellExperience.Helper;
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
        
        Thread threadLoaded;

        

        public ViewMain()
        {
            InitializeComponent();
            this.DataContext = App.dataContextListApplications;

            //threadLoaded = new Thread(() => 
            //{
            //    string pathIcon = string.Empty;
            //    string nameExe = string.Empty;
               

            //    foreach (var df in Directory.GetFiles(@"C:\Users\UnderKo\Downloads").Concat(Directory.GetDirectories(@"C:\Users\UnderKo\Downloads")))
            //    {

            //        if (NativeShell.ExtructIcon(df, ref pathIcon, ref nameExe))
            //        {

            //            this.Dispatcher.Invoke(() =>
            //            {

            //                App.dataContextListApplications.Applications.Add(new Model.ExecutableApplication()
            //                {
            //                    Name = nameExe,
            //                    PathIcon = pathIcon,
            //                    Path = df,
            //                });
            //            });
            //        };
            //        Thread.Sleep(10);
            //    }
                
            //});
            //threadLoaded.Start();  





        }
    }
}
