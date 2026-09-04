using ErpKernmodul.Schnittstellen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace ErpKernmodul.Repositorys
{
    public class KundenRepository : IKundenRepository
    {
        private readonly ErpKontext datenbankKontext;

        public KundenRepository(ErpKontext kontext)
        {
            datenbankKontext = kontext;       
        }
        public void akutualisieren()
        {
            #region Erklaerung
            // EF Core verfolgt automatisch Änderungen an den Entitäten, die aus dem Kontext geladen wurden.
            // daher müssen wir nur SaveChanges aufrufen, um die Änderungen in der Datenbank zu speichern.
            #endregion
            datenbankKontext.SaveChanges();
        }
        public void hinzufuegen(Kunde kunde)
        {
            datenbankKontext.Kunden.Add(kunde);
            datenbankKontext.SaveChanges();
        }
        public List<Kunde> HoleAlleKundenMitBestellungen()
        {
            return datenbankKontext.Kunden.Include(k => k.Bestellungen).ToList();
        }
        public Kunde HoleNachId(int kundenId)
        {
            return datenbankKontext.Kunden.FirstOrDefault(k => k.KundenId == kundenId);
        }
        public void loeschen(Kunde kunde)
        {
            datenbankKontext.Kunden.Remove(kunde);
            datenbankKontext.SaveChanges();
        }
    }
}
