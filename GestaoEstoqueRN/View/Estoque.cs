using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestaoEstoqueRN.DAO;
using GestaoEstoqueRN.Views;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using ClosedXML.Excel;

namespace GestaoEstoqueRN
{
    public partial class Estoque : Form
    {
        private DataTable produtosTable;
        public Estoque()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void CarregarDados()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Database.conn))
                {
                    conn.Open();

                    string query = "SELECT IdProduto, Nome, Descricao, Preco, QtdEstoque FROM produtos";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        produtosTable = new DataTable();
                        adapter.Fill(produtosTable);

                        foreach (DataColumn column in produtosTable.Columns)
                        {
                            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                            {
                                HeaderText = column.ColumnName,
                                Name = column.ColumnName,
                                DataPropertyName = column.ColumnName,
                                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                            });
                        }
                        dataGridView1.DataSource = produtosTable;
                    }
                }
                AdicionarColunaBotao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Estoque_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CarregarDados();
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi na coluna do botão
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["ButtonColumn"].Index)
            {
                // Obtém o ID do produto da linha selecionada
                int idProduto = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IdProduto"].Value);

                // Abre o formulário secundário e passa o ID do produto
                InformacaoEstoque formDetalhes = new(idProduto);
                formDetalhes.ShowDialog();
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Filtra os dados com base no texto da pesquisa
            string filter = txtSearch.Text.Trim();

            if (produtosTable != null)
            {
                string query = $"Nome LIKE '%{filter}%' OR Descricao LIKE '%{filter}%'";

                // Aplica o filtro ao DataView
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = query;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroEstoque frmCadastroEstoque = new();
            frmCadastroEstoque.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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
                            int idProduto = Convert.ToInt32(row.Cells["IdProduto"].Value);

                            // Comando SQL para exclusão
                            string query = "DELETE FROM produtos WHERE IdProduto = @IdProduto";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@IdProduto", idProduto);
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

        private void button3_Click(object sender, EventArgs e)
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
        private void ExportarParaExcelInterop(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados na grid para exportar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Cria uma aplicação do Excel

                Excel.Application excelApp = new Excel.Application
                {
                    Visible = true
                };



                // Adiciona um novo workbook
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Worksheet)workbook.Sheets[1];
                worksheet = (Worksheet)workbook.ActiveSheet;
                worksheet.Name = "Dados Exportados";

                // Escreve os cabeçalhos das colunas
                for (int i = 1; i <= dataGridView.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                }

                // Escreve os dados das células
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Ajusta o tamanho das colunas automaticamente
                worksheet.Columns.AutoFit();

                workbook.SaveAs(@"C:\Caminho\DadosExportados.xlsx");
                excelApp.Quit();

                MessageBox.Show("Dados exportados para o Excel com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar para o Excel: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
            int idProduto = Convert.ToInt32(registrosSelecionados.First().Cells["IdProduto"].Value);

            // Abre o formulário de adicionar/editar com o ID do registro
            var formAdicionar = new CadastroEstoque(idProduto);
            formAdicionar.ShowDialog();

            // Atualiza a grid após a edição (se necessário)
            ConfigurarDataGridView();
            CarregarDados();
        }
    }
}
