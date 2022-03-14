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

        public void Add(InputVeiculoViewModel veiculo)
        {

            var jogoNovo = new Veiculo
            {
                id = Guid.NewGuid(),
                AnoFabricacao = veiculo.AnoFabricacao,
                Marca = veiculo.Marca,
                Placa = veiculo.Placa
            };

            dbContext.Veiculos.Add(jogoNovo);
            dbContext.SaveChanges();
        }

        public void Delete(Veiculo veiculo)
        {
            dbContext.Veiculos.Remove(veiculo);
            dbContext.SaveChanges();
        }

        public List<Veiculo> GetAll() => dbContext.Veiculos.ToList();

        public Veiculo GetById(Guid id) => dbContext.Veiculos.Where(x => x.id == id).First();

        public void Update(Guid id, InputVeiculoViewModel veiculo)
        {
            var veiculoUpdate = dbContext.Veiculos.Where(x => x.id == id).First();

            veiculoUpdate.Marca = veiculo.Marca;
            veiculoUpdate.AnoFabricacao = veiculo.AnoFabricacao;
            veiculoUpdate.Placa = veiculo.Placa;


            dbContext.Update(veiculoUpdate);
            dbContext.SaveChanges();
            
        }
                                          
    }
}

