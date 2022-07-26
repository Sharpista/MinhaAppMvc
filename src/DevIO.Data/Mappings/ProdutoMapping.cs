using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnType("vchar(200)")
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnType("18,2");
            builder.Property(p => p.Descricao)
                .HasColumnType("vchar(1000)")
                .IsRequired();
            builder.Property(p => p.Imagem)
                .HasColumnType("vchar(100)")
                .IsRequired();

            builder.ToTable("Produtos");
        }

    }


}
