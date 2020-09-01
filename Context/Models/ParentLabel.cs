namespace Context.Models
{
    public class ParentLabel
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public int LabelId {get; set;}
        public Label ChildLabel {get; set;}
    }
}