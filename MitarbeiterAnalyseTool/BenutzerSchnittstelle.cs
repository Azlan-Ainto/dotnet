using System;
using System.Collections.Generic;
using System.Text;

namespace MitarbeiterAnalyseTool
{
    public class BenutzerSchnittstelle
    {
        private readonly MitarbeiterVerwaltung mitarbeiterVerwaltung;


        public BenutzerSchnittstelle(MitarbeiterVerwaltung mitarbeiterverwaltung)
        {
            this.mitarbeiterVerwaltung = mitarbeiterverwaltung;
        }

        public void Starten()
        {
            bool programmlaeuft = true;
            while (programmlaeuft) 
            {
                Console.Clear();
                Console.WriteLine("=== Mitarbeiter Analyse Tool ===");
                Console.WriteLine("1. Alle Mitarbeiter ausgeben");
                Console.WriteLine("2.Neuen Mitarbeiter anlegen");
                Console.WriteLine("3.Nach Abteilung filtern");
                Console.WriteLine("4.Top Verdiener ausgeben");
                Console.WriteLine("5.Speichern und beenden");
                Console.WriteLine("Bitte wählen Sie eine Option aus[1-5]:");
                string auswahl = Console.ReadLine();
                Console.WriteLine();
                switch (auswahl) 
                {
                    case "1":
                        mitarbeiterVerwaltung.AlleMitarbeiterAusgeben();
                        break;
                    case "2":
                        MitarbeiterErfassen();
                        break;
                    case "3":
                        AbteilungFiltern();
                        break;
                    case "4":
                        mitarbeiterVerwaltung.TopVerdienerAusgeben();
                        break;
                    case "5":
                        mitarbeiterVerwaltung.DatenSichern();
                        programmlaeuft = false;
                        Console.WriteLine("Programm wird beendet...");
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte wähle eine Zahl von 1 bis 5.");
                        break;
                }

                if (programmlaeuft)
                {
                    Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                    Console.ReadKey();
                }

            }
        }

        private void AbteilungFiltern()
        {
            Console.WriteLine("\nNach welchen Abteilung möchtest du filtern?");
            Abteilung gesuchteAbteilung = AbteilungAuswaehlen();
            mitarbeiterVerwaltung.MitarbeiterNachAbteilungAusgeben(gesuchteAbteilung);

        }

        private void MitarbeiterErfassen()
        {
            Console.WriteLine("--- Neuen Mitarbeiter anlegen ---");
            Console.WriteLine("Vorname: ");
            string vorname = Console.ReadLine();
            Console.WriteLine("Nachname: ");
            string nachname = Console.ReadLine();
            DateTime geburtsdatum;
            Console.WriteLine("Geburtsdatum (TT.MM.JJJJ):");
            while(!DateTime.TryParse(Console.ReadLine(), out geburtsdatum))
            {
                Console.WriteLine("Ungültiges Datum. Bitte erneut eingeben (TT.MM.JJJJ):");
            }
            decimal gehalt;
            Console.WriteLine("Gehalt in Euro: ");
            while (!decimal.TryParse(Console.ReadLine(), out gehalt) || gehalt < 0)
            {
                Console.WriteLine("Ungültiges Gehalt. Bitte erneut eingeben (positiver Wert):");
            }
            Abteilung mitarbeiterAbteilung;
            mitarbeiterAbteilung = AbteilungAuswaehlen();
            try
            {
                Mitarbeiter neuerMitarbeiter = new(vorname, nachname, geburtsdatum, gehalt, mitarbeiterAbteilung);
                mitarbeiterVerwaltung.MitarbeiterHinzufuegen(neuerMitarbeiter);

            }catch(ArgumentException aex)
            {
                Console.WriteLine($"Fehler beim Anlegen des Mitarbeiters: {aex.Message}");
            }

        }

        private Abteilung AbteilungAuswaehlen()
        {
            Console.WriteLine("Verfügbare Abteilungen:");
            foreach (var abteilung in Enum.GetValues(typeof(Abteilung)))
            {
                Console.WriteLine($"{(int)abteilung} = {abteilung}");
            }
            Abteilung auswahl;
            Console.WriteLine("Bitte Nummer der Abteilung eingeben: ");
            while (!Enum.TryParse(Console.ReadLine(), out auswahl) || !Enum.IsDefined(typeof(Abteilung), auswahl))
            {
                Console.WriteLine("Ungültige Abteilungsnummer. Bitte erneut versuchen.");            
            }
            return auswahl;
        }
    }
}
