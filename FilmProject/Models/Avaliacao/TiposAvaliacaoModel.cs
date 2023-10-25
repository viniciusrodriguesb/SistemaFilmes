using System.ComponentModel.DataAnnotations;

namespace FilmProject.Models.Avaliacao
{
    public class TiposAvaliacaoModel
    {
        [Key]
        public int TipoAvaliacao { get; set; }

        [Required]
        public string noAvaliacao { get; set; }
    }
}
