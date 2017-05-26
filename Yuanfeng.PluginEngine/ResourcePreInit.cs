using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Yuanfeng.Smarty;

namespace Yuanfeng.PluginEngine
{
    public class ResourcePreInit
    {
        private ImageSection section = new ImageSection();
        private System.Reflection.BindingFlags bindingFlags = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase;
        private static ResourcePreInit @this;
        private List<int> initedHandles = new List<int>();
        private ResourcePreInit()
        {
            section = new ConfigParser().Images;
        }

        public static ResourcePreInit New()
        {
            if (@this == null) @this = new ResourcePreInit(); return @this;
        }

        public void Init(object handle, string key)
        {
            try
            {
                List<Exception> catchs = new List<Exception>();
                if (handle == null) return;
                int hashCode = handle.GetHashCode();
                if (initedHandles.Contains(hashCode)) return;

                var images = section.Images.Find(key);
                foreach (DynImage item in images)
                {
                    string controlKey = string.Empty;
                    try { controlKey = item.Key.Split('.')[1]; } catch { controlKey = string.Empty; }
                    if (string.IsNullOrEmpty(controlKey)) continue;
                    try
                    {
                        object o = handle.GetType().GetField(controlKey, bindingFlags).GetValue(handle);
                        o.GetType().GetProperty("Image").SetValue(o, GetImage(item.Image), null);
                    }
                    catch (Exception exception)
                    {
                        SimpleConsole.WriteLine(exception); catchs.Add(new Exception(string.Format("set image '{0}' exception", item.Image), exception));
                        // throw new Exception(item.Image, exception);
                    }
                }

                var backgrounds = section.Backgrounds.Find(key);
                foreach (var item in backgrounds)
                {
                    string controlKey = string.Empty;
                    try { controlKey = item.Key.Split('.')[1]; } catch { controlKey = string.Empty; }
                    if (string.IsNullOrEmpty(controlKey)) continue;
                    try
                    {
                        object o = handle.GetType().GetField(controlKey, bindingFlags).GetValue(handle);
                        o.GetType().GetProperty("BackgroundImage").SetValue(o, GetImage(item.Image), null);
                    }
                    catch (Exception exception)
                    {
                        SimpleConsole.WriteLine(exception); catchs.Add(new Exception(string.Format("set background image '{0}' exception", item.Image), exception));
                        //throw new Exception(item.Image, exception);
                    }
                }

                StringBuilder sbError = new StringBuilder();
                foreach (var item in catchs)
                {
                    sbError.AppendLine("msg:" + item.Message + ",trace:" + item.StackTrace);
                }
                if (catchs.Count > 0) throw new Exception(sbError.ToString());
            }
            catch (Exception exception)
            {
                SimpleConsole.Write(exception); throw new Exception("pre init resource exception.", exception);
            }
        }

        public Image GetImage(string filename)
        {
            Image bmp = null;
            try
            {
                if (!File.Exists(filename)) filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
                bmp = filename.Reader().ToBitmap();
                return bmp;
            }
            catch (Exception exception)
            {
                throw new Exception(filename, exception);
            }
        }
    }
}
