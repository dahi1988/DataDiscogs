using System.Collections.Generic;

namespace Context.Models
{
    public class Image
    {
        public int Id {get; set;}
        public int Height { get; set; }
        public int Width { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public string Uri150 { get; set; }
    }
}