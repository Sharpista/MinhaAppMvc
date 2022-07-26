using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevIO.Data.Context
{
    public  class DevIOContext:DbContext
    {
        public DevIOContext()
        {

        }
        public DevIOContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevIOContext).Assembly);

            //evitar quando esquecido algum mapeando de por nvarchar max, não sobreescreve o que foi feito nos mappings
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            //evitar de exluir em cascata
            foreach (var relationships in modelBuilder.Model.
                GetEntityTypes().SelectMany(r => r.GetForeignKeys())) relationships.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
        }
    }
}
