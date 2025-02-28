using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEstoqueRN.Helper;
//using MySql.Data.MySqlClient;
using MySqlConnector;

namespace GestaoEstoqueRN.DAO
{
    public class UsuarioDAO
    {
        public void CadastrarUsuario(string usuario, string senha)
        {
            string senhaHash = Criptografia.GerarHashSHA256(senha);

            using (MySqlConnection connection = new MySqlConnection(Database.conn))
            {
                string query = "INSERT INTO usuarios (Usuario, Senha) VALUES (@Usuario, @Senha)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Senha", senhaHash);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public bool ValidarLogin(string usuario, string senha)
        {
            using (MySqlConnection connection = new MySqlConnection(Database.conn))
            {
                string query = "SELECT Senha FROM usuarios WHERE Usuario = @Usuario";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Usuario", usuario);

                    connection.Open();
                    object resultado = command.ExecuteScalar();

                    if (resultado != null)
                    {
                        string senhaHashBanco = resultado.ToString();
                        string senhaHashDigitada = Criptografia.GerarHashSHA256(senha);

                        return senhaHashBanco == senhaHashDigitada;
                    }
                }
            }
            return false;
        }
    }
}
