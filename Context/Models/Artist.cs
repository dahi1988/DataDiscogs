using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Xml;

namespace Context.Models
{
    public class Artist
    {
        #region Data definition
        public int Id { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Profile { get; set; }
        public string DataQuality { get; set; }
        public string Urls {get; set;}
        [NotMapped]
        public List<string> UrlsList { 
            get {
                if (string.IsNullOrEmpty(this.Urls)) {
                    return new List<string>();
                }
                return this.Urls.Split("|").ToList();
            }
            set {
                this.Urls = string.Join('|', value);
            }
        }
        public string NameVariations {get; set;}
        [NotMapped]
        public List<string> NameVariationsList {
            get {
                if (string.IsNullOrEmpty(this.NameVariations)) {
                    return new List<string>();
                }
                return this.NameVariations.Split("|").ToList();
            }
            set {
                this.NameVariations = string.Join('|', value);
            }
        }

        public List<ArtistImage> ArtistImages {get; set;}
        public List<ArtistAlias> Aliases { get; set; }
        public List<ArtistMember> MEMBERS { get; set; }
        public List<ArtistGroup> GROUPS { get; set; }

        public string Anv {get; set;}
        public string Join {get; set;}
        public string Role {get; set;}
        public string Tracks {get; set;}
        #endregion
        #region Parse XML
        public static Artist ParseXML(XmlElement xArtist)
        {
            throw new NotImplementedException();
/*
            Artist artist = new Artist();

            artist.ARTIST_ID = Convert.ToInt32(xArtist.GetElementsByTagName("id")[0].InnerText);
            artist.NAME = xArtist["name"].InnerText;
            if (xArtist["realname"] != null)
            {
                artist.REALNAME = xArtist["realname"].InnerText;
            }
            if (xArtist["profile"] != null)
            {
                artist.PROFILE = xArtist["profile"].InnerText;
            }
            artist.DATA_QUALITY = xArtist["data_quality"].InnerText;

            if (xArtist.GetElementsByTagName("images")[0] != null)
            {
                foreach (XmlNode xn in xArtist.GetElementsByTagName("images")[0].ChildNodes)
                {
                    XmlElement xImage = (XmlElement)xn;
                    Image image = new Image();
                    image.HEIGHT = Convert.ToInt32(xImage.Attributes["height"].Value);
                    image.WIDTH = Convert.ToInt32(xImage.Attributes["width"].Value);
                    image.TYPE = xImage.Attributes["type"].Value;
                    image.URI = xImage.Attributes["uri"].Value;
                    image.URI150 = xImage.Attributes["uri150"].Value;
                    artist.IMAGES.Add(image);
                } //foreach
            }

            if (xArtist.GetElementsByTagName("urls")[0] != null)
            {
                foreach (XmlNode xn in xArtist.GetElementsByTagName("urls")[0].ChildNodes)
                {
                    XmlElement xUrl = (XmlElement)xn;
                    if (!string.IsNullOrEmpty(xUrl.InnerText))
                    {
                        artist.URLS.Add(xUrl.InnerText.Trim());
                    }
                } //foreach
            }

            if (xArtist.GetElementsByTagName("namevariations")[0] != null)
            {
                foreach (XmlNode xn in xArtist.GetElementsByTagName("namevariations")[0].ChildNodes)
                {
                    XmlElement xName = (XmlElement)xn;
                    if (!string.IsNullOrEmpty(xName.InnerText))
                    {
                        artist.NAMEVARIATIONS.Add(xName.InnerText.Trim());
                    }
                } //foreach
            }

            if (xArtist.GetElementsByTagName("aliases")[0] != null)
            {
                foreach (XmlNode xn in xArtist.GetElementsByTagName("aliases")[0].ChildNodes)
                {
                    XmlElement xAlias = (XmlElement)xn;
                    Alias alias = new Alias();
                    if (!string.IsNullOrEmpty(xAlias.InnerText))
                    {
                        alias.ARTIST_ID = Convert.ToInt32(xAlias.Attributes["id"].Value);
                        alias.NAME = xAlias.InnerText;
                        artist.ALIASES.Add(alias);
                    }
                } //foreach
            }

            if (xArtist.GetElementsByTagName("members")[0] != null)
            {
                XmlElement xMembers = (XmlElement)xArtist.GetElementsByTagName("members")[0];

                foreach (XmlNode xn in xMembers.GetElementsByTagName("name"))
                {
                    XmlElement xMember = (XmlElement)xn;
                    Member member = new Member();
                    if (!string.IsNullOrEmpty(xMember.InnerText))
                    {
                        member.ARTIST_ID = Convert.ToInt32(xMember.Attributes["id"].Value);
                        member.NAME = xMember.InnerText;
                        artist.MEMBERS.Add(member);
                    }
                } //foreach
            }

            if (xArtist.GetElementsByTagName("groups")[0] != null)
            {
                foreach (XmlNode xn in xArtist.GetElementsByTagName("groups")[0].ChildNodes)
                {
                    XmlElement xMember = (XmlElement)xn;
                    Group group = new Group();
                    if (!string.IsNullOrEmpty(xMember.InnerText))
                    {
                        group.ARTIST_ID = Convert.ToInt32(xMember.Attributes["id"].Value);
                        group.NAME = xMember.InnerText;
                        artist.GROUPS.Add(group);
                    }
                } //foreach
            }

            return artist;
*/
        }
        #endregion

    }
}
