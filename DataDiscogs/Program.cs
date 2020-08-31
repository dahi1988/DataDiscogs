using DiscogsContext.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Linq;
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
            
             string discogsRemoteLastDate= null ;
            string dbLastDate = null;
            ImportData import = new ImportData();
            if (!string.IsNullOrEmpty(dbLastDate) && dbLastDate.Length == 8)
            {
                
                if ( discogsRemoteLastDate != null && discogsRemoteLastDate.Length == 8)
                {
                    if (dbLastDate == discogsRemoteLastDate )
                    {
                        Console.WriteLine($"The last discogs export ({discogsRemoteLastDate}) is allready in the database. Exiting...");
                        Environment.Exit(0);
                    }
                }
            }

                import.Run();
            Console.WriteLine();

            Console.WriteLine("Press enter to close program.");
            Console.ReadLine();


            // exit with error 1 that something is gonne wrong
            Environment.Exit(1);
        }


    }
}













