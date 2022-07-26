using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .HasColumnType("vchar(200)")
                .IsRequired();
            builder.Property(f => f.Documento)
                .HasColumnType("vchar(14)")
                .IsRequired();

            // 1 : 1 => Fornecedor : Endereço

            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            //1 : N  => Fornecedor : Produtos
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);
            builder.ToTable("Fornecedores");
        }
    }


}
