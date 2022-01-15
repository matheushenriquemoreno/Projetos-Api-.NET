using System;
using System.Collections.Generic;
using System.Text;

namespace APPSimplesDeCadatroDeSeries.Interfaces
{
    interface IRepositorio<T>
    {
        List<T> RetornaListaSeries();
        T RetornaPorID(int Id);
        void AdicionarSerie(T entidade);
        void ExcluirSerie(int id);
        void AtualizaSerie(int id, T entidade);
        int ProximoId();
    }
}
