using System;
using System.IO;

using static System.Net.Mime.MediaTypeNames;

namespace DataDiscogs
{
     public class Program
    {
        
        private static string dataPath = "/home/snyssen/Downloads/";
       

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
            Console.WriteLine();

            Console.WriteLine("Press enter to close program.");
            Console.ReadLine();


            
        }


    }
}













