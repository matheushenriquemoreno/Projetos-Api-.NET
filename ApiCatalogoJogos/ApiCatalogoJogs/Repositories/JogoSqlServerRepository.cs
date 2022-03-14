using ApiCatalogoJogs.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogs.Repositories
{
    public class JogoSqlServerRepository //: IjogoRepository
    {
        private readonly SqlConnection sqlConection;

        public JogoSqlServerRepository(IConfiguration conection) // IConfiguration pega comfigurações de appsettings.json
        {
            sqlConection = new SqlConnection(conection.GetConnectionString("defalut"));
        }


        public async Task Atualizar(Jogo jogo)
        {
            var comandoSql = $"UPDATE Jogos set Nome {jogo.Nome}, Produtora = {jogo.Produtora}, Catergoria = {jogo.Categoria}, Preco = {jogo.Preco.ToString().Replace(",", ".")} where Id = {jogo.ID}";

            await sqlConection.OpenAsync();
            SqlCommand executaBanco = new SqlCommand(comandoSql, sqlConection);
            executaBanco.ExecuteNonQuery();
            await sqlConection.CloseAsync();

        }

        public async Task Inserir(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Jogo>> Obter(int pagina, int quantidade)
        //{
        //    var jogos = new List<Jogo>();

        //    var comando = $"select * from jogos order by id offset {((pagina - 1) + quantidade)} row fetcht next {quantidade} rows only";

        //    await sqlConection.OpenAsync();
        //    SqlCommand executa = new SqlCommand(comando, sqlConection);
        //    //SqlDataReader 

        //}

        public async Task<Jogo> Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Jogo>> Obter(string nome, string produtora)
        {
            throw new NotImplementedException();
        }

        public async Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            sqlConection?.Close();
            sqlConection?.Dispose();
        }
    }
}
