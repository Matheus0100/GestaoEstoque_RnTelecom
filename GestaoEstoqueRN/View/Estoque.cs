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
//using MySql.Data.MySqlClient;
using MySqlConnector;
using Excel = Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using ClosedXML.Excel;
using GestaoEstoqueRN.Model;
using GestaoEstoqueRN.Services;

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
            if (e.ColumnIndex == dataGridView1.Columns["CheckBoxColumn"].Index && e.RowIndex >= 0)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Clear();

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "",
                Name = "CheckBoxColumn",
                Width = 30,
                ReadOnly = false,
                TrueValue = true,
                FalseValue = false,
            };
            dataGridView1.Columns.Add(checkBoxColumn);

        }
        private void CarregarDados()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Database.conn))
                {
                    conn.Open();

                    string query = "SELECT IdProduto, Nome, Descricao, Preco, QtdEstoque FROM produtos WHERE Status <> 5 OR Status IS NULL order by Status asc";

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

            if (Usuario.Cargo != "OP" && Usuario.Cargo != "AD")
            {
                btnAdicionar.Enabled = false;
                btnExcluir.Enabled = false;
                btnExportar.Enabled = false;
                btnEditar.Enabled = false;
            }
            if (Usuario.Cargo == "OP")
            {
                btnExcluir.Enabled = false;
            }
        }
        private void AdicionarColunaBotao()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Detalhes",
                Name = "ButtonColumn",
                Text = "",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dataGridView1.Columns.Add(buttonColumn);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["ButtonColumn"].Index)
                {
                    int idProduto = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IdProduto"].Value);

                    CadastroEstoque formDetalhes = new(idProduto);
                    formDetalhes.btnCadastrar.Visible = false;
                    formDetalhes.Text = "Exibição de Informações";
                    formDetalhes.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                return;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();

            if (produtosTable != null)
            {
                string query = $"Nome LIKE '%{filter}%' OR Descricao LIKE '%{filter}%'";

                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = query;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroEstoque frmCadastroEstoque = new();
            frmCadastroEstoque.Text = "LANÇAMENTO DE ITENS - ESTOQUE";
            frmCadastroEstoque.Show();
            ConfigurarDataGridView();
            CarregarDados();
        }

        private void button2_Click(object sender, EventArgs e)
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
                            int idProduto = Convert.ToInt32(row.Cells["IdProduto"].Value);

                            string query = "UPDATE produtos SET Status = 5 WHERE IdProduto = @IdProduto";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@IdProduto", idProduto);
                                cmd.ExecuteNonQuery();
                                HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O usuário excluiu o produto " + idProduto + " do estoque.");

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
                    HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O usuário exportou a tabela da aba Estoque.");

                    MessageBox.Show("Dados exportados para o Excel com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao exportar para o Excel: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //private void ExportarParaExcelInterop(DataGridView dataGridView)
        //{
        //    if (dataGridView.Rows.Count == 0)
        //    {
        //        MessageBox.Show("Não há dados na grid para exportar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    try
        //    {
        //        // Cria uma aplicação do Excel

        //        Excel.Application excelApp = new Excel.Application
        //        {
        //            Visible = true
        //        };



        //        // Adiciona um novo workbook
        //        Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
        //        Excel.Worksheet worksheet = (Worksheet)workbook.Sheets[1];
        //        worksheet = (Worksheet)workbook.ActiveSheet;
        //        worksheet.Name = "Dados Exportados";

        //        // Escreve os cabeçalhos das colunas
        //        for (int i = 1; i <= dataGridView.Columns.Count; i++)
        //        {
        //            worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
        //        }

        //        // Escreve os dados das células
        //        for (int i = 0; i < dataGridView.Rows.Count; i++)
        //        {
        //            for (int j = 0; j < dataGridView.Columns.Count; j++)
        //            {
        //                worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value?.ToString();
        //            }
        //        }

        //        // Ajusta o tamanho das colunas automaticamente
        //        worksheet.Columns.AutoFit();

        //        workbook.SaveAs(@"C:\Caminho\DadosExportados.xlsx");
        //        excelApp.Quit();

        //        MessageBox.Show("Dados exportados para o Excel com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Erro ao exportar para o Excel: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            var registrosSelecionados = dataGridView1.Rows
            .Cast<DataGridViewRow>()
            .Where(row => row.Cells["CheckBoxColumn"].Value != null && Convert.ToBoolean(row.Cells["CheckBoxColumn"].Value))
            .ToList();

            if (registrosSelecionados.Count != 1)
            {
                MessageBox.Show("Por favor, selecione apenas um registro para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProduto = Convert.ToInt32(registrosSelecionados.First().Cells["IdProduto"].Value);

            var formAdicionar = new CadastroEstoque(idProduto);
            formAdicionar.Text = "Editar Estoque";
            formAdicionar.ShowDialog();

            ConfigurarDataGridView();
            CarregarDados();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ButtonColumn"].Index && e.RowIndex >= 0)
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
