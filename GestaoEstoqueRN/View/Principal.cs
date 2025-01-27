using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                // Verifica se o formulário já está aberto
                Form ?frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Estoque);

                MudarCorTitulo(btnEstoque);

                if (frm != null)
                {
                    // Se o formulário já está aberto, traz para o primeiro plano
                    frm.BringToFront();
                }
                else
                {
                    // Se não está aberto, cria uma nova instância e mostra
                    frm = new Estoque();
                    frm.MdiParent = this;
                    frm.Dock = DockStyle.Fill;
                    //frm.Text = "";
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
                Form ?frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is EstoqueAtivos);

                MudarCorTitulo(btnEstoqueAtivos);


                if (frm != null)
                {
                    // Se o formulário já está aberto, traz para o primeiro plano
                    frm.BringToFront();
                }
                else
                {
                    // Se não está aberto, cria uma nova instância e mostra
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
                Form ?frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is ExibirTecnico);

                //this.toolStripButton1.ForeColor = Color.Black;
                MudarCorTitulo(btnDesignarTecnico);

                if (frm != null)
                {
                    // Se o formulário já está aberto, traz para o primeiro plano
                    frm.BringToFront();
                }
                else
                {
                    // Se não está aberto, cria uma nova instância e mostra
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
    }
}
