namespace FilmProject.DTO.UsuarioDTO
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string? Telefone { get; set; }
    }
}
