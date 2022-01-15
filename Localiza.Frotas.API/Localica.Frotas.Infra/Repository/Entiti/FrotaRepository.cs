using Localica.Frotas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Localica.Frotas.Infra.Repository.Entiti
{
    public class FrotaRepository : IveiculosRepository
    {

        private readonly FrotaContext dbContext;


        public FrotaRepository(FrotaContext context)
        {
            this.dbContext = context;
        }

        public void Add(Veiculo veiculo)
        {
            dbContext.Veiculos.Add(veiculo);
            dbContext.SaveChanges();
        }

        public void Delete(Veiculo veiculo)
        {
            dbContext.Veiculos.Remove(veiculo);
            dbContext.SaveChanges();
        }

        public List<Veiculo> GetAll() => dbContext.Veiculos.ToList();

        public Veiculo GetById(Guid id) => dbContext.Veiculos.Where(x => x.id == id).First();

        public void Update(Guid id, Veiculo veiculo)
        {
            if(veiculo.id == id) // caso o usuario informe o mesmo id nas duas verificações o id não e mudado.
            {
                dbContext.Entry(veiculo).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            else /* Mas como o id e alterado o comportamento a se fazer e excluir o objeto antigo e adicionar o novo com id pra não gerar registros duplos */
            {
                Delete(GetById(id));
                Add(veiculo);
            }
            
        }
                                          
    }
}

