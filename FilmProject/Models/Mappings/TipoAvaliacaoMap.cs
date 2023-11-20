using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FilmProject.Models.Avaliacao;

namespace FilmProject.Models.Mappings
{
    public class TipoAvaliacaoMap : IEntityTypeConfiguration<TiposAvaliacaoModel>
    {
        public void Configure(EntityTypeBuilder<TiposAvaliacaoModel> builder)
        {
            builder.ToTable("TipoAvaliacao");

            builder.HasKey("TipoAvaliacao");

            builder.Property(x => x.TipoAvaliacao).HasColumnName("TipoAvaliacao");
            builder.Property(x => x.noAvaliacao).HasColumnName("NoAvaliacao");
        }
    }
}
