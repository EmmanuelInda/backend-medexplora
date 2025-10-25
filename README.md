# backend-medexplora

#instalar en la terminal
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Pomelo.EntityFrameworkCore.MySql

# o en el pmc
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Pomelo.EntityFrameworkCore.MySql


# configurar appsettings.json
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

