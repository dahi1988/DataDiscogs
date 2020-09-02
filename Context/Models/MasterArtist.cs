namespace Context.Models
{
    public class MasterArtist
    {
        public int Id {get; set;}
        public Artist Artist {get; set;}
        public Master Master {get; set;}
    }
}