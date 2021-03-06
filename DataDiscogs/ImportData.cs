﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DataDiscogs
{
    public class ImportData
    {
        public void Run()
        {

            string discogsLocal = Path.GetFileName(ArtistsXMLFile(Program.DataPath));
            //if (string.IsNullOrEmpty(discogsLocal) || discogsLocal.Length < 16)
            //{
            //    // should never come here!
            //    Console.WriteLine("Discogs xml files not found.");
            //    Console.WriteLine("Exiting...");
            //    Environment.Exit(1);
            //}
            //discogsLocal = discogsLocal.Substring(8, 8);


            if (ConvertArtistsXML2TAB(Program.DataPath))
            {

                Console.WriteLine("Importing ARTISTS Data");

                Console.WriteLine("ARTIST Done.");

            }

            // -------------------------------------------------------------------------------------------------------


            //if (ConvertLabelsXML2TAB(Program.DataPath))
            //{

            //    Console.WriteLine("Importing LABELS Data");
            //    Console.WriteLine("LABELS Done.");


            //}

            //if (ConvertReleasesXML2TAB(Program.DataPath))
            //{

            //    Console.WriteLine("Importing RELEASES Data");

            //    Console.WriteLine("RELEASE Done.");

            //}
            //if (ConvertMastersXML2TAB(Program.DataPath))
            //{

            //    Console.WriteLine("Importing MASTERS Data");

            //    Console.WriteLine("MASTER Done.");

            //}

        }
        // -------------------------------------------------------------------------------------------------------
        #region Discogs ARTIST

        public string ArtistsXMLFile(string xmlPath)
        {
            List<string> lArtists = new List<string>();
            foreach (string filename in System.IO.Directory.GetFiles(xmlPath))
            {
                if (Path.GetExtension(filename).ToUpper() == ".XML")
                {
                    string noExtension = Path.GetFileNameWithoutExtension(filename).ToUpper();
                    //if (!(noExtension.Length > 8 && noExtension.Substring(0, 8) == "Artists_"))
                    //{
                    //    continue;
                    //}
                    //if (!(noExtension.Length >= 24 && noExtension.Substring(noExtension.Length - 8, 8) == "_Artists"))
                    //{
                    //    continue;
                    //}
                    lArtists.Add(filename);
                }
            } //foreach

            lArtists.ForEach(x => Console.WriteLine(x));

            if (lArtists.Count == 0)
            {
                return null;
            }

            lArtists.Sort();
            return lArtists[0];
        }

        public bool ConvertArtistsXML2TAB(string basePath)
        {
            string xmlFilename = ArtistsXMLFile(basePath);
            if (!string.IsNullOrEmpty(xmlFilename))
            {
                var optionsBuilder = new DbContextOptionsBuilder<Context.DiscogsContext>()
                .UseSqlServer("Server=DESKTOP-5A54U6A;Database=DiscogsData;Trusted_Connection=True;MultipleActiveResultSets=true");
                using (var dbCOntext = new Context.DiscogsContext(optionsBuilder.Options))
                {
                    using (XmlReader reader = XmlReader.Create(xmlFilename))
                    {
                        var artists = new List<Artist>();
                        reader.MoveToContent(); // skip to first node with content (should be root node)
                        if (reader.ReadToDescendant("artist"))
                        { // go to first artist (and checks if correct)
                            int counter = 0;
                            do
                            {
                                var xArtist = new XmlDocument();
                                var artistElement = xArtist.CreateElement(reader.Name);
                                artistElement.InnerXml = reader.ReadInnerXml();
                                Console.WriteLine(artistElement.Name + " : " + artistElement.InnerText);
                                var art = Artist.ParseXML(artistElement);
                                artists.Add(art);
                                counter++;
                                if (counter >= 100)
                                {
                                    dbCOntext.AddRange(artists);
                                    try
                                    {
                                        dbCOntext.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Error while adding to DB");
                                        Console.WriteLine(e);
                                    }
                                    counter = 0;
                                    artists = new List<Artist>();
                                }
                            } while (reader.ReadToNextSibling("artist"));
                        }

                        dbCOntext.AddRange(artists);
                        try
                        {
                            dbCOntext.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error while adding to DB");
                            Console.WriteLine(e);
                        }
                .UseSqlServer("Server=.;Database=Discogz;User Id=CasterStatsApp;Password=Test123=;");

                    }
                }

            }
            return false;
        }
        
    }
    return false;
}

        #endregion
        #region Discogs LABEL

        //public string LabelsXMLFile(string xmlPath)
        //{
        //    List<string> lLabels = new List<string>();
        //    foreach (string filename in System.IO.Directory.GetFiles(xmlPath))
        //    {
        //        if (Path.GetExtension(filename).ToUpper() == ".XML")
        //        {
        //            string noExtension = Path.GetFileNameWithoutExtension(filename).ToUpper();
        //            if (!(noExtension.Length > 8 && noExtension.Substring(0, 8) == "DISCOGS_"))
        //            {
        //                continue;
        //            }
        //            if (!(noExtension.Length >= 23 && noExtension.Substring(noExtension.Length - 7, 7) == "_LABELS"))
        //            {
        //                continue;
        //            }
        //            lLabels.Add(filename);
        //        }
        //    } //foreach

        //    if (lLabels.Count == 0)
        //    {
        //        return null;
        //    }

        //    lLabels.Sort();
        //    return lLabels[0];
        //}

        //public bool ConvertLabelsXML2TAB(string basePath)
        //{
        //    string xmlFilename = LabelsXMLFile(basePath);
        //    if (!string.IsNullOrEmpty(xmlFilename))
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<Context.DiscogsContext>()
        //        .UseSqlServer("Server=DESKTOP-5A54U6A;Database=DiscogsData;Trusted_Connection=True;MultipleActiveResultSets=true");
        //        using (var dbCOntext = new Context.DiscogsContext(optionsBuilder.Options))
        //        {
        //            using (XmlReader reader = XmlReader.Create(xmlFilename))
        //            {
        //                var labels = new List<Label>();
        //                reader.MoveToContent(); // skip to first node with content (should be root node)
        //                if (reader.ReadToDescendant("artist"))
        //                { // go to first artist (and checks if correct)
        //                    int counter = 0;
        //                    do
        //                    {
        //                        var xLabel = new XmlDocument();
        //                        var labelElement = xLabel.CreateElement(reader.Name);
        //                        labelElement.InnerXml = reader.ReadInnerXml();
        //                        labels.Add(Label.ParseXML(labelElement));
        //                        counter++;
        //                        if (counter >= 1000)
        //                        {

        //                            counter = 0;
        //                        }
        //                    } while (reader.ReadToNextSibling("label"));
        //                }

        //                dbCOntext.AddRange(labels);
        //                try
        //                {
        //                    dbCOntext.SaveChanges();
        //                }
        //                catch (Exception e)
        //                {
        //                    Console.WriteLine("Error while adding to DB");
        //                    Console.WriteLine(e);
        //                }

        //            }
        //        }

        //    }
        //    return false;
        //}
        //#endregion
        //#region Discogs MASTER

        //private string MastersXMLFile(string xmlPath)
        //{
        //    List<string> lMasters = new List<string>();
        //    foreach (string filename in System.IO.Directory.GetFiles(xmlPath))
        //    {
        //        if (Path.GetExtension(filename).ToUpper() == ".XML")
        //        {
        //            string noExtension = Path.GetFileNameWithoutExtension(filename).ToUpper();
        //            if (!(noExtension.Length > 8 && noExtension.Substring(0, 8) == "DISCOGS_"))
        //            {
        //                continue;
        //            }
        //            if (!(noExtension.Length >= 24 && noExtension.Substring(noExtension.Length - 8, 8) == "_MASTERS"))
        //            {
        //                continue;
        //            }
        //            lMasters.Add(filename);
        //        }
        //    } //foreach

        //    if (lMasters.Count == 0)
        //    {
        //        return null;
        //    }

        //    lMasters.Sort();
        //    return lMasters[0];
        //}

        //public bool ConvertMastersXML2TAB(string basePath)
        //{
        //    string xmlFilename = MastersXMLFile(basePath);
        //    xmlFilename = @"C:\Users\dahi1\Discogs Data\Masters.XML";
        //    if (!string.IsNullOrEmpty(xmlFilename))
        //    {
        //        XmlSnibbitReader reader = new XmlSnibbitReader();
        //        if (reader.OpenFile(xmlFilename))
        //        {

        //            string xmlBlock = "";
        //            try
        //            {
        //                int blockCounter = 0;
        //                while ((xmlBlock = reader.GetXMLSnibbit("master")) != null)
        //                {
        //                    Master master = Master.ParseXML(XmlString2XmlElement(xmlBlock));

        //                    blockCounter++;
        //                    Console.Write($"\rXML Block: {blockCounter}");
        //                } //while
        //                Console.WriteLine();

        //                return true;
        //            }
        //            catch (Exception e)
        //            {

        //                Console.WriteLine(xmlBlock);
        //                Console.WriteLine(e.ToString());
        //            }
        //            finally
        //            {
        //                reader.Close();

        //            }
        //        }
        //    }

        //    return false;
        //}

        #endregion
        #region Discogs RELEASE

        //private string ReleasesXMLFile(string xmlPath)
        //{
        //    List<string> lReleases = new List<string>();
        //    foreach (string filename in System.IO.Directory.GetFiles(xmlPath))
        //    {
        //        if (Path.GetExtension(filename).ToUpper() == ".XML")
        //        {
        //            string noExtension = Path.GetFileNameWithoutExtension(filename).ToUpper();
        //            if (!(noExtension.Length > 8 && noExtension.Substring(0, 8) == "DISCOGS_"))
        //            {
        //                continue;
        //            }
        //            if (!(noExtension.Length >= 25 && noExtension.Substring(noExtension.Length - 9, 9) == "_RELEASES"))
        //            {
        //                continue;
        //            }
        //            lReleases.Add(filename);
        //        }
        //    } //foreach

        //    if (lReleases.Count == 0)
        //    {
        //        return null;
        //    }

        //    lReleases.Sort();
        //    return lReleases[0];
        //}

        //public bool ConvertReleasesXML2TAB(string basePath)
        //{
        //    string xmlFilename = ReleasesXMLFile(basePath);

        //    xmlFilename = @"C:\Users\dahi1\Discogs Data\Releases.XML";
        //    if (!string.IsNullOrEmpty(xmlFilename))
        //    {
        //        XmlSnibbitReader reader = new XmlSnibbitReader();
        //        if (reader.OpenFile(xmlFilename))
        //        {


        //            string xmlBlock = "";
        //            try
        //            {
        //                int blockCounter = 0;
        //                while ((xmlBlock = reader.GetXMLSnibbit("release")) != null)
        //                {
        //                    Release release = Release.ParseXML(XmlString2XmlElement(xmlBlock));

        //                    blockCounter++;
        //                    Console.Write($"\rXML Block: {blockCounter}");
        //                } //while
        //                Console.WriteLine();

        //                return true;
        //            }
        //            catch (Exception e)
        //            {

        //                Console.WriteLine(xmlBlock);
        //                Console.WriteLine(e.ToString());
        //            }
        //            finally
        //            {
        //                reader.Close();

        //            }
        //        }
        //    }

        //    return false;
        //}

        #endregion
        private XmlElement XmlString2XmlElement(string xml)
        {
            // Create the instance of XmlDocument
            XmlDocument doc = new XmlDocument();
            // Loads the XML from the string
            doc.LoadXml(xml);
            // Returns the XMLElement of the loaded XML String
            return doc.DocumentElement;
        }

    }
}