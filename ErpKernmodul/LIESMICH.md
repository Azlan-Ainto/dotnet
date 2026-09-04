# ERP Kernmodul (Projekt 2)

## Projektbeschreibung
Entwicklung eines relationalen Datenbankmodells unter Nutzung von Entity Framework Core und dem Microsoft SQL Server (LocalDB).

## Lernfortschritt Tag 7
- C# Konsolen-Projekt für ERP-System aufgesetzt.
- NuGet-Pakete `EFCore.SqlServer` und `EFCore.Tools` installiert.
- Erste Entität `Kunde` (inkl. Data Annotations) implementiert.
- `ErpKontext` (DbContext) erstellt und Verbindungszeichenfolge (Connection String) konfiguriert.
- Code-First-Migration durchgeführt (`Add-Migration`, `Update-Database`) und physische SQL-Datenbank erstellt.

## Lernfortschritt Tag 8
- Geschäftslogik-Schicht (`KundenVerwaltung`) zur Kapselung des Datenzugriffs erstellt.
- Entity Framework Core CRUD-Operationen (Erstellen, Lesen, Aktualisieren, Löschen) implementiert.
- Nutzung von `using`-Blöcken zur sicheren Ressourcenfreigabe (`IDisposable`) des DbContexts.
- Verifikation der SQL-Daten über den Visual Studio SQL Server-Objekt-Explorer.

## Lernfortschritt Tag 9
- 1:n-Beziehung zwischen Entitäten implementiert (`Kunde` und `Bestellung`).
- Primärschlüssel- und Fremdschlüsselbeziehungen in C# modelliert (`[ForeignKey]`).
- Eager Loading (`.Include()`) angewendet, um SQL-JOIN-Operationen über Entity Framework auszuführen.
- Zweite Code-First-Migration erfolgreich auf die SQL-Datenbank angewendet.

## Lernfortschritt Tag 10
- Projektstruktur in logische Ordner (`Schnittstellen`, `Repositorys`, `Geschaeftslogik`) unterteilt.
- Schnittstelle `IKundenRepository` zur Entkopplung definiert (Clean Architecture).
- `KundenRepository` als Implementierung für den EF Core Datenzugriff erstellt.
- Dependency Injection (Konstruktor-Injektion) implementiert: Die `KundenVerwaltung` kennt keine Datenbank mehr.