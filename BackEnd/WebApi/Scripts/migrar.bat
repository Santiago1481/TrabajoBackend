@echo off
SET /P Nombre=Escribe el nombre de la migracion: 

echo.
echo --- 1. Generando para PostgreSQL ---
dotnet ef migrations add %Nombre% --context ApplicationDbContext --project ../Entity --startup-project . --output-dir Migrations/PostgresMigrations

echo.
echo --- 2. Generando para MySQL ---
dotnet ef migrations add %Nombre% --context MySqlDbContext --project ../Entity --startup-project . --output-dir Migrations/MySqlMigrations

echo.
echo --- 3. Generando para SQL Server ---
dotnet ef migrations add %Nombre% --context SqlServerDbContext --project ../Entity --startup-project . --output-dir Migrations/SqlServerMigrations

echo.
pause