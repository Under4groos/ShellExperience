﻿using ShellExperience.Helper;
using ShellExperience.Model;
using ShellExperience.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AppExe.xaml
    /// </summary>
    public partial class AppExe : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text),
            typeof(object),
            typeof(AppExe), 
            new PropertyMetadata(default)
            );

        public object Text
        {
            get { return (object)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        // ============
        public static readonly DependencyProperty PathProperty = DependencyProperty.Register(
            nameof(Path),
            typeof(string),
            typeof(AppExe),
            new PropertyMetadata(default)
            );

        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }



        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
            nameof(UriImage),
            typeof(Uri),
            typeof(AppExe),
            new PropertyMetadata(default)
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


        protected override void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
        {
            

            base.OnPreviewMouseRightButtonUp(e);
        }
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            Debug.WriteLine($"{Text} {UriImage}");


            Explorer.Start(this.Path);
            base.OnPreviewMouseLeftButtonDown(e);
        }

        public AppExe()
        {
            InitializeComponent();
             
        }
        

        private void ItemRemove(object sender, RoutedEventArgs e)
        {
            if(App.viewMain.DataContext is VMListApplications DataContext)
            {
                for (int i = 0; i < DataContext.Applications.Count; i++)
                {
                    if (DataContext.Applications[i].Path == Path)
                    {
                        DataContext.RemoveAt(i);
                    }
                }
                Debug.WriteLine($"[ItemRemove] {Text} {Path}");
                App.viewMain.Save();
            }
           
        }

        private void ItemShowInExplorer(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"[ItemShowInExplorer] {Text} {Path}");

            Explorer.Start("explorer.exe" , $"/select, \"{this.Path}\"");
        }

        private void ItemRunAsAdmin(object sender, RoutedEventArgs e)
        {
            Explorer.Start(this.Path , isadmin:true);
        }
    }
}
