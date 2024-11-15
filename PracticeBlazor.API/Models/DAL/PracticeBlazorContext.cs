// Importar el espacio de nombres necesarios para PracticeBlazorContext
using Microsoft.EntityFrameworkCore;
using PracticeBlazor.API.Models.EN;

// Define la clase PracticeBlazorContext que hereda de DbContext
namespace PracticeBlazor.API.Models.DAL
{
    public class PracticeBlazorContext : DbContext
    {
        // Constructor que toma DbContextOptions como parámetro para configurar la conexión a la base de datos
        public PracticeBlazorContext(DbContextOptions<PracticeBlazorContext> options) : base(options)
        { 
        }

        // Define un DbSet llamado "Cliente"  que representa una tabla de clientes en la base de datos
        public DbSet<Cliente> Clientes { get; set; }
    }
}
