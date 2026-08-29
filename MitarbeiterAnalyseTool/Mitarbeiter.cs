using System;
using System.Collections.Generic;
using System.Text;

namespace MitarbeiterAnalyseTool
{
    public class Mitarbeiter
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public decimal Gehalt {  get; set; }

        public Mitarbeiter(string vorname, 
                           string nachname,
                           DateTime geburtsdatum,
                           decimal gehalt)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geburtsdatum = geburtsdatum;
            this.Gehalt = gehalt;


        }


        public void DatenAusgeben()
        {
            Console.WriteLine("--- Mitarbeiter Details ---\n");
            Console.WriteLine($"Name:\t\t{Vorname} {Nachname}");
            Console.WriteLine($"Geburtsdatum:\t{Geburtsdatum:d}");      // d == .ToShortDateString()

            Console.WriteLine($"Gehalt:\t\t{Gehalt} Euro");
        }

    }
}
