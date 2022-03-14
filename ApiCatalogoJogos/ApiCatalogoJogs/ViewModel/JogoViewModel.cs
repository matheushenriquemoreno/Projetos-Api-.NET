using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogs.ViewModel
{
    public class JogoViewModel
    {
        /*
         Utilizo essa clase quando vou mostrar dados na tela.
         */

        public Guid ID { get; set; }

        public string Nome {get; set;}

        public string Produtora { get; set; }

        public string Categoria { get; set; }

        public double Preco { get; set; }




    }
}
