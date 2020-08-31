using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Xml;

namespace DiscogsContext.Models
{
  public  class Artist
    {
        #region Data definition
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ARTIST_ID { get; set; }
        public string NAME { get; set; }
        public string REALNAME { get; set; }
        public string PROFILE { get; set; }
        public string DATA_QUALITY { get; set; }
        
        public List<Image> IMAGES = new List<Image>();
        public List<string> URLS = new List<string>();
        public List<string> NAMEVARIATIONS = new List<string>();
        public List<Alias> ALIASES = new List<Alias>();
        public List<Member> MEMBERS = new List<Member>();
        public List<Group> GROUPS = new List<Group>();

        public class Image
        {
            public int HEIGHT { get; set; }
            public int WIDTH { get; set; }
            public string TYPE { get; set; }
            public string URI { get; set; }
            public string URI150 { get; set; }
        }

        public class Alias
        {
            public int ARTIST_ID { get; set; }
            public string NAME { get; set; }
        }


        public class Member
        {
            public int ARTIST_ID { get; set; }
            public string NAME { get; set; }
        }

        public class Group
        {
            public int ARTIST_ID { get; set; }
            public string NAME { get; set; }
        }
        #endregion
        #region Parse XML
        public static Artist ParseXML(XmlElement xArtist)
        {

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
        }

        public static List<Artist> Clone(List<Artist> list)
        {
            List<Artist> newList = new List<Artist>();
            foreach (Artist a in list)
            {
                Artist artist = new Artist();
                artist.ARTIST_ID = a.ARTIST_ID;
                artist.NAME = a.NAME;
                artist.REALNAME = a.REALNAME;
                artist.PROFILE = a.PROFILE;
                artist.IMAGES= a.IMAGES;
                artist.MEMBERS = a.MEMBERS;
                newList.Add(artist);
            }

            return newList;
        }

        public static List<Artist> ParseArtists(XmlElement xRelease)
        {
            List<Artist> artists = new List<Artist>();

            if (xRelease.GetElementsByTagName("artists")[0] != null)
            {
                foreach (XmlNode xn in xRelease.GetElementsByTagName("artists")[0].ChildNodes)
                {
                    XmlElement xArtist = (XmlElement)xn;
                    Artist artist = new Artist();
                    artist.ARTIST_ID = Convert.ToInt32(xArtist["id"].InnerText);
                    artist.NAME = xArtist["name"].InnerText;
                    
                    artists.Add(artist);
                } //foreach
            }
            if (xRelease.GetElementsByTagName("extraartists")[0] != null)
            {
                foreach (XmlNode xn in xRelease.GetElementsByTagName("extraartists")[0].ChildNodes)
                {
                    XmlElement xArtist = (XmlElement)xn;
                    Artist artist = new Artist();
                    artist.ARTIST_ID = Convert.ToInt32(xArtist["id"].InnerText);
                    artist.NAME = xArtist["name"].InnerText;
                   


                    artists.Add(artist);
                } //foreach
            }

            return artists;
        }
        #endregion

    }

}
