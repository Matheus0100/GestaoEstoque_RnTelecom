using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoEstoqueRN
{
    public partial class ExibirTecnico : Form
    {
        public ExibirTecnico()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
