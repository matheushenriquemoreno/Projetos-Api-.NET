using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Localica.Frotas.Domain
{
    public interface IveiculosDetran // vistoria e algo que todo carro precisa, e cada regra pra agendamento varia de estado pra estado,
                                     // então essa interface pode implementada por cada estado que varia suas regras
    {

        public Task AgendarVistoriaDetran(Guid veiculoID);
    }
}
