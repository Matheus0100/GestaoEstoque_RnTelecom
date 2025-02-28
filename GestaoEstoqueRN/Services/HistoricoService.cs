using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEstoqueRN.DAO;
//using MySql.Data.MySqlClient;
using MySqlConnector;

namespace GestaoEstoqueRN.Services
{
    public static class HistoricoService
    {
        public static void RegistrarAcao(int idUsuario, string acao)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.conn))
                {
                    connection.Open();
                    string query = @"INSERT INTO historico (IdUsuario, Acao, DataAcao) VALUES (@IdUsuario, @Acao, @DataAcao)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        command.Parameters.AddWithValue("@Acao", acao);
                        command.Parameters.AddWithValue("@DataAcao", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar ação: {ex.Message}");
            }
        }
    }
}
