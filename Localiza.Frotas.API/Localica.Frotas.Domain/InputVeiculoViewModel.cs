using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Localica.Frotas.Domain
{
    public  class InputVeiculoViewModel
    {
        
        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Placa precisa ter entre 8 a 10 caracter")]
        public string Placa { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Minimo de 3 letras e maximo de 100")]
        public string Marca { get; set; }

        [Required]
        [DataType("dd/MM/yyyy")]
        public DateTime AnoFabricacao { get; set; }


    }
}
