using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Piće")]
    public class Pica
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string ImePica { get; set; }

        [Required]
        public int Cena { get; set; }
        
        [Required]
         public Restoran Restoran { get; set; }
   
         [JsonIgnore]
        public virtual List<Narudzbina> PicaNaruci { get; set; }
    }
}