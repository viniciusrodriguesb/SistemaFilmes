using FilmProject.Models.Avaliacao;
using System.ComponentModel.DataAnnotations;

namespace FilmProject.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string? Telefone { get; set; }
        public DateTime dataCriacao { get; set; }

        //Relacionamento
        public virtual ICollection<AvaliacaoModel> AvaliacaoNavigation { get; set; }
    }
}
