using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Jela")]
    public class Jela
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string ImeJela { get; set; }

        [Required]
        public int Cena { get; set; }

        [Required]
        public Restoran Restoran { get; set; }
        
        [JsonIgnore]
        public virtual List<Narudzbina> JelaNaruci { get; set; }
    }
}