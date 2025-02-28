using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEstoqueRN.DAO;
//using MySql.Data.MySqlClient;
using MySqlConnector;

namespace GestaoEstoqueRN.Helper
{
    public static class Combos
    {
        public static void PreencherComboBox(ComboBox comboBox, string tabela, string colunaId = "Id", string colunaNome = "Nome", string ColunaWhere = null, string NomeWhere = null)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.conn))
                {
                    connection.Open();
                    string query = "";

                    if (ColunaWhere is not null) query = $"SELECT {colunaId}, {colunaNome} FROM {tabela} WHERE {ColunaWhere} = '{NomeWhere}' ORDER BY {colunaNome} ASC";
                    else query = $"SELECT {colunaId}, {colunaNome} FROM {tabela} ORDER BY {colunaNome} ASC";
                    

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        comboBox.DataSource = dt;
                        comboBox.DisplayMember = colunaNome;
                        comboBox.ValueMember = colunaId;

                        DataRow row = dt.NewRow();
                        row[colunaId] = DBNull.Value;
                        row[colunaNome] = "-- Selecione --";
                        dt.Rows.InsertAt(row, 0);

                        comboBox.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar {tabela}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
