using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.DBModels
{
    public class Consulta
    {
        [Key]
        public int ID { get; set; }
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Usuario { get; set; }
        public List<Referencia> Referencias { get; set; }
    }
}
