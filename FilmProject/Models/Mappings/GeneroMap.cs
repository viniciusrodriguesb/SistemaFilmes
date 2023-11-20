using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FilmProject.Models.Filmes;

namespace FilmProject.Models.Mappings
{
    public class GeneroMap : IEntityTypeConfiguration<GeneroModel>
    {
        public void Configure(EntityTypeBuilder<GeneroModel> builder)
        {
            builder.ToTable("genero");

            builder.HasKey("Id");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.noGenero).HasColumnName("noGenero");
        }
    }
}
