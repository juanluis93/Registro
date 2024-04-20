using Microsoft.EntityFrameworkCore;
using Registro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.DAL.Context
{
    public class VisitantesContext:DbContext
    { 
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Edificio> Edificios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Visitante> Visitantes { get; set; }

        public VisitantesContext(DbContextOptions<VisitantesContext> options) : base(options){

        }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aula>().ToTable("Aulas", "dbo");
            modelBuilder.Entity<Edificio>().ToTable("Edificios", "dbo");
            modelBuilder.Entity<Usuarios>().ToTable("Usuarios", "dbo");
            modelBuilder.Entity<Visitante>().ToTable("Visitantes", "dbo");
        }
    }
}
