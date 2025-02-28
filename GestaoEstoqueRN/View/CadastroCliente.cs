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
//using MySql.Data.MySqlClient;
using MySqlConnector;

namespace GestaoEstoqueRN.View
{
    public partial class CadastroCliente : Form
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string telefone = txtTelefone.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            //string email = txtEmail.Text.Trim();
            string tipo = cboTipo.Text == "-- Selecione --" ? "" : cboTipo.Text;
            string cpfCnpj = txtCpfCnpj.Text.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            string rg = txtRg.Text.Trim().Replace(".", "").Replace("-", "");
            string genero = cboGenero.Text == "-- Selecione --" ? "" : cboGenero.Text;
            DateTime dataNasc = dtpDataNascimento.Value;
            string cep = txtCep.Text.Trim().Replace("-", "");
            string endereco = txtEndereco.Text.Trim();
            string cidade = txtCidade.Text.Trim();
            string bairro = txtBairro.Text.Trim();

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("O campo Nome é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtCodigo.Text) || !int.TryParse(txtCodigo.Text, out int codigo))
            {
                MessageBox.Show("O campo Código é obrigatório e deve conter apenas números!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                using (MySqlConnection connection = new MySqlConnection(Database.conn))
                {
                    connection.Open();

                    string query = @"INSERT INTO clientes (Nome, Telefone, Codigo, Tipo, CpfCnpj, Rg, Genero, DataNasc, Cep, Endereco, Cidade, Bairro) 
                             VALUES (@Nome, @Telefone, @Codigo, @Tipo, @CpfCnpj, @Rg, @Genero, @DataNasc, @Cep, @Endereco, @Cidade, @Bairro)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@Telefone", string.IsNullOrEmpty(telefone) ? DBNull.Value : (object)telefone);
                        //command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? DBNull.Value : (object)email);
                        command.Parameters.AddWithValue("@Codigo", codigo);
                        command.Parameters.AddWithValue("@Tipo", string.IsNullOrEmpty(tipo) ? DBNull.Value : (object)tipo);
                        command.Parameters.AddWithValue("@CpfCnpj", string.IsNullOrEmpty(cpfCnpj) ? DBNull.Value : (object)cpfCnpj);
                        command.Parameters.AddWithValue("@Rg", string.IsNullOrEmpty(rg) ? DBNull.Value : (object)rg);
                        command.Parameters.AddWithValue("@Genero", string.IsNullOrEmpty(genero) ? DBNull.Value : (object)genero);
                        command.Parameters.AddWithValue("@DataNasc", dataNasc);
                        command.Parameters.AddWithValue("@Cep", string.IsNullOrEmpty(cep) ? DBNull.Value : (object)cep);
                        command.Parameters.AddWithValue("@Endereco", string.IsNullOrEmpty(endereco) ? DBNull.Value : (object)endereco);
                        command.Parameters.AddWithValue("@Cidade", string.IsNullOrEmpty(cidade) ? DBNull.Value : (object)cidade);
                        command.Parameters.AddWithValue("@Bairro", string.IsNullOrEmpty(bairro) ? DBNull.Value : (object)bairro);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparCampos()
        {
            txtNome.Clear();
            txtTelefone.Clear();
            //txtEmail.Clear();
            txtCodigo.Clear();
            cboTipo.SelectedIndex = 0;
            txtCpfCnpj.Clear();
            txtRg.Clear();
            cboGenero.SelectedIndex = 0;
            dtpDataNascimento.Value = DateTime.Now;
            txtCep.Clear();
            txtEndereco.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
        }

        private void CadastroCliente_Load(object sender, EventArgs e)
        {
            Combos.PreencherComboBox(cboTipo, "tipocliente", "IdTipoCliente", "NomeTipoCliente");
            Combos.PreencherComboBox(cboGenero, "tipogenero", "IdTipoGenero", "NomeTipoGenero");
        }
    }
}
