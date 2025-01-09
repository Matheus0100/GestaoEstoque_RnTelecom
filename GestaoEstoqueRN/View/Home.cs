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
    public partial class Home : Form
    {
        public Home()
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
                frmEstoqueAtivos.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao clicar no botão estoque ativos. Erro: " + ex.Message);
            }
        }
    }
}
