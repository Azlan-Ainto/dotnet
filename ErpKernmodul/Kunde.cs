using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErpKernmodul
{
    [Table("Kunden")]
    public class Kunde
    {
        [Key]
        public int KundenId { get; set; }
        [Required(ErrorMessage = "Der Name des Kunden ist zwingend erforderlich.")]
        [MaxLength(20)]
        public string KundenNummer { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string Firmenname { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Ansprechpartner { get; set; } = string.Empty;
        public DateTime Erfassunsdatum { get; set; } = DateTime.Now;
        //Navigationseigenschaft für die Beziehung zu Bestellung
        // 1:n Beziehung zwischen Kunde und Bestellung
        public ICollection<Bestellung> Bestellungen { get; set; } = [];
    }      
}
