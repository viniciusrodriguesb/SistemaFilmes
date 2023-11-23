using System.ComponentModel.DataAnnotations.Schema;

namespace FilmProject.Models.Filmes
{
    public class GeneroModel
    {
        public int Id { get; set; }
        public string noGenero { get; set; }

        //Relacionamento
        [NotMapped]
        public virtual ICollection<FilmeModel> FilmeNavigation { get; set; }
    }
}
