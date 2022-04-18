using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPi.Data.DTOS
{
    public class FilmeDtoLeitura
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "o campo Diretor é obrigatório")]
        public string Diretor { get; set; }

        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "A duração tem que ser entre 1 a 600 minutos")]
        public int Duracao { get; set; }

        public DateTime HoraDaConsulta { get; set; }

    }
}
