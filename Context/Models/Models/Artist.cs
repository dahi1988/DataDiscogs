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
        public int ARTIST_ID = -1;
        public string NAME = "";
        public string REALNAME = "";
        public string PROFILE = "";
        public string DATA_QUALITY = "";

        public List<Image> IMAGES = new List<Image>();
        public List<string> URLS = new List<string>();
        public List<string> NAMEVARIATIONS = new List<string>();
        public List<Alias> ALIASES = new List<Alias>();
        public List<Member> MEMBERS = new List<Member>();
        public List<Group> GROUPS = new List<Group>();

        public class Image
        {
            public int HEIGHT = -1;
            public int WIDTH = -1;
            public string TYPE = "";
            public string URI = "";
            public string URI150 = "";
        }

        public class Alias
        {
            public int ARTIST_ID = -1;
            public string NAME = "";
        }


        public class Member
        {
            public int ARTIST_ID = -1;
            public string NAME = "";
        }

        public class Group
        {
            public int ARTIST_ID = -1;
            public string NAME = "";
        }
        #endregion
        #region Parse XML
        public static Artist ParseXML(XmlElement xArtist)
        {
            // -------------------------------------------------------------------------
            System.Globalization.NumberFormatInfo nfi = null;
            System.Globalization.CultureInfo culture = null;

            nfi = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencySymbol = "€";
            nfi.CurrencyDecimalDigits = 2;
            nfi.CurrencyDecimalSeparator = ".";
            nfi.NumberGroupSeparator = "";
            nfi.NumberDecimalSeparator = ".";

            culture = new System.Globalization.CultureInfo("en-US");
            // -------------------------------------------------------------------------


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

        internal static List<Artist> ParseArtists(XmlElement xMaster)
        {
            throw new NotImplementedException();
        }

        internal static List<Artist> Clone(List<Artist> aRTISTS)
        {
            throw new NotImplementedException();
        }
        #endregion

    }

}
