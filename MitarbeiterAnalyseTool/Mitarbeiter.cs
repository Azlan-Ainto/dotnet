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
        public Abteilung MitarbeiterAbteilung { get; set; } 

        public Mitarbeiter(string vorname, 
                           string nachname,
                           DateTime geburtsdatum,
                           decimal gehalt,
                           Abteilung mitarbeiterabteilung)
        {
            if(gehalt < 0)
            {
                throw new ArgumentException("Das Gehalt darf nicht negativ sein", nameof(gehalt));
            }
            Vorname = vorname;
            Nachname = nachname;
            Geburtsdatum = geburtsdatum;
            Gehalt = gehalt;
            MitarbeiterAbteilung = mitarbeiterabteilung;
        }

        public void DatenAusgeben()
        {
            Console.WriteLine("--- Mitarbeiter Details ---\n"+
                            $"Name:\t\t{Vorname} {Nachname}\n"+
                            $"Geburtsdatum:\t{Geburtsdatum:d}\n"+     
                            $"Abteilung: {MitarbeiterAbteilung}\n"+
                            $"Gehalt:\t\t{Gehalt} Euro\n");
        }
        // d == .ToShortDateString()        

    }
}
