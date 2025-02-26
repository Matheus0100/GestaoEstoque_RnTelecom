namespace GestaoEstoqueRN.View
{
    partial class CadastroCliente
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
            cboTipo = new ComboBox();
            txtNome = new TextBox();
            label11 = new Label();
            txtCpfCnpj = new TextBox();
            txtCodigo = new TextBox();
            label9 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtEndereco = new TextBox();
            label1 = new Label();
            dtpDataNascimento = new DateTimePicker();
            label12 = new Label();
            txtRg = new MaskedTextBox();
            cboGenero = new ComboBox();
            label7 = new Label();
            label13 = new Label();
            txtCep = new MaskedTextBox();
            label5 = new Label();
            txtCidade = new TextBox();
            label6 = new Label();
            txtBairro = new TextBox();
            label8 = new Label();
            txtTelefone = new MaskedTextBox();
            SuspendLayout();
            // 
            // btnCadastrar
            // 
            btnCadastrar.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnCadastrar.ForeColor = Color.Black;
            btnCadastrar.Image = Properties.Resources.save_outline1;
            btnCadastrar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCadastrar.Location = new Point(423, 466);
            btnCadastrar.Margin = new Padding(4, 3, 4, 3);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(108, 42);
            btnCadastrar.TabIndex = 70;
            btnCadastrar.Text = "Salvar";
            btnCadastrar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(320, 129);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(211, 23);
            cboTipo.TabIndex = 69;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(31, 61);
            txtNome.Margin = new Padding(4, 3, 4, 3);
            txtNome.Multiline = true;
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "INSERIR";
            txtNome.Size = new Size(213, 23);
            txtNome.TabIndex = 68;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.Control;
            label11.Location = new Point(31, 40);
            label11.Name = "label11";
            label11.Size = new Size(54, 18);
            label11.TabIndex = 67;
            label11.Text = "NOME";
            // 
            // txtCpfCnpj
            // 
            txtCpfCnpj.Location = new Point(31, 129);
            txtCpfCnpj.Margin = new Padding(4, 3, 4, 3);
            txtCpfCnpj.Multiline = true;
            txtCpfCnpj.Name = "txtCpfCnpj";
            txtCpfCnpj.PlaceholderText = "INSERIR";
            txtCpfCnpj.Size = new Size(213, 23);
            txtCpfCnpj.TabIndex = 64;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(320, 61);
            txtCodigo.Margin = new Padding(4, 3, 4, 3);
            txtCodigo.Multiline = true;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.PlaceholderText = "INSERIR";
            txtCodigo.Size = new Size(211, 23);
            txtCodigo.TabIndex = 63;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(31, 322);
            label9.Name = "label9";
            label9.Size = new Size(94, 18);
            label9.TabIndex = 59;
            label9.Text = "ENDEREÇO";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(31, 108);
            label4.Name = "label4";
            label4.Size = new Size(82, 18);
            label4.TabIndex = 54;
            label4.Text = "CPF/CNPJ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(319, 40);
            label3.Name = "label3";
            label3.Size = new Size(70, 18);
            label3.TabIndex = 53;
            label3.Text = "CÓDIGO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(319, 108);
            label2.Name = "label2";
            label2.Size = new Size(44, 18);
            label2.TabIndex = 52;
            label2.Text = "TIPO";
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(31, 343);
            txtEndereco.Margin = new Padding(4, 3, 4, 3);
            txtEndereco.Multiline = true;
            txtEndereco.Name = "txtEndereco";
            txtEndereco.PlaceholderText = "INSERIR";
            txtEndereco.Size = new Size(500, 23);
            txtEndereco.TabIndex = 50;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(321, 250);
            label1.Name = "label1";
            label1.Size = new Size(174, 18);
            label1.TabIndex = 72;
            label1.Text = "DATA DE NASCIMENTO";
            // 
            // dtpDataNascimento
            // 
            dtpDataNascimento.Format = DateTimePickerFormat.Short;
            dtpDataNascimento.Location = new Point(321, 272);
            dtpDataNascimento.Name = "dtpDataNascimento";
            dtpDataNascimento.Size = new Size(210, 23);
            dtpDataNascimento.TabIndex = 73;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = SystemColors.Control;
            label12.Location = new Point(31, 185);
            label12.Name = "label12";
            label12.Size = new Size(31, 18);
            label12.TabIndex = 76;
            label12.Text = "RG";
            // 
            // txtRg
            // 
            txtRg.Location = new Point(31, 207);
            txtRg.Mask = "9999999 AA";
            txtRg.Name = "txtRg";
            txtRg.Size = new Size(213, 23);
            txtRg.TabIndex = 78;
            // 
            // cboGenero
            // 
            cboGenero.FormattingEnabled = true;
            cboGenero.Location = new Point(321, 207);
            cboGenero.Name = "cboGenero";
            cboGenero.Size = new Size(210, 23);
            cboGenero.TabIndex = 80;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(320, 186);
            label7.Name = "label7";
            label7.Size = new Size(74, 18);
            label7.TabIndex = 79;
            label7.Text = "GÊNERO";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = SystemColors.Control;
            label13.Location = new Point(31, 251);
            label13.Name = "label13";
            label13.Size = new Size(39, 18);
            label13.TabIndex = 82;
            label13.Text = "CEP";
            // 
            // txtCep
            // 
            txtCep.Location = new Point(31, 272);
            txtCep.Mask = "99999-999";
            txtCep.Name = "txtCep";
            txtCep.Size = new Size(213, 23);
            txtCep.TabIndex = 81;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(32, 389);
            label5.Name = "label5";
            label5.Size = new Size(64, 18);
            label5.TabIndex = 84;
            label5.Text = "CIDADE";
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(32, 410);
            txtCidade.Margin = new Padding(4, 3, 4, 3);
            txtCidade.Multiline = true;
            txtCidade.Name = "txtCidade";
            txtCidade.PlaceholderText = "INSERIR";
            txtCidade.Size = new Size(212, 23);
            txtCidade.TabIndex = 83;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(319, 389);
            label6.Name = "label6";
            label6.Size = new Size(66, 18);
            label6.TabIndex = 86;
            label6.Text = "BAIRRO";
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(319, 410);
            txtBairro.Margin = new Padding(4, 3, 4, 3);
            txtBairro.Multiline = true;
            txtBairro.Name = "txtBairro";
            txtBairro.PlaceholderText = "INSERIR";
            txtBairro.Size = new Size(212, 23);
            txtBairro.TabIndex = 85;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(32, 458);
            label8.Name = "label8";
            label8.Size = new Size(89, 18);
            label8.TabIndex = 88;
            label8.Text = "TELEFONE";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(31, 479);
            txtTelefone.Mask = "99 99999-9999";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(213, 23);
            txtTelefone.TabIndex = 89;
            // 
            // CadastroCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkRed;
            ClientSize = new Size(567, 527);
            Controls.Add(txtTelefone);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(txtBairro);
            Controls.Add(label5);
            Controls.Add(txtCidade);
            Controls.Add(label13);
            Controls.Add(txtCep);
            Controls.Add(cboGenero);
            Controls.Add(label7);
            Controls.Add(txtRg);
            Controls.Add(label12);
            Controls.Add(dtpDataNascimento);
            Controls.Add(label1);
            Controls.Add(btnCadastrar);
            Controls.Add(cboTipo);
            Controls.Add(txtNome);
            Controls.Add(label11);
            Controls.Add(txtCpfCnpj);
            Controls.Add(txtCodigo);
            Controls.Add(label9);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtEndereco);
            MaximumSize = new Size(583, 566);
            MinimumSize = new Size(583, 566);
            Name = "CadastroCliente";
            Text = "Cadastro de Clientes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button btnCadastrar;
        private ComboBox cboTipo;
        private TextBox txtNome;
        private Label label11;
        private TextBox txtCpfCnpj;
        private TextBox txtCodigo;
        private Label label9;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtEndereco;
        private Label label1;
        private DateTimePicker dtpDataNascimento;
        private Label label12;
        private MaskedTextBox txtRg;
        private ComboBox cboGenero;
        private Label label7;
        private Label label13;
        private MaskedTextBox txtCep;
        private Label label5;
        private TextBox txtCidade;
        private Label label6;
        private TextBox txtBairro;
        private Label label8;
        private MaskedTextBox txtTelefone;
    }
}