using MedExploraAPI.Servicio;
using Microsoft.EntityFrameworkCore;
using MedExploraAPI.Models.DB;

var builder = WebApplication.CreateBuilder(args);

// Obtiene la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("TestBase");

// Configura el contexto de la base de datos para usar MySQL
builder.Services.AddDbContext<MedexploraContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Agrega servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddScoped<ParteCuerpoServicio>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


    var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
