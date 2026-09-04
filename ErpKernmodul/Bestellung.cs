using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErpKernmodul
{
    [Table("Bestellungen")]
    public class Bestellung
    {
        [Key]
        public int BestellId { get; set; }
        [Required]
        public DateTime Bestelldatum { get; set; } = DateTime.Now;
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Gesamtbetrag { get; set; }
        [MaxLength(255)]
        public string Lieferadresse { get; set; } = string.Empty;
        [Required]
        public int kundenId { get; set; }
        // Navigationseigenschaft für die Beziehung zu Kunde
        [ForeignKey(nameof(kundenId))]
        public Kunde BestellenderKunde { get; set; }

    }
}
