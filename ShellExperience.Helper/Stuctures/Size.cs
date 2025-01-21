using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShellExperience.Helper.Stuctures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Size
    {
        
        public double Height;
        public double Width;

        public Size(double w, double h)
        {

            Height = h;
            Width = w;
        }

        public override string ToString()
        {
            return $"{Width}px/{Height}px";
        }
    }
}
