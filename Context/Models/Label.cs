using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Context.Models
{

    public class Label
    {
        #region Data definition
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string Profile { get; set; }
        public string DataQuality { get; set; }
        public string Urls {get; set;}
        [NotMapped]
        public List<string> UrlsList { 
            get {
                if (string.IsNullOrEmpty(this.Urls)) {
                    return new List<string>();
                }
                return this.Urls.Split(";").ToList();
            }
            set {
                this.Urls = string.Join(';', value);
            }
        }
        public ParentLabel ParentLabel { get; set; }
        public List<SubLabel> SubLabels {get; set;}
        public List<LabelImage> LabelImages {get; set;}
        
        #endregion
        #region Parse XML
        public static Label ParseXML(XmlElement xLabel)
        {

            throw new NotImplementedException();
/*
            Label label = new Label();

            label.LABEL_ID = Convert.ToInt32(xLabel.GetElementsByTagName("id")[0].InnerText);
            label.NAME = xLabel["name"].InnerText;
            if (xLabel["contactinfo"] != null)
            {
                label.CONTACTINFO = xLabel["contactinfo"].InnerText;
            }
            if (xLabel["profile"] != null)
            {
                label.PROFILE = xLabel["profile"].InnerText;
            }
            if (xLabel["data_quality"] != null)
            {
                label.DATA_QUALITY = xLabel["data_quality"].InnerText;
            }
            if (xLabel["parentLabel"] != null)
            {
                label.PARENTLABEL = new SubLabel();
                label.PARENTLABEL.LABEL_ID = Convert.ToInt32(xLabel["parentLabel"].Attributes["id"].Value);
                label.PARENTLABEL.NAME = xLabel["parentLabel"].InnerText;
            }

            if (xLabel.GetElementsByTagName("images")[0] != null)
            {
                foreach (XmlNode xn in xLabel.GetElementsByTagName("images")[0].ChildNodes)
                {
                    XmlElement xImage = (XmlElement)xn;
                    Image image = new Image();
                    image.HEIGHT = Convert.ToInt32(xImage.Attributes["height"].Value);
                    image.WIDTH = Convert.ToInt32(xImage.Attributes["width"].Value);
                    image.TYPE = xImage.Attributes["type"].Value;
                    image.URI = xImage.Attributes["uri"].Value;
                    image.URI150 = xImage.Attributes["uri150"].Value;
                    label.IMAGES.Add(image);
                } //foreach
            }

            if (xLabel.GetElementsByTagName("urls")[0] != null)
            {
                foreach (XmlNode xn in xLabel.GetElementsByTagName("urls")[0].ChildNodes)
                {
                    XmlElement xUrl = (XmlElement)xn;
                    if (!string.IsNullOrEmpty(xUrl.InnerText))
                    {
                        label.URLS.Add(xUrl.InnerText.Trim());
                    }
                } //foreach
            }

            if (xLabel.GetElementsByTagName("sublabels")[0] != null)
            {
                foreach (XmlNode xn in xLabel.GetElementsByTagName("sublabels")[0].ChildNodes)
                {
                    XmlElement xSublabel = (XmlElement)xn;
                    SubLabel subLabel = new SubLabel();
                    if (!string.IsNullOrEmpty(xSublabel.InnerText))
                    {
                        subLabel.LABEL_ID = Convert.ToInt32(xSublabel.Attributes["id"].Value);
                        subLabel.NAME = xSublabel.InnerText;
                        label.SUBLABELS.Add(subLabel);
                    }
                } //foreach
            }


            return label;
*/
        }
        #endregion
    }

}
