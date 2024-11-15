// Importa los espacios de nombres necesarios
using PracticeBlazor.API.Models.EN;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

// Define la clase ClienteDAL que se utiliza para interactuar
// con los datos de los clientes en la base da datos

namespace PracticeBlazor.API.Models.DAL
{
    public class ClienteDAL
    {
        readonly PracticeBlazorContext _context;

        // Contructor que recibe un objeto PracticeBlazorContext para
        // interactuar con la base de datos

        public ClienteDAL(PracticeBlazorContext practiceBlazorContext)
        {
            _context = practiceBlazorContext;
        }

        // Método para crear un nuevo cliente en la base de datos
        public async Task<int> Create (Cliente cliente)
        {
            _context.Add(cliente);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener un cliente por su ID
        public async Task<Cliente> GetById(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(s => s.Id == id);
            return cliente != null ? cliente : new Cliente();
        }

        // Método para editar un cliente existente en la base de datos
        public async Task<int> Edit(Cliente cliente)
        {
            int result = 0;
            var clienteUpdate = await GetById(cliente.Id);
            if (clienteUpdate.Id != 0)
            {
                //Actualiza los datos del cliente
                clienteUpdate.Nombre = cliente.Nombre;
                clienteUpdate.Apellido = cliente.Apellido;
                clienteUpdate.Direccion = cliente.Direccion;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        //Método para eliminar un cliente de la base de datos por su ID
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var clienteDelete = await GetById(id);
            if (clienteDelete.Id > 0)
            {
                // Elimina el cliente de la base de datos
                _context.Clientes.Remove(clienteDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método privado para construir una consulta IQueryable para buscar clientes con filtros
        private IQueryable<Cliente> Query(Cliente cliente)
        {
            var query = _context.Clientes.AsQueryable();
            if (!string.IsNullOrWhiteSpace(cliente.Nombre))
                query = query.Where(s => s.Nombre.Contains(cliente.Nombre));
            if(!string.IsNullOrWhiteSpace(cliente.Apellido))
                query = query.Where(s => s.Apellido.Contains(cliente.Apellido));
            return query;
        }

        // Método para contar la cantidad de resultados de búsqueda con filtro
        public async Task<int> CountSearch(Cliente cliente)
        {
            return await Query(cliente).CountAsync();
        }

        // Método para buscar cliente con filtro, paginación y ordenamiento
        public async Task<List<Cliente>> Search(Cliente cliente, int take= 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(cliente);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();

        }
    }

}
