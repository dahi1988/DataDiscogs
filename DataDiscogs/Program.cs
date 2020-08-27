using DiscogsContext.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using static System.Net.Mime.MediaTypeNames;

namespace DataDiscogs
{
     public class Program
    {
        
        private static string dataPath = "";
        public static string DataPath
        {
            get
            {
                if (string.IsNullOrEmpty(dataPath))
                {
                    

                    string tmpS = "DataPath";
                    if (string.IsNullOrEmpty(tmpS))
                    {
                        tmpS = @".\";
                    }
                    dataPath = Path.GetFullPath(tmpS);
                    if (!Directory.Exists(dataPath))
                    {
                        Directory.CreateDirectory(dataPath);
                    }
                }

                return dataPath;
            }
        }


        public static string IniFilename
        {
            get
            {
                return System.IO.Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().Location, ".ini");
            }
        }

        static void Main(string[] args)
        {
            ImportData import = new ImportData();

            import.Run();
            Console.WriteLine($"Using (xml) data stored in '{DataPath}'.");
            Console.WriteLine();

        }
        }
          
}
    





