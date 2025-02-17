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
using GestaoEstoqueRN.Helper;
using GestaoEstoqueRN.Model;
using GestaoEstoqueRN.Services;
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

            if (idProduto.HasValue)
            {
                CarregarDadosDoBanco(idProduto.Value);
            }
        }
        private void CarregarDadosDoBanco(int idProduto)
        {
            try
            {
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
                                txtNome.Text = reader["Nome"] != DBNull.Value ? reader["Nome"].ToString() : string.Empty;
                                txtDescricao.Text = reader["Descricao"] != DBNull.Value ? reader["Descricao"].ToString() : string.Empty;
                                nudPreco.Text = reader["Preco"] != DBNull.Value ? reader["Preco"].ToString() : "0";
                                nudQtdEstoque.Text = reader["QtdEstoque"] != DBNull.Value ? reader["QtdEstoque"].ToString() : "0";
                                cboTipo.Text = reader["Tipo"] != DBNull.Value ? reader["Tipo"].ToString() : string.Empty;
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
            string nome = txtNome.Text.Trim();
            string descricao = txtDescricao.Text.Trim();
            decimal preco = nudPreco.Value;
            int qtdEstoque = (int)nudQtdEstoque.Value;
            var tipo = cboTipo.Text.Trim();
            string marca = txtMarca.Text.Trim();
            string modelo = txtModelo.Text.Trim();
            DateTime dataGarantia = dtpDataGarantia.Value;
            string notaFiscal = txtNotaFiscal.Text.Trim();
            DateTime dataCompra = dtpDataCompra.Value;

            if (string.IsNullOrEmpty(nome) || preco <= 0 || qtdEstoque < 0)
            {
                MessageBox.Show("Preencha os campos obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.conn))
                {
                    connection.Open();

                    string query;
                    if (idProduto.HasValue)
                    {
                        query = @"UPDATE produtos 
                              SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco, 
                                  QtdEstoque = @QtdEstoque, Tipo = @Tipo, Marca = @Marca, 
                                  Modelo = @Modelo, DataGarantia = @DataGarantia, 
                                  NotaFiscal = @NotaFiscal, DataCompra = @DataCompra 
                              WHERE IdProduto = @IdProduto";
                    }
                    else
                    {
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

                        if (!idProduto.HasValue)
                        {
                            command.CommandText = "SELECT LAST_INSERT_ID()";
                            int ultimoIdInserido = Convert.ToInt32(command.ExecuteScalar());

                            HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O usuário inseriu o Produto: " + ultimoIdInserido + " com a quantidade: " + qtdEstoque);
                            MessageBox.Show($"Dados salvos com sucesso! ID do Produto: {ultimoIdInserido}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O usuário alterou o Produto: " + idProduto.Value + " com a quantidade: " + qtdEstoque);
                            MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            nudPreco.Value = 0;
            nudQtdEstoque.Value = 0;
            cboTipo.SelectedIndex = 0;
            txtMarca.Clear();
            txtModelo.Clear();
            dtpDataGarantia.Value = DateTime.Now;
            txtNotaFiscal.Clear();
            dtpDataCompra.Value = DateTime.Now;
        }

        private void INSERIR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CadastroEstoque_Load(object sender, EventArgs e)
        {
            Combos.PreencherComboBox(cboTipo,"tipoestoque","IdTipoEstoque","NomeTipoEstoque");
        }
    }
}
