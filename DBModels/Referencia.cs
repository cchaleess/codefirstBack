using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.DBModels
{
    public class Referencia
    {
        [Key]
        public int ID { get; set; }
        public string Ref { get; set; }
        public int UnidadesPropuesta { get; set; }
        public List<Archivo> Archivos { get; set; }

    }
}
