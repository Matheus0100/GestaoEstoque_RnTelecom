namespace GestaoEstoqueRN
{
    partial class EstoqueAtivos
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
            dataGridView1 = new DataGridView();
            txtSearch = new TextBox();
            btnEditar = new Button();
            btnExportar = new Button();
            btnExcluir = new Button();
            btnAdicionar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 81);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1160, 595);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            txtSearch.Location = new Point(971, 44);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Pesquisar";
            txtSearch.Size = new Size(180, 31);
            txtSearch.TabIndex = 17;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.FlatStyle = FlatStyle.Popup;
            btnEditar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.ForeColor = SystemColors.ActiveCaptionText;
            btnEditar.Image = Properties.Resources.options_outline;
            btnEditar.Location = new Point(846, 44);
            btnEditar.Margin = new Padding(4, 3, 4, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(118, 31);
            btnEditar.TabIndex = 21;
            btnEditar.Text = "Editar";
            btnEditar.TextAlign = ContentAlignment.MiddleRight;
            btnEditar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportar.FlatStyle = FlatStyle.Popup;
            btnExportar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportar.ForeColor = SystemColors.ActiveCaptionText;
            btnExportar.Image = Properties.Resources.print_outline;
            btnExportar.Location = new Point(697, 44);
            btnExportar.Margin = new Padding(4, 3, 4, 3);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(117, 31);
            btnExportar.TabIndex = 20;
            btnExportar.Text = "Exportar";
            btnExportar.TextAlign = ContentAlignment.MiddleRight;
            btnExportar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExcluir.FlatStyle = FlatStyle.Popup;
            btnExcluir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExcluir.ForeColor = SystemColors.ActiveCaptionText;
            btnExcluir.Image = Properties.Resources.close_circle_outline;
            btnExcluir.Location = new Point(539, 44);
            btnExcluir.Margin = new Padding(4, 3, 4, 3);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(117, 31);
            btnExcluir.TabIndex = 19;
            btnExcluir.Text = "Excluir";
            btnExcluir.TextAlign = ContentAlignment.MiddleRight;
            btnExcluir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdicionar.FlatAppearance.BorderColor = Color.White;
            btnAdicionar.FlatStyle = FlatStyle.Popup;
            btnAdicionar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdicionar.ForeColor = SystemColors.ActiveCaptionText;
            btnAdicionar.Image = Properties.Resources.add_circle_outline;
            btnAdicionar.Location = new Point(386, 44);
            btnAdicionar.Margin = new Padding(4, 3, 4, 3);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(115, 31);
            btnAdicionar.TabIndex = 18;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.TextAlign = ContentAlignment.MiddleRight;
            btnAdicionar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // EstoqueAtivos
            // 
            AutoScaleDimensions = new SizeF(7F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkRed;
            ClientSize = new Size(1184, 688);
            ControlBox = false;
            Controls.Add(btnEditar);
            Controls.Add(btnExportar);
            Controls.Add(btnExcluir);
            Controls.Add(btnAdicionar);
            Controls.Add(txtSearch);
            Controls.Add(dataGridView1);
            Font = new Font("Times New Roman", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "EstoqueAtivos";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Estoque";
            Load += EstoqueAtivos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private TextBox txtSearch;
        private Button btnEditar;
        private Button btnExportar;
        private Button btnExcluir;
        private Button btnAdicionar;
    }
}