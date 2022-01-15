using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using APPSimplesDeCadatroDeSeries.Interfaces;
using APPSimplesDeCadatroDeSeries.Entiti;
using Microsoft.EntityFrameworkCore;
using APPSimplesDeCadatroDeSeries.Domain.Classes;
using APPSimplesDeCadatroDeSeries.Domain.Classes.Enum;

namespace APPSimplesDeCadatroDeSeries
{
    class Program
    {

		static IRepositorio<Series> _repositorySeries;

        static void Main(string[] args)
        {
			/* https://entityframeworkcore.com/providers-inmemory */

			var resultado = new DbContextOptionsBuilder<CatalagoContext>().UseInMemoryDatabase(databaseName: "Test").Options; // como não a uma classe startap no projeto a instancia do db context tem que ser criada a mão 

			var context = new CatalagoContext(resultado);

			_repositorySeries = new RepositorioSeriesEntiti(context);
			ChamaOpcao();

        }

		public static void ListarSeries()
        {

			var lista = (from series in  _repositorySeries.RetornaListaSeries()
						 where series.Excluido == false
						 select series).ToList();

            if (!lista.Any()) // https://www.delftstack.com/pt/howto/csharp/check-if-list-is-empty-in-csharp/
			{
				Console.WriteLine("Nenhuma Serie Listada");
				ChamaOpcao();
			}
			var cor = Console.BackgroundColor;
			Console.BackgroundColor = ConsoleColor.DarkGray;

			Console.WriteLine("Todas as Séries!!");

			foreach (var serie in lista)
            {
				Thread.Sleep(500);
                Console.Write("---------------------------");
				Console.WriteLine($"{serie}");
			}
			Console.BackgroundColor = cor;
		}


		public static void InserirSerie()
        {

			PrintGenerosSerie();

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: (dd/mm/yyyy): ");
			DateTime entradaAno = DateTime.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Series novaSerie = new Series(_repositorySeries.ProximoId(),
											(Genero)entradaGenero,
											entradaTitulo,
											entradaDescricao,
											entradaAno
											);

			_repositorySeries.AdicionarSerie(novaSerie);
			ChamaOpcao();
		}



		public static void AtualizarSerie()
        {

			ListarSeries();

            Console.Write("Qual o id da serie que deseja atualizar? ");
			int idSerie = int.Parse(Console.ReadLine());
		
			PrintGenerosSerie();

			Console.Write("Digite o novo gênero entre as opções acima: ");
			int genero = int.Parse(Console.ReadLine());

			Console.Write("Digite o novo Título da Série: ");
			string titulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: (dd/mm/yyyy): ");
			DateTime ano = DateTime.Parse(Console.ReadLine());

			Console.Write("Digite a nova descrição da Série: ");
			string descricao = Console.ReadLine();

			var listaseries = _repositorySeries.RetornaListaSeries();

			var serieAtualizada =
						  (from serie in listaseries
						   where (serie.Id == idSerie)
						   select new Series
						   {
							   Id = serie.Id,
							   GeneroSerie = (Genero)genero,
							   Descricao = descricao,
							   Lançamento = ano,
							   Titulo = titulo
						   }).ToList().First(); // retorna o dado preciso 


			var reserva2 =
				           (from serie in listaseries
							where (serie.Id == idSerie)
							select new Series
							{
								Id = serie.Id,
								GeneroSerie = serie.GeneroSerie,
								Descricao = serie.Descricao,
								Lançamento = serie.Lançamento,
								Titulo = serie.Titulo
							}).ToList(); // retorna uma lista com o dado selecionado 


			var reserva3 =
				            from serie in listaseries
							where (serie.Id == idSerie)
							select new Series
							{
								Id = serie.Id,
								GeneroSerie = serie.GeneroSerie,
								Descricao = serie.Descricao,
								Lançamento = serie.Lançamento,
								Titulo = serie.Titulo
							}; // retorna um enumerable com o dado selecionado

			


			//Console.WriteLine(reserva + "1\n\n "+ reserva2.First() + "2\n\n " + reserva3.First());

			_repositorySeries.AtualizaSerie(idSerie, serieAtualizada);

			ChamaOpcao();
		}


		public static void ExcluirSerie()
        {
			ListarSeries();
			Console.Write("Qual o id da serie que deseja excluir? ");
			int idSerie = int.Parse(Console.ReadLine());

			_repositorySeries.ExcluirSerie(idSerie);

		}

        public static void VisualizarSerie()
        {
			ListarSeries();
			Console.Write("Qual o id da serie que deseja? ");
			int idSerie = int.Parse(Console.ReadLine());

			var serie  = _repositorySeries.RetornaPorID(idSerie);
			Console.WriteLine(serie);
        }
 
		public static void  PrintGenerosSerie()
		{
			var enums = Enum.GetValues(typeof(Genero));

			foreach (int posicao in enums)
			{
				Console.WriteLine("{0}-{1} ", posicao, Enum.GetName(typeof(Genero), posicao));
			}

		}

		public static void ChamaOpcao()
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						ChamaOpcao();
						break;
					case "2":
						InserirSerie();
						ChamaOpcao();
						break;
					case "3":
						AtualizarSerie();
						ChamaOpcao();
						break;
					case "4":
						ExcluirSerie();
						ChamaOpcao();
						break;
					case "5":
						VisualizarSerie();
						ChamaOpcao();
						break;
					case "C":
						Console.Clear();
						ChamaOpcao();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

			}

		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine("\nDIO Séries a seu dispor!!!\n");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
