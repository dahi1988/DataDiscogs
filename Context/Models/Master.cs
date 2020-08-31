using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Context.Models
{
/*
    public class Master
    {
        #region Data definition
        [Key]
        public int MASTER_ID { get; set; }
        public int MAIN_RELEASE_ID { get; set; }
        public string TITLE { get; set; }
        public DateTime RELEASED = DateTime.MinValue; // only year is valid when it is a master record
        public string NOTES { get; set; }
        public string DATA_QUALITY { get; set; }

        public List<Image> IMAGES = new List<Image>();
        public List<Artist> ARTISTS = new List<Artist>(); // Note: no <extraartists> tag!
        public List<string> GENRES = new List<string>();
        public List<string> STYLES = new List<string>();
        public List<Video> VIDEOS = new List<Video>();

        public class Image
        {
            public int HEIGHT { get; set; }
            public int WIDTH { get; set; }
            public string TYPE { get; set; }
            public string URI { get; set; }
            public string URI150 { get; set; }
        }

        public class Video
        {
            public bool EMBED { get; set; }
            public int DURATION_IN_SEC { get; set; }
            public string SRC { get; set; }
            public string TITLE { get; set; }
            public string DESCRIPTION { get; set; }
        }

        #endregion
        #region Parse XML

        public static Master ParseXML(XmlElement xMaster)
        {
            


            Master master = new Master();

            master.MASTER_ID = Convert.ToInt32(xMaster.Attributes["id"].Value);
            master.TITLE = xMaster["title"].InnerText;
            if (xMaster["year"] != null)
            {
                DateTime.TryParse($"{xMaster["year"].InnerText}-01-01", out master.RELEASED);
            }
            if (xMaster["notes"] != null)
            {
                master.NOTES = xMaster["notes"].InnerText;
            }
            if (xMaster["main_release"] != null)
            {
                master.MAIN_RELEASE_ID = Convert.ToInt32(xMaster["main_release"].InnerText);
            }
            if (xMaster["data_quality"] != null)
            {
                master.DATA_QUALITY = xMaster["data_quality"].InnerText;
            }

            if (xMaster.GetElementsByTagName("images")[0] != null)
            {
                foreach (XmlNode xn in xMaster.GetElementsByTagName("images")[0].ChildNodes)
                {
                    XmlElement xImage = (XmlElement)xn;
                    Image image = new Image();
                    image.HEIGHT = Convert.ToInt32(xImage.Attributes["height"].Value);
                    image.WIDTH = Convert.ToInt32(xImage.Attributes["width"].Value);
                    image.TYPE = xImage.Attributes["type"].Value;
                    image.URI = xImage.Attributes["uri"].Value;
                    image.URI150 = xImage.Attributes["uri150"].Value;
                    master.IMAGES.Add(image);
                } //foreach
            }

            master.ARTISTS= Artist.ParseArtists(xMaster);

            if (xMaster.GetElementsByTagName("genres")[0] != null)
            {
                foreach (XmlNode xn in xMaster.GetElementsByTagName("genres")[0].ChildNodes)
                {
                    XmlElement xGenre = (XmlElement)xn;
                    master.GENRES.Add(xGenre.InnerText);
                } //foreach
            }
            if (xMaster.GetElementsByTagName("styles")[0] != null)
            {
                foreach (XmlNode xn in xMaster.GetElementsByTagName("styles")[0].ChildNodes)
                {
                    XmlElement xStyle = (XmlElement)xn;
                    master.STYLES.Add(xStyle.InnerText);
                } //foreach
            }

            if (xMaster.GetElementsByTagName("videos")[0] != null)
            {
                foreach (XmlNode xn in xMaster.GetElementsByTagName("videos")[0].ChildNodes)
                {
                    XmlElement xVideo = (XmlElement)xn;
                    Video video = new Video();
                    video.EMBED = (xVideo.Attributes["embed"].Value == "true");
                    video.DURATION_IN_SEC = Convert.ToInt32(xVideo.Attributes["duration"].Value);
                    video.SRC = xVideo.Attributes["src"].Value;
                    video.TITLE = xVideo["title"].InnerText;
                    video.DESCRIPTION = xVideo["description"].InnerText;

                    master.VIDEOS.Add(video);
                } //foreach
            }

            return master;
        }

        #endregion

    }
*/
}
