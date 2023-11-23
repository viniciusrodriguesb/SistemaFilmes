using FilmProject.Models.Avaliacao;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmProject.Models.Filmes
{
    public class FilmeModel
    {
        [Key]
        public int FilmeId { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public int GeneroId { get; set; }
        public int AvaliacaoId { get; set; }

        // Relacionamentos
        [NotMapped]
        public virtual ICollection<AvaliacaoModel> AvaliacoesNavigation { get; set; }
        [NotMapped]
        public virtual AvaliacaoModel AvaliacoesNavigations { get; set; }
        [NotMapped]        
        public virtual GeneroModel GeneroNavigation { get; set; }
    }
}
