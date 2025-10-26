# ActiviGo

ActiviGo är en webbapplikation för att hitta, visa och boka aktiviteter i en kommun. Projektet består av en .NET 8 Web API-backend och en React + Vite-frontend, designad för att erbjuda en sömlös användarupplevelse.

## Översikt

ActiviGo är en webbapplikation för att hitta, visa och boka aktiviteter i en kommun. Backend är byggd med .NET 8, Entity Framework Core och REST API. Frontend är byggd med React och Vite för snabb utveckling och responsiv design. Syftet är att ge användare möjlighet att bläddra bland aktiviteter, boka platser och hantera bokningar.

## Vad är det?

ActiviGo! är en API för att hantera ett bokningssystem för evenemang. Den kan användas av olika typer av aktivitetsledare för att skapa och hantera olika förekomster av en eller flera aktiviteter. Den har också CRUD-funktionalitet för att hantera platser, "underplatser" (som ett gym och en simhall i samma arena) och bokningar för nämnda aktiviteter.

## Teknik

### Backend
Byggd med C#, ASP.NET Core och Entity Framework. Använder SQL Server som databas, FluentValidation för datavalidering, AutoMapper för DTO-objektmappning och Microsoft Identity för autentisering och auktorisation.

### Frontend
Byggd med JavaScript, React och Vite. Använder också React Router för navigering.

## Arkitekturoversikt

API:et använder en N-tier-struktur med fyra distinkta lager: Infrastruktur hanterar kommunikation med databasen, WebAPI hanterar kommunikation med slutanvändare, Core hanterar kärnmodeller för programmet och Service hanterar affärslogik, mappning och validering.

## Repostruktur

### Backend (API)
Platsen för backend-koden finns i ActiviGoApi/.

- [ActiviGoApi.sln](ActiviGoApi/ActiviGoApi.sln): Lösningsfil för Visual Studio.
- ActiviGoApi/ActiviGoApi/:
  - [Program.cs](ActiviGoApi/ActiviGoApi/Program.cs): Huvudfil för uppstart, konfiguration och Dependency Injection (DI).
  - [appsettings.json](ActiviGoApi/ActiviGoApi/appsettings.json): Konfigurationsfil (kan vara .gitignored för säkerhet).
- ActiviGoApi/ActiviGoApi.Infrastructur/:
  - [ToadContext.cs](ActiviGoApi/ActiviGoApi.Infrastructur/Data/ToadContext.cs): EF Core DbContext för databasåtkomst.
  - [SeedData.cs](ActiviGoApi/ActiviGoApi.Infrastructur/Data/SeedData.cs): Inkluderar initial data (t.ex. kategorier, aktiviteter, platser).
  - Migrations: Exempel:
    - [20251009092802_moreSeedData.cs](ActiviGoApi/ActiviGoApi.Infrastructur/Migrations/20251009092802_moreSeedData.cs)
    - [20251023112936_activity-fix-and-seedlatlong.Designer.cs](ActiviGoApi/ActiviGoApi.Infrastructur/Migrations/20251023112936_activity-fix-and-seedlatlong.Designer.cs)
- ActiviGoApi/ActiviGoApi.Core/Models/:
  - [Location.cs](ActiviGoApi/ActiviGoApi.Core/Models/Location.cs) och [SubLocation.cs](ActiviGoApi/ActiviGoApi.Core/Models/SubLocation.cs): Modeller för platser och underplatser.
- ActiviGoApi/ActiviGoApi.Services/:
  - Innehåller DTOs, mappning och tjänster.
  - Exempel: [GetSubLocationResponse.cs](ActiviGoApi/ActiviGoApi.Services/DTOs/SubLocationDTOs/GetSubLocationResponse.cs).

### Frontend (Client)
Platsen för frontend-koden finns i Client/.

- [package.json](Client/package.json): Definierar beroenden och skript.
- Client/src/:
  - Innehåller React-komponenter, sidor och CSS-filer.

## Snabbstart (Utveckling)

### Krav
- Backend: .NET 8 SDK.
- Frontend: Node.js (med npm eller yarn).

### Steg

#### 1. Starta Backend
- Navigera till ActiviGoApi/ActiviGoApi/ i en terminal.
- Kör följande kommandon:
  ```sh
  dotnet build
  dotnet ef database update --project ../ActiviGoApi.Infrastructur/ActiviGoApi.Infrastructur.csproj
  dotnet run
  ```

#### 2. Starta Frontend
- Navigera till Client/ i en terminal.
- Kör följande kommandon:
```sh
  npm install
  npm run dev
```
## Frontend körs med Vite (se Client/vite.config.js för konfiguration).
### 3 Konfigurera appsettings.json

