namespace GestaoEstoqueRN.Views
{
    partial class InformacaoEstoque
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
            txtTipo = new ComboBox();
            txtNome = new TextBox();
            label11 = new Label();
            nudQtdEstoque = new NumericUpDown();
            nudPreco = new NumericUpDown();
            txtModelo = new TextBox();
            txtMarca = new TextBox();
            dtpDataCompra = new DateTimePicker();
            dtpDataGarantia = new DateTimePicker();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtDescricao = new TextBox();
            txtNotaFiscal = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudQtdEstoque).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPreco).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 14.25F, FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(28, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(290, 23);
            label1.TabIndex = 52;
            label1.Text = "INFORMAÇÕES DO ESTOQUE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTipo
            // 
            txtTipo.FormattingEnabled = true;
            txtTipo.Items.AddRange(new object[] { "Fibra", "Conector", "Outro" });
            txtTipo.Location = new Point(28, 150);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(213, 23);
            txtTipo.TabIndex = 105;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(28, 80);
            txtNome.Margin = new Padding(4, 3, 4, 3);
            txtNome.Multiline = true;
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "INSERIR";
            txtNome.Size = new Size(213, 23);
            txtNome.TabIndex = 104;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.Control;
            label11.Location = new Point(28, 59);
            label11.Name = "label11";
            label11.Size = new Size(54, 18);
            label11.TabIndex = 103;
            label11.Text = "NOME";
            // 
            // nudQtdEstoque
            // 
            nudQtdEstoque.Location = new Point(316, 226);
            nudQtdEstoque.Name = "nudQtdEstoque";
            nudQtdEstoque.Size = new Size(213, 23);
            nudQtdEstoque.TabIndex = 102;
            // 
            // nudPreco
            // 
            nudPreco.DecimalPlaces = 2;
            nudPreco.Location = new Point(28, 294);
            nudPreco.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(213, 23);
            nudPreco.TabIndex = 101;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(28, 225);
            txtModelo.Margin = new Padding(4, 3, 4, 3);
            txtModelo.Multiline = true;
            txtModelo.Name = "txtModelo";
            txtModelo.PlaceholderText = "INSERIR";
            txtModelo.Size = new Size(213, 23);
            txtModelo.TabIndex = 100;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(317, 150);
            txtMarca.Margin = new Padding(4, 3, 4, 3);
            txtMarca.Multiline = true;
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "INSERIR";
            txtMarca.Size = new Size(212, 23);
            txtMarca.TabIndex = 99;
            // 
            // dtpDataCompra
            // 
            dtpDataCompra.Format = DateTimePickerFormat.Short;
            dtpDataCompra.Location = new Point(28, 361);
            dtpDataCompra.Name = "dtpDataCompra";
            dtpDataCompra.Size = new Size(213, 23);
            dtpDataCompra.TabIndex = 98;
            // 
            // dtpDataGarantia
            // 
            dtpDataGarantia.Format = DateTimePickerFormat.Short;
            dtpDataGarantia.Location = new Point(317, 361);
            dtpDataGarantia.Name = "dtpDataGarantia";
            dtpDataGarantia.Size = new Size(212, 23);
            dtpDataGarantia.TabIndex = 97;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.Control;
            label10.Location = new Point(28, 405);
            label10.Name = "label10";
            label10.Size = new Size(97, 18);
            label10.TabIndex = 96;
            label10.Text = "DESCRIÇÃO";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(317, 272);
            label9.Name = "label9";
            label9.Size = new Size(104, 18);
            label9.TabIndex = 95;
            label9.Text = "NOTA FISCAL";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(28, 272);
            label8.Name = "label8";
            label8.Size = new Size(133, 18);
            label8.TabIndex = 94;
            label8.Text = "VALOR UNITÁRIO";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(317, 204);
            label7.Name = "label7";
            label7.Size = new Size(106, 18);
            label7.TabIndex = 93;
            label7.Text = "QUANTIDADE";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(317, 340);
            label6.Name = "label6";
            label6.Size = new Size(148, 18);
            label6.TabIndex = 92;
            label6.Text = "DATA DE GARANTIA";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(28, 340);
            label5.Name = "label5";
            label5.Size = new Size(139, 18);
            label5.TabIndex = 91;
            label5.Text = "DATA DE COMPRA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(29, 204);
            label4.Name = "label4";
            label4.Size = new Size(75, 18);
            label4.TabIndex = 90;
            label4.Text = "MODELO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(317, 129);
            label3.Name = "label3";
            label3.Size = new Size(61, 18);
            label3.TabIndex = 89;
            label3.Text = "MARCA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(28, 129);
            label2.Name = "label2";
            label2.Size = new Size(44, 18);
            label2.TabIndex = 88;
            label2.Text = "TIPO";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(31, 426);
            txtDescricao.Margin = new Padding(4, 3, 4, 3);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.PlaceholderText = "INSERIR";
            txtDescricao.Size = new Size(498, 86);
            txtDescricao.TabIndex = 86;
            // 
            // txtNotaFiscal
            // 
            txtNotaFiscal.Location = new Point(317, 293);
            txtNotaFiscal.Margin = new Padding(4, 3, 4, 3);
            txtNotaFiscal.Multiline = true;
            txtNotaFiscal.Name = "txtNotaFiscal";
            txtNotaFiscal.PlaceholderText = "INSERIR";
            txtNotaFiscal.Size = new Size(212, 23);
            txtNotaFiscal.TabIndex = 85;
            // 
            // InformacaoEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(557, 536);
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
            Controls.Add(txtDescricao);
            Controls.Add(txtNotaFiscal);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(573, 575);
            MinimumSize = new Size(573, 575);
            Name = "InformacaoEstoque";
            Text = "Exibição das informações do estoque";
            Load += InformacaoEstoque_Load;
            ((System.ComponentModel.ISupportInitialize)nudQtdEstoque).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPreco).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private ComboBox txtTipo;
        private TextBox txtNome;
        private Label label11;
        private NumericUpDown nudQtdEstoque;
        private NumericUpDown nudPreco;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private DateTimePicker dtpDataCompra;
        private DateTimePicker dtpDataGarantia;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtDescricao;
        private TextBox txtNotaFiscal;
    }
}