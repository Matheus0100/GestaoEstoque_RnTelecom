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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void CarregarDados()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Database.conn))
                {
                    conn.Open();

                    string query = "SELECT IdAtivo, Nome, Descricao, Preco, Serial, Patrimonio FROM ativos";

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
            // Configurar as colunas do DataGridView
            dataGridView1.Columns.Clear(); // Limpa quaisquer colunas anteriores

            // Adiciona a coluna de checkbox
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
            // Adiciona a coluna do botão no final
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Ação",
                Name = "ButtonColumn",
                Text = "Detalhes",
                UseColumnTextForButtonValue = true, // Exibe o texto em todas as células da coluna
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
            // Filtra os dados com base no texto da pesquisa
            string filter = txtSearch.Text.Trim();

            if (ativosTable != null)
            {
                string query = $"Nome LIKE '%{filter}%' OR Descricao LIKE '%{filter}%'";

                // Aplica o filtro ao DataView
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = query;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verificar se há linhas selecionadas
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

            // Confirmação de exclusão
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
                            // Obter o IdProduto da linha selecionada
                            int idAtivo = Convert.ToInt32(row.Cells["IdAtivo"].Value);

                            // Comando SQL para exclusão
                            string query = "DELETE FROM ativos WHERE IdAtivo = @IdAtivo";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@IdAtivo", idAtivo);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // Atualizar o DataGridView após a exclusão
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

            // Abre um diálogo para salvar o arquivo
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
                    // Cria um novo arquivo Excel
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Dados");

                        // Adiciona os cabeçalhos das colunas
                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = dataGridView.Columns[col].HeaderText;
                        }

                        // Adiciona os dados das células
                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            for (int col = 0; col < dataGridView.Columns.Count; col++)
                            {
                                worksheet.Cell(row + 2, col + 1).Value = dataGridView.Rows[row].Cells[col].Value?.ToString();
                            }
                        }

                        // Ajusta o tamanho das colunas automaticamente
                        worksheet.Columns().AdjustToContents();

                        // Salva o arquivo no caminho selecionado
                        workbook.SaveAs(saveFileDialog.FileName);
                    }

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
            // Verifica se há apenas um registro selecionado
            var registrosSelecionados = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where(row => Convert.ToBoolean(row.Cells["CheckBoxColumn"].Value) == true)
                .ToList();

            if (registrosSelecionados.Count != 1)
            {
                MessageBox.Show("Por favor, selecione apenas um registro para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtém o ID do registro selecionado
            int idAtivo = Convert.ToInt32(registrosSelecionados.First().Cells["IdAtivo"].Value);

            // Abre o formulário de adicionar/editar com o ID do registro
            var formAdicionar = new CadastroEstoque(idAtivo);
            formAdicionar.ShowDialog();

            // Atualiza a grid após a edição (se necessário)
            ConfigurarDataGridView();
            CarregarDados();
        }
    }
}
