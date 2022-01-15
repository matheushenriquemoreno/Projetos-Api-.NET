using System;
using System.Collections.Generic;
using System.Text;

namespace Localica.Frotas.Domain
{
    public class Veiculo
    {
        public Guid id { get; set; } 

        public string Placa { get; set; }

        public string Marca { get; set; }

        public DateTime AnoFabricacao { get; set; }

    }
}
