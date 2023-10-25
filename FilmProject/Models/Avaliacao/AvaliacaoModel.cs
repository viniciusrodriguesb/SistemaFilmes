using System.ComponentModel.DataAnnotations;

namespace FilmProject.Models.Avaliacao
{
    public class AvaliacaoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DescricaoMensagem { get; set; } = string.Empty;

        public TiposAvaliacaoModel tipoAvaliacaoNavigation { get; set; }
    }
}
