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
            Console.WriteLine("Verfügbare Abteilungen: 0=IT, 1=Vertrieb, 2=Personal, 3=Geschaeftsfuehrung");
            Console.Write("Bitte Nummer der Abteilung eingeben: ");
            if(Enum.TryParse<Abteilung>(Console.ReadLine(), out Abteilung abteilung))
            {
                mitarbeiterVerwaltung.MitarbeiterNachAbteilungAusgeben(abteilung);
            }
            else
            {
                Console.WriteLine("Ungültige Abteilungsnummer. Bitte erneut versuchen.");
            }
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
            mitarbeiterAbteilung = Abteilung.IT;
            try
            {
                Mitarbeiter neuerMitarbeiter = new(vorname, nachname, geburtsdatum, gehalt, mitarbeiterAbteilung);
                mitarbeiterVerwaltung.MitarbeiterHinzufuegen(neuerMitarbeiter);

            }catch(ArgumentException aex)
            {
                Console.WriteLine($"Fehler beim Anlegen des Mitarbeiters: {aex.Message}");
            }

        }


    }
}
