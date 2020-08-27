using System;
using System.IO;
using System.Text;

namespace DataDiscogs
{
    public  class XmlSnibbitReader
    {
        public StreamReader stream = null;
        public StringBuilder sbLeft = new StringBuilder();
        public string GetXMLSnibbit(string v)
        {
            throw new NotImplementedException();
        }

        public bool OpenFile(string xmlFilename)
        {
            try
            {
                stream = new StreamReader(new FileStream(xmlFilename, FileMode.Open, FileAccess.Read));
                sbLeft.Clear();
                return true;
            }
            catch { }

            return false;
        }
        public void Close()
        {
            if (stream != null)
            {
                stream.Close();
                stream = null;
                sbLeft.Clear();
            }
        }
        static public string FixXML(string xml)
        {
            StringBuilder sb = new StringBuilder(xml.Length);
            // delete any byte that's between 0x00 and 0x1F except 0x09 (tab), 0x0A (LF), and 0x0D (CR).
            foreach (char c in xml)
            {
                if (c == '\t' || c == '\n' || c == '\r')
                {
                    // escape char
                    switch (c)
                    {
                        case '\t':
                            sb.Append("\\t");
                            break;
                        case '\n':
                            sb.Append("\\n");
                            break;
                        case '\r':
                            sb.Append("\\r");
                            break;
                    } //switch
                }
                else if ((ushort)c > 0x1f)
                {
                    sb.Append(c);
                }
            } //foreach

            return sb.ToString();
        }
    }
}