namespace GestaoEstoqueRN
{
    partial class ExibirTecnico
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
            components = new System.ComponentModel.Container();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            btnDesignar = new Button();
            dataGridView1 = new DataGridView();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePicker1.Font = new Font("Times New Roman", 15F, FontStyle.Bold);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(625, 45);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(134, 30);
            dateTimePicker1.TabIndex = 8;
            dateTimePicker1.Value = new DateTime(2025, 1, 10, 2, 56, 31, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 19F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(543, 45);
            label1.Name = "label1";
            label1.Size = new Size(76, 30);
            label1.TabIndex = 9;
            label1.Text = "Data:";
            // 
            // btnDesignar
            // 
            btnDesignar.AutoSize = true;
            btnDesignar.BackColor = Color.White;
            btnDesignar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnDesignar.ForeColor = Color.Black;
            btnDesignar.Image = Properties.Resources.people_outline1;
            btnDesignar.Location = new Point(12, 37);
            btnDesignar.Name = "btnDesignar";
            btnDesignar.Size = new Size(138, 38);
            btnDesignar.TabIndex = 10;
            btnDesignar.Text = "Designar";
            btnDesignar.TextAlign = ContentAlignment.MiddleRight;
            btnDesignar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDesignar.UseVisualStyleBackColor = false;
            btnDesignar.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 81);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(747, 415);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            // 
            // timer1
            // 
            timer1.Interval = 200;
            timer1.Tick += timer1_Tick;
            // 
            // ExibirTecnico
            // 
            AutoScaleDimensions = new SizeF(7F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkRed;
            ClientSize = new Size(771, 508);
            ControlBox = false;
            Controls.Add(dataGridView1);
            Controls.Add(btnDesignar);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Font = new Font("Times New Roman", 8.25F, FontStyle.Bold);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ExibirTecnico";
            ShowIcon = false;
            ShowInTaskbar = false;
            Load += ExibirTecnico_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Button btnDesignar;
        private DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
    }
}