using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.DBModels
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; } 
        public string Email { get; set; }

        public string artista { get; set; }
        public string pais { get; set; }
        public string ventas { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}