using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ErpKernmodul.Schnittstellen;

namespace ErpKernmodul.Geschaeftslogik
{
    public class KundenVerwaltung
    {
        private readonly IKundenRepository kundenRepository;

        public KundenVerwaltung(IKundenRepository kundenRepository)
        {
            this.kundenRepository = kundenRepository;
        }
        public List<Kunde> AlleKundenMitBestellungenLaden()
        {
            return kundenRepository.HoleAlleKundenMitBestellungen();
        }        
        public void KundeAnlegen(Kunde neuerKunde)
        {
            kundenRepository.hinzufuegen(neuerKunde);
            Console.WriteLine($"Kunde '{neuerKunde.Firmenname}' erfolgreich in die Datenbank gespeichert.");
        }
        public void KundeAktualisieren(int kundenId, string neuerAnsprechpartner)
        {
            
            var kunde = kundenRepository.HoleNachId(kundenId);
            if (kunde != null){
                kunde.Ansprechpartner = neuerAnsprechpartner;
                kundenRepository.akutualisieren();
                Console.WriteLine($"Ansprechpartner für Kunde-ID {kundenId} wurde aktualisiert.");
            }else{
                Console.WriteLine($"Fehler: Kunde mit der ID {kundenId} wurde nicht gefunden.");
            }
        }
        public void KundeLoeschen(int kundenId)
        {            
            var kunde = kundenRepository.HoleNachId(kundenId);
            if (kunde != null)
            {
                kundenRepository.loeschen(kunde);
                Console.WriteLine($"Kunde mit der ID {kundenId} erfolgreich gelöscht.");
            }
        }

    }
}
