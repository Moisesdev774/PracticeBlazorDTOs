using PracticeBlazor.WebBlazor.Data; // Importa el espacio de nombres donde se encuentra CustomerService

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor de dependencias.
builder.Services.AddRazorPages(); // Agrega soporte para p�ginas Razor
builder.Services.AddServerSideBlazor(); // Agrega soporte para Blazor en el lado del servidor

// Registra CustomerService como un servicio Singleton (una instancia �nica para toda la aplicaci�n)
builder.Services.AddSingleton<ClienteService>();

// Configura y agrega un cliente HTTP con nombre "CRMAPI"
builder.Services.AddHttpClient("PRACTAPI", c =>
{
    // Configura la direcci�n base del cliente HTTP desde la configuraci�n
    c.BaseAddress = new Uri(builder.Configuration["UrlsAPI:PracticeBlazor"]);
    // Puedes configurar otras opciones del HttpClient aqu� seg�n sea necesario
});

var app = builder.Build(); // Crea una instancia de la aplicaci�n web

// Configura el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Maneja excepciones en caso de errores
    // El valor HSTS predeterminado es de 30 d�as. Puedes cambiarlo para escenarios de producci�n.
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redirige las solicitudes HTTP a HTTPS

app.UseStaticFiles(); // Habilita el uso de archivos est�ticos como CSS, JavaScript, im�genes, etc.

app.UseRouting(); // Configura el enrutamiento de solicitudes

app.MapBlazorHub(); // Mapea BlazorHub para habilitar la funcionalidad de Blazor en tiempo real
app.MapFallbackToPage("/_Host"); // Mapea la p�gina _Host para servir aplicaciones Blazor

app.Run(); // Inicia la aplicaci�n web