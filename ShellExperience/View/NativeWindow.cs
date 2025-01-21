using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShellExperience.View
{
    public class NativeWindow : Window
    {


        protected override void OnInitialized(EventArgs e)
        {
            if (App.Options.SizeWindow is Size sizeWindow)
            {
                this.Width = sizeWindow.Width;
                this.Height = sizeWindow.Height;
            }


            base.OnInitialized(e);
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            App.Options.SizeWindow = sizeInfo.NewSize;
            base.OnRenderSizeChanged(sizeInfo);
        }

        public virtual void OnChangePosition(EventArgs e) 
        { 
            
        
        }
    }
}
