# ActiviGo

ActiviGo är en webbapplikation för att hitta, visa och boka aktiviteter i en kommun. Projektet består av en .NET 8 Web API-backend och en React + Vite-frontend, designad för att erbjuda en sömlös användarupplevelse.

---

## Översikt

ActiviGo är en webbapplikation för att hitta, visa och boka aktiviteter i en kommun. Systemet består av en .NET 8 Web API-backend och en React + Vite-frontend, designad för att erbjuda en sömlös användarupplevelse.

API:et kan användas av olika typer av aktivitetsledare för att skapa och hantera förekomster av aktiviteter. Det har CRUD-funktionalitet för att hantera platser, underplatser (som ett gym och en simhall i samma arena) och bokningar.

---

## 📑 Innehållsförteckning

- [Teknik](#teknik)
- [Arkitekturöversikt](#️-arkitekturöversikt)
- [Snabbstart och lokal körning](#snabbstart-och-lokal-körning)
- [API-endpoints](#api-endpoints)
- [Felsökning](#felsökning)
- [Gruppens arbetsprocess](#gruppens-arbetsprocess)
- [Team](#-team)

---

## Teknik

### Backend

| Teknologi | Version | Användning |
|-----------|---------|------------|
| .NET | 8.0 | Runtime & Framework |
| ASP.NET Core | 8.0 | Web API |
| Entity Framework Core | 8.0.20 | ORM & Databasåtkomst |
| SQL Server | 2022 | Databas |
| FluentValidation | 12.0.0 | Datavalidering |
| AutoMapper | 13.0.1 | DTO-mappning |
| JWT Bearer | 8.0.20 | Autentisering |
| RestSharp | 112.1.0 | HTTP-klient |
| Swashbuckle | 6.6.2 | API-dokumentation (Swagger) |

#### NuGet-paket

- `Microsoft.EntityFrameworkCore (8.0.20)`
- `Microsoft.EntityFrameworkCore.Design (8.0.20)`
- `Microsoft.EntityFrameworkCore.SqlServer (8.0.20)`
- `Microsoft.EntityFrameworkCore.Tools (8.0.20)`
- `AutoMapper (13.0.1)`
- `FluentValidation (12.0.0)`
- `FluentValidation.DependencyInjectionExtensions (12.0.0)`
- `Microsoft.AspNetCore.Authentication.JwtBearer (8.0.20)`
- `RestSharp (112.1.0)`
- `Swashbuckle.AspNetCore (6.6.2)`

### Frontend

| Teknologi | Version | Användning |
|-----------|---------|------------|
| React | 18.x | UI-bibliotek |
| Vite | 5.x | Build-tool & Dev Server |
| React Router | 6.x | Navigering |

<div align="right"><a href="#activigo">⬆ Till toppen</a></div>

---

## 🏗️ Arkitekturöversikt

API:et använder en N-tier-struktur med fyra distinkta lager: Infrastruktur hanterar kommunikation med databasen, WebAPI hanterar kommunikation med slutanvändare, Core hanterar kärnmodeller för programmet och Service hanterar affärslogik, mappning och validering.

### Backend N-tier arkitektur

```
┌─────────────────────────────────────────┐
│         WebAPI Layer (Controllers)      │
│  - HTTP endpoints, authentication       │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│         Service Layer                   │
│  - Business logic, validation, mapping  │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│         Infrastructure Layer            │
│  - DbContext, Repositories, Data access │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│         Core Layer                      │
│  - Domain models, interfaces            │
└─────────────────────────────────────────┘

```

### Katalogstruktur

```
ActiviGo/
├── ActiviGoApi/                    # Backend Solution
│   │
│   ├── ActiviGoApi.sln             # Visual Studio Solution
│   │
│   ├── ActiviGoApi.Core/           # Core Layer - Domänmodeller
│   │   ├── Models/                 # Entiteter
│   │   └── Interfaces/             # Interfaces
│   │
│   ├── ActiviGoApi.Infrastructur/  # Infrastructure Layer - Dataåtkomst
│   │   ├── Data/                   # DbContext & Seed
│   │   ├── Migrations/             # EF migrations
│   │   └── Repositories/           # Repository-implementationer
│   │
│   ├── ActiviGoApi.Services/       # Service Layer - Affärslogik
│   │   ├── DTOs/                   # Data Transfer Objects
│   │   ├── Services/               # Tjänster
│   │   ├── Mapping/                # AutoMapper profiles
│   │   ├── Validation/             # FluentValidation
│   │   └── Interfaces/             # Service interfaces
│   │
│   └── ActiviGoApi.WebApi/         # WebAPI Layer - Controllers
│       ├── Controllers/            # API-controllers
│       ├── Program.cs              # Startup & DI
│       ├── appsettings.json        # Konfiguration
│       └── Properties/             # Launch settings
│
└── Client/                         # Frontend-projekt (React + Vite)
    ├── public/                     # Statiska filer
    ├── src/
    │   ├── api/                    # API-anrop & services
    │   ├── assets/                 # Bilder, ikoner, etc.
    │   ├── Components/             # React-komponenter
    │   │   ├── Cards/              # Card-komponenter
    │   │   ├── Display/            # Display-komponenter
    │   │   ├── Layout/             # Layout-komponenter
    │   │   └── Pages/              # Sidkomponenter
    │   │       └── Admin/          # Admin-sidor
    │   ├── contexts/               # React Context providers
    │   ├── App.jsx                 # Root-komponent & routing
    │   ├── main.jsx                # Entry point
    │   └── responsive.css          # Responsive design styles
    |
    ├── package.json                # NPM dependencies & scripts
    ├── vite.config.js              # Vite konfiguration
    └── .env                        # Miljövariabler (gitignored)
```

### Viktiga filer och kataloger

#### Backend (API)

Platsen för backend-koden finns i `ActiviGoApi/`

- **ActiviGoApi.sln** - Visual Studio Solution-fil
  
- **ActiviGoApi.WebApi/**
  - `Program.cs` - Huvudfil för uppstart, konfiguration och Dependency Injection (DI)
  - `appsettings.json` - Konfigurationsfil (kan vara .gitignored för säkerhet)
  - `Controllers/` - API-controllers för alla endpoints
    
- **ActiviGoApi.Infrastructur/**
  - `ToadContext.cs` - EF Core DbContext för databasåtkomst
  - `SeedData.cs` - Inkluderar initial data (t.ex. kategorier, aktiviteter, platser)
  - `Migrations/` - Entity Framework migrationer
    - Exempel: `20251009092802_moreSeedData.cs`
    - Exempel: `20251023112936_activity-fix-and-seedlatlong.cs`
  - `Repositories/` - Repository-implementationer
      
- **ActiviGoApi.Core/**
  - `Models/` - Domänmodeller och entiteter
    - `Location.cs` och `SubLocation.cs` - Modeller för platser och underplatser
    - `Activity.cs`, `Booking.cs`, `Category.cs` - Övriga entiteter
  - `Interfaces/` - Interfaces för repositories och services
    
- **ActiviGoApi.Services/**
  - `DTOs/` - Data Transfer Objects
    - Exempel: `GetSubLocationResponse.cs`, `CreateActivityRequest.cs`
  - `Services/` - Affärslogik och tjänster
  - `Validation/` - FluentValidation validators
  - `Mapping/` - AutoMapper profiles

#### Frontend (Client)

Platsen för frontend-koden finns i `Client/`

- **package.json** - Definierar beroenden och skript
- **vite.config.js** - Vite konfiguration
- **Client/src/**
  - `Components/` - React-komponenter organiserade i underkataloger
  - `api/` - API-anrop och services
  - `contexts/` - React Context providers
  - `App.jsx` - Root-komponent med routing
  - `main.jsx` - Entry point

<div align="right"><a href="#activigo">⬆ Till toppen</a></div>

---

## Snabbstart och lokal körning

### Krav
- **Backend:** .NET 8 SDK
- **Frontend:** Node.js (med npm eller yarn)
- **Databas:** SQL Server (LocalDB eller full installation)

### Steg-för-steg

#### 1. Klona repositoryt

```sh
git clone https://github.com/Darkdusk234/ActiviGo.git
cd ActiviGo
```

#### 2. Konfigurera databasen

Projektet använder Entity Framework Core (Code-First). I `appsettings.json` hittar du anslutningssträngen för SQL Server.

Öppna `ActiviGoApi/ActiviGoApi.WebApi/appsettings.json` och justera anslutningssträngen efter din lokala setup:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ActiviGoDB;Trusted_Connection=true;TrustServerCertificate=true;"
  },
  "Jwt": {
    "Key": "din-hemliga-nyckel-minst-32-tecken-lång",
    "Issuer": "ActiviGoAPI",
    "Audience": "ActiviGoClient"
  }
}
```

**Viktigt:** Håll känslig data borta från versionering (använd t.ex. UserSecrets eller miljövariabler).

#### 3. Tillämpa migrations och seed-data

Navigera till `ActiviGoApi/ActiviGoApi.WebApi/` i en terminal och kör:

```sh
dotnet ef database update --project ../ActiviGoApi.Infrastructur/ActiviGoApi.Infrastructur.csproj
```

*Detta skapar databasen och tillämpar all seed-data från `SeedData.cs`.*

#### 4. Miljövariabler (valfritt för väder-API)

Lägg till en `.env`-fil i roten av `ActiviGoApi/ActiviGoApi.WebApi/` för SMHI eller annan väder-API-integration.  
Lägg till `.env` i `.gitignore` för att undvika att spara känslig data.

#### 5. Starta Backend

I samma katalog (`ActiviGoApi/ActiviGoApi.WebApi/`), kör:

```sh
dotnet build
dotnet run
```

*API:et startar på `https://localhost:7XXX` (porten visas i terminalen).*

#### 6. Starta Frontend

Öppna en ny terminal, navigera till `Client/` och kör:

```sh
npm install
npm run dev
```

*Frontend körs med Vite på `http://localhost:5173` (se `Client/vite.config.js` för konfiguration).*

### Databas och Seed-data

- **DbContext:** `ToadContext.cs` hanterar databasen
- **Seed-data:** Definieras i `SeedData.cs` och inkluderar kategorier, aktiviteter, platser och underplatser
- **Migrations:** Finns i `ActiviGoApi/ActiviGoApi.Infrastructur/Migrations/`

<div align="right"><a href="#activigo">⬆ Till toppen</a></div>

---

## API-endpoints

<details>
<summary><strong>Activity</strong> - Hantera aktiviteter</summary>

| Metod | Endpoint | Beskrivning | Svar |
|-------|----------|-------------|------|
| POST | `/api/Activity` | Skapa ny aktivitet<br>**Body:** `CreateActivityRequest` | `200 → GetActivityResponse` |
| GET | `/api/Activity` | Hämta alla aktiviteter | `200 → array av GetActivityResponse` |
| GET | `/api/Activity/{id}` | Hämta specifik aktivitet<br>**Path:** `id (int)` | `200 → GetActivityResponse` |
| PUT | `/api/Activity/{id}` | Uppdatera aktivitet<br>**Path:** `id (int)`<br>**Body:** `UpdateActivityRequest` | `200` |
| DELETE | `/api/Activity/{id}` | Ta bort aktivitet<br>**Path:** `id (int)` | `200` |
| GET | `/api/Activity/category/{categoryId}` | Hämta aktiviteter per kategori<br>**Path:** `categoryId (int)` | `200 → array av GetActivityResponse`<br>`404 → ProblemDetails` |

</details>

<details>
<summary><strong>ActivityOccurence</strong> - Hantera aktivitetsförekomster</summary>

| Metod | Endpoint | Beskrivning | Svar |
|-------|----------|-------------|------|
| GET | `/api/ActivityOccurence` | Hämta alla förekomster | `200 → array av ActivityOccurenceResponseDTO` |
| POST | `/api/ActivityOccurence` | Skapa ny förekomst<br>**Body:** `CreateActivityOccurrenceDTO` | `201 → ActivityOccurenceResponseDTO`<br>`400 → ProblemDetails` |
| GET | `/api/ActivityOccurence/admin` | Hämta alla förekomster (admin) | `200 → array av ActivityOccurenceResponseDTO` |
| GET | `/api/ActivityOccurence/{id}` | Hämta specifik förekomst<br>**Path:** `id (int)` | `200 → ActivityOccurenceResponseDTO`<br>`404 → ProblemDetails` |
| PUT | `/api/ActivityOccurence/{id}` | Uppdatera förekomst<br>**Path:** `id (int)`<br>**Body:** `UpdateActivityOccurrenceDTO` | `200 → ActivityOccurenceResponseDTO`<br>`400, 404 → ProblemDetails` |
| DELETE | `/api/ActivityOccurence/{id}` | Ta bort förekomst<br>**Path:** `id (int)` | `204 (No Content)`<br>`404 → ProblemDetails` |
| POST | `/api/ActivityOccurence/search` | Sök förekomster med filter<br>**Body:** `ActivityOccurenceSearchFilterDTO` | `200 → array av ActivityOccurenceResponseDTO` |
| POST | `/api/ActivityOccurence/general-search` | Generell sökning<br>**Body:** `GeneralSearchDTO` | `200 → array av ActivityOccurenceResponseDTO` |
| PUT | `/api/ActivityOccurence/cancel/{id}` | Avboka förekomst<br>**Path:** `id (int)` | `204 (No Content)`<br>`400, 404 → ProblemDetails` |
| GET | `/api/ActivityOccurence/adminstatistics` | Hämta statistik (admin) | `200` |

</details>

<details>
<summary><strong>Booking</strong> - Hantera bokningar</summary>

| Metod | Endpoint | Beskrivning | Svar |
|-------|----------|-------------|------|
| GET | `/api/Booking` | Hämta alla bokningar | `200 → array av BookingReadDTO` |
| POST | `/api/Booking` | Skapa ny bokning<br>**Body:** `BookingCreateDTO` | `200 → BookingReadDTO` |
| GET | `/api/Booking/{id}` | Hämta specifik bokning<br>**Path:** `id (int)` | `200 → BookingReadDTO` |
| PUT | `/api/Booking/{id}` | Uppdatera bokning<br>**Path:** `id (int)`<br>**Body:** `BookingUpdateDTO` | `200` |
| DELETE | `/api/Booking/{id}` | Ta bort bokning<br>**Path:** `id (int)` | `200` |
| GET | `/api/Booking/bookings/user` | Hämta användarens bokningar | `200 → array av BookingReadDTO`<br>`404 → ProblemDetails` |
| PUT | `/api/Booking/cancel/{id}` | Avboka<br>**Path:** `id (int)` | `204 (No Content)`<br>`400, 404 → ProblemDetails` |

</details>

<details>
<summary><strong>Auth</strong> - Autentisering</summary>

| Metod | Endpoint | Beskrivning | Svar |
|-------|----------|-------------|------|
| POST | `/api/Auth` | Registrera ny användare<br>**Body:** `RegisterDTO` | `200` |
| POST | `/api/Auth/login` | Logga in<br>**Body:** `LoginDto` | `200` |
| PUT | `/api/Auth/{id}` | Uppdatera användare<br>**Path:** `id (string)` | `200` |
| PUT | `/api/Auth/reinstate/{id}` | Återställ användare<br>**Path:** `id (string)` | `200` |
| GET | `/api/Auth/AuthCheck` | Kontrollera autentisering | `200 → boolean` |

</details>

<details>
<summary><strong>Category</strong> - Hantera kategorier</summary>

| Metod | Endpoint | Beskrivning | Svar |
|-------|----------|-------------|------|
| GET | `/api/Category` | Hämta alla kategorier | `200` |
| POST | `/api/Category` | Skapa ny kategori<br>**Body:** `CategoryCreateDto` | `201`<br>`400 → ProblemDetails` |
| GET | `/api/Category/{id}` | Hämta specifik kategori<br>**Path:** `id (int)` | `200`<br>`404 → ProblemDetails` |
| PUT | `/api/Category/{id}` | Uppdatera kategori<br>**Path:** `id (int)`<br>**Body:** `CategoryUpdateDto` | `200`<br>`400, 404 → ProblemDetails` |
| DELETE | `/api/Category/{id}` | Ta bort kategori<br>**Path:** `id (int)` | `204 (No Content)`<br>`404 → ProblemDetails` |

</details>

<details>
<summary><strong>Location</strong> - Hantera platser</summary>

| Metod | Endpoint | Beskrivning | Svar |
|-------|----------|-------------|------|
| GET | `/api/Location` | Hämta alla platser | `200 → array av LocationRequestDTO` |
| POST | `/api/Location` | Skapa ny plats<br>**Body:** `CreateLocationDTO` | `201 → LocationRequestDTO`<br>`400, 404 → ProblemDetails` |
| GET | `/api/Location/{id}` | Hämta specifik plats<br>**Path:** `id (int)` | `200 → LocationRequestDTO`<br>`404 → ProblemDetails` |
| PUT | `/api/Location/{id}` | Uppdatera plats<br>**Path:** `id (int)`<br>**Body:** `UpdateLocationDTO` | `200 → LocationRequestDTO`<br>`400, 404 → ProblemDetails` |
| DELETE | `/api/Location/{id}` | Ta bort plats<br>**Path:** `id (int)` | `204 (No Content)`<br>`404 → ProblemDetails` |

</details>

<details>
<summary><strong>SubLocation</strong> - Hantera underplatser</summary>

| Metod | Endpoint | Beskrivning | Svar |
|-------|----------|-------------|------|
| POST | `/api/SubLocation` | Skapa ny underplats<br>**Body:** `CreateSubLocationRequest` | `200` |
| GET | `/api/SubLocation` | Hämta alla underplatser | `200 → array av GetSubLocationResponse` |
| GET | `/api/SubLocation/{id}` | Hämta specifik underplats<br>**Path:** `id (int)` | `200 → GetSubLocationResponse` |
| PUT | `/api/SubLocation/{id}` | Uppdatera underplats<br>**Path:** `id (int)`<br>**Body:** `UpdateSubLocationRequest` | `200` |
| DELETE | `/api/SubLocation/{id}` | Ta bort underplats<br>**Path:** `id (int)` | `200` |

</details>

<details>
<summary><strong>Weather</strong> - Väderprognos</summary>

| Metod | Endpoint | Beskrivning | Svar |
|-------|----------|-------------|------|
| POST | `/api/Weather/LocationForecast` | Hämta väderprognos för plats<br>**Body:** `WeatherLocationForecastRequestDTO` | `200 → array av WeatherResponseDTO` |
| POST | `/api/Weather/weather-at-time` | Hämta väder för specifik tid<br>**Body:** `WeatherAtTimeRequestDTO` | `200 → WeatherResponseDTO` |

</details>

<div align="right"><a href="#activigo">⬆ Till toppen</a></div>

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

### Vanliga problem

- **Databasanslutning misslyckas:** Kontrollera `ConnectionStrings` i `appsettings.json`.  
- **JWT-fel:** Se till att `Jwt:Key` är korrekt och unik.  
- **CORS-fel:** Lägg till rätt ursprung i backend-konfigurationen om frontend körs på en annan port.

<div align="right"><a href="#activigo">⬆ Till toppen</a></div>

---

## Gruppens arbetsprocess

**Branch-strategi:**  
Använd `main` för produktionskod, `develop` för integration, och `feature/namn` för nya funktioner.

**PR-rutiner:**  
Öppna pull requests mot `develop`, minst en granskning krävs innan sammanslagning.  
Inkludera beskrivning och testresultat.

**Kodstandard:**  
Följ .NET och React best practices, inklusive konsistent namngivning  
(*PascalCase* för klasser, *camelCase* för variabler)  
och kommentarer för komplex logik.

---

## 👥 Team

Utvecklare i ActiviGo Team Toad

- Johan Svensson: **"Darkdusk234"** https://github.com/Darkdusk234
- Leon Johansson: **"Conixen"** https://github.com/Conixen
- Gustav Eriksson Söderlund: **"GoodStuff15"** https://github.com/GoodStuff15
- Edgar Skönnegård: **"Edgarskonnegard"** https://github.com/Edgarskonnegard

<div align="right"><a href="#activigo">⬆ Till toppen</a></div>

---
