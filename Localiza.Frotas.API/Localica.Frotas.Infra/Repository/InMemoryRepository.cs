using Localica.Frotas.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Localica.Frotas.Infra.Repository
{
    public class InMemoryRepository // : IveiculosRepository
    {

        private readonly List<Veiculo> listVeiculos = new List<Veiculo>();

        public void Add(Veiculo veiculo) => listVeiculos.Add(veiculo);

        public void Delete(Veiculo veiculo) => listVeiculos.Remove(veiculo);

        public List<Veiculo> GetAll() { return listVeiculos; }


        public Veiculo GetById(Guid id) => listVeiculos.Where(x => x.id == id).First();

        public void Update(Guid id, Veiculo veiculo)
        {
            listVeiculos.Remove(GetById(veiculo.id));
            listVeiculos.Add(veiculo);
        }
    }
}
