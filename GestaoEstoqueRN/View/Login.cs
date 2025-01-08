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
            try
            {
                Form frmHome = new Home();
                this.Hide();
                frmHome.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado ao tentar entrar na aplicação. Erro: " + ex.Message);
            }
        }
    }
}
