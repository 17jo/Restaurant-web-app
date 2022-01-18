using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Klijent")]
    public class Klijent
    {
        [Key]
        public int ID { get; set; }

         [Required]
        [MaxLength(30)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(30)]
        public string Prezime { get; set; }

        [Required]
        public int BrojTelefona { get; set; }

        [JsonIgnore]
        public virtual List<Narudzbina> Klijenti { get; set; }
    }
}