using System;
using System.Collections.Generic;
using System.Text;

namespace Localica.Frotas.Domain
{
    public interface IveiculosRepository
    {
        /* não preciso saber de qual base de dados esta retornando so preciso desses metodos pra estar trabalhando em um controller ou servico */

        Veiculo GetById(Guid id);

        List<Veiculo> GetAll();

        void Add(InputVeiculoViewModel veiculo);

        void Delete(Veiculo veiculo);

        void Update(Guid id, InputVeiculoViewModel veiculo);

    }
}
