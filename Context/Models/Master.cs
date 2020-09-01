using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Context.Models
{

    public class Master
    {
        #region Data definition
        public int Id { get; set; }
        public int? MainRelease { get; set; }
        public List<MasterImage> Images {get; set;}
        public List<MasterArtist> Artists {get; set;}
        public string Genres {get; set;}
        [NotMapped]
        public List<string> GenresList {
            get {
                if (string.IsNullOrEmpty(this.Genres)) {
                    return new List<string>();
                }
                return this.Genres.Split("|").ToList();
            }
            set {
                this.Genres = string.Join('|', value);
            }
        }
        public string Styles {get; set;}
        [NotMapped]
        public List<string> StylesList {
            get {
                if (string.IsNullOrEmpty(this.Styles)) {
                    return new List<string>();
                }
                return this.Styles.Split("|").ToList();
            }
            set {
                this.Styles = string.Join('|', value);
            }
        }
        public int? Year {get; set;}
        public string Title { get; set; }
        public string DataQuality { get; set; }
        public string Notes { get; set; }
        public List<MasterVideo> Videos {get; set;}
        #endregion
        #region Parse XML

        public static Master ParseXML(XmlElement xMaster)
        {
            throw new NotImplementedException();
/*
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
*/
        }

        #endregion

    }
}
