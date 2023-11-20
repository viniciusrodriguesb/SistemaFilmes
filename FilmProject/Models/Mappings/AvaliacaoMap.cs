using FilmProject.Models.Avaliacao;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FilmProject.Models.Mappings
{
    public class AvaliacaoMap : IEntityTypeConfiguration<AvaliacaoModel>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoModel> builder)
        {
            builder.ToTable("Avaliacao");

            builder.HasKey("Id");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.UsuarioId).HasColumnName("UsuarioId");
            builder.Property(x => x.FilmeId).HasColumnName("FilmeId");
            builder.Property(x => x.TipoAvaliacaoId).HasColumnName("TipoAvaliacaoId");

            //Relacionamentos
            builder.HasOne(x => x.UsuarioNavigation)
                   .WithMany(x => x.AvaliacaoNavigation)
                   .HasForeignKey(x => x.UsuarioId);

            builder.HasOne(x => x.FilmeNavigations)
                   .WithMany(x => x.AvaliacoesNavigation)
                   .HasForeignKey(x => x.FilmeId);
        }
    }
}
