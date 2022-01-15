using System;
using APPSimplesDeCadatroDeSeries.Domain.Classes.Enum;

namespace APPSimplesDeCadatroDeSeries.Domain.Classes
{
    public class Series : EntidadeBase
    {

        public Genero GeneroSerie { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Lançamento { get; set; }
        public bool Excluido { get; private set; }

        public Series()
        {

        }

        public Series(int id, Genero genero, string titulo, string descricao,DateTime ano)
        {
            this.Id = id;
            this.GeneroSerie = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Lançamento = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            return
                    $"\nID: {Id + Environment.NewLine}" +
                    $"Titulo: {Titulo + Environment.NewLine}" +
                    $"Descrição: { Descricao + Environment.NewLine}" +
                    $"Gênero: {GeneroSerie + Environment.NewLine}" +
                    $"Data de Lançamento: {Lançamento.ToString("dd/MM/yyyy") + Environment.NewLine}";
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}
