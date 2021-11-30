using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.DTO
{
    public class UsuarioDTO
    {
        public int ID { get; set; }
       // [Required(ErrorMessage = "This field is required")]
       // [StringLength(200, ErrorMessage ="Debe tener menos de 200 caracteres")]
        public string Nombre { get; set; }
        public string Email { get; set; }

        public string pepe { get; set; }
    }
}
