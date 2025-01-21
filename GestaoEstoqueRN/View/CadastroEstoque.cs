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

namespace GestaoEstoqueRN.Views
{
    public partial class CadastroEstoque : Form
    {
        private int? idProduto;
        public CadastroEstoque(int? idProduto = null)
        {
            InitializeComponent();
            this.idProduto = idProduto;

            // Se o ID foi fornecido, carrega os dados do banco
            if (idProduto.HasValue)
            {
                CarregarDadosDoBanco(idProduto.Value);
            }
        }
        private void CarregarDadosDoBanco(int idProduto)
        {
            try
            {
                // Conexão com o banco de dados
                //string connectionString = "sua_string_de_conexao_aqui";
                using (MySqlConnection connection = new MySqlConnection(Database.conn))
                {
                    connection.Open();
                    string query = "SELECT * FROM produtos WHERE IdProduto = @IdProduto";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdProduto", idProduto);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Preenche os campos do formulário com os dados do banco
                                txtNome.Text = reader["Nome"] != DBNull.Value ? reader["Nome"].ToString() : string.Empty;
                                txtDescricao.Text = reader["Descricao"] != DBNull.Value ? reader["Descricao"].ToString() : string.Empty;
                                nudPreco.Text = reader["Preco"] != DBNull.Value ? reader["Preco"].ToString() : "0";
                                nudQtdEstoque.Text = reader["QtdEstoque"] != DBNull.Value ? reader["QtdEstoque"].ToString() : "0";
                                txtTipo.Text = reader["Tipo"] != DBNull.Value ? reader["Tipo"].ToString() : string.Empty;
                                txtMarca.Text = reader["Marca"] != DBNull.Value ? reader["Marca"].ToString() : string.Empty;
                                txtModelo.Text = reader["Modelo"] != DBNull.Value ? reader["Modelo"].ToString() : string.Empty;
                                dtpDataGarantia.Value = reader["DataGarantia"] != DBNull.Value ? Convert.ToDateTime(reader["DataGarantia"]) : DateTime.Now;
                                txtNotaFiscal.Text = reader["NotaFiscal"] != DBNull.Value ? reader["NotaFiscal"].ToString() : string.Empty;
                                dtpDataCompra.Value = reader["DataCompra"] != DBNull.Value ? Convert.ToDateTime(reader["DataCompra"]) : DateTime.Now;
                            }
                            else
                            {
                                MessageBox.Show("Registro não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Coletar os dados dos TextBoxes e outros controles
            string nome = txtNome.Text.Trim();
            string descricao = txtDescricao.Text.Trim();
            decimal preco = nudPreco.Value; // Use um NumericUpDown para o preço
            int qtdEstoque = (int)nudQtdEstoque.Value; // Use um NumericUpDown para a quantidade
            var tipo = txtTipo.Text.Trim();
            string marca = txtMarca.Text.Trim();
            string modelo = txtModelo.Text.Trim();
            DateTime dataGarantia = dtpDataGarantia.Value;
            string notaFiscal = txtNotaFiscal.Text.Trim();
            DateTime dataCompra = dtpDataCompra.Value;

            // Validação básica
            if (string.IsNullOrEmpty(nome) || preco <= 0 || qtdEstoque < 0)
            {
                MessageBox.Show("Preencha os campos obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Inserir os dados no banco de dados
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.conn))
                {
                    connection.Open();

                    string query;
                    if (idProduto.HasValue)
                    {
                        // Atualiza o registro existente
                        query = @"UPDATE produtos 
                              SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco, 
                                  QtdEstoque = @QtdEstoque, Tipo = @Tipo, Marca = @Marca, 
                                  Modelo = @Modelo, DataGarantia = @DataGarantia, 
                                  NotaFiscal = @NotaFiscal, DataCompra = @DataCompra 
                              WHERE IdProduto = @IdProduto";
                    }
                    else
                    {
                        // Insere um novo registro
                        query = @"INSERT INTO produtos (Nome, Descricao, Preco, QtdEstoque, Tipo, Marca, Modelo, DataGarantia, NotaFiscal, DataCompra) 
                              VALUES (@Nome, @Descricao, @Preco, @QtdEstoque, @Tipo, @Marca, @Modelo, @DataGarantia, @NotaFiscal, @DataCompra)";
                    }

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@Descricao", descricao);
                        command.Parameters.AddWithValue("@Preco", preco);
                        command.Parameters.AddWithValue("@QtdEstoque", qtdEstoque);
                        command.Parameters.AddWithValue("@Tipo", tipo);
                        command.Parameters.AddWithValue("@Marca", marca);
                        command.Parameters.AddWithValue("@Modelo", modelo);
                        command.Parameters.AddWithValue("@DataGarantia", dataGarantia);
                        command.Parameters.AddWithValue("@NotaFiscal", notaFiscal);
                        command.Parameters.AddWithValue("@DataCompra", dataCompra);

                        if (idProduto.HasValue)
                        {
                            command.Parameters.AddWithValue("@IdProduto", idProduto.Value);
                        }

                        command.ExecuteNonQuery();
                    }
                }

                if (idProduto.HasValue)
                {
                    MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            // Limpa todos os campos do formulário após o cadastro
            txtNome.Clear();
            txtDescricao.Clear();
            nudPreco.Value = 0;
            nudQtdEstoque.Value = 0;
            txtTipo.ResetText();
            txtMarca.Clear();
            txtModelo.Clear();
            dtpDataGarantia.Value = DateTime.Now;
            txtNotaFiscal.Clear();
            dtpDataCompra.Value = DateTime.Now;
        }

        private void INSERIR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
