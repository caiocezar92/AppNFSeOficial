using Microsoft.EntityFrameworkCore;
using NFSe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Data
{
    public class NotaContext : DbContext
    {
        public DbSet<NotaModel> Notas { get; set; }

        public DbSet<ItemNotaModel> ItemNotas { get; set; }

        public DbSet<CertificadoModel> Certificado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.;initial catalog=AppNFSeOficial;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }

        // Campos que são chaves
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
