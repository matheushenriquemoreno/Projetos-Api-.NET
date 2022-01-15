using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APPSimplesDeCadatroDeSeries.Interfaces;
using APPSimplesDeCadatroDeSeries.Domain.Classes;
using APPSimplesDeCadatroDeSeries.Domain.Classes.Enum;

namespace APPSimplesDeCadatroDeSeries.Classes
{
    class RepositorioDeSeries : IRepositorio<Series> // essa classe implementa um repositorio de series, pode utilizar ooutras entidades reaproveitando a interface.
    {

        private List<Series> listaSerie = new List<Series>();

        public RepositorioDeSeries()
        {
            AdicionarSerie(new Series(ProximoId(), Genero.Acao, "Vai Volta", "Serie otima", new DateTime(2019, 10, 10)));
            AdicionarSerie(new Series(ProximoId(), Genero.Fantasia, "Avolta dos que não foram", "Serie Mais o menos", new DateTime(2018, 10, 10)));
            AdicionarSerie(new Series(ProximoId(), Genero.Documentario, "Historia da segunda guerra mundial", "Fala sobre a segunda gera ue", new DateTime(2020, 1, 28)));
            AdicionarSerie(new Series(ProximoId(), Genero.Drama, "Viagem ate a lua", "Serie sobre a ida a lua", new DateTime(2017, 4, 20)));
        }

        public void AdicionarSerie(Series entidade) => listaSerie.Add(entidade);
        

        public void AtualizaSerie(int id, Series entidade) => listaSerie.Insert(id, entidade);
       

        public void ExcluirSerie(int id)
        {
           var excluir = listaSerie.Where(x => x.Id == id).First();
           excluir.Excluir(); 
        }

        public List<Series> RetornaListaSeries() => listaSerie;
        

        public int ProximoId() => listaSerie.Count;
        

        public Series RetornaPorID(int Id) => listaSerie.Where(x=> x.Id == Id).First();
        
    }
}
