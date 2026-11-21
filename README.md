# TaskManager

System zarządzania zadaniami – projekt na zajęcia z programowania aplikacji webowych (.NET).
ASP.NET Core Web API (kontrolery), dane przechowywane w pamięci.

## Struktura
- `Controllers/` – `TasksController` (GET wszystkie, GET po id, POST)
- `Models/` – modele domeny: `User` i `TaskItem`
- `DTOs/` – obiekty transferu danych: `TaskDto` i `CreateTaskDto`

## Uruchomienie
```
dotnet run
```
Swagger UI: `http://localhost:5267/swagger` (adres może się różnić, patrz komunikat `Now listening on` w konsoli).

## Na co się natknąłem
- Wkleiłem oba modele do jednego pliku `User.cs` i kompilator się pogubił (błędy CS0116 i CS1022). Rozdzieliłem je na dwa pliki w `Models/`.
- Przypadkiem została mi literka za klamrą `}` w `TaskItem.cs` i też był błąd. Znalazłem ją po numerze linii z komunikatu `dotnet build`.
- Przy każdym buildzie wyskakiwało ostrzeżenie NU1903 o pakiecie `Microsoft.OpenApi`. Przychodziło razem z szablonem `dotnet new webapi`. Zniknęło po usunięciu pakietu `Microsoft.AspNetCore.OpenApi` (opis niżej).
- Szablon w .NET 10 nie ma już wbudowanego Swagger UI, więc dodałem pakiet `Swashbuckle.AspNetCore`. Po jego dodaniu build przestał działać (błąd CS0200 w kodzie generowanym przez `Microsoft.AspNetCore.OpenApi` z szablonu – oba pakiety się kłóciły). Ponieważ `AddOpenApi()` nie jest już używane, usunąłem ten pakiet komendą `dotnet remove package Microsoft.AspNetCore.OpenApi` i wszystko zaczęło działać.
