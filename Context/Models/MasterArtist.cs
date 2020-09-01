namespace Context.Models
{
    public class MasterArtist
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Anv {get; set;}
        public string Join {get; set;}
        public string Role {get; set;}
        public string Tracks {get; set;}

        public Master Master {get; set;}
    }
}