using FilmProject.Models.Avaliacao;

namespace FilmProject.Models.Filmes
{
    public class FilmeModel
    {
        public int FilmeId { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public int GeneroId { get; set; }
        public int AvaliacaoId { get; set; }

        // Relacionamentos
        public virtual ICollection<AvaliacaoModel> AvaliacoesNavigation { get; set; }
        public virtual AvaliacaoModel AvaliacoesNavigations { get; set; }
        public virtual GeneroModel GeneroNavigation { get; set; }
    }
}
