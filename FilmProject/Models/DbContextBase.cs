using FilmProject.Models.Avaliacao;
using FilmProject.Models.Filmes;
using FilmProject.Models.Mappings;
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
        public virtual DbSet<FilmeModel> FilmeModel { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.ApplyConfiguration(new UsuarioMap());
        //    modelBuilder.ApplyConfiguration(new FilmesMap());
        //    modelBuilder.ApplyConfiguration(new GeneroMap());
        //    modelBuilder.ApplyConfiguration(new AvaliacaoMap());
        //    modelBuilder.ApplyConfiguration(new TipoAvaliacaoMap());
        //}
    }
}
