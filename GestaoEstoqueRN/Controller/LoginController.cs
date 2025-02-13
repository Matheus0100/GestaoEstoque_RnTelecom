using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEstoqueRN.DAO;
using GestaoEstoqueRN.Helper;
using GestaoEstoqueRN.Model;
using MySql.Data.MySqlClient;

namespace GestaoEstoqueRN.Controller
{
    public class LoginController
    {
        public static bool AutenticarUsuario(string usuario, string senha)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Database.conn))
                {
                    conn.Open();
                    string query = "SELECT IdUsuario, Senha, Cargo FROM usuarios WHERE usuario = @usuario";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string senhaHashBanco = reader["Senha"].ToString();
                                string senhaHashDigitada = Criptografia.GerarHashSHA256(senha);

                                if (senhaHashBanco == senhaHashDigitada)
                                {
                                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                    string cargoUsuario = reader["Cargo"].ToString();
                                    Usuario.DefinirUsuario(idUsuario, usuario, cargoUsuario);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
