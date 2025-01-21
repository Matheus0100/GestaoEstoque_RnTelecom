namespace GestaoEstoqueRN.Views
{
    partial class CadastroEstoque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtNotaFiscal = new TextBox();
            txtDescricao = new TextBox();
            btnCadastrar = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            dtpDataGarantia = new DateTimePicker();
            dtpDataCompra = new DateTimePicker();
            txtMarca = new TextBox();
            txtModelo = new TextBox();
            nudPreco = new NumericUpDown();
            nudQtdEstoque = new NumericUpDown();
            txtNome = new TextBox();
            label11 = new Label();
            txtTipo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQtdEstoque).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(62, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(244, 28);
            label1.TabIndex = 0;
            label1.Text = "CADASTRO DE ESTOQUE";
            // 
            // txtNotaFiscal
            // 
            txtNotaFiscal.Location = new Point(351, 304);
            txtNotaFiscal.Margin = new Padding(4, 3, 4, 3);
            txtNotaFiscal.Multiline = true;
            txtNotaFiscal.Name = "txtNotaFiscal";
            txtNotaFiscal.PlaceholderText = "INSERIR";
            txtNotaFiscal.Size = new Size(212, 23);
            txtNotaFiscal.TabIndex = 11;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(65, 437);
            txtDescricao.Margin = new Padding(4, 3, 4, 3);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.PlaceholderText = "INSERIR";
            txtDescricao.Size = new Size(498, 86);
            txtDescricao.TabIndex = 16;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCadastrar.ForeColor = Color.FromArgb(192, 0, 0);
            btnCadastrar.Location = new Point(431, 541);
            btnCadastrar.Margin = new Padding(4, 3, 4, 3);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(132, 42);
            btnCadastrar.TabIndex = 25;
            btnCadastrar.Text = "CADASTRAR\r\n  ESTOQUE";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(62, 140);
            label2.Name = "label2";
            label2.Size = new Size(44, 18);
            label2.TabIndex = 28;
            label2.Text = "TIPO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(351, 140);
            label3.Name = "label3";
            label3.Size = new Size(61, 18);
            label3.TabIndex = 29;
            label3.Text = "MARCA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(63, 215);
            label4.Name = "label4";
            label4.Size = new Size(75, 18);
            label4.TabIndex = 30;
            label4.Text = "MODELO";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(62, 351);
            label5.Name = "label5";
            label5.Size = new Size(139, 18);
            label5.TabIndex = 31;
            label5.Text = "DATA DE COMPRA";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(351, 351);
            label6.Name = "label6";
            label6.Size = new Size(148, 18);
            label6.TabIndex = 32;
            label6.Text = "DATA DE GARANTIA";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(351, 215);
            label7.Name = "label7";
            label7.Size = new Size(106, 18);
            label7.TabIndex = 33;
            label7.Text = "QUANTIDADE";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(62, 283);
            label8.Name = "label8";
            label8.Size = new Size(133, 18);
            label8.TabIndex = 34;
            label8.Text = "VALOR UNITÁRIO";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(351, 283);
            label9.Name = "label9";
            label9.Size = new Size(104, 18);
            label9.TabIndex = 35;
            label9.Text = "NOTA FISCAL";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.Control;
            label10.Location = new Point(62, 416);
            label10.Name = "label10";
            label10.Size = new Size(97, 18);
            label10.TabIndex = 36;
            label10.Text = "DESCRIÇÃO";
            // 
            // dtpDataGarantia
            // 
            dtpDataGarantia.Format = DateTimePickerFormat.Short;
            dtpDataGarantia.Location = new Point(351, 372);
            dtpDataGarantia.Name = "dtpDataGarantia";
            dtpDataGarantia.Size = new Size(212, 23);
            dtpDataGarantia.TabIndex = 37;
            // 
            // dtpDataCompra
            // 
            dtpDataCompra.Format = DateTimePickerFormat.Short;
            dtpDataCompra.Location = new Point(62, 372);
            dtpDataCompra.Name = "dtpDataCompra";
            dtpDataCompra.Size = new Size(213, 23);
            dtpDataCompra.TabIndex = 38;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(351, 161);
            txtMarca.Margin = new Padding(4, 3, 4, 3);
            txtMarca.Multiline = true;
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "INSERIR";
            txtMarca.Size = new Size(212, 23);
            txtMarca.TabIndex = 39;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(62, 236);
            txtModelo.Margin = new Padding(4, 3, 4, 3);
            txtModelo.Multiline = true;
            txtModelo.Name = "txtModelo";
            txtModelo.PlaceholderText = "INSERIR";
            txtModelo.Size = new Size(213, 23);
            txtModelo.TabIndex = 40;
            // 
            // nudPreco
            // 
            nudPreco.DecimalPlaces = 2;
            nudPreco.Location = new Point(62, 305);
            nudPreco.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(213, 23);
            nudPreco.TabIndex = 42;
            // 
            // nudQtdEstoque
            // 
            nudQtdEstoque.Location = new Point(350, 237);
            nudQtdEstoque.Name = "nudQtdEstoque";
            nudQtdEstoque.Size = new Size(213, 23);
            nudQtdEstoque.TabIndex = 43;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(62, 91);
            txtNome.Margin = new Padding(4, 3, 4, 3);
            txtNome.Multiline = true;
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "INSERIR";
            txtNome.Size = new Size(213, 23);
            txtNome.TabIndex = 45;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.Control;
            label11.Location = new Point(62, 70);
            label11.Name = "label11";
            label11.Size = new Size(54, 18);
            label11.TabIndex = 44;
            label11.Text = "NOME";
            // 
            // txtTipo
            // 
            txtTipo.FormattingEnabled = true;
            txtTipo.Items.AddRange(new object[] { "Fibra", "Conector", "Outro" });
            txtTipo.Location = new Point(62, 161);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(213, 23);
            txtTipo.TabIndex = 46;
            // 
            // CadastroEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(618, 595);
            Controls.Add(txtTipo);
            Controls.Add(txtNome);
            Controls.Add(label11);
            Controls.Add(nudQtdEstoque);
            Controls.Add(nudPreco);
            Controls.Add(txtModelo);
            Controls.Add(txtMarca);
            Controls.Add(dtpDataCompra);
            Controls.Add(dtpDataGarantia);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCadastrar);
            Controls.Add(txtDescricao);
            Controls.Add(txtNotaFiscal);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(634, 634);
            MinimumSize = new Size(634, 634);
            Name = "CadastroEstoque";
            Text = "Cadastrar Item ao Estoque";
            ((System.ComponentModel.ISupportInitialize)nudPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQtdEstoque).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.ComboBox cboTipo;
        //private System.Windows.Forms.ComboBox txtMarca;
        private System.Windows.Forms.ComboBox cboModelo;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtNotaFiscal;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnCadastrar;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private DateTimePicker dtpDataGarantia;
        private DateTimePicker dtpDataCompra;
        private TextBox txtMarca;
        private TextBox txtModelo;
        //private TextBox txtTipo;
        private NumericUpDown nudPreco;
        private NumericUpDown nudQtdEstoque;
        private TextBox txtNome;
        private Label label11;
        private ComboBox txtTipo;
    }
}