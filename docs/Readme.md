# Match App - Web Api

Web Api application for match management and its ods

## Architecture 

Using Clean Architecture Layers

- MatchAPP.API
- MatchAPP.Data
- MatchAPP.Domain
- MatchAPP.UnitTest

## Technologies Used

- ASP.NET Core 3.1
- Entity Framework Core
- MSSQL Server

## Application Features

### Swagger

- UI Endpoint: /swagger/index.html
- Json Endpoint: /swagger/v1/swagger.json

### Healthcheck

- Endpoint: /healthcheck

### CORS

### Docker Support

- Run build-run-docker.ps1 to run the web api on container, it will run docker-compose.yml to setup mssql server and the app

*Make sure you have installed dotnet sdk*

### Migrations

Migrations folder located on project MatchAPP.Data

**Steps**
1. Open command line
2. Navigate to MatchAPP.Data
3. Run dotnet ef migrations add -c MatchContext --startup-project ../MatchAPP.API/ {migrationname}
4. On application start UseDatabaseMigrate will apply the migrations to database

*Make sure you have installed dotnet sdk and added the tool dotnet ef*