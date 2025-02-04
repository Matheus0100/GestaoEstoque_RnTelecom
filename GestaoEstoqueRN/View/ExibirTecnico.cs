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
        }
        private void CarregarDados()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Database.conn))
                {
                    conn.Open();

                    string query = "SELECT emuso.Radu, " +
                        "CASE WHEN emuso.IdProduto IS NOT NULL THEN produtos.Nome " +
                        "WHEN emuso.IdAtivo IS NOT NULL THEN ativos.Patrimonio ELSE NULL END AS ItemRelacionado, " +
                        "emuso.QtdProduto, emuso.Associado FROM emuso " +
                        "LEFT JOIN produtos ON emuso.IdProduto = produtos.IdProduto " +
                        "LEFT JOIN ativos ON emuso.IdAtivo = ativos.IdAtivo ";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        tecnicosTable = new DataTable();
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
                AdicionarColunaBotaoResponsavel();
                AdicionarColunaBotaoRetornoEstoque();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AdicionarColunaBotaoResponsavel()
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
        private void AdicionarColunaBotaoRetornoEstoque()
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
    }
}
