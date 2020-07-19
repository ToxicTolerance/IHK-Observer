using System;
using System.IO;

namespace IhkObserver.Text.Classes
{
    public class PathGetter
    {
        /// <summary>
        /// Returns the base path (directory: IHK-Observer)
        /// </summary>
        /// <returns></returns>
        public static string GetBasePath()
        {
            DirectoryInfo info = new DirectoryInfo(Environment.CurrentDirectory);
            while (true)
            {
                if (info.Name == "IHK-Observer")
                {
                    break;
                }

                if (info.Parent == null)
                {
                    throw new NotSupportedException("Could not find IHK-Observer Directory!");
                }
                info = info.Parent;
            }
            return info.FullName;
        }
    }
}
