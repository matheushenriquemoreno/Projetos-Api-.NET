using FilmesAPi.Data;
using FilmesAPi.Models;
using FilmesAPi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmesAPi.Repository
{
    public class RepositoryFilmes : IRepositoryFilme
    {
        readonly FilmeContext _context;
        public RepositoryFilmes(FilmeContext context)
        {
            _context = context;
        }

        public Filme GetByWhere(Expression<Func<Filme, bool>> expression)
        {
            return _context.Filmes.Where(expression).FirstOrDefault();
        }

        public List<Filme> BuscaTodos() => _context.Filmes.ToList();

        public void Adicionar(Filme objeto)
        {
            _context.Filmes.Add(objeto);
            _context.SaveChanges();
        }

        public void Atualizar(Filme objeto)
        {
            _context.Filmes.Update(objeto);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var dadosExlcuir = _context.Filmes.FirstOrDefault(x => x.Id == id);

            _context.Filmes.Remove(dadosExlcuir);
            _context.SaveChanges();
        }

        public Filme GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