Skapa eller kopiera `appsettings.json` om den saknas (kan vara `.gitignored`).  
Fyll i följande sektioner:

- **ConnectionStrings:DefaultConnection**: Databasanslutning (t.ex. SQL Server).  
- **Jwt:Key**: En stark hemlig nyckel för JWT-autentisering.

**Viktigt:** Håll känslig data borta från versionering (använd t.ex. UserSecrets eller miljövariabler).

---

### Instruktioner för lokal körning (inkl. migrations/seed, env-variabler för väder-API-nyckel)

För att köra projektet lokalt, följ dessa steg utöver Snabbstart:

- **Migrations och Seed:**  
  Kör `dotnet ef database update` för att tillämpa migrationer och seed-data från `SeedData.cs`.

- **Miljövariabler:**  
  Lägg till en `.env`-fil i roten av `ActiviGoApi/ActiviGoApi/` med följande variabler:

(för SMHI eller annan väder-API-integration).  
Lägg till `.env` i `.gitignore` för att undvika att spara känslig data.

- **Kör med miljövariabler:**  
Använd `dotnet run --environment Development` och se till att `appsettings.Development.json` (om det finns) laddar `.env`-värden.

---

### Databas och Seed-data

- **DbContext:** `ToadContext.cs` hanterar databasen.  
- **Seed-data:** Definieras i `SeedData.cs` och inkluderar kategorier, aktiviteter, platser och underplatser.  
- **Migrations:** Finns i `ActiviGoApi/ActiviGoApi.Infrastructur/Migrations/`.

---

## API-endpoints — översikt

Nedan är en komplett lista över controllers och deras endpoints baserat på din OpenAPI-spec.

---

### Activity

**POST** `/api/Activity`  
Body: `CreateActivityRequest`  
Svar: `200 → GetActivityResponse`

**GET** `/api/Activity`  
Svar: `200 → array av GetActivityResponse`

**GET** `/api/Activity/{id}`  
Path: `id (int)`  
Svar: `200 → GetActivityResponse`

**PUT** `/api/Activity/{id}`  
Path: `id (int)`  
Body: `UpdateActivityRequest`  
Svar: `200`

**DELETE** `/api/Activity/{id}`  
Path: `id (int)`  
Svar: `200`

**GET** `/api/Activity/category/{categoryId}`  
Path: `categoryId (int)`  
Svar: `200 → array av GetActivityResponse`  
`404 → ProblemDetails`

---

### ActivityOccurence

**GET** `/api/ActivityOccurence`  
Svar: `200 → array av ActivityOccurenceResponseDTO`

**POST** `/api/ActivityOccurence`  
Body: `CreateActivityOccurrenceDTO`  
Svar: `201 → ActivityOccurenceResponseDTO`  
`400 → ProblemDetails`

**GET** `/api/ActivityOccurence/admin`  
Svar: `200 → array av ActivityOccurenceResponseDTO`

**GET** `/api/ActivityOccurence/{id}`  
Path: `id (int)`  
Svar: `200 → ActivityOccurenceResponseDTO`  
`404 → ProblemDetails`

**PUT** `/api/ActivityOccurence/{id}`  
Path: `id (int)`  
Body: `UpdateActivityOccurrenceDTO`  
Svar: `200 → ActivityOccurenceResponseDTO`  
`400, 404 → ProblemDetails`

**DELETE** `/api/ActivityOccurence/{id}`  
Path: `id (int)`  
Svar: `204 (No Content)` eller `404 → ProblemDetails`

**POST** `/api/ActivityOccurence/search`  
Body: `ActivityOccurenceSearchFilterDTO`  
Svar: `200 → array av ActivityOccurenceResponseDTO`

**POST** `/api/ActivityOccurence/general-search`  
Body: `GeneralSearchDTO`  
Svar: `200 → array av ActivityOccurenceResponseDTO`

**PUT** `/api/ActivityOccurence/cancel/{id}`  
Path: `id (int)`  
Svar: `204; 400 eller 404 → ProblemDetails`

**GET** `/api/ActivityOccurence/adminstatistics`  
Svar: `200`

---

### Auth

**POST** `/api/Auth`  
Body: `RegisterDTO`  
Svar: `200`

**POST** `/api/Auth/login`  
Body: `LoginDto`  
Svar: `200`

**PUT** `/api/Auth/{id}`  
Path: `id (string)`  
Svar: `200`

