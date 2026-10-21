# BikeServis

Web aplikacija za servis bicikala: klijent zakazuje termin, mehaničar ga vodi kroz statuse.
Stack: .NET 8 (Web API, EF Core, SQLite) + Angular 18.

## Pokretanje

### Backend
```bash
cd backend
dotnet tool install --global dotnet-ef   # jednom
dotnet ef migrations add Pocetno --project BikeServis.Api
dotnet run --project BikeServis.Api       # http://localhost:5000/swagger
dotnet test
```

### Frontend
```bash
npx @angular/cli@18 new frontend --standalone --routing=false --style=css --skip-git
cp -r frontend-overlay/src/* frontend/src/   # prepisuje app.* fajlove
cd frontend && npm start                      # http://localhost:4200
```

## Tok rada
Svaki zadatak: issue → grana `N-opis` → commiti s `(#N)` → PR s `Closes #N` → review → merge.
Dijagram klasa: `docs/dijagram-klasa.md`.
