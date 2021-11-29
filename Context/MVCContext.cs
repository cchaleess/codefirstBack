using CodeFirst.DBModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CodeFirst.Context
{
    public class MVCContext : DbContext
    {
        public MVCContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Archivo> Archivo { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Referencia> Referencia { get; set; }
    }
}
