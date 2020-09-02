using System.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Xml;

namespace Context.Models
{
   
    public class Release
    {
        #region Data definition
        public int Id {get; set;}
        public string Status {get; set;}
        public List<ReleaseImage> Images {get; set;}
        public List<ReleaseArtist> Artists {get; set;}
        public string Title {get; set;}
        public List<Label> Labels {get; set;}
        public List<ReleaseExtraArtist> ExtraArtists {get; set;}
        public List<ReleaseFormat> Formats {get; set;}
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
        public string Country {get; set;}
        [DataType(DataType.Date)]
        public DateTime? Released {get; set;}
        public string Notes {get; set;}
        public string DataQuality {get; set;}
        public Master Master {get; set;}
        public bool IsMainRelease {get; set;}
        public List<Track> TrackList {get; set;}
        public List<ReleaseIdentifier> Identifiers {get; set;}
        public List<ReleaseVideo> Videos {get; set;}
        public List<Company> Companies {get; set;}

        #endregion
        #region Parse XML

        public static Release ParseXML(XmlElement xRelease)
        {
            throw new NotImplementedException();
/*
           Release release = new Release();

            release.RELEASE_ID = Convert.ToInt32(xRelease.Attributes["id"].Value);
            release.STATUS = xRelease.Attributes["status"].Value;
            release.TITLE = xRelease["title"].InnerText;
            if (xRelease["country"] != null)
            {
                release.COUNTRY = xRelease["country"].InnerText;
            }
            if (xRelease["released"] != null)
            {
                string[] tmp = xRelease["released"].InnerText.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tmp.Length; i++)
                {
                    int v;
                    if (int.TryParse(tmp[i], out v))
                    {
                        if (v == 0)
                        {
                            tmp[i] = "01";
                            if (i == 0)
                            {
                                tmp[i] = "0001";
                            }
                        }
                    }
                    else
                    {
                        tmp[i] = "01";
                        if (i == 0)
                        {
                            tmp[i] = "0001";
                        }
                    }
                }

                switch (tmp.Length)
                {
                    case 0:
                        release.RELEASED = DateTime.Parse("0001-01-01");
                        break;
                    case 1:
                        DateTime.TryParse($"{tmp[0]}-01-01", out release.RELEASED);
                        break;
                    case 2:
                        DateTime.TryParse($"{tmp[0]}-{tmp[1]}-01", out release.RELEASED);
                        break;
                    case 3:
                    default:
                        DateTime.TryParse($"{tmp[0]}-{tmp[1]}-{tmp[2]}", out release.RELEASED);
                        break;
                } //switch
            }
            if (xRelease["notes"] != null)
            {
                release.NOTES = xRelease["notes"].InnerText;
            }
            release.MASTER_ID = null;
            release.IS_MAIN_RELEASE = false;
            if (xRelease["master_id"] != null)
            {
                release.MASTER_ID = Convert.ToInt32(xRelease["master_id"].InnerText);
                if (release.MASTER_ID == 0)
                {
                    release.MASTER_ID = null;
                }
                release.IS_MAIN_RELEASE = (xRelease["master_id"].Attributes["is_main_release"].Value == "true");
            }
            if (xRelease["data_quality"] != null)
            {
                release.DATA_QUALITY = xRelease["data_quality"].InnerText;
            }

            if (xRelease.GetElementsByTagName("images")[0] != null)
            {
                foreach (XmlNode xn in xRelease.GetElementsByTagName("images")[0].ChildNodes)
                {
                    XmlElement xImage = (XmlElement)xn;
                    Image image = new Image();
                    image.HEIGHT = Convert.ToInt32(xImage.Attributes["height"].Value);
                    image.WIDTH = Convert.ToInt32(xImage.Attributes["width"].Value);
                    image.TYPE = xImage.Attributes["type"].Value;
                    image.URI = xImage.Attributes["uri"].Value;
                    image.URI150 = xImage.Attributes["uri150"].Value;
                    release.IMAGES.Add(image);
                } //foreach
            }

            release.ARTISTS = Artist.ParseArtists(xRelease);

            if (xRelease.GetElementsByTagName("genres")[0] != null)
            {
                foreach (XmlNode xn in xRelease.GetElementsByTagName("genres")[0].ChildNodes)
                {
                    XmlElement xGenre = (XmlElement)xn;
                    release.GENRES.Add(xGenre.InnerText);
                } //foreach
            }
            if (xRelease.GetElementsByTagName("styles")[0] != null)
            {
                foreach (XmlNode xn in xRelease.GetElementsByTagName("styles")[0].ChildNodes)
                {
                    XmlElement xStyle = (XmlElement)xn;
                    release.STYLES.Add(xStyle.InnerText);
                } //foreach
            }

            if (xRelease.GetElementsByTagName("formats")[0] != null)
            {
                foreach (XmlNode xn1 in xRelease.GetElementsByTagName("formats")[0].ChildNodes)
                {
                    XmlElement xformat = (XmlElement)xn1;
                    Format format = new Format();

                    Release.SERIAL_FORMAT_ID++;
                    format.FORMAT_ID = Release.SERIAL_FORMAT_ID;
                    format.FORMAT_NAME = xformat.Attributes["name"].Value;
                    format.FORMAT_TEXT = xformat.Attributes["text"].Value;
                    if (xformat.Attributes["qty"] != null)
                    {
                        int.TryParse(xformat.Attributes["qty"].Value, out format.QUANTITY);
                    }

                    if (xformat.GetElementsByTagName("descriptions")[0] != null)
                    {
                        int cnt = 1;
                        foreach (XmlNode xn2 in xRelease.GetElementsByTagName("descriptions")[0].ChildNodes)
                        {
                            XmlElement xDescription = (XmlElement)xn2;
                            Format.FormatDescription formatDescription = new Format.FormatDescription();
                            formatDescription.DESCRIPTION = xDescription.InnerText;
                            formatDescription.DESCRIPTION_ORDER = cnt;
                            format.FORMAT_DESCRIPTIONS.Add(formatDescription);
                            cnt++;
                        } //foreach
                    }

                    release.FORMATS.Add(format);
                } //foreach
            }

            if (xRelease.GetElementsByTagName("labels")[0] != null)
            {
                foreach (XmlNode xn in xRelease.GetElementsByTagName("labels")[0].ChildNodes)
                {
                    XmlElement xLabel = (XmlElement)xn;
                    ReleaseLabel releaseLabel = new ReleaseLabel();
                    releaseLabel.LABEL_ID = Convert.ToInt32(xLabel.Attributes["id"].Value);
                    releaseLabel.NAME = xLabel.Attributes["name"].Value;
                    releaseLabel.CATNO = xLabel.Attributes["catno"].Value;

                    release.RELEASELABELS.Add(releaseLabel);
                } //foreach
            }

            if (xRelease.GetElementsByTagName("tracklist")[0] != null)
            {
                int cnt = 1;
                foreach (XmlNode xn in xRelease.GetElementsByTagName("tracklist")[0].ChildNodes)
                {
                    XmlElement xTrack = (XmlElement)xn;
                    if (xTrack["title"] != null)
                    {
                        Track track = new Track();
                        track.TRACKNUMBER = cnt;
                        SERIAL_TRACK_ID++;
                        track.TRACK_ID = SERIAL_TRACK_ID;
                        track.POSITION = track.TRACKNUMBER.ToString();
                        if (xTrack["position"] != null)
                        {
                            track.POSITION = xTrack["position"].InnerText;
                        }
                        track.TITLE = xTrack["title"].InnerText;

                        if (xTrack["duration"] != null)
                        {
                            track.DURATION_IN_SEC = ParseDuration(xTrack["duration"].InnerText);
                        }

                        track.ARTISTS = Artist.ParseArtists(xTrack);
                        if (track.ARTISTS.Count == 0)
                        {
                            // Copy Artists from release album
                            track.ARTISTS = Artist.Clone(release.ARTISTS);
                        }

                        // Only when there are no subtracks do we use the "main" track info
                        release.TRACKS.Add(track);
                        cnt++;

                        // Are there sub tracks? (then we ignore the main track!)
                        if (xTrack.GetElementsByTagName("sub_tracks")[0] != null)
                        {
                            track.HAS_SUBTRACKS = true;

                            foreach (XmlNode xn2 in xTrack.GetElementsByTagName("sub_tracks")[0].ChildNodes)
                            {
                                XmlElement xSubTrack = (XmlElement)xn2;
                                Track subTrack = new Track();
                                SERIAL_TRACK_ID++;
                                subTrack.TRACK_ID = SERIAL_TRACK_ID;
                                subTrack.MAIN_TRACK_ID = track.TRACK_ID;
                                subTrack.TRACKNUMBER = cnt;

                                subTrack.IS_SUBTRACK = true;
                                subTrack.POSITION = subTrack.TRACKNUMBER.ToString();
                                if (xSubTrack["position"] != null)
                                {
                                    subTrack.POSITION = xSubTrack["position"].InnerText;
                                }
                                subTrack.TITLE = track.TITLE + " / " + xSubTrack["title"].InnerText;
                                subTrack.SUBTRACK_TITLE = xSubTrack["title"].InnerText;
                                if (xSubTrack["duration"] != null)
                                {
                                    subTrack.DURATION_IN_SEC = ParseDuration(xSubTrack["duration"].InnerText);
                                }

                                // I don't believe this exists for sub_tracks but it doesn't hurt
                                subTrack.ARTISTS = Artist.ParseArtists(xSubTrack);
                                if (subTrack.ARTISTS.Count == 0)
                                {
                                    // Copy Artists from "Main" track album
                                    subTrack.ARTISTS = Artist.Clone(track.ARTISTS);
                                }

                                release.TRACKS.Add(subTrack);
                                cnt++;
                            } //foreach subtrack
                        }
                    }
                } //foreach
            }

            if (xRelease.GetElementsByTagName("identifiers")[0] != null)
            {
                foreach (XmlNode xn in xRelease.GetElementsByTagName("identifiers")[0].ChildNodes)
                {
                    XmlElement xIdentifier = (XmlElement)xn;
                    Identifier identifier = new Identifier();
                    if (xIdentifier.Attributes["value"] != null)
                    {
                        if (xIdentifier.Attributes["description"] != null)
                        {
                            identifier.DESCRIPTION = xIdentifier.Attributes["description"].Value;
                        }
                        if (xIdentifier.Attributes["type"] != null)
                        {
                            identifier.TYPE = xIdentifier.Attributes["type"].Value;
                        }
                        identifier.VALUE = xIdentifier.Attributes["value"].Value;

                        release.IDENTIFIERS.Add(identifier);
                    }
                } //foreach
            }

            if (xRelease.GetElementsByTagName("videos")[0] != null)
            {
                foreach (XmlNode xn in xRelease.GetElementsByTagName("videos")[0].ChildNodes)
                {
                    XmlElement xVideo = (XmlElement)xn;
                    Video video = new Video();
                    video.EMBED = (xVideo.Attributes["embed"].Value == "true");
                    video.DURATION_IN_SEC = Convert.ToInt32(xVideo.Attributes["duration"].Value);
                    video.SRC = xVideo.Attributes["src"].Value;
                    video.TITLE = xVideo["title"].InnerText;
                    video.DESCRIPTION = xVideo["description"].InnerText;

                    release.VIDEOS.Add(video);
                } //foreach
            }

            if (xRelease.GetElementsByTagName("companies")[0] != null)
            {
                foreach (XmlNode xn in xRelease.GetElementsByTagName("companies")[0].ChildNodes)
                {
                    XmlElement xCompany = (XmlElement)xn;
                    Company company = new Company();
                    company.COMPANY_ID = Convert.ToInt32(xCompany["id"].InnerText);
                    company.NAME = xCompany["name"].InnerText;
                    company.CATNO = xCompany["catno"].InnerText;
                    company.ENTITY_TYPE = Convert.ToInt32(xCompany["entity_type"].InnerText);
                    company.ENTITY_TYPE_NAME = xCompany["entity_type_name"].InnerText;
                    company.RESOURCE_URL = xCompany["resource_url"].InnerText;

                    release.COMPANIES.Add(company);
                } //foreach
            }

            return release;
*/
        }
        #endregion

    }

}
