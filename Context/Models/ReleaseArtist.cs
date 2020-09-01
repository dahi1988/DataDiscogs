namespace Context.Models
{
    public class ReleaseArtist
    {
        public int Id {get; set;}
        public Release Release {get; set;}
        public Artist Artist {get; set;}
    }
}