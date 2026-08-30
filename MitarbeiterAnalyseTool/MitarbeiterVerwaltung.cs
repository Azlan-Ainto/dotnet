using static System.Console;

namespace MitarbeiterAnalyseTool
{
    public class MitarbeiterVerwaltung
    {
        private readonly List<Mitarbeiter> mitarbeiterListe;

        public MitarbeiterVerwaltung()
        {
            mitarbeiterListe = new List<Mitarbeiter>();
        }

        public void MitarbeiterHinzufuegen(Mitarbeiter neuerMitarbeiter)
        {
            mitarbeiterListe.Add(neuerMitarbeiter);
            WriteLine($"Mitarbeiter {neuerMitarbeiter.Vorname} " +
                              $"{neuerMitarbeiter.Nachname} " +
                              $"wurde erfolgreich hinzugefügt.");   
        }



        public void AlleMitarbeiterAusgeben()
        {
            WriteLine("\n--- Komplette Mitarbeiterliste ---");
            if (mitarbeiterListe.Count == 0)
            {
                WriteLine("Kein Mitarbeiter in der Datenbank vorhanden.");
                return;
            }

            foreach (Mitarbeiter aktuellerMitarbeiter in mitarbeiterListe)
            {
                aktuellerMitarbeiter.DatenAusgeben();
            }
        }

        public decimal DurchschnittsgehaltsBerechnen()
        {
            if (mitarbeiterListe.Count == 0)
            {
                return 0m;
            }

            decimal gesamtGehalt = 0m;

            foreach(Mitarbeiter aktuellerMitarbeier in mitarbeiterListe)
            {
                gesamtGehalt += aktuellerMitarbeier.Gehalt;
            }

            return gesamtGehalt / mitarbeiterListe.Count;
        }


    }
}
