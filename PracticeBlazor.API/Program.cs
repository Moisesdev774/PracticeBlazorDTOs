// Importa los espacios de nombres necesarios para el proyecto
using PracticeBlazor.API.Endpoints;
using PracticeBlazor.API.Models.DAL;
using Microsoft.EntityFrameworkCore;

// Crear un nuevo constructor de la aplicación web
var builder = WebApplication.CreateBuilder(args);

// Agrega servicios para habiliar la generación de documentación de API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura y agrega un contexto de base de datos para Entity Framework Core
builder.Services.AddDbContext<PracticeBlazorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"))
);

// Agrega una instancia de la ClienteDAL como un servicio para la inyeccion de dependencias
builder.Services.AddScoped<ClienteDAL>();

// Construye la aplicación web
var app = builder.Build();

// Agrega los puntos finales relacionados con los clientes a la aplicacion
app.AddClienteEndpoints();

// Verifica si la aplicación se está ejecutando en un entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    // Habilita el uso de Swagger para la documentación de la API
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Agrega middleware para redirigir las solicitudes HTTP a HTTPS
app.UseHttpsRedirection();

// Ejecuta la aplicación
app.Run();
