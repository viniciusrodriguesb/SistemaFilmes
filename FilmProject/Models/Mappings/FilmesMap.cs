using FilmProject.Models.Filmes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmProject.Models.Mappings
{
    public class FilmesMap : IEntityTypeConfiguration<FilmeModel>
    {
        public void Configure(EntityTypeBuilder<FilmeModel> builder)
        {
            builder.ToTable("filmes");

            builder.HasKey("Id");

            builder.Property(x => x.FilmeId).HasColumnName("Id");
            builder.Property(x => x.Titulo).HasColumnName("Titulo");
            builder.Property(x => x.SubTitulo).HasColumnName("SubTitulo");
            builder.Property(x => x.GeneroId).HasColumnName("GeneroId");
            builder.Property(x => x.AvaliacaoId).HasColumnName("AvaliacaoId");

            //Relacionamentos
            builder.HasOne(x => x.GeneroNavigation)
                   .WithMany(x => x.FilmeNavigation)
                   .HasForeignKey(x => x.GeneroId);

            builder.HasOne(x => x.AvaliacoesNavigations)
                   .WithMany(x => x.FilmeNavigation)
                   .HasForeignKey(x => x.FilmeId);
        }
    }
}
