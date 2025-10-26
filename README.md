# ActiviGo

## - What is it?

ActiviGo! is an API for managing an event booking system. It can be used by activity leaders of different kinds
to create and manage different occurences of one ore more activities. It also has CRUD functionality for handling
locations, "sub-locations" (like a gym and a swimming pool located in the same arena) and bookings for the
aforementioned activites. 

### - Technology

#### - Backend 
Built with C#, ASP.NET Core and Entity Framework.

Database using SQL Server. 

Data validation using FluentValidation
DTO-Object Mapping using Automapper 
Authorization/Authentication with Microsoft Identity

#### - Frontend
Built with JavaScript, React and Vite. 

Also using React Router, (something something!)

## - Architecture overview
The API uses an N-tier strucute with 4 distinct layers:
#### Infrastructure
- Handles communication with the database
#### WebAPI
- Handles communication with end users
#### Core
- Handles core business models for the program
#### Service
- Handles business logic, mapping and validation


## - Instruktioner för lokal körning (inkl. migrations/seed, env‑variabler för väder‑API‑nyckel).


## - API‑dokumentation och beskrivning av centrala flöden.
## - Gruppens arbetsprocess (branch‑strategi, PR‑rutiner, kodstandard).
