using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Api.Core.Domain.Entities;

namespace Template.Api.Infrastructure.Data.Mapping
{
    internal class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("PESSOA");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("SQPESSOA");
            builder.Property(x => x.AlvaraId).HasColumnName("SQALVARA");
            builder.Property(x => x.EnderecoId).HasColumnName("SQENDERECO");
            builder.Property(x => x.Nome).HasColumnName("DSNOME");
            builder.Property(x => x.Cpf).HasColumnName("DSCPF");
            builder.Property(x => x.Cnpj).HasColumnName("DSCNPJ");
            builder.Property(x => x.Cga).HasColumnName("DSCGA");
            builder.Property(x => x.Email).HasColumnName("DSEMAIL");
            builder.Property(x => x.DddCelular).HasColumnName("NUDDDCELULAR");
            builder.Property(x => x.Celular).HasColumnName("DSCELULAR");
            builder.Property(x => x.DddTelefone).HasColumnName("NUDDDTELEFONE");
            builder.Property(x => x.Telefone).HasColumnName("DSTELEFONE");
            builder.HasOne(x => x.Endereco).WithMany().HasForeignKey(s => s.EnderecoId);

        }
    }
}
