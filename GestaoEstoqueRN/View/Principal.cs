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
            this.LayoutMdi(MdiLayout.TileHorizontal);
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Estoque frmEstoque = new();
                frmEstoque.MdiParent = this;
                frmEstoque.Dock= DockStyle.Fill;
                frmEstoque.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao clicar no botão estoque. Erro: " + ex.Message);
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                EstoqueAtivos frmEstoqueAtivos = new();
                frmEstoqueAtivos.MdiParent = this;
                frmEstoqueAtivos.Dock= DockStyle.Fill;
                frmEstoqueAtivos.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao clicar no botão estoque ativos. Erro: " + ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ExibirTecnico frmDesignarTecnico = new();
                frmDesignarTecnico.MdiParent = this;
                frmDesignarTecnico.Dock = DockStyle.Fill;
                frmDesignarTecnico.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao clicar no botão Designar para Técnico. Erro: " + ex.Message);
            }
        }
    }
}
