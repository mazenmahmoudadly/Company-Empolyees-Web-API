# Company Empolyees Web API

Lightweight ASP.NET Core (.NET 10) REST API for managing company employees. Includes JWT authentication, role/permission guidance, API versioning and Swagger UI.

## Requirements
- .NET 10 SDK
- Visual Studio 2026 or `dotnet` CLI
- (Development) LocalDB for the default connection string

## Quick start

1. Restore and build
   - Visual Studio: open solution and build.
   - CLI:
     dotnet restore
     dotnet build

2. Configure environment
   - Default dev profile (Properties/launchSettings.json) exposes:
     - HTTP: `http://localhost:50001`
     - HTTPS: `https://localhost:5002`
   - You can override with environment variable:
     - `ASPNETCORE_URLS="https://localhost:5002;http://localhost:5001"`

3. Run
   - Visual Studio: Run (F5) or Debug > Start Without Debugging (Ctrl+F5).
   - CLI:
     dotnet run --project CompanyEmployees

4. Open Swagger UI
   - HTTP: `http://localhost:5001/swagger`
   - HTTPS: `https://localhost:5002/swagger`

## Configuration

- Main settings: `appsettings.json`
  - `ConnectionStrings:sqlConnection` — default uses LocalDB.
  - `JwtSettings` — contains `Secret`, `validIssuer`, `validAudience`, `expires`. Update for production.

## Authentication & Swagger
- JWT Bearer authentication is configured.
- Swagger UI includes a Bearer token input. To test secured endpoints:
  1. Acquire a token from the authentication endpoint.
  2. Click "Authorize" in Swagger and paste `Bearer <token>`.

## Roles (intended for this project)
- Administrator
  - Global/system-level privileges.
  - Manage users, roles, system configuration and all resources.
  - Should be tightly controlled (MFA, audit).
- Manager
  - Scoped operational privileges (team/department).
  - Can manage employees/team data within assigned scope, but not global user/role configuration.
- Recommendation
  - Prefer policy/permission-based authorization: map roles to permission claims (e.g., `employees.manage`) and enforce scope via claims (e.g., `teamId`).
  - Example policy registration is in Program.cs (search for `AddAuthorization` / `RequireRole` / permission handlers).

## Database / EF Core
- Connection string points to LocalDB. If using EF Core migrations:
  - dotnet ef database update --project CompanyEmployees
- If you do not use migrations in this repo, create the DB according to your preferred workflow.

## Logging
- NLog is configured (see `nlog.config`). Logs are used for the global exception handler.


