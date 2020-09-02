namespace Context.Models
{
    public class ReleaseVideo
    {
        public int Id {get; set;}
        public Release Release {get; set;}
        public Video Video {get; set;}
    }
}