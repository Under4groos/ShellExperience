using ShellExperience.ViewModel;
using System;
using System.Collections.Generic;
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
        VMListApplications dataContextListApplications = new VMListApplications();
        public ViewMain()
        {
            InitializeComponent();
            for (int i = 0; i < 25; i++)
            {
                dataContextListApplications.Applications.Add(new Model.ExecutableApplication()
                {
                    Name = "Name:" + i.ToString(),
                    Path = "Path:" + i.ToString(),
                });
            }
            this.DataContext = dataContextListApplications;


           
        }
    }
}
