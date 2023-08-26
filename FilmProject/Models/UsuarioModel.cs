using System.ComponentModel.DataAnnotations;

namespace FilmProject.Models
{
    public class UsuarioModel
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string? Telefone { get; set; }

        public DateTime dataCriacao { get; set; }
        public DateTime? dataExclusao { get; set; }
    }
}
