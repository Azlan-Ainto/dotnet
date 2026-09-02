using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace MitarbeiterAnalyseTool
{
    public class DateiVerwaltung
    {
        private const string DateiName = "mitarbeiter_daten.json";


       public void DatenSpeichern(List<Mitarbeiter> mitarbeiterListe)
       {
            JsonSerializerOptions optionen = new()
            {
                WriteIndented = true
            };
            
            string jsonText = JsonSerializer.Serialize(mitarbeiterListe, optionen);
            File.WriteAllText(DateiName, jsonText);
            Console.WriteLine("\nDaten wurden erfolgreich auf der Festplatte gespeichert");
       }


            public List<Mitarbeiter> DatenLaden()
            {
                if (!File.Exists(DateiName) || new FileInfo(DateiName).Length == 0)
                {
                    Console.WriteLine("Keine bestehende Datenbank-Datei gefunde. Starte mit leerer Liste.");
                    return new List<Mitarbeiter>();
                }

                string jsonText = File.ReadAllText(DateiName);
                var geladeneListe = JsonSerializer.Deserialize<List<Mitarbeiter>>(jsonText);
                Console.WriteLine("Daten wurden erfolgreich von der Festplatte geladen.");
                return geladeneListe ?? new List<Mitarbeiter>();

            }
    }
}
