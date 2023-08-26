using FilmProject.DTO;
using FilmProject.DTO.UsuarioDTO;
using FilmProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Transactions;

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
                retorno.Mensagem = "E-mail já está em uso";
            }
            return retorno;
        }

        public async Task<List<UsuarioResponse>> ListarUsuarios()
        {
            try
            {
                var usuarios = await _dbContext.UsuarioModel
                               .AsNoTracking()
                               .Where(x => x.dataExclusao == null)
                               .Select(l => new UsuarioResponse
                               {
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

    }
}
