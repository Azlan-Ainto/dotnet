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
        public Abteilung MitarbeiterAbteilug { get; set; } 

        public Mitarbeiter(string vorname, 
                           string nachname,
                           DateTime geburtsdatum,
                           decimal gehalt,
                           Abteilung abteilung)
        {
            if(gehalt < 0)
            {
                throw new ArgumentException("Das Gehalt darf nicht negativ sein", nameof(gehalt));
            }
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geburtsdatum = geburtsdatum;
            this.Gehalt = gehalt;
            MitarbeiterAbteilug = abteilung;
        }

        public void DatenAusgeben()
        {
            Console.WriteLine("--- Mitarbeiter Details ---\n"+
                            $"Name:\t\t{Vorname} {Nachname}\n"+
                            $"Geburtsdatum:\t{Geburtsdatum:d}\n"+     
                            $"Abteilung: {MitarbeiterAbteilug}\n"+
                            $"Gehalt:\t\t{Gehalt} Euro\n");
        }
        // d == .ToShortDateString()        

    }
}
