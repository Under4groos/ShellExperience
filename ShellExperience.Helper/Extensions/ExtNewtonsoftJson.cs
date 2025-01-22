using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellExperience.Helper.Extensions
{
    public static class ExtNewtonsoftJson
    {
        public static bool ToFile(this object obj,  string path )
        {
            try
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(obj , Formatting.Indented));

                Debug.WriteLine("Save to " + path);
                return true;
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
            return false;
        }
        public static object? FileToObject(this string path)
        {
            try
            {
                return JsonConvert.DeserializeObject(File.ReadAllText(path) , new JsonSerializerSettings() { });
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
            return null;
        }
    }
}
