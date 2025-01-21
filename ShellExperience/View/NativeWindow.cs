using ShellExperience.Helper;
using ShellExperience.Helper.Stuctures;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace ShellExperience.View
{
    public class NativeWindow : Window
    {
        NativeBackgroundScreenWorker screenWorker = new NativeBackgroundScreenWorker()
        {
            TimeSleep = 100
        };




        protected override void OnInitialized(EventArgs e)
        {
            if (App.Options.SizeWindow is System.Windows.Size sizeWindow)
            {
                this.Width = sizeWindow.Width;
                this.Height = sizeWindow.Height;
            }


            this.SizeChanged += NativeWindow_SizeChanged;
            this.MouseLeave += NativeWindow_MouseLeave;
            this.MouseEnter += NativeWindow_MouseLeave;
            _setCenter();
            base.OnInitialized(e);
        }

        private void NativeWindow_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _setCenter();
        }

        void _setCenter()
        {
            var size = screenWorker.listMonitors.First().WorkArea.GetSize();
            this.Left = size.Width / 2 - this.ActualWidth / 2;
            this.Top = size.Height - this.ActualHeight;
        }



        private void NativeWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            App.Options.SizeWindow = e.NewSize;






        }




    }
}
