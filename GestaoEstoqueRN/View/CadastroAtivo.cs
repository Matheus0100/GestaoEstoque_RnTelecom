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
using Org.BouncyCastle.Asn1.Cmp;

namespace GestaoEstoqueRN.Views
{
    public partial class CadastroAtivo : Form
    {
        private int? idAtivo;
        public CadastroAtivo(int? idAtivo = null)
        {
            InitializeComponent();
            this.idAtivo = idAtivo;

            // Se o ID foi fornecido, carrega os dados do banco
            if (idAtivo.HasValue)
            {
                CarregarDadosDoBanco(idAtivo.Value);
            }
        }
        private void CarregarDadosDoBanco(int idAtivo)
        {
            try
            {
                // Conexão com o banco de dados
                using (MySqlConnection connection = new MySqlConnection(Database.conn))
                {
                    connection.Open();
                    string query = "SELECT * FROM ativos WHERE IdAtivo = @IdAtivo";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdAtivo", idAtivo);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Preenche os campos do formulário com os dados do banco
                                txtPatrimonio.Text = reader["Patrimonio"] != DBNull.Value ? reader["Patrimonio"].ToString() : string.Empty;
                                txtObservacao.Text = reader["Descricao"] != DBNull.Value ? reader["Descricao"].ToString() : string.Empty;
                                nudValor.Value = reader["Preco"] != DBNull.Value ? Convert.ToDecimal(reader["Preco"]) : 0;
                                txtSerial.Text = reader["Serial"] != DBNull.Value ? reader["Serial"].ToString() : string.Empty;
                                cboAtivo.Text = reader["Tipo"] != DBNull.Value ? reader["Tipo"].ToString() : string.Empty;
                                txtMarca.Text = reader["Marca"] != DBNull.Value ? reader["Marca"].ToString() : string.Empty;
                                txtModelo.Text = reader["Modelo"] != DBNull.Value ? reader["Modelo"].ToString() : string.Empty;
                                dtpDataGarantia.Value = reader["DataGarantia"] != DBNull.Value ? Convert.ToDateTime(reader["DataGarantia"]) : DateTime.Now;
                                txtNotaFiscal.Text = reader["NotaFiscal"] != DBNull.Value ? reader["NotaFiscal"].ToString() : string.Empty;
                                dtpDataCompra.Value = reader["DataCompra"] != DBNull.Value ? Convert.ToDateTime(reader["DataCompra"]) : DateTime.Now;

                                //// Campo adicional: Status (opcional, depende de como você o representa no formulário)
                                //if (reader["Status"] != DBNull.Value)
                                //{
                                //    int status = Convert.ToInt32(reader["Status"]);
                                //    // Exemplo: Se houver um ComboBox para Status
                                //    cboStatus.SelectedIndex = cboStatus.Items.IndexOf(status.ToString());
                                //}
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

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Coletar os dados dos TextBoxes e outros controles
            string patrimonio = txtPatrimonio.Text.Trim();
            string descricao = txtObservacao.Text.Trim();
            decimal preco = nudValor.Value; // Use um NumericUpDown para o preço
            string serial = txtSerial.Text.Trim();
            string tipo = cboAtivo.Text.Trim();
            string marca = txtMarca.Text.Trim();
            string modelo = txtModelo.Text.Trim();
            DateTime dataGarantia = dtpDataGarantia.Value;
            string notaFiscal = txtNotaFiscal.Text.Trim();
            DateTime dataCompra = dtpDataCompra.Value;

            // Validação básica
            if (string.IsNullOrEmpty(patrimonio) || string.IsNullOrEmpty(descricao) || preco <= 0)
            {
                MessageBox.Show("Preencha os campos obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Inserir ou atualizar os dados no banco de dados
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.conn))
                {
                    connection.Open();

                    string query;
                    if (idAtivo.HasValue)
                    {
                        // Atualiza o registro existente
                        query = @"UPDATE ativos 
                      SET Descricao = @Descricao, Preco = @Preco, Patrimonio = @Patrimonio, 
                          Serial = @Serial, Tipo = @Tipo, Marca = @Marca, Modelo = @Modelo, 
                          DataGarantia = @DataGarantia, NotaFiscal = @NotaFiscal, DataCompra = @DataCompra 
                      WHERE IdAtivo = @IdAtivo";
                    }
                    else
                    {
                        query = @"INSERT INTO ativos (Descricao, Preco, Patrimonio, Serial, Tipo, Marca, Modelo, DataGarantia, NotaFiscal, DataCompra, Status) 
                      VALUES (@Descricao, @Preco, @Patrimonio, @Serial, @Tipo, @Marca, @Modelo, @DataGarantia, @NotaFiscal, @DataCompra, 1)";
                    }

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Descricao", descricao);
                        command.Parameters.AddWithValue("@Preco", preco);
                        command.Parameters.AddWithValue("@Patrimonio", patrimonio);
                        command.Parameters.AddWithValue("@Serial", serial);
                        command.Parameters.AddWithValue("@Tipo", tipo);
                        command.Parameters.AddWithValue("@Marca", marca);
                        command.Parameters.AddWithValue("@Modelo", modelo);
                        command.Parameters.AddWithValue("@DataGarantia", dataGarantia);
                        command.Parameters.AddWithValue("@NotaFiscal", notaFiscal);
                        command.Parameters.AddWithValue("@DataCompra", dataCompra);

                        if (idAtivo.HasValue)
                        {
                            command.Parameters.AddWithValue("@IdAtivo", idAtivo.Value);
                        }

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (idAtivo.HasValue)
                {
                    this.Close();
                }
                else
                {
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
            cboAtivo.SelectedIndex = -1;
            txtObservacao.Clear();
            nudValor.Value = 0;
            //nudQtdEstoque.Value = 0;
            txtPatrimonio.ResetText();
            txtSerial.ResetText();
            //cboAtivo.ResetText();
            txtMarca.Clear();
            txtModelo.Clear();
            dtpDataGarantia.Value = DateTime.Now;
            txtNotaFiscal.Clear();
            dtpDataCompra.Value = DateTime.Now;
        }
    }
}

