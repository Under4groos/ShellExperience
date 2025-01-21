using ShellExperience.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShellExperience.Helper
{
    // https://stackoverflow.com/questions/462270/get-file-icon-used-by-shell
    public sealed class NativeShell : NativeMethods
    {

        public static string DirectoryCache
        = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "cache");
#pragma warning disable CA1416 // Проверка совместимости платформы
        public static bool ExtructIcon(string fileOrDirectory, ref string pathIcon , ref string name)
        {


            try
            {
                string nameIcon = string.Empty;
                if (File.Exists(fileOrDirectory))
                {
                    FileInfo fileInfo = new FileInfo(fileOrDirectory);
                    name = fileInfo.Name;
                    nameIcon = name.Replace(fileInfo.Extension, ".png");
                }
                else if (Directory.Exists(fileOrDirectory))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(fileOrDirectory);
                    name = directoryInfo.Name;
                    nameIcon = $"{directoryInfo.Name}.png";  
                }
                else
                {
                    return false;
                }



                

                if (!Directory.Exists(DirectoryCache))
                {
                    Directory.CreateDirectory(DirectoryCache);
                }
                pathIcon = Path.Combine(DirectoryCache, $"img_{nameIcon}");
                if (File.Exists(pathIcon))
                {
                    return true;
                }
                Icon win_icon = OfPath(fileOrDirectory, false);

                if (win_icon == null || win_icon.Handle == 0)
                    return false;
                using (Bitmap win_bitmap = win_icon.ToBitmap())
                {
                    win_bitmap.Save(pathIcon);
                }
                DestroyIcon(win_icon.Handle);
                if (File.Exists(pathIcon))
                    return true;
                return false;
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                return false;
            }
        }
#pragma warning restore CA1416 // Проверка совместимости платформы
        public static Icon OfPath(string filepath, bool small = true, bool checkdisk = true, bool overlay = false)
        {
            Icon clone;
            SHGFI_Flag flags;
            SHFILEINFO shinfo = new SHFILEINFO();
            if (small)
            {
                flags = SHGFI_Flag.SHGFI_ICON | SHGFI_Flag.SHGFI_SMALLICON;
            }
            else
            {
                flags = SHGFI_Flag.SHGFI_ICON | SHGFI_Flag.SHGFI_LARGEICON;
            }
            if (checkdisk == false)
            {
                flags |= SHGFI_Flag.SHGFI_USEFILEATTRIBUTES;
            }
            if (overlay)
            {
                flags |= SHGFI_Flag.SHGFI_LINKOVERLAY;
            }
            if (SHGetFileInfo(filepath, 0, ref shinfo, Marshal.SizeOf(shinfo), flags) == 0)
            {
                throw (new FileNotFoundException());
            }
            Icon tmp = Icon.FromHandle(shinfo.hIcon);
            clone = (Icon)tmp.Clone();
            tmp.Dispose();
            if (DestroyIcon(shinfo.hIcon) != 0)
            {
                return clone;
            }
            return clone;
        }

    }
}
