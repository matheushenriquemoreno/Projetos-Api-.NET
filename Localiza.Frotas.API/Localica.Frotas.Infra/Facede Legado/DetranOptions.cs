using System;
using System.Collections.Generic;
using System.Text;

namespace Localica.Frotas.Infra.Facede
{
    public class DetranOptions
    {
        public Guid id { get; } = Guid.NewGuid();

        public string BaseUrl { get; set; }

        public string VistoriaUri { get; set; }
    
        public int QuantidadeDiasAgendamento { get; set; }

    }
}
