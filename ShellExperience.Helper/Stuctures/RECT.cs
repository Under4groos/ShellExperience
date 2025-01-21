
using System.Runtime.InteropServices;


namespace ShellExperience.Helper.Stuctures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public Size GetSize()
        {
            return new Size(this.Right - this.Left, this.Bottom - this.Top);
        }
        public Size GetSize(double w, double h)
        {
            return new Size((this.Right - this.Left) * w, (this.Bottom - this.Top) * h);
        }
        public override string ToString()
        {
            return $"x:{this.Left} y: {Top} / {this.GetSize()}";
        }
    }
}
