namespace GestaoEstoqueRN.Views
{
    partial class CadastroAtivo
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
            btnCadastrar = new Button();
            txtObservacao = new TextBox();
            txtSerial = new TextBox();
            cboAtivo = new ComboBox();
            btnRetorno = new Button();
            dtpDataCompra = new DateTimePicker();
            dtpDataGarantia = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtPatrimonio = new TextBox();
            txtNotaFiscal = new TextBox();
            txtModelo = new TextBox();
            txtMarca = new TextBox();
            nudValor = new NumericUpDown();
            label1 = new Label();
            cboStatus = new ComboBox();
            txtLocalizacao = new TextBox();
            lblLocalizacao = new Label();
            ((System.ComponentModel.ISupportInitialize)nudValor).BeginInit();
            SuspendLayout();
            // 
            // btnCadastrar
            // 
            btnCadastrar.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnCadastrar.ForeColor = Color.Black;
            btnCadastrar.Image = Properties.Resources.save_outline1;
            btnCadastrar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCadastrar.Location = new Point(435, 526);
            btnCadastrar.Margin = new Padding(4, 3, 4, 3);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(108, 42);
            btnCadastrar.TabIndex = 48;
            btnCadastrar.Text = "Salvar";
            btnCadastrar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // txtObservacao
            // 
            txtObservacao.Location = new Point(63, 454);
            txtObservacao.Margin = new Padding(4, 3, 4, 3);
            txtObservacao.Multiline = true;
            txtObservacao.Name = "txtObservacao";
            txtObservacao.PlaceholderText = "INSERIR";
            txtObservacao.Size = new Size(215, 114);
            txtObservacao.TabIndex = 39;
            // 
            // txtSerial
            // 
            txtSerial.Location = new Point(63, 284);
            txtSerial.Margin = new Padding(4, 3, 4, 3);
            txtSerial.Multiline = true;
            txtSerial.Name = "txtSerial";
            txtSerial.PlaceholderText = "INSERIR";
            txtSerial.Size = new Size(215, 23);
            txtSerial.TabIndex = 33;
            // 
            // cboAtivo
            // 
            cboAtivo.FormattingEnabled = true;
            cboAtivo.Location = new Point(63, 111);
            cboAtivo.Margin = new Padding(4, 3, 4, 3);
            cboAtivo.Name = "cboAtivo";
            cboAtivo.Size = new Size(215, 23);
            cboAtivo.TabIndex = 28;
            // 
            // btnRetorno
            // 
            btnRetorno.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRetorno.ForeColor = Color.Black;
            btnRetorno.Location = new Point(420, 14);
            btnRetorno.Margin = new Padding(4, 3, 4, 3);
            btnRetorno.Name = "btnRetorno";
            btnRetorno.Size = new Size(123, 41);
            btnRetorno.TabIndex = 51;
            btnRetorno.Text = "RETORNANDO AO\r\n ESTOQUE";
            btnRetorno.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRetorno.UseVisualStyleBackColor = true;
            btnRetorno.Click += btnRetorno_Click;
            // 
            // dtpDataCompra
            // 
            dtpDataCompra.Format = DateTimePickerFormat.Short;
            dtpDataCompra.Location = new Point(328, 454);
            dtpDataCompra.Name = "dtpDataCompra";
            dtpDataCompra.Size = new Size(215, 23);
            dtpDataCompra.TabIndex = 55;
            // 
            // dtpDataGarantia
            // 
            dtpDataGarantia.Format = DateTimePickerFormat.Short;
            dtpDataGarantia.Location = new Point(328, 370);
            dtpDataGarantia.Name = "dtpDataGarantia";
            dtpDataGarantia.Size = new Size(215, 23);
            dtpDataGarantia.TabIndex = 54;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(328, 349);
            label6.Name = "label6";
            label6.Size = new Size(148, 18);
            label6.TabIndex = 53;
            label6.Text = "DATA DE GARANTIA";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(328, 433);
            label5.Name = "label5";
            label5.Size = new Size(139, 18);
            label5.TabIndex = 52;
            label5.Text = "DATA DE COMPRA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(63, 349);
            label2.Name = "label2";
            label2.Size = new Size(104, 18);
            label2.TabIndex = 56;
            label2.Text = "NOTA FISCAL";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(328, 263);
            label3.Name = "label3";
            label3.Size = new Size(57, 18);
            label3.TabIndex = 57;
            label3.Text = "VALOR";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(328, 177);
            label4.Name = "label4";
            label4.Size = new Size(102, 18);
            label4.TabIndex = 58;
            label4.Text = "PATRIMÔNIO";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(63, 263);
            label7.Name = "label7";
            label7.Size = new Size(61, 18);
            label7.TabIndex = 59;
            label7.Text = "SERIAL";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(63, 90);
            label8.Name = "label8";
            label8.Size = new Size(115, 18);
            label8.TabIndex = 60;
            label8.Text = "TIPO DE ATIVO";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(328, 90);
            label9.Name = "label9";
            label9.Size = new Size(61, 18);
            label9.TabIndex = 61;
            label9.Text = "MARCA";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.Control;
            label10.Location = new Point(63, 177);
            label10.Name = "label10";
            label10.Size = new Size(75, 18);
            label10.TabIndex = 62;
            label10.Text = "MODELO";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.Control;
            label11.Location = new Point(63, 433);
            label11.Name = "label11";
            label11.Size = new Size(111, 18);
            label11.TabIndex = 63;
            label11.Text = "OBSERVAÇÃO";
            // 
            // txtPatrimonio
            // 
            txtPatrimonio.Location = new Point(328, 198);
            txtPatrimonio.Margin = new Padding(4, 3, 4, 3);
            txtPatrimonio.Multiline = true;
            txtPatrimonio.Name = "txtPatrimonio";
            txtPatrimonio.PlaceholderText = "INSERIR";
            txtPatrimonio.Size = new Size(215, 23);
            txtPatrimonio.TabIndex = 64;
            // 
            // txtNotaFiscal
            // 
            txtNotaFiscal.Location = new Point(63, 370);
            txtNotaFiscal.Margin = new Padding(4, 3, 4, 3);
            txtNotaFiscal.Multiline = true;
            txtNotaFiscal.Name = "txtNotaFiscal";
            txtNotaFiscal.PlaceholderText = "INSERIR";
            txtNotaFiscal.Size = new Size(215, 23);
            txtNotaFiscal.TabIndex = 66;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(63, 198);
            txtModelo.Margin = new Padding(4, 3, 4, 3);
            txtModelo.Multiline = true;
            txtModelo.Name = "txtModelo";
            txtModelo.PlaceholderText = "INSERIR";
            txtModelo.Size = new Size(215, 23);
            txtModelo.TabIndex = 67;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(328, 111);
            txtMarca.Margin = new Padding(4, 3, 4, 3);
            txtMarca.Multiline = true;
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "INSERIR";
            txtMarca.Size = new Size(215, 23);
            txtMarca.TabIndex = 68;
            // 
            // nudValor
            // 
            nudValor.DecimalPlaces = 2;
            nudValor.Location = new Point(328, 285);
            nudValor.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudValor.Name = "nudValor";
            nudValor.Size = new Size(215, 23);
            nudValor.TabIndex = 69;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(63, 14);
            label1.Name = "label1";
            label1.Size = new Size(66, 18);
            label1.TabIndex = 71;
            label1.Text = "STATUS";
            label1.Visible = false;
            // 
            // cboStatus
            // 
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(63, 35);
            cboStatus.Margin = new Padding(4, 3, 4, 3);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(215, 23);
            cboStatus.TabIndex = 70;
            cboStatus.Visible = false;
            // 
            // txtLocalizacao
            // 
            txtLocalizacao.Location = new Point(328, 536);
            txtLocalizacao.Margin = new Padding(4, 3, 4, 3);
            txtLocalizacao.Multiline = true;
            txtLocalizacao.Name = "txtLocalizacao";
            txtLocalizacao.PlaceholderText = "INSERIR";
            txtLocalizacao.Size = new Size(215, 23);
            txtLocalizacao.TabIndex = 73;
            txtLocalizacao.Visible = false;
            // 
            // lblLocalizacao
            // 
            lblLocalizacao.AutoSize = true;
            lblLocalizacao.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblLocalizacao.ForeColor = SystemColors.Control;
            lblLocalizacao.Location = new Point(328, 515);
            lblLocalizacao.Name = "lblLocalizacao";
            lblLocalizacao.Size = new Size(111, 18);
            lblLocalizacao.TabIndex = 72;
            lblLocalizacao.Text = "LOCALIZAÇÃO";
            lblLocalizacao.Visible = false;
            // 
            // CadastroAtivo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(607, 589);
            Controls.Add(txtLocalizacao);
            Controls.Add(lblLocalizacao);
            Controls.Add(label1);
            Controls.Add(cboStatus);
            Controls.Add(nudValor);
            Controls.Add(txtMarca);
            Controls.Add(txtModelo);
            Controls.Add(txtNotaFiscal);
            Controls.Add(txtPatrimonio);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpDataCompra);
            Controls.Add(dtpDataGarantia);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnRetorno);
            Controls.Add(btnCadastrar);
            Controls.Add(txtObservacao);
            Controls.Add(txtSerial);
            Controls.Add(cboAtivo);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(623, 628);
            MinimumSize = new Size(623, 628);
            Name = "CadastroAtivo";
            Text = "Cadastrar Ativo";
            Load += CadastroAtivo_Load;
            ((System.ComponentModel.ISupportInitialize)nudValor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox cboAtivo;
        private DateTimePicker dtpDataCompra;
        private DateTimePicker dtpDataGarantia;
        private Label label6;
        private Label label5;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtPatrimonio;
        private TextBox txtNotaFiscal;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private NumericUpDown nudValor;
        public Button btnCadastrar;
        public Button btnRetorno;
        private Label label1;
        private ComboBox cboStatus;
        public TextBox txtLocalizacao;
        public Label lblLocalizacao;
        private Label label12;
    }
}