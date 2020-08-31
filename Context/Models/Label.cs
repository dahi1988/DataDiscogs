using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Context.Models
{
/*
    public class Label
    {
        #region Data definition
        [Key]
        public int LABEL_ID { get; set; }
        public string NAME { get; set; }
        public string CONTACTINFO { get; set; }
        public string PROFILE { get; set; }
        public string DATA_QUALITY { get; set; }
        public SubLabel PARENTLABEL { get; set; }

        public List<Image> IMAGES = new List<Image>();
        public List<string> URLS = new List<string>();
        public List<SubLabel> SUBLABELS = new List<SubLabel>();

        public class Image
        {
            public int HEIGHT { get; set; }
            public int WIDTH { get; set; }
            public string TYPE { get; set; }
            public string URI { get; set; }
            public string URI150 { get; set; }
        }

        public class SubLabel
        {
            [Key]
            public int LABEL_ID { get; set; }
            public string NAME { get; set; }
        }
        #endregion
        #region Parse XML
        public static Label ParseXML(XmlElement xLabel)
        {

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
        }
        #endregion
    }
*/
}