**PUT** `/api/Auth/reinstate/{id}`  
Path: `id (string)`  
Svar: `200`

**GET** `/api/Auth/AuthCheck`  
Svar: `200 → boolean`

---

### Booking

**GET** `/api/Booking`  
Svar: `200 → array av BookingReadDTO`

**POST** `/api/Booking`  
Body: `BookingCreateDTO`  
Svar: `200 → BookingReadDTO`

**GET** `/api/Booking/{id}`  
Path: `id (int)`  
Svar: `200 → BookingReadDTO`

**PUT** `/api/Booking/{id}`  
Path: `id (int)`  
Body: `BookingUpdateDTO`  
Svar: `200`

**DELETE** `/api/Booking/{id}`  
Path: `id (int)`  
Svar: `200`

**GET** `/api/Booking/bookings/user`  
Svar: `200 eller 404 → ProblemDetails`

**PUT** `/api/Booking/cancel/{id}`  
Path: `id (int)`  
Svar: `204; 400 eller 404 → ProblemDetails`

---

### Category

**GET** `/api/Category`  
Svar: `200`

**POST** `/api/Category`  
Body: `CategoryCreateDto`  
Svar: `201; 400 → ProblemDetails`

**GET** `/api/Category/{id}`  
Path: `id (int)`  
Svar: `200; 404 → ProblemDetails`

**PUT** `/api/Category/{id}`  
Path: `id (int)`  
Body: `CategoryUpdateDto`  
Svar: `200; 400 eller 404 → ProblemDetails`

**DELETE** `/api/Category/{id}`  
Path: `id (int)`  
Svar: `204; 404 → ProblemDetails`

---

### Location

**GET** `/api/Location`  
Svar: `200 → array av LocationRequestDTO`

**POST** `/api/Location`  
Body: `CreateLocationDTO`  
Svar: `201 → LocationRequestDTO; 400 eller 404 → ProblemDetails`

**GET** `/api/Location/{id}`  
Path: `id (int)`  
Svar: `200 → LocationRequestDTO; 404 → ProblemDetails`

**PUT** `/api/Location/{id}`  
Path: `id (int)`  
Body: `UpdateLocationDTO`  
Svar: `200 → LocationRequestDTO; 400 eller 404 → ProblemDetails`

**DELETE** `/api/Location/{id}`  
Path: `id (int)`  
Svar: `204; 404 → ProblemDetails`

---

### SubLocation

**POST** `/api/SubLocation`  
Body: `CreateSubLocationRequest`  
Svar: `200`

**GET** `/api/SubLocation`  
Svar: `200 → array av GetSubLocationResponse`

**GET** `/api/SubLocation/{id}`  
Path: `id (int)`  
Svar: `200 → GetSubLocationResponse`

**PUT** `/api/SubLocation/{id}`  
Path: `id (int)`  
Body: `UpdateSubLocationRequest`  
Svar: `200`

**DELETE** `/api/SubLocation/{id}`  
Path: `id (int)`  
Svar: `200`

---

### Weather

**POST** `/api/Weather/LocationForecast`  
Body: `WeatherLocationForecastRequestDTO`  
Svar: `200 → array av WeatherResponseDTO`

**POST** `/api/Weather/weather-at-time`  
Body: `WeatherAtTimeRequestDTO`  
Svar: `200 → WeatherResponseDTO`

---

## Felsökning

### Viktiga filer att granska

**Konfiguration/Secrets:**
- `appsettings.json`
- `.gitignore` (kontrollera att appsettings.json är ignorerad om det är avsett)

**Databas/Seed:**
- `SeedData.cs`
- `ToadContext.cs`

**Start/DI/Autentisering:**
- `Program.cs`

---

### Vanliga problem

- **Databasanslutning misslyckas:** Kontrollera `ConnectionStrings` i `appsettings.json`.  
- **JWT-fel:** Se till att `Jwt:Key` är korrekt och unik.  
- **CORS-fel:** Lägg till rätt ursprung i backend-konfigurationen om frontend körs på en annan port.

---

## Gruppens arbetsprocess (branch-strategi, PR-rutiner, kodstandard)

**Branch-strategi:**  
Använd `main` för produktionskod, `develop` för integration, och `feature/namn` för nya funktioner.

**PR-rutiner:**  
Öppna pull requests mot `develop`, minst en granskning krävs innan sammanslagning.  
Inkludera beskrivning och testresultat.

**Kodstandard:**  
Följ .NET och React best practices, inklusive konsistent namngivning  
(*PascalCase* för klasser, *camelCase* för variabler)  
och kommentarer för komplex logik.
