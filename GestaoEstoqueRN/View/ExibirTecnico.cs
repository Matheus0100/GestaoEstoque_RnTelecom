using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using GestaoEstoqueRN.DAO;
using GestaoEstoqueRN.Views;
using MySql.Data.MySqlClient;

namespace GestaoEstoqueRN
{
    public partial class ExibirTecnico : Form
    {
        private DataTable tecnicosTable;
        public ExibirTecnico()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ExibirTecnico_Load(object sender, EventArgs e)
        {
            CarregarDados();
            ObterDataAtual();
        }
        private void ObterDataAtual()
        {
            dateTimePicker1.Value = DateTime.Now;
        }
        private void CarregarDados()
        {

            try
            {
                dataGridView1.Columns.Clear();
                using (MySqlConnection conn = new MySqlConnection(Database.conn))
                {
                    conn.Open();

                    string query = "SELECT emuso.IdEmUso as 'Id', emuso.Radu, " +
                        "CASE WHEN emuso.IdProduto IS NOT NULL THEN produtos.Nome " +
                        "WHEN emuso.IdAtivo IS NOT NULL THEN ativos.Patrimonio ELSE NULL END AS ItemRelacionado, " +
                        "emuso.QtdProduto, emuso.Associado FROM emuso " +
                        "LEFT JOIN produtos ON emuso.IdProduto = produtos.IdProduto " +
                        "LEFT JOIN ativos ON emuso.IdAtivo = ativos.IdAtivo " +
                        "WHERE DATE(emuso.DataUso) = @Data";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        string dataFormatada = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        cmd.Parameters.AddWithValue("@Data", dataFormatada);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable tecnicosTable = new DataTable();
                            adapter.Fill(tecnicosTable);

                            foreach (DataColumn column in tecnicosTable.Columns)
                            {
                                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                                {
                                    HeaderText = column.ColumnName,
                                    Name = column.ColumnName,
                                    DataPropertyName = column.ColumnName,
                                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                });
                            }
                            dataGridView1.DataSource = tecnicosTable;
                        }
                    }
                }

                //AdicionarColunaBotaoOk();
                AdicionarColunaBotaoRetornoEstoque();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AdicionarColunaBotaoOk()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Confirmar",
                Name = "ButtonColumnOk",
                Text = "",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dataGridView1.Columns.Add(buttonColumn);
        }
        private void AdicionarColunaBotaoRetornoEstoque()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Retornar",
                Name = "ButtonColumn",
                Text = "",
                UseColumnTextForButtonValue = true,
                Width = 80
            };

            dataGridView1.Columns.Add(buttonColumn);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DesignarTecnico frmDesignarTecnico = new();
                frmDesignarTecnico.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.ColumnIndex == dataGridView1.Columns["ButtonColumnOk"].Index && e.RowIndex >= 0)
            //{

            //    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            //    var w = Properties.Resources.save_outline.Width;
            //    var h = Properties.Resources.save_outline.Height;
            //    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
            //    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

            //    e.Graphics.DrawImage(Properties.Resources.checkmark_outline, new Rectangle(x, y, w, h));
            //    e.Handled = true;
            //}
            if (e.ColumnIndex == dataGridView1.Columns["ButtonColumn"].Index && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.save_outline.Width;
                var h = Properties.Resources.save_outline.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.arrow_undo_outline, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["ButtonColumn"].Index && e.RowIndex >= 0)
                {
                    int idEmUso = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    string itemRelacionado = dataGridView1.Rows[e.RowIndex].Cells["ItemRelacionado"].Value.ToString();
                    int qtdProduto = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["QtdProduto"].Value);

                    try
                    {
                        using (MySqlConnection connection = new MySqlConnection(Database.conn))
                        {
                            connection.Open();

                            if (IsNumero(itemRelacionado))
                            {
                                string queryAtivo = "UPDATE ativos SET Status = 1 WHERE Patrimonio = @Patrimonio";
                                using (MySqlCommand command = new MySqlCommand(queryAtivo, connection))
                                {
                                    command.Parameters.AddWithValue("@Patrimonio", itemRelacionado);
                                    command.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                string queryProduto = "UPDATE produtos SET QtdEstoque = QtdEstoque + @QtdProduto WHERE Nome = @NomeProduto";
                                using (MySqlCommand command = new MySqlCommand(queryProduto, connection))
                                {
                                    command.Parameters.AddWithValue("@QtdProduto", qtdProduto);
                                    command.Parameters.AddWithValue("@NomeProduto", itemRelacionado);
                                    command.ExecuteNonQuery();
                                }
                            }

                            string queryExcluir = "DELETE FROM emuso WHERE IdEmUso = @IdEmUso";
                            using (MySqlCommand command = new MySqlCommand(queryExcluir, connection))
                            {
                                command.Parameters.AddWithValue("@IdEmUso", idEmUso);
                                command.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Operação concluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarDados();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao processar a operação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch(Exception ex)
            {
                return;
            }
        }

        private bool IsNumero(string texto)
        {
            return texto.All(char.IsDigit);
        }
    }
}
