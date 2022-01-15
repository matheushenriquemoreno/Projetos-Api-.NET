using APPSimplesDeCadatroDeSeries.Domain.Classes.Enum;
using APPSimplesDeCadatroDeSeries.Domain.Classes;
using APPSimplesDeCadatroDeSeries.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APPSimplesDeCadatroDeSeries.Entiti
{
    class RepositorioSeriesEntiti : IRepositorio<Series>
    {
        private readonly CatalagoContext _repositori;


        public RepositorioSeriesEntiti(CatalagoContext catalago)
        {
            _repositori = catalago;
            AdicionarSerie(new Series(ProximoId(), Genero.Acao, "Vai Volta", "Serie otima", new DateTime(2019, 10, 10)));
            AdicionarSerie(new Series(ProximoId(), Genero.Fantasia, "Avolta dos que não foram", "Serie Mais o menos", new DateTime(2018, 10, 10)));
            AdicionarSerie(new Series(ProximoId(), Genero.Documentario, "Historia da segunda guerra mundial", "Fala sobre a segunda gera ue", new DateTime(2020, 1, 28)));
            AdicionarSerie(new Series(ProximoId(), Genero.Drama, "Viagem ate a lua", "Serie sobre a ida a lua", new DateTime(2017, 4, 20)));
        }

        public void AdicionarSerie(Series entidade)
        {
            _repositori.SeriesDb.Add(entidade);
            _repositori.SaveChanges();
        }

        public void AtualizaSerie(int id, Series entidade)
        {
            throw new NotImplementedException();
        }

        public void ExcluirSerie(int id)
        {
            throw new NotImplementedException();
        }

        public int ProximoId()
        {
            int valorLista = RetornaListaSeries().Count();
            return (valorLista + 1);
        }

        public List<Series> RetornaListaSeries()
        {
            return _repositori.SeriesDb.ToList();
        }

        public Series RetornaPorID(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
