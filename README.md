
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

## generar modelos y dbcontext 
Scaffold-DbContext "Server=localhost;Database=medexplora;User=root;Password=culoseco" Pomelo.EntityFrameworkCore.MySql -OutputDir Models/DB -Force  

## database de prueba  
CREATE DATABASE medexplora;  
USE medexplora;  

CREATE TABLE parte_cuerpo (  
    id INT AUTO_INCREMENT PRIMARY KEY,  
    nombre VARCHAR(100) NOT NULL,  
    descripcion TEXT,  
    enfermedades_asociadas TEXT  
);  

INSERT INTO parte_cuerpo (nombre, descripcion, enfermedades_asociadas) VALUES  
('Pulmones', 'Órganos responsables del intercambio de gases en la respiración.', 'Neumonía, Asma, EPOC'),  
('Corazón', 'Bombea la sangre a través del sistema circulatorio.', 'Arritmias, Infarto, Insuficiencia cardíaca'),  
('Hígado', 'Órgano vital que filtra toxinas y produce bilis.', 'Hepatitis, Cirrosis'),  
('Riñones', 'Filtran desechos y regulan líquidos del cuerpo.', 'Insuficiencia renal, Cálculos renales'),  
('Cerebro', 'Centro del sistema nervioso encargado de procesar información.', 'Epilepsia, Alzheimer, Tumores cerebrales');  
