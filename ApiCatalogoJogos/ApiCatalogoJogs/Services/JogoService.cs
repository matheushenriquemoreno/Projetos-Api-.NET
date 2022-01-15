using ApiCatalogoJogs.Entities;
using ApiCatalogoJogs.Exceptions;
using ApiCatalogoJogs.InputModel;
using ApiCatalogoJogs.Repositories;
using ApiCatalogoJogs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogs.Services
{
    public class JogoService : IjogoService
    {

        private readonly IjogoRepository _repostorioJogo;

        public JogoService(IjogoRepository repositori)
        {
            _repostorioJogo = repositori;
        }


        public async Task Atualizar(Guid id, JogoInputModel jogo)
        {
            var jogoAtualizar = await _repostorioJogo.Obter(id);

            if (jogoAtualizar is null)
                throw new JogosExceptions("Jogo não existe!");

            jogoAtualizar.Nome = jogo.Nome;
            jogoAtualizar.Produtora = jogo.Produtora;
            jogoAtualizar.Categoria = jogo.Categoria;
            jogoAtualizar.Preco = jogo.Preco;


             await _repostorioJogo.Atualizar(jogoAtualizar);

        }

        public async Task Atualizar(Guid id, double preco)
        {

            var jogoAtualizar = await _repostorioJogo.Obter(id);

            if (jogoAtualizar is null)
                throw new JogosExceptions("Jogo não existe!");

            jogoAtualizar.Preco = preco;

            await _repostorioJogo.Atualizar(jogoAtualizar);
        }

        public async Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {

            var verificaJogo = await _repostorioJogo.Obter(jogo.Nome, jogo.Produtora);

            if (verificaJogo.Count > 0)
                throw new JogosExceptions("Jogo ja Existente");

            var novoJogo = new Jogo
            {
                ID = Guid.NewGuid(),
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Categoria = jogo.Categoria,
                Preco = jogo.Preco
            };

            await  _repostorioJogo.Inserir(novoJogo);

            return new JogoViewModel
            {
                ID = novoJogo.ID,
                Nome = novoJogo.Nome,
                Produtora = novoJogo.Produtora,
                Categoria = novoJogo.Categoria,
                Preco = novoJogo.Preco
            };
        }

        public async Task<List<JogoViewModel>> Obter(int pagina, int quantidade)
        {
            var jogosPAginacao = await _repostorioJogo.Obter(pagina, quantidade);

            return jogosPAginacao.Select(x => new JogoViewModel
            {
                ID = x.ID,
                Nome = x.Nome,
                Produtora = x.Produtora,
                Categoria = x.Categoria,
                Preco = x.Preco
            }).ToList();

        }

        public async Task<JogoViewModel> Obter(Guid id)
        {
            var jogoBuscado =  await _repostorioJogo.Obter(id);

            if (jogoBuscado is null)
                return null;

            return new JogoViewModel
            {
                ID = jogoBuscado.ID,
                Nome = jogoBuscado.Nome,
                Produtora = jogoBuscado.Produtora,
                Categoria = jogoBuscado.Categoria,
                Preco = jogoBuscado.Preco
            };

        }

        public async Task Remover(Guid id)
        {
            var jogoARemover = await _repostorioJogo.Obter(id);

            if (jogoARemover is null)
                throw new JogosExceptions("Jogo Não Cadastrado!");

           await _repostorioJogo.Remover(id);
        }

        public void Dispose()
        {
            _repostorioJogo?.Dispose(); // pra evitar multiplas coneções no banco de dados
        }

    }
}
