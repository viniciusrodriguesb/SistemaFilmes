using Microsoft.EntityFrameworkCore;

namespace FilmProject.Models
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions<DbContextBase> options)
        : base(options) { }

        public virtual DbSet<UsuarioModel> UsuarioModel { get; set; }

        //Configurar mapeamentos caso o banco fosse SQL
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{ }
    }
}
