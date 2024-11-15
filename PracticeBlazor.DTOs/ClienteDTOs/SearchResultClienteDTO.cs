using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PracticeBlazor.DTOs.ClienteDTOs
{
    public class SearchResultClienteDTO
    {
        public int CountRow {  get; set; }
        public List<ClienteDTO> Data {  get; set; }
        public class ClienteDTO
        {
            public int Id { get; set; }
            [Display(Name = "Nombre")]
            public string Nombre { get; set; }
            [Display(Name = "Apellido")]
            public string Apellido { get; set; }
            [Display(Name = "Direccion")]
            public string? Direccion { get; set; }
        }
    }
}
