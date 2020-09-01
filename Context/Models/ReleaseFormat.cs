using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Context.Models
{
    public class ReleaseFormat
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public int Quantity {get; set;}
        public string Text {get; set;}
        public string Descriptions {get; set;}
        [NotMapped]
        public List<string> DescriptionsList { 
            get {
                if (string.IsNullOrEmpty(this.Descriptions)) {
                    return new List<string>();
                }
                return this.Descriptions.Split("|").ToList();
            }
            set {
                this.Descriptions = string.Join('|', value);
            }
        }
    }
}