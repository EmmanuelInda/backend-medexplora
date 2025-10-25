
# backend-medexplora

## Instalación de dependencias

En la terminal:
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Pomelo.EntityFrameworkCore.MySql

O en el Package Manager Console:
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Pomelo.EntityFrameworkCore.MySql

## Configurar appsettings.json

{
"ConnectionStrings": {
"TestBase": "Server=localhost;Database=medexplora;User=root;Password=culoseco;TreatTinyAsBoolean=true"
},
"Logging": {
"LogLevel": {
"Default": "Information",
"Microsoft.AspNetCore": "Warning"
}
},
"AllowedHosts": "*"
}


¿Quieres que haga eso también?

