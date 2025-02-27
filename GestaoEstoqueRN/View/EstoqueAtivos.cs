using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using GestaoEstoqueRN.DAO;
using GestaoEstoqueRN.Model;
using GestaoEstoqueRN.Services;
using GestaoEstoqueRN.Views;
using MySql.Data.MySqlClient;

namespace GestaoEstoqueRN
{
    public partial class EstoqueAtivos : Form
    {
        private DataTable ativosTable;
        public EstoqueAtivos()
        {
            InitializeComponent();
        }
        private void CarregarDados()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Database.conn))
                {
                    conn.Open();

                    string query = "SELECT IdAtivo, Tipo, Descricao, Preco, Serial, Patrimonio, " +
                        "CASE WHEN Status = 1 THEN 'Em estoque' " +
                        "WHEN Status = 2 THEN 'Em uso' " +
                        "WHEN Status = 3 THEN 'Em manutenção' " +
                        "WHEN Status = 4 THEN 'Desativado' " +
                        "WHEN Status = 5 THEN 'Excluído' " +
                        "ELSE 'Indefinido' END AS Status " +
                        "FROM ativos " +
                        "WHERE Status <> 5 OR Status IS NULL " +
                        "ORDER BY Status ASC;";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        ativosTable = new DataTable();
                        adapter.Fill(ativosTable);

                        foreach (DataColumn column in ativosTable.Columns)
                        {
                            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                            {
                                HeaderText = column.ColumnName,
                                Name = column.ColumnName,
                                DataPropertyName = column.ColumnName,
                                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                            });
                        }
                        dataGridView1.DataSource = ativosTable;
                    }
                }
                AdicionarColunaBotaoLoc();
                AdicionarColunaBotaoInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Clear();

            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "",
                Name = "CheckBoxColumn",
                Width = 30,
                ReadOnly = false
            };
            dataGridView1.Columns.Add(checkboxColumn);

        }
        private void AdicionarColunaBotaoLoc()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Localização",
                Name = "ButtonColumnLoc",
                Text = "",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dataGridView1.Columns.Add(buttonColumn);
        }
        private void AdicionarColunaBotaoInfo()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Detalhes",
                Name = "ButtonColumnInfo",
                Text = "",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dataGridView1.Columns.Add(buttonColumn);
        }

        private void EstoqueAtivos_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CarregarDados();

            if (Usuario.Cargo != "OP" && Usuario.Cargo != "AD")
            {
                btnAdicionar.Enabled = false;
                btnExcluir.Enabled = false;
                btnExportar.Enabled = false;
                btnEditar.Enabled = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();

            if (ativosTable != null)
            {
                string query = $"Nome LIKE '%{filter}%' OR Descricao LIKE '%{filter}%'";

                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = query;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            bool linhaSelecionada = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["CheckBoxColumn"] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null && Convert.ToBoolean(checkBoxCell.Value) == true)
                {
                    linhaSelecionada = true;
                    break;
                }
            }

            if (!linhaSelecionada)
            {
                MessageBox.Show("Selecione pelo menos um registro para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Tem certeza de que deseja excluir os registros selecionados?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Database.conn))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        DataGridViewCheckBoxCell checkBoxCell = row.Cells["CheckBoxColumn"] as DataGridViewCheckBoxCell;

                        if (checkBoxCell != null && Convert.ToBoolean(checkBoxCell.Value) == true)
                        {
                            int idAtivo = Convert.ToInt32(row.Cells["IdAtivo"].Value);

                            string query = "UPDATE ativos SET Status = 5 WHERE IdAtivo = @IdAtivo";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@IdAtivo", idAtivo);
                                cmd.ExecuteNonQuery();
                                HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O usuário excluiu o ativo " + idAtivo + " do estoque.");
                            }
                        }
                    }
                }

                MessageBox.Show("Registros excluídos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConfigurarDataGridView();
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir registros: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarParaExcel(dataGridView1);
        }
        private void ExportarParaExcel(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados na grid para exportar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Arquivo Excel (*.xlsx)|*.xlsx",
                Title = "Salvar Arquivo Excel",
                FileName = "DadosExportados.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Dados");

                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = dataGridView.Columns[col].HeaderText;
                        }

                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            for (int col = 0; col < dataGridView.Columns.Count; col++)
                            {
                                worksheet.Cell(row + 2, col + 1).Value = dataGridView.Rows[row].Cells[col].Value?.ToString();
                            }
                        }
                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(saveFileDialog.FileName);
                    }
                    HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O usuário exportou a tabela da aba EstoqueAtivos.");

                    MessageBox.Show("Dados exportados para o Excel com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao exportar para o Excel: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var registrosSelecionados = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where(row => Convert.ToBoolean(row.Cells["CheckBoxColumn"].Value) == true)
                .ToList();

            if (registrosSelecionados.Count != 1)
            {
                MessageBox.Show("Por favor, selecione apenas um registro para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idAtivo = Convert.ToInt32(registrosSelecionados.First().Cells["IdAtivo"].Value);

            var formAdicionar = new CadastroAtivo(idAtivo);
            formAdicionar.btnRetorno.Visible = false;
            formAdicionar.ShowDialog();

            ConfigurarDataGridView();
            CarregarDados();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CadastroAtivo frmCadastroAtivo = new();
            frmCadastroAtivo.Text = "Cadastro de Ativo";
            frmCadastroAtivo.Show();
            ConfigurarDataGridView();
            CarregarDados();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["ButtonColumnInfo"].Index)
                {
                    int idAtivo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IdAtivo"].Value);

                    CadastroAtivo formDetalhes = new(idAtivo);
                    formDetalhes.btnCadastrar.Visible = false;
                    formDetalhes.btnRetorno.Visible = false;
                    formDetalhes.txtLocalizacao.Visible = true;
                    formDetalhes.lblLocalizacao.Visible = true;
                    formDetalhes.Text = "Exibição de Informações";
                    formDetalhes.ShowDialog();
                }

                if (Usuario.Cargo != "OP" && Usuario.Cargo != "AD")
                {
                    MessageBox.Show("Usuário sem permissão.");
                    return;
                }

                if (e.ColumnIndex == dataGridView1.Columns["ButtonColumnLoc"].Index && e.RowIndex >= 0)
                {
                    int idAtivo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IdAtivo"].Value);

                    string local = Microsoft.VisualBasic.Interaction.InputBox(
                        "Digite o local onde o ativo está:",
                        "Atualizar Local",
                        "");

                    if (string.IsNullOrEmpty(local))
                    {
                        //MessageBox.Show("Local não inserido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        using (MySqlConnection connection = new MySqlConnection(Database.conn))
                        {
                            connection.Open();

                            string query = "UPDATE ativos SET Localizacao = @Local WHERE IdAtivo = @IdAtivo";
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Local", local);
                                command.Parameters.AddWithValue("@IdAtivo", idAtivo);
                                command.ExecuteNonQuery();
                                HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O usuário inseriu a localização: " + local + " para o ativo: " + idAtivo);

                            }
                        }

                        MessageBox.Show("Local atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao atualizar o local: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                return;
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ButtonColumnLoc"].Index && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.save_outline.Width;
                var h = Properties.Resources.save_outline.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.location_outline, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            if (e.ColumnIndex == dataGridView1.Columns["ButtonColumnInfo"].Index && e.RowIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.save_outline.Width;
                var h = Properties.Resources.save_outline.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.information_outline, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
    }
}
