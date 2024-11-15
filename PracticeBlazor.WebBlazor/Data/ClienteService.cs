// Importancia del espacio de nombres para los DTOs relacionados con los clientes
using PracticeBlazor.DTOs.ClienteDTOs;
using System.ComponentModel.DataAnnotations;

namespace PracticeBlazor.WebBlazor.Data
{
    public class ClienteService
    {
        readonly HttpClient _httpClientPRACTAPI;

        // Constructor que recibe una instancia de IHttpClientFactory para crear el cliente HTTP
        public ClienteService(IHttpClientFactory httpClientFactory)
        {
            _httpClientPRACTAPI = httpClientFactory.CreateClient("PRACTAPI");
        }

        // Método para buscar clientes utilizando una solicitud HTTP POST
        public async Task<SearchResultClienteDTO> Search(SearchQueryClienteDTO searchQueryClienteDTO)
        {
            var response = await _httpClientPRACTAPI.PostAsJsonAsync("buscartodos/cliente/", searchQueryClienteDTO);  // Esta es la ruta que tiene que coinsidir con la de la API
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultClienteDTO>();
                return result ?? new SearchResultClienteDTO();
            }
            return new SearchResultClienteDTO(); // Devolver un objeto vacío en caso de error o respuesta no exitosa
        }

        //´Método para obtener un cliente por su ID utilizando una solicitud HTTP GET
        public async Task<GetIdResultClienteDTO> GetById(int id)
        {
            var response = await _httpClientPRACTAPI.GetAsync("obtener/cliente/" + id);  // Esta es la ruta que tiene que coinsidir con la de la API
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultClienteDTO>();
                return result ?? new GetIdResultClienteDTO();
            }
            return new GetIdResultClienteDTO(); // Devolcer un objeto vacío en caso de error o respuesta no exitosa
        }

        // Método para crear un nuevo cliente utilizando una solicitud HTTP POST
        public async Task<int> Create(CreateClienteDTO createClienteDTO)
        {
            int result = 0;
            var response = await _httpClientPRACTAPI.PostAsJsonAsync("crear/cliente/", createClienteDTO);  // Esta es la ruta que tiene que coinsidir con la de la API
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        // Método para editar un cliente existente utilizando una solicitud HTTP PUT
        public async Task<int> Edit(EditClienteDTO editClienteDTO)
        {
            int result = 0;
            var response = await _httpClientPRACTAPI.PutAsJsonAsync("edit/cliente/", editClienteDTO);   // Esta es la ruta que tiene que coinsidir con la de la API
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        // Método para eliminar un cliente por su ID utilizando una solicitud HTTP DELETE
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var response = await _httpClientPRACTAPI.DeleteAsync("eliminar/cliente/" + id);   // Esta es la ruta que tiene que coinsidir con la de la API
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

    }
}
