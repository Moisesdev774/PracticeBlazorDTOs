using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PracticeBlazor.DTOs.ClienteDTOs
{
    public class CreateClienteDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El campo nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set;}
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo Apellido es requerido")]
        [MaxLength(50, ErrorMessage = "El campo Apellido no puede tener más de 50 caracteres")]
        public string Apellido { get; set;}
        [Display(Name = "Direccion")]
        [MaxLength(255, ErrorMessage = "El campo Direccion no puede tener más de 255 caracteres")]
        public string? Direccion { get; set; }
    }
}
