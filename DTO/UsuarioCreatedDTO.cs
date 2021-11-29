using CodeFirst.ValidationsAtributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.DTO
{
    public class UsuarioCreatedDTO
    {
    
        public int id { get; set; }
        //[ValidationAttributeIntGreaterThanZero(ErrorMessage = "El campo tiene que ser mas grande que 0.")]
        //[ValidationAttributeLengthGreaterthanFive(ErrorMessage = "la longitud del campo tiene que ser mas grande que 0")]
        public string Nombre { get; set; }
       
        public string Email { get; set; }
    }
}
