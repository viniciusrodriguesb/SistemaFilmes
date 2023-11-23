using FilmProject.Models.Filmes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmProject.Models.Avaliacao
{
    public class AvaliacaoModel
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? FilmeId { get; set; }
        public int TipoAvaliacaoId { get; set; }

        //Relacionamentos
        [NotMapped]
        public virtual UsuarioModel UsuarioNavigation { get; set; }
        [NotMapped]
        public virtual ICollection<FilmeModel> FilmeNavigation { get; set; }
        [NotMapped]
        public virtual FilmeModel FilmeNavigations { get; set; }
        [NotMapped]
        public virtual TiposAvaliacaoModel TipoAvaliacaoNavigation { get; set; }
    }
}
