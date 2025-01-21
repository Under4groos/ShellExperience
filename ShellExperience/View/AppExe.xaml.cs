using ShellExperience.Model;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AppExe.xaml
    /// </summary>
    public partial class AppExe : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text),
            typeof(object),
            typeof(AppExe), 
            new PropertyMetadata("<NULL>")
            );

        public object Text
        {
            get { return (object)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }




        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
            nameof(UriImage),
            typeof(Uri),
            typeof(AppExe),
            new PropertyMetadata(null)
            );



        public Uri UriImage
        {
            get { return (Uri)GetValue(ImageProperty); }
            set 
            {
                if (!File.Exists(value.AbsolutePath))
                {
                    return;
                }
                SetValue(ImageProperty, value); 
            }
        }




        public AppExe()
        {
            InitializeComponent();
             
        }
    }
}
