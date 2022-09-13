# ASP.NET Core Fundamentals

## Creating the New Project
* dotnet -h (see commands)
* To create, build, and run a project like we do in Visual Studio, you can use the command line:
* dotnet new webapp
* dotnet build
* dotnet run

## Editing Razor Pages
* VS uses some magic to automatically restart the web server when you make changes to source code files. 
* If you are using command line tools, you can do the same using:
* dotnet watch run

## Working with SQL Server and the Entity Framework Core
* dotnet ef -h
* dotnet tool install --global dotnet-ef --version 2.1.4
* dotnet ef dbcontext info -s ..\OdeToFood\OdeToFood.csproj

## Add migrations and database
* dotnet ef migrations add initialcreate -s ..\OdeToFood\OdeToFood.csproj
* dotnet ef database update -s ..\OdeToFood\OdeToFood.csproj