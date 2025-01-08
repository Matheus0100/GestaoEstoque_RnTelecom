using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GestaoEstoqueRN.DAO
{
    public class Database
    {
        public static string conn = "server=SERVIDOR;User Id=USUARIO;database=BANCO; password=SENHA";
        //MySqlConnection conexao = new MySqlConnection(conn);
        DataGridView gridView = new DataGridView();

        public bool ExecSql(string sql, MySqlConnection conexao)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static DataTable ObterTabela(string connectionString, string sql)
        {
            DataTable tabela = new DataTable();

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    using (MySqlDataReader leitor = comando.ExecuteReader())
                    {
                        tabela.Load(leitor);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

            return tabela;
        }
        public static DataTable ObterTabela(string sql, MySqlConnection conexao)
        {
            DataTable tabela = new DataTable();

            try
            {
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                using (MySqlDataReader leitor = comando.ExecuteReader())
                {
                    tabela.Load(leitor);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao obter a tabela: " + ex.Message);
            }

            return tabela;
        }

    }
}
