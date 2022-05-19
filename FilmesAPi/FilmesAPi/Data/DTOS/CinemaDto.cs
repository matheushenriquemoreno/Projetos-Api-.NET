using FilmesAPi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPi.Data.DTOS
{
    public class CinemaDto
    {
        [Required]
        public string Nome { get; set; }
        public int GerenteId { get; set; }
        [Required]
        public EnderecoDTO Endereco { get; set; }
    }
}
