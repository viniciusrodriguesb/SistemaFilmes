using System.ComponentModel.DataAnnotations;

namespace FilmProject.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = null!;

        [Required]
        public string Sobrenome { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = null!;
        public string? Telefone { get; set; }

        public DateTime dataCriacao { get; set; }
        public DateTime? dataExclusao { get; set; }
    }
}
