namespace GestaoEstoqueRN.Views
{
    partial class DesignarTecnico
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cboRadu = new ComboBox();
            cboAtivo = new ComboBox();
            cboProduto = new ComboBox();
            btnSalvar = new Button();
            groupBox1 = new GroupBox();
            nudQtdProduto = new NumericUpDown();
            dtpDataUso = new DateTimePicker();
            label5 = new Label();
            txtAssociado = new ComboBox();
            label6 = new Label();
            txtDescricao = new TextBox();
            label7 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQtdProduto).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(53, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(46, 16);
            label1.TabIndex = 0;
            label1.Text = "RADU";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(271, 19);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 16);
            label2.TabIndex = 1;
            label2.Text = "ATIVO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(17, 19);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(75, 16);
            label3.TabIndex = 2;
            label3.Text = "PRODUTO";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(17, 85);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(101, 16);
            label4.TabIndex = 3;
            label4.Text = "QUANTIDADE";
            // 
            // cboRadu
            // 
            cboRadu.ForeColor = Color.Black;
            cboRadu.FormatString = "Selecione";
            cboRadu.FormattingEnabled = true;
            cboRadu.Location = new Point(53, 30);
            cboRadu.Margin = new Padding(4, 3, 4, 3);
            cboRadu.Name = "cboRadu";
            cboRadu.Size = new Size(183, 23);
            cboRadu.TabIndex = 5;
            // 
            // cboAtivo
            // 
            cboAtivo.ForeColor = Color.Black;
            cboAtivo.FormatString = "Selecione";
            cboAtivo.FormattingEnabled = true;
            cboAtivo.Location = new Point(271, 38);
            cboAtivo.Margin = new Padding(4, 3, 4, 3);
            cboAtivo.Name = "cboAtivo";
            cboAtivo.Size = new Size(183, 24);
            cboAtivo.TabIndex = 6;
            cboAtivo.SelectedIndexChanged += cboAtivo_SelectedIndexChanged;
            // 
            // cboProduto
            // 
            cboProduto.FlatStyle = FlatStyle.System;
            cboProduto.ForeColor = Color.Black;
            cboProduto.FormatString = "Selecione";
            cboProduto.FormattingEnabled = true;
            cboProduto.Location = new Point(17, 40);
            cboProduto.Margin = new Padding(4, 3, 4, 3);
            cboProduto.Name = "cboProduto";
            cboProduto.Size = new Size(183, 24);
            cboProduto.TabIndex = 7;
            cboProduto.SelectedIndexChanged += cboProduto_SelectedIndexChanged;
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvar.ForeColor = Color.FromArgb(192, 0, 0);
            btnSalvar.Location = new Point(415, 344);
            btnSalvar.Margin = new Padding(4, 3, 4, 3);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(105, 36);
            btnSalvar.TabIndex = 10;
            btnSalvar.Text = "SALVAR";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nudQtdProduto);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboAtivo);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboProduto);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new Point(36, 69);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(484, 152);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "TIPO";
            // 
            // nudQtdProduto
            // 
            nudQtdProduto.Location = new Point(17, 104);
            nudQtdProduto.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            nudQtdProduto.Name = "nudQtdProduto";
            nudQtdProduto.Size = new Size(183, 23);
            nudQtdProduto.TabIndex = 8;
            // 
            // dtpDataUso
            // 
            dtpDataUso.Format = DateTimePickerFormat.Short;
            dtpDataUso.Location = new Point(53, 257);
            dtpDataUso.Name = "dtpDataUso";
            dtpDataUso.Size = new Size(183, 23);
            dtpDataUso.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(53, 238);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(104, 16);
            label5.TabIndex = 9;
            label5.Text = "DATA DO USO";
            // 
            // txtAssociado
            // 
            txtAssociado.ForeColor = Color.Black;
            txtAssociado.FormatString = "Selecione";
            txtAssociado.FormattingEnabled = true;
            txtAssociado.Location = new Point(307, 260);
            txtAssociado.Margin = new Padding(4, 3, 4, 3);
            txtAssociado.Name = "txtAssociado";
            txtAssociado.Size = new Size(183, 23);
            txtAssociado.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(307, 241);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(110, 16);
            label6.TabIndex = 13;
            label6.Text = "RESPONSÁVEL";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(53, 323);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(347, 57);
            txtDescricao.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(54, 304);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(91, 16);
            label7.TabIndex = 16;
            label7.Text = "DESCRIÇÃO";
            // 
            // DesignarTecnico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkRed;
            ClientSize = new Size(557, 415);
            Controls.Add(label7);
            Controls.Add(txtDescricao);
            Controls.Add(txtAssociado);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dtpDataUso);
            Controls.Add(groupBox1);
            Controls.Add(btnSalvar);
            Controls.Add(cboRadu);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(573, 454);
            MinimumSize = new Size(573, 454);
            Name = "DesignarTecnico";
            Text = "Designar Técnico";
            Load += DesignarTecnico_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQtdProduto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboRadu;
        private System.Windows.Forms.ComboBox cboAtivo;
        private System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.Button btnSalvar;
        private GroupBox groupBox1;
        private NumericUpDown nudQtdProduto;
        private DateTimePicker dtpDataUso;
        private Label label5;
        private ComboBox txtAssociado;
        private Label label6;
        private TextBox txtDescricao;
        private Label label7;
    }
}