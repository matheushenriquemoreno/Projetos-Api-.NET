using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilmesAPi.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        List<T> BuscaTodos();
        T GetByWhere(Expression<Func<T, bool>> expression);

        T GetById(int id);
        
        void Adicionar(T objeto);

        void Atualizar(T objeto);

        void Remover(int id);

    }
}
