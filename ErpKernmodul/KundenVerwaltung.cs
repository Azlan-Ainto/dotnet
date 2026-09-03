using System;
using System.Collections.Generic;
using System.Text;

namespace ErpKernmodul
{
    public class KundenVerwaltung
    {
        public void KundeAnlegen(Kunde neuerKunde)
        {
            using var kontext = new ErpKontext();
            kontext.Kunden.Add(neuerKunde);
            kontext.SaveChanges();
            Console.WriteLine($"Kunde '{neuerKunde.Firmenname}' erfolgreich in die Datenbank gespeichert.");
        }

        public List<Kunde> AlleKundenLaden()
        {
            using var kontext = new ErpKontext();
            return kontext.Kunden.ToList();
        }

        public void KundeAktualisieren(int kundenId, string neuerAnsprechpartner)
        {
            using var kontext = new ErpKontext();
            var kunde = kontext.Kunden.FirstOrDefault(k => k.KundenId == kundenId);
            if (kunde != null){
                kunde.Ansprechpartner = neuerAnsprechpartner;
                kontext.SaveChanges();
                Console.WriteLine($"Ansprechpartner für Kunde-ID {kundenId} wurde aktualisiert.");
            }else{
                Console.WriteLine($"Fehler: Kunde mit der ID {kundenId} wurde nicht gefunden.");
            }
        }
        public void KundeLoeschen(int kundenId)
        {
            using var kontext = new ErpKontext();
            var kunde = kontext.Kunden.FirstOrDefault(k => k.KundenId == kundenId);
            if (kunde != null)
            {
                kontext.Kunden.Remove(kunde);
                kontext.SaveChanges();
                Console.WriteLine($"Kunde mit der ID {kundenId} erfolgreich gelöscht.");
            }
        }

    }
}
