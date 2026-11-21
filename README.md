# TaskManager

System zarządzania zadaniami – projekt na zajęcia z programowania aplikacji webowych (.NET).
ASP.NET Core Web API (kontrolery), dane przechowywane w pamięci.

## Struktura
- `Controllers/` – kontrolery API (na razie pusty)
- `Models/` – modele domeny: `User` i `TaskItem`
- `DTOs/` – obiekty transferu danych (na razie pusty)

## Uruchomienie
```
dotnet run
```
Projekt dopiero powstaje – endpointy będą dodawane w kolejnych krokach.

## Na co się natknąłem
- Wkleiłem oba modele do jednego pliku `User.cs` i kompilator się pogubił (błędy CS0116 i CS1022). Rozdzieliłem je na dwa pliki w `Models/`.
- Przypadkiem została mi literka za klamrą `}` w `TaskItem.cs` i też był błąd. Znalazłem ją po numerze linii z komunikatu `dotnet build`.
- Przy każdym buildzie wyskakuje ostrzeżenie NU1903 o pakiecie `Microsoft.OpenApi`. Przychodzi razem z szablonem `dotnet new webapi` i nie blokuje projektu.
