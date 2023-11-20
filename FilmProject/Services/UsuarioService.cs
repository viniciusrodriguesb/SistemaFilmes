using FilmProject.DTO;
using FilmProject.DTO.UsuarioDTO;
using FilmProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace FilmProject.Services
{
    public class UsuarioService
    {
        #region Construtor
        private readonly DbContextBase _dbContext;
        public UsuarioService(
            DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        public async Task<MensagemErroResponse> CadastrarUsuario(UsuarioRequest usuario)
        {
            var retorno = new MensagemErroResponse();

            if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Nome))
            {
                retorno.Mensagem = "Campos obrigatórios faltando";
                return retorno;
            }

            var verificar = await _dbContext.UsuarioModel
                            .AsNoTracking()
                            .Where(u => u.Email == usuario.Email)
                            .FirstOrDefaultAsync();

            if (verificar == null)
            {
                try
                {
                    UsuarioModel novoUsuario = new UsuarioModel()
                    {
                        Nome = usuario.Nome,
                        Sobrenome = usuario.Sobrenome,
                        Email = usuario.Email,
                        Senha = usuario.Senha,
                        Telefone = usuario.Telefone,
                        dataCriacao = DateTime.Now
                    };
                    _dbContext.Add(novoUsuario);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbException dbEx)
                {
                    throw new Exception($"{dbEx}");
                }
            }
            else
            {
                retorno.Mensagem = "Usuário com dados já existentes.";
            }
            return retorno;
        }

        public async Task<UsuarioModel?> BuscarUsuario(string email, string senha)
        {
            var usuario = await _dbContext.UsuarioModel
                                .AsNoTracking()
                                .Where(u => u.Email.ToLower() == email.ToLower() &&
                                            u.Senha.ToLower() == senha.ToLower())
                                .Select(u => new UsuarioModel()
                                {
                                    Email = u.Email,
                                    Senha = u.Senha
                                }).FirstOrDefaultAsync();

            return usuario != null ? usuario : new UsuarioModel();
        }

        public async Task<List<UsuarioResponse>> ListarUsuarios()
        {
            try
            {
                var usuarios = await _dbContext.UsuarioModel
                               .AsNoTracking()
                               .Select(l => new UsuarioResponse
                               {
                                   Id = l.Id,
                                   Nome = l.Nome,
                                   Sobrenome = l.Sobrenome,
                                   Email = l.Email,
                                   Telefone = l.Telefone
                               })
                               .ToListAsync();

                return usuarios.Count > 0 ? usuarios : new List<UsuarioResponse>();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao listar usuários", e);
            }
        }

        public async Task<UsuarioResponse> EditarUsuarios(UsuarioRequest usuario, int Id)
        {
            var verificaExistencia = await _dbContext.UsuarioModel
                                    .AsNoTracking()
                                    .Where(x => x.Id == Id)
                                    .FirstOrDefaultAsync();

            if (verificaExistencia is not null)
            {
                verificaExistencia.Nome = usuario.Nome;
                verificaExistencia.Sobrenome = usuario.Sobrenome;
                verificaExistencia.Telefone = usuario.Telefone;
                verificaExistencia.Email = usuario.Email;
                verificaExistencia.Senha = usuario.Senha;

                _dbContext.Update(verificaExistencia);
                await _dbContext.SaveChangesAsync();

                return new UsuarioResponse()
                {
                    Id = verificaExistencia.Id,
                    Nome = verificaExistencia.Nome,
                    Sobrenome = verificaExistencia.Sobrenome,
                    Telefone = verificaExistencia.Telefone,
                    Email = verificaExistencia.Email
                };
            }
            return new UsuarioResponse();
        }

        public async Task<bool> DeletarUsuario(int Id)
        {
            bool deletou = false;

            var result = await _dbContext.UsuarioModel
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.Id == Id);

            if (result is not null)
            {
                _dbContext.UsuarioModel.Remove(result);
                await _dbContext.SaveChangesAsync();

                return deletou;
            }
            return deletou = true;
        }

    }
}
