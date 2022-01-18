using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Restoran")]
    public class Restoran
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string ImeRestorana { get; set; }
        
        [JsonIgnore]
        public virtual List<Narudzbina> Narudzbine { get; set; }

        [JsonIgnore]
        public virtual List<Dezert> Dezert { get; set; }

        [JsonIgnore]
        public virtual List<Jela> Jela { get; set; }

        [JsonIgnore]
        public virtual List<Pica> Pica { get; set; }
    }
}