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
        public ViewMain()
        {
            InitializeComponent();
            this.DataContext = App.dataContextListApplications;
        }

        private void fileDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (var file in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    App.dataContextListApplications.Append(this.Dispatcher, file);
                }
                App.Save();
            }

        }
    }
}
