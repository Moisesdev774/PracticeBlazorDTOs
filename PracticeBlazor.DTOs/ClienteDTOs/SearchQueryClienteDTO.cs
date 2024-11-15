using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PracticeBlazor.DTOs.ClienteDTOs
{
    public class SearchQueryClienteDTO
    {
        [Display(Name = "Nombre")]
        public string? Nombre_Like {  get; set; }
        [Display(Name = "Apellido")]
        public string? Apellido_Like {  get; set; }
        [Display(Name = "CantReg X Pagina")]
        public int Skip {  get; set; }
        public int Take {  get; set; }
        /// <summary>
        /// 1 = No se cuenta los resultados de la busqueda
        /// 2 = Cuenta los resultados de la busqueda
        /// </summary>
        public byte SendRowCount {  get; set; }
    }
}
