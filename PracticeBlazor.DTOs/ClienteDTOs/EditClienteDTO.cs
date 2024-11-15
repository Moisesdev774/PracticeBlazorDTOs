using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PracticeBlazor.DTOs.ClienteDTOs
{
    public class EditClienteDTO
    {
        public EditClienteDTO(GetIdResultClienteDTO getIdResultClienteDTO)
        {
            Id = getIdResultClienteDTO.Id;
            Nombre = getIdResultClienteDTO.Nombre;
            Apellido = getIdResultClienteDTO.Apellido;
            Direccion = getIdResultClienteDTO.Direccion;
        }
        public EditClienteDTO()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
        }
        [Required(ErrorMessage = "El campo Id es obligatorio")]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres")]
        public string Nombre {  get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Apellido no puede tener más de 50 caracteres")]
        public string Apellido { get; set; }
        [Display(Name = "Direccion")]
        [MaxLength(255, ErrorMessage = "El campo Direccion no puede tener más de 255 caracteres")]
        public string? Direccion { get; set; }
    }
}
