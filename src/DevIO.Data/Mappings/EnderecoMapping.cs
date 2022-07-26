using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro)
                .HasColumnType("vchar(200)")
                .IsRequired();
            builder.Property(e => e.Numero)
                .HasColumnType("vchar(50)")
                .IsRequired();
            builder.Property(e => e.Cep)
              .HasColumnType("vchar(8)")
              .IsRequired();
            builder.Property(e => e.Complemento)
              .HasColumnType("vchar(250)")
              .IsRequired();
            builder.Property(e => e.Bairro)
              .HasColumnType("vchar(100)")
              .IsRequired();
            builder.Property(e => e.Estado)
              .HasColumnType("vchar(50)")
              .IsRequired();
            

            builder.ToTable("Enderecos");
        }
    }


}
