﻿using FilmProject.DTO.AvaliacaoDTO;
using FilmProject.Models;
using FilmProject.Models.Avaliacao;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace FilmProject.Services
{
    public class AvaliacaoService
    {
        #region Construtor
        public readonly DbContextBase _context;

        public AvaliacaoService(DbContextBase context)
        {
            _context = context;
        }
        #endregion
               
        public async Task<bool> GravarAvaliacaoUsuario(AvaliacaoUsuarioRequest avaliacaoUsuario)
        {
            bool registrado = false;
            try
            {
                if (avaliacaoUsuario.TipoAvaliacao != null)
                {
                    var tipoAvaliacao = await _context.TiposAvaliacaoModel
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.TipoAvaliacao == avaliacaoUsuario.TipoAvaliacao);

                    if (tipoAvaliacao is not null)
                    {
                        _context.Add(new AvaliacaoModel
                        {
                            //tipoAvaliacaoNavigation = tipoAvaliacao
                        });

                        await _context.SaveChangesAsync();
                        registrado = true;
                    }
                }
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException($"Erro - {dbEx}", dbEx);
            }
            return registrado;
        }

        public async Task<List<MediaAvaliacaoResponse>> GerarMediaAvaliacoesPorFilme()
        {
            var listaAvaliacao = await _context.AvaliacaoModel
                                 .AsNoTracking()
                                 .GroupBy(a => a.FilmeId)
                                 .Select(item => new MediaAvaliacaoResponse
                                 {
                                     FilmeId = item.Key,
                                     Avaliacao = item.Average(a => a.TipoAvaliacaoId)
                                 }).ToListAsync();

            return listaAvaliacao;
        }

        public async Task<List<TiposAvaliacaoResponse>> ListarTiposAvaliacao()
        {
            var tipoAvaliacao = await _context.TiposAvaliacaoModel
                                        .AsNoTracking()
                                        .Select(itens => new TiposAvaliacaoResponse
                                        {
                                            TipoAvaliacao = itens.TipoAvaliacao,
                                            noAvaliacao = itens.noAvaliacao
                                        }).ToListAsync();

            return tipoAvaliacao.Any() ? tipoAvaliacao : new List<TiposAvaliacaoResponse> { };
        }

    }
}
