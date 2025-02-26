using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestaoEstoqueRN.Helper;

namespace GestaoEstoqueRN.Views
{
    public partial class AssociarAtivo : Form
    {
        public int IdClienteSelecionado { get; private set; }
        public AssociarAtivo()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cboAssociado.SelectedIndex >= 1)
            {
                IdClienteSelecionado = Convert.ToInt32(cboAssociado.SelectedValue);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AssociarAtivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AssociarAtivo_Load(object sender, EventArgs e)
        {
            Combos.PreencherComboBox(cboAssociado, "clientes", "IdCliente", "Nome");
        }
    }
}
