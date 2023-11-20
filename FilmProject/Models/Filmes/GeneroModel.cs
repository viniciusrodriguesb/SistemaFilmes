namespace FilmProject.Models.Filmes
{
    public class GeneroModel
    {
        public int Id { get; set; }
        public string noGenero { get; set; }

        //Relacionamento
        public virtual ICollection<FilmeModel> FilmeNavigation { get; set; }
    }
}
