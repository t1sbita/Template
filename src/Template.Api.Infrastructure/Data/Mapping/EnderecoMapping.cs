using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Api.Core.Domain.Entities;

namespace Template.Api.Infrastructure.Data.Mapping
{
    internal class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("ENDERECO");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("SQENDERECO");
            builder.Property(x => x.Cep).HasColumnName("NUCEP").HasMaxLength(100);
            builder.Property(x => x.CodLogradouro).HasColumnName("NUCODLOGRADOURO").HasMaxLength(250);
            builder.Property(x => x.Logradouro).HasColumnName("DSLOGRADOURO").HasMaxLength(2);
            builder.Property(x => x.Numero).HasColumnName("DSNUMERO");
            builder.Property(x => x.Complemento).HasColumnName("DSCOMPLEMENTO").HasMaxLength(100);
            builder.Property(x => x.PontoReferencia).HasColumnName("DSPONTOREFERENCIA").HasMaxLength(250);
            builder.Property(x => x.Bairro).HasColumnName("DSBAIRRO").HasMaxLength(20);
            builder.Property(x => x.Cidade).HasColumnName("DSCIDADE").HasMaxLength(250);
            builder.Property(x => x.Estado).HasColumnName("DSESTADO").HasMaxLength(2);
            builder.Property(x => x.Pais).HasColumnName("DSPAIS");

        }
    }
}
