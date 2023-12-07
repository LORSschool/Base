using Microsoft.EntityFrameworkCore;
using Base.Shared.Modelos;

namespace Base.Server.Data
{
    public class BasedeDatosContext : DbContext
    {
        public BasedeDatosContext(DbContextOptions<BasedeDatosContext> options) : base(options)
        {
        }
        public DbSet<Carro> Carros { get; set; }

        public DbSet<Ciudad> Ciudades { get; set; } 

        public DbSet<Condicion> Condiciones { get; set;}

    }
}

