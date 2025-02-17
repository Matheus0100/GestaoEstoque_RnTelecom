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

                    string query = "SELECT IdAtivo, Tipo, Descricao, Preco, Serial, Patrimonio FROM ativos WHERE Status <> 5 OR Status IS NULL ORDER BY Status asc";

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
                AdicionarColunaBotao();
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
        private void AdicionarColunaBotao()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Ação",
                Name = "ButtonColumn",
                Text = "Detalhes",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dataGridView1.Columns.Add(buttonColumn);
        }

        private void EstoqueAtivos_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CarregarDados();
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
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["ButtonColumn"].Index)
            {
                int idAtivo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IdAtivo"].Value);

                CadastroAtivo formDetalhes = new(idAtivo);
                formDetalhes.btnCadastrar.Visible = false;
                formDetalhes.btnRetorno.Visible = false;
                formDetalhes.Text = "Exibição de Informações";
                formDetalhes.ShowDialog();
            }
        }
    }
}
