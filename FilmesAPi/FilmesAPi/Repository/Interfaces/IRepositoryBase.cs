using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilmesAPi.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> BuscaTodos();
        T BuscarOnde(Expression<Func<T, bool>> expression);

        T Adicionar(T objeto);

        void Atualizar(T objeto);

        void Remover(T objeto);
    }
}
