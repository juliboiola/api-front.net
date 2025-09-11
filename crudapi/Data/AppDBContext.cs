using Microsoft.EntityFrameworkCore;
using crudapi.Models;

namespace crudapi.Data
{
    public class AppDBContext : DbContext
    {
                             //objeto que contiene config necesarias para crear una instancia del contexto
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        //Declara una propiedad que representa una tabla Empleados en la db, donde cada fila es una instancia de la clase Empleado
        public DbSet<Empleado> Empleados { get; set; }
        
        //configuraciones
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empleado>(tb => {
                tb.HasKey(col => col.IdEmpleado);

                tb.Property(col => col.IdEmpleado)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre).HasMaxLength(50);
                tb.Property(col => col.Email).HasMaxLength(100);
            });

            modelBuilder.Entity<Empleado>().ToTable("Empleado");
        
        }
    }
}
