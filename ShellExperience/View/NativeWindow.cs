using Newtonsoft.Json;
using ShellExperience.Helper;
using ShellExperience.Helper.Extensions;
using ShellExperience.Helper.Stuctures;
using ShellExperience.ViewModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace ShellExperience.View
{
    public class NativeWindow : Window
    {
        string jsonPath = "NativeWindow.json";
        public IntPtr HwndWindow
        {
            get
            {

                return new System.Windows.Interop.WindowInteropHelper(this).Handle;
            }
        }
        private NativeBackgroundScreenWorker screenWorker = new NativeBackgroundScreenWorker()
        {
            TimeSleep = 100
        };
        public System.Windows.Size SizeWindow = new System.Windows.Size(0, 0);



        protected override void OnInitialized(EventArgs e)
        {
            
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
            if (this.Visibility == Visibility.Collapsed)
            {
                App.viewMain.Save();
                this.Save();
            }

            _setCenter();


            return IntPtr.Zero;
        }
        private void NativeWindow_Loaded(object sender, RoutedEventArgs eq)
        {
            this.Top = this.Left = -1000;
            try
            {
                if (!File.Exists(jsonPath))
                {
                    
                    this.Save();
                }
                var jsonObject = JsonConvert.DeserializeObject<System.Windows.Size>(File.ReadAllText(jsonPath));
                if (jsonObject != null)
                {
                    SizeWindow = jsonObject;


                    this.Width = SizeWindow.Width;
                    this.Height = SizeWindow.Height;
                }

            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
            

            
            this.Visibility = Visibility.Collapsed;


            NativeMethods.RegisterHotKey(HwndWindow, (int)ModKeys.HOTKEY_ID, ModKeys.MOD_ALT, (uint)KeyInterop.VirtualKeyFromKey(Key.X));
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            if (source != null)
            {
                source.AddHook(WndProc);
            }
           
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

         
        public void Save()
        {
            SizeWindow = new System.Windows.Size(this.Width, this.Height);
            SizeWindow.ToFile(jsonPath);
        }



    }
}
