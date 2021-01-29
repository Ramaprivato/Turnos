using System;
using Microsoft.EntityFrameworkCore;

namespace Turnos.Models{

    public class TurnosContext : DbContext
    
    {

     public TurnosContext(DbContextOptions<TurnosContext> opciones) : base(opciones)
     { 
      

     }
      
      public DbSet<Especialidad> Especialidad{get; set;}//definiendo objeto especialidad del tipo DBSET (es una entidad), dbset es del tipo especialidad (modelo definido en la tabla)

      public DbSet<Paciente> Paciente {get;set;}
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {

     modelBuilder.Entity<Especialidad>(entidad => {

         entidad.ToTable("Especialidad");//Le doy nombre a la tabla
         entidad.HasKey(e => e.IdEspecialidad); //indico que la PK de ta tabla sera idEspecialidad
         entidad.Property(e => e.Descripcion)//especificar que el campo descripcion "No puede ser nulo"
         .IsRequired()
         .HasMaxLength(200)
         .IsUnicode(false);
     });


      modelBuilder.Entity<Paciente>(entidad => 
      {
        entidad.ToTable("Paciente");
        entidad.HasKey(p => p.IdPaciente);
        entidad.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);


        entidad.Property(p => p.Apellido)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        entidad.Property(p => p.Direccion)
        .IsRequired()
        .HasMaxLength(250)
        .IsUnicode(false);

        entidad.Property(p => p.Telefono)
        .IsRequired()
        .HasMaxLength(20)
        .IsUnicode(false);

        entidad.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(100)
        .IsUnicode(false);
      }
      );

      
      } 
    
    }


}