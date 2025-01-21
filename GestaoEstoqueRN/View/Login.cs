using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestaoEstoqueRN.Views;
using MySql.Data.MySqlClient;
using GestaoEstoqueRN.DAO;

namespace GestaoEstoqueRN
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                lblMensagem.Text = "Usuário e senha são obrigatórios.";
                lblMensagem.Visible = true;
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Database.conn))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario AND senha = @senha";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@senha", senha);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            //MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Principal frmPrincipal = new Principal();
                            frmPrincipal.Show();
                        }
                        else
                        {
                            lblMensagem.Text = "Usuário ou senha incorretos.";
                            lblMensagem.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            CancelarEnter(sender, e);
        }

        private void CancelarEnter(object sender, KeyPressEventArgs e)
        {
            try 
            {
                //O enter é usado para pular linha quando ativa o multiline da textbox, então eu criei este método para efetuar o login e não pular a linha.
                switch (e.KeyChar)
                {
                    case '\r':
                        e.Handled = true;
                        btnEntrar_Click(sender, e);
                        break;

                    default:
                        break;
                }
            }
            catch(NotImplementedException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            CancelarEnter(sender, e);
        }
    }
}
