namespace Context.Models
{
    public class ReleaseImage
    {
        public int Id {get; set;}
        public Release Release {get; set;}
        public Image Image {get; set;}
    }
}