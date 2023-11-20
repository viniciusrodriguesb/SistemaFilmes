using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmProject.Models.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey("Id");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Nome).HasColumnName("Nome");
            builder.Property(x => x.Sobrenome).HasColumnName("Sobrenome");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.Senha).HasColumnName("Senha");
            builder.Property(x => x.Telefone).HasColumnName("Telefone");
            builder.Property(x => x.dataCriacao).HasColumnName("DataCriacao");
        }
    }
}
