using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Dezert")]
    public class Dezert
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string ImeDezerta { get; set; }

        [Required]
        public int Cena { get; set; }
        
        [Required]
        public Restoran Restoran { get; set; }
        
        [JsonIgnore]
        public virtual List<Narudzbina> DezertiNaruci { get; set; }
    }
}
