using System.Threading.Channels;

namespace MitarbeiterAnalyseTool
{
    public class MitarbeiterAnalyseTool
    {
        static void Main(string[] args)
        {

            MitarbeiterVerwaltung verwaltung = new();
            BenutzerSchnittstelle ui = new(verwaltung);
            ui.Starten();
        }


        private void FehlerbehandlungTesten(MitarbeiterVerwaltung verwaltung)
        {
            Console.WriteLine("--- Versuche fehlerhaften Mitarbeiter anzulegen. ---");
            try
            {
                Mitarbeiter fehlerhafterMitarbeiter = new("Fehler", "haft",
                    new DateTime(1990, 1, 1),
                    -5000.00m,
                    Abteilung.IT
                );
                verwaltung.MitarbeiterHinzufuegen(fehlerhafterMitarbeiter);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Fehler beim Hinzufügen des Mitarbeiters: {ex.Message}");
            }
        }

        private static void TestDatenErzeugen(MitarbeiterVerwaltung verwaltung)
        {
            // 1. Sicheres Hinzufügen mit Abteilungen
            Mitarbeiter m1 = new("Max", "Mustermann",
                                new DateTime(1986, 12, 02),
                                5000.00m,
                                Abteilung.IT
            );
            Mitarbeiter m2 = new("Anna", "Schmidt",
                                new DateTime(1990, 12, 2),
                                4000.90m,
                                Abteilung.Personal
            );
            Mitarbeiter m3 = new("Thomas", "Mann",
                                new DateTime(1950, 12, 2),
                                4500.50m,
                                Abteilung.IT
            );
            verwaltung.MitarbeiterHinzufuegen(m1);
            verwaltung.MitarbeiterHinzufuegen(m2);
            verwaltung.MitarbeiterHinzufuegen(m3);
            verwaltung.MitarbeiterHinzufuegen(
                        new Mitarbeiter("Anna", "Schmidt",
                                        new DateTime(1990, 8, 15),
                                        4200.00m,
                                        Abteilung.Vertrieb
                        )
            );
            verwaltung.MitarbeiterHinzufuegen(
                new Mitarbeiter("Lukas", "Weber",
                                new DateTime(1982, 1, 30),
                                3800.75m,
                                Abteilung.IT
                )
            );
            List<Mitarbeiter> mitarbeiterListe =
            [
                  new("Max","Meier",
                       new DateTime(1986, 12, 02),
                       5000.00m,
                       Abteilung.IT
                  ),
                  new("Anna","Anton",
                      new DateTime(1990, 12, 2),
                      4000.90m,
                      Abteilung.Vertrieb
                  ),
                  new("Tim", "Tuchel",
                      new DateTime(1950,12,2),
                      4500.50m,
                      Abteilung.Geschaeftsfuehrung),
                  new("Bart", "Baum",
                      new DateTime(1986,12,2),
                      3500.10m,
                      Abteilung.Vertrieb),
                  new("Claudia","Clark",
                      new DateTime(1986,12, 2),
                      4800.20m,
                      Abteilung.Vertrieb),
                  new("Claus","Clown",
                      new DateTime(1986,12,3),
                      4900.30m,
                      Abteilung.Personal
                  )
            ];
            foreach (var m in mitarbeiterListe)
            {
                verwaltung.MitarbeiterHinzufuegen(m);
            }
        }
    }
}
