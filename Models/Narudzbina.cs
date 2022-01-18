using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Narudzbina")]
    public class Narudzbina
    {
        [Key]
        public int ID { get; set; }
        public virtual Dezert Dezert { get; set; }
        public virtual Jela Jela { get; set; }
        public virtual Klijent Klijent { get; set; }
        public virtual Pica Pica { get; set; }
        public virtual Restoran Restoran {get; set;}
    }
}