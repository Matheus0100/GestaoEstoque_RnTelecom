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
using Org.BouncyCastle.Asn1.Cmp;

namespace GestaoEstoqueRN.Views
{
    public partial class CadastroAtivo : Form
    {
        private int? idAtivo;
        private bool RetornoEstoque = false;
        public CadastroAtivo(int? idAtivo = null)
        {
            InitializeComponent();
            this.idAtivo = idAtivo;
        }
        private void CarregarDadosDoBanco(int idAtivo)
        {
            try
            {
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
                                txtLocalizacao.Text = reader["Localizacao"] != DBNull.Value ? reader["Localizacao"].ToString() : string.Empty;
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
            string patrimonio = txtPatrimonio.Text.Trim();
            string descricao = txtObservacao.Text.Trim();
            decimal preco = nudValor.Value;
            string serial = txtSerial.Text.Trim();
            string tipo = cboAtivo.Text.Trim();
            string marca = txtMarca.Text.Trim();
            string modelo = txtModelo.Text.Trim();
            DateTime dataGarantia = dtpDataGarantia.Value;
            string notaFiscal = txtNotaFiscal.Text.Trim();
            DateTime dataCompra = dtpDataCompra.Value;

            if (string.IsNullOrEmpty(patrimonio) || string.IsNullOrEmpty(descricao) || preco <= 0)
            {
                MessageBox.Show("Preencha os campos obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.conn))
                {
                    connection.Open();

                    string checkQuery = @"SELECT IdAtivo, Status FROM ativos WHERE Patrimonio = @Patrimonio OR Serial = @Serial";
                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Patrimonio", patrimonio);
                        checkCommand.Parameters.AddWithValue("@Serial", serial);

                        using (MySqlDataReader reader = checkCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idExistente = Convert.ToInt32(reader["IdAtivo"]);
                                int statusExistente = Convert.ToInt32(reader["Status"]);
                                reader.Close();

                                if (RetornoEstoque)
                                {
                                    string updateStatusQuery = "UPDATE ativos SET Status = 1 WHERE IdAtivo = @IdAtivo";
                                    using (MySqlCommand updateCommand = new MySqlCommand(updateStatusQuery, connection))
                                    {
                                        updateCommand.Parameters.AddWithValue("@IdAtivo", idExistente);
                                        updateCommand.ExecuteNonQuery();
                                    }
                                    HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O ativo com o ID: " + idExistente + " foi reativado.");
                                    MessageBox.Show("O ativo foi reativado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                else
                                {
                                    DialogResult result = MessageBox.Show("Já existe um ativo com este Patrimônio ou Serial. Deseja reativá-lo?",
                                                                          "Registro Existente",
                                                                          MessageBoxButtons.YesNo,
                                                                          MessageBoxIcon.Warning);

                                    if (result == DialogResult.Yes)
                                    {
                                        string updateStatusQuery = "UPDATE ativos SET Status = 1 WHERE IdAtivo = @IdAtivo";
                                        using (MySqlCommand updateCommand = new MySqlCommand(updateStatusQuery, connection))
                                        {
                                            updateCommand.Parameters.AddWithValue("@IdAtivo", idExistente);
                                            updateCommand.ExecuteNonQuery();
                                        }
                                        HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O ativo com o ID: " + idExistente + " foi reativado.");
                                        MessageBox.Show("O ativo foi reativado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    return;
                                }
                            }
                        }
                    }

                    string query;
                    if (idAtivo.HasValue)
                    {
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


                        if (idAtivo.HasValue)
                        {
                            HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O ativo com o ID: " + idAtivo.Value + " foi atualizado.");
                            this.Close();
                        }
                        else
                        {
                            command.CommandText = "SELECT LAST_INSERT_ID()";
                            int ultimoIdInserido = Convert.ToInt32(command.ExecuteScalar());
                            HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O ativo com o ID: " + ultimoIdInserido + " foi inserido.");
                            LimparCampos();
                        }
                        MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cboAtivo.SelectedIndex = -1;
            txtObservacao.Clear();
            nudValor.Value = 0;
            txtPatrimonio.ResetText();
            txtSerial.ResetText();
            txtMarca.Clear();
            txtModelo.Clear();
            dtpDataGarantia.Value = DateTime.Now;
            txtNotaFiscal.Clear();
            dtpDataCompra.Value = DateTime.Now;
            RetornoEstoque = false;
        }

        private void btnRetorno_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("O ativo está retornando ao estoque?",
                                                      "Confirmação",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                RetornoEstoque = true;
            }
        }

        private void CadastroAtivo_Load(object sender, EventArgs e)
        {
            Combos.PreencherComboBox(cboAtivo, "tipoativo", "IdTipoAtivo", "NomeTipoAtivo");
            if (idAtivo.HasValue)
            {
                CarregarDadosDoBanco(idAtivo.Value);
            }
        }
    }
}

