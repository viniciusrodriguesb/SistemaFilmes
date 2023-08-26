namespace FilmProject.DTO.UsuarioDTO
{
    public class UsuarioResponse
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string? Telefone { get; set; }
    }
}
