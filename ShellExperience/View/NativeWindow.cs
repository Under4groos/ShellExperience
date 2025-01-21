using ShellExperience.Helper;
using ShellExperience.Helper.Stuctures;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace ShellExperience.View
{
    public class NativeWindow : Window
    {
        public IntPtr HwndWindow
        {
            get
            {
                
                return new System.Windows.Interop.WindowInteropHelper(this).Handle;
            }
        }
            
        NativeBackgroundScreenWorker screenWorker = new NativeBackgroundScreenWorker()
        {
            TimeSleep = 100
        };




        protected override void OnInitialized(EventArgs e)
        {
            



            this.SizeChanged += NativeWindow_SizeChanged;
            this.MouseLeave += NativeWindow_MouseLeave;
            this.MouseEnter += NativeWindow_MouseLeave;

            this.Loaded += NativeWindow_Loaded;
            base.OnInitialized(e);
        }
        private IntPtr WndProc(nint hwnd, int msg, nint wParam, nint lParam, ref bool handled)
        {
            if (msg != 0x0312)
                return IntPtr.Zero;
            this.Visibility = this.Visibility != Visibility.Visible ? Visibility.Visible : Visibility.Collapsed;
            _setCenter();


            return IntPtr.Zero;
        }
        private void NativeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            NativeMethods.RegisterHotKey(HwndWindow, (int)ModKeys.HOTKEY_ID, ModKeys.MOD_ALT, (uint)KeyInterop.VirtualKeyFromKey(Key.H));
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            if (source != null)
            {
                source.AddHook(WndProc);
            }

            if (App.Options.SizeWindow is System.Windows.Size sizeWindow)
            {
                this.Width = sizeWindow.Width;
                this.Height = sizeWindow.Height;
            }
            _setCenter();
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

        protected override void OnClosed(EventArgs e)
        {
            NativeMethods.UnregisterHotKey(HwndWindow, (int)ModKeys.HOTKEY_ID);
            base.OnClosed(e);
        }

        private void NativeWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            App.Options.SizeWindow = e.NewSize;






        }




    }
}
