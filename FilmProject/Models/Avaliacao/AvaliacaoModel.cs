using FilmProject.Models.Filmes;
using System.ComponentModel.DataAnnotations;

namespace FilmProject.Models.Avaliacao
{
    public class AvaliacaoModel
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? FilmeId { get; set; }
        public int TipoAvaliacaoId { get; set; }

        //Relacionamentos
        public virtual UsuarioModel UsuarioNavigation { get; set; }
        public virtual ICollection<FilmeModel> FilmeNavigation { get; set; }
        public virtual FilmeModel FilmeNavigations { get; set; }
        public virtual TiposAvaliacaoModel TipoAvaliacaoNavigation { get; set; }
    }
}
