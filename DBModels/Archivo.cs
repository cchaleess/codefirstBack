using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.DBModels
{
    public class Archivo
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        public int Size { get; set; }
        public Referencia Referencia { get; set; }
    }
}