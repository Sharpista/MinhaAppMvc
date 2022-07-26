using DevIO.App2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DevIO.App2.ContextApp
{
    public class DevIOContext2 : DbContext
    {
        public DevIOContext2()
        {

        }
        public DevIOContext2(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProdutoViewModel> Produtos { get; set; }
        public DbSet<EnderecoViewModel> Enderecos { get; set; }
        public DbSet<FornecedorViewModel> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevIOContext2).Assembly);

            ////evitar quando esquecido algum mapeando de por nvarchar max, não sobreescreve o que foi feito nos mappings
            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetProperties()
            //    .Where(p => p.ClrType == typeof(string))))
            //    property.SetColumnType("varchar(100)");

            ////evitar de exluir em cascata
            //foreach (var relationships in modelBuilder.Model.
            //    GetEntityTypes().SelectMany(r => r.GetForeignKeys())) relationships.DeleteBehavior = DeleteBehavior.ClientSetNull;
            //base.OnModelCreating(modelBuilder);
        }
    }
}
