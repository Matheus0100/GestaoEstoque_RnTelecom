using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestaoEstoqueRN.View;

namespace GestaoEstoqueRN.Views
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            try
            {
                Form? frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Estoque);

                MudarCorTitulo(btnEstoque);

                if (frm != null)
                {
                    frm.BringToFront();
                }
                else
                {
                    frm = new Estoque();
                    frm.MdiParent = this;
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao clicar no botão estoque. Erro: " + ex.Message);
            }
        }
        private void btnEstoqueAtivos_Click(object sender, EventArgs e)
        {
            try
            {
                Form? frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is EstoqueAtivos);

                MudarCorTitulo(btnEstoqueAtivos);


                if (frm != null)
                {
                    frm.BringToFront();
                }
                else
                {
                    frm = new EstoqueAtivos();
                    frm.MdiParent = this;
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao clicar no botão estoque ativos. Erro: " + ex.Message);
            }
        }

        private void btnDesignarTecnico_Click(object sender, EventArgs e)
        {
            try
            {
                Form? frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is ExibirTecnico);

                MudarCorTitulo(btnDesignarTecnico);

                if (frm != null)
                {
                    frm.BringToFront();
                }
                else
                {
                    frm = new ExibirTecnico();
                    frm.MdiParent = this;
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao clicar no botão Designar para Técnico. Erro: " + ex.Message);
            }
        }
        private void MudarCorTitulo(ToolStripButton a)
        {
            try
            {
                //pinta o botão selecionado de preto e o resto de branco
                var numeroItens = toolStrip1.Items.Count;
                for (int i = 0; i < numeroItens; i++)
                {
                    toolStrip1.Items[i].ForeColor = Color.White;
                }
                a.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao mudar a cor do título. Erro: " + ex.Message);
            }
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnCadastrarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                Form? frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is CadastroCliente);

                MudarCorTitulo(btnCadastrarClientes);

                if (frm != null)
                {
                    frm.BringToFront();
                }
                else
                {
                    frm = new CadastroCliente();
                    //frm.MdiParent = this;
                    //frm.Dock = DockStyle.Fill;
                    frm.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao clicar no botão Cadastro de Clientes. Erro: " + ex.Message);
            }
        }
    }
}
