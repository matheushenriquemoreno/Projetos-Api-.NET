using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoJogs.ViewModel;
using ApiCatalogoJogs.InputModel;

namespace ApiCatalogoJogs.Services
{
    public interface IjogoService : IDisposable
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);  // Metodo retorna uma lista de jogo mas com paginação 

        Task<JogoViewModel> Obter(Guid id);

        Task<JogoViewModel> Inserir(JogoInputModel jogo);

        Task Atualizar(Guid id, JogoInputModel jogo);

        Task Atualizar(Guid id, double preco);

        Task Remover(Guid id);


    }
}
