using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Empleados.Models
{
    public partial class DemoDbContext : DbContext
    {
        public DemoDbContext()
        {
        }

        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=local.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
        }
        public virtual int sp_consulta_de_tranferencias_pendientes_de_recepcionar(string cod_estab)
        {
            return Database.ExecuteSqlCommand("sp_consulta_de_tranferencias_pendientes_de_recepcionar @p0 ", parameters: cod_estab);
        }
        public DbSet<Employe> Empleados { get; set; }
        public DbSet<Client> Clientes { get; set; }
        public DbSet<IdRecord> Foliados { get; set; }
        public DbSet<PortFolio> Carteras { get; set; }
        public DbSet<Payments> Pagos { get; set; }
    }
}
