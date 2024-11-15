using PracticeBlazor.API.Models.DAL;
using PracticeBlazor.API.Models.EN;
using PracticeBlazor.DTOs.ClienteDTOs;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PracticeBlazor.API.Endpoints
{
    public static class ClienteEndpoint
    {
        // Método para configurar los endpoints relacionados con los clientes
        public static void AddClienteEndpoints(this WebApplication app)
        {
            //Configurar un endpoint de tipo POST para buscar clientes #AL BUSCAR SOLO UNO DEVUELVE TODOS
            app.MapPost("buscartodos/cliente", async (SearchQueryClienteDTO clienteDTO, ClienteDAL clienteDAL) =>
            {
                // Crear un objeto "Cliente" a partir de los datos proporcionados
                var cliente = new Cliente
                {
                    Nombre = clienteDTO.Nombre_Like != null ? clienteDTO.Nombre_Like : string.Empty,
                    Apellido = clienteDTO.Apellido_Like != null ? clienteDTO.Apellido_Like : string.Empty
                };

                // Iniciar una lista de clientes y una variable para contar las filas
                var clientes = new List<Cliente>();
                int countRow = 0;

                // Verificar si se debe enviar la cantidad de filas
                if (clienteDTO.SendRowCount == 2)
                {
                    // Realizar una búsqueda de clientes y contar las filas
                    clientes = await clienteDAL.Search(cliente, skip: clienteDTO.Skip, take: clienteDTO.Take);
                    if (clientes.Count() > 0)
                        countRow = await clienteDAL.CountSearch(cliente);
                }
                else
                {
                    // Realizar una búsqueda de clientes sin contar las filas
                    clientes = await clienteDAL.Search(cliente, skip: clienteDTO.Skip, take: clienteDTO.Take);
                }
                // Crear un objeto 'SearchResultClienteDTO' para almacenar los resultados
                var clienteResult = new SearchResultClienteDTO
                {
                    Data = new List<SearchResultClienteDTO.ClienteDTO>(),
                    CountRow = countRow
                };

                // Mapear los resultados a objetos 'ClienteDTO' y agregarlos al resultado
                clientes.ForEach(s =>
                {
                    clienteResult.Data.Add(new SearchResultClienteDTO.ClienteDTO
                    {
                        Id = s.Id,
                        Nombre = s.Nombre,
                        Apellido = s.Apellido,
                        Direccion = s.Direccion
                    });
                });

                // Devolver los resultados
                return clienteResult;
            });

            // Configurar un endpoint de tipo GET para obtener un cliente por ID
            app.MapGet("obtener/cliente/{id}", async (int id, ClienteDAL clienteDAL) =>
            {
                // Obtener un cliente por ID
                var cliente = await clienteDAL.GetById(id);

                // Crear un objeto 'GetResultClienteDTO' para almacenar el resultado
                var clienteResult = new GetIdResultClienteDTO
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Direccion = cliente.Direccion
                };

                // Verificar si se encontró el cliente y devolver la respuesta correspondiente
                if (clienteResult.Id > 0)
                    return Results.Ok(clienteResult);
                else
                    return Results.NotFound(clienteResult);
            });

            // Configurar un endpoint de tipo POST para crear un nuevo cliente 
            app.MapPost("crear/cliente", async (CreateClienteDTO clienteDTO, ClienteDAL clienteDAL) =>
            {
                // Crear un objeto 'Cliente' a partiir de los datos proporcionados
                var cliente = new Cliente
                {
                    Nombre = clienteDTO.Nombre,
                    Apellido = clienteDTO.Apellido,
                    Direccion = clienteDTO.Direccion
                };

                // Intentar crear el cliente y devolver el resultado correspondiente
                int result = await clienteDAL.Create(cliente);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            // Configurar un endpoint de tipo PUT para editar un cliente existente
            app.MapPut("edit/cliente", async (EditClienteDTO clienteDTO, ClienteDAL clienteDAL) =>
            {
                // Crear un objeto 'Cliente' a partir de los datos proporcionados
                var cliente = new Cliente
                {
                    Id = clienteDTO.Id,
                    Nombre = clienteDTO.Nombre,
                    Apellido = clienteDTO.Apellido,
                    Direccion = clienteDTO.Direccion
                };

                // Intentar editar el cliente y devolver el resultado correspondiente
                int result = await clienteDAL.Edit(cliente);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            // Configurar un endpoint de tipo DELETE para eliminar un cliente por ID
            app.MapDelete("eliminar/cliente/{id}", async (int id, ClienteDAL clienteDAL) =>
            {
                // Intenta eliminar el cliente y devolver el resultado correspondiente
                int result = await clienteDAL.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
        }
    }
}
