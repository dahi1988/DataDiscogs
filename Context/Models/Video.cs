namespace Context.Models
{
    public class Video
    {
        public int Id {get; set;}
        public string Src {get; set;}
        public int? Duration {get; set;}
        public bool? Embed {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
    }
}