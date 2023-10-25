using FilmProject.Models.Avaliacao;
using Microsoft.EntityFrameworkCore;

namespace FilmProject.Models
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions<DbContextBase> options)
        : base(options) { }

        public virtual DbSet<UsuarioModel> UsuarioModel { get; set; }
        public virtual DbSet<TiposAvaliacaoModel> TiposAvaliacaoModel { get; set; }
        public virtual DbSet<AvaliacaoModel> AvaliacaoModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TiposAvaliacaoModel>().HasData(
            new TiposAvaliacaoModel { TipoAvaliacao = 1, noAvaliacao = "Muito satisfeito" },
            new TiposAvaliacaoModel { TipoAvaliacao = 2, noAvaliacao = "Satisfeito" },
            new TiposAvaliacaoModel { TipoAvaliacao = 3, noAvaliacao = "Neutro" },
            new TiposAvaliacaoModel { TipoAvaliacao = 4, noAvaliacao = "Insatisfeito" },
            new TiposAvaliacaoModel { TipoAvaliacao = 5, noAvaliacao = "Muito insatisfeito" });

        }
    }
}
