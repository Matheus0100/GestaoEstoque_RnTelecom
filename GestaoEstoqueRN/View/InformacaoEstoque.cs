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
    public partial class InformacaoEstoque : Form
    {
        private int idProduto;
        public InformacaoEstoque(int idProduto)
        {
            InitializeComponent();
            this.idProduto = idProduto;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void InformacaoEstoque_Load(object sender, EventArgs e)
        {
            CarregarDetalhes();
        }
        private void CarregarDetalhes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Database.conn))
                {
                    conn.Open();

                    string query = "SELECT Nome, Descricao, Preco, QtdEstoque, Tipo, Marca, Modelo, DataGarantia, NotaFiscal, DataCompra FROM produtos WHERE IdProduto = @IdProduto";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdProduto", idProduto);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Exibe os dados nos controles
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
                                MessageBox.Show("Produto não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar detalhes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
