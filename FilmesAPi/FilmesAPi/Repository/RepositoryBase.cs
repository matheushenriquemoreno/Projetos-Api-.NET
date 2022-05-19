using FilmesAPi.Data;
using FilmesAPi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmesAPi.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        readonly DbContext _context;

        public RepositoryBase(AppDbContext filmeContext)
        {
            _context = filmeContext;
        }

        public T BuscarOnde(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).FirstOrDefault();
        }

        public IEnumerable<T> BuscaTodos()
        {
            return _context.Set<T>().ToList();
        }

        public T Adicionar(T objeto)
        {
            _context.Set<T>().Add(objeto);
            Salvar();
            return objeto;
        }

        public void Atualizar(T objeto)
        {
            _context.Set<T>().Update(objeto);
        }

        public virtual void Remover(T objeto)
        {
           _context.Set<T>().Remove(objeto);
       
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
