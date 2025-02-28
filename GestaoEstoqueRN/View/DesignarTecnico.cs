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
//using MySql.Data.MySqlClient;
using MySqlConnector;

namespace GestaoEstoqueRN.Views
{
    public partial class DesignarTecnico : Form
    {
        public DesignarTecnico()
        {
            InitializeComponent();
        }
        private void LimparCampos()
        {
            cboProduto.SelectedIndex = -1;
            cboAtivo.SelectedIndex = -1;
            cboProduto.Enabled = true;
            cboAtivo.Enabled = true;
            cboRadu.SelectedIndex = -1;
            nudQtdProduto.Value = 0;
            nudQtdProduto.Enabled = true;
            txtDescricao.Clear();
            txtAssociado.SelectedIndex = -1;
            dtpDataUso.Value = DateTime.Now;
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int? idProduto = cboProduto.SelectedValue as int?;
            int? idAtivo = cboAtivo.SelectedValue as int?;
            string radu = cboRadu.Text.Trim();
            int qtdProduto = (int)nudQtdProduto.Value;
            string descricao = txtDescricao.Text.Trim();
            //string associado = txtAssociado.Text.Trim();
            DateTime dataUso = dtpDataUso.Value;

            if (string.IsNullOrEmpty(radu) || (idProduto == null && idAtivo == null))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idAtivo != null && qtdProduto > 1)
            {
                MessageBox.Show("Ativos só podem ser cadastrados com quantidade igual a 1.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.conn))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string query = @"INSERT INTO emuso (IdProduto, IdAtivo, DataUso, Radu, QtdProduto, Descricao, Associado)
                                 VALUES (@IdProduto, @IdAtivo, @DataUso, @Radu, @QtdProduto, @Descricao)";

                        using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@IdProduto", (object)idProduto ?? DBNull.Value);
                            command.Parameters.AddWithValue("@IdAtivo", (object)idAtivo ?? DBNull.Value);
                            command.Parameters.AddWithValue("@DataUso", dataUso);
                            command.Parameters.AddWithValue("@Radu", radu);
                            command.Parameters.AddWithValue("@QtdProduto", qtdProduto);
                            command.Parameters.AddWithValue("@Descricao", descricao);
                            //command.Parameters.AddWithValue("@Associado", associado);

                            command.ExecuteNonQuery();
                        }

                        if (idAtivo != null)
                        {
                            string updateAtivo = "UPDATE ativos SET Status = 2 WHERE IdAtivo = @IdAtivo";
                            using (MySqlCommand command = new MySqlCommand(updateAtivo, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@IdAtivo", idAtivo.Value);
                                command.ExecuteNonQuery();
                            }
                            HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O usuário designou o Ativo: " + idAtivo.Value + " para o Radu: " + radu);
                        }

                        if (idProduto != null)
                        {
                            string updateProduto = "UPDATE produtos SET QtdEstoque = QtdEstoque - @QtdProduto WHERE IdProduto = @IdProduto AND QtdEstoque >= @QtdProduto";
                            using (MySqlCommand command = new MySqlCommand(updateProduto, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@IdProduto", idProduto.Value);
                                command.Parameters.AddWithValue("@QtdProduto", qtdProduto);

                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    throw new Exception("Quantidade insuficiente no estoque.");
                                }
                                HistoricoService.RegistrarAcao(Usuario.IdUsuario, "O usuário designou o Produto: " + idProduto.Value + " com a quantidade: " + qtdProduto + " para o Radu: " + radu);
                            }
                        }

                        transaction.Commit();

                        MessageBox.Show("Registro salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar com o banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduto.SelectedIndex >= 1)
            {
                cboAtivo.SelectedIndex = -1;
                cboAtivo.Enabled = false;
                nudQtdProduto.Enabled = true;
            }
            else
            {
                cboAtivo.Enabled = true;
            }
        }

        private void cboAtivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAtivo.SelectedIndex >= 1)
            {
                cboProduto.SelectedIndex = -1;
                cboProduto.Enabled = false;
                nudQtdProduto.Value = 1;
                nudQtdProduto.Enabled = false;
            }
            else
            {
                cboProduto.Enabled = true;
                nudQtdProduto.Enabled = true;
            }
        }

        private void DesignarTecnico_Load(object sender, EventArgs e)
        {
            dtpDataUso.Value = DateTime.Now;
            Combos.PreencherComboBox(cboRadu, "usuarios", "IdUsuario", "Usuario","Cargo","TC");
            Combos.PreencherComboBox(cboProduto, "produtos", "IdProduto", "Nome","Status","1");
            Combos.PreencherComboBox(cboAtivo, "ativos", "IdAtivo", "Patrimonio","Status","1");
            Combos.PreencherComboBox(txtAssociado,"clientes","IdCliente","Nome");
        }
    }
}
