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
            dataGridView1 = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            button1 = new Button();
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
            dataGridView1.Size = new Size(747, 415);
            dataGridView1.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePicker1.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(625, 45);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(134, 30);
            dateTimePicker1.TabIndex = 8;
            dateTimePicker1.Value = new DateTime(2025, 1, 10, 2, 56, 31, 0);
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 19F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(543, 45);
            label1.Name = "label1";
            label1.Size = new Size(76, 30);
            label1.TabIndex = 9;
            label1.Text = "Data:";
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = Color.White;
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.DarkRed;
            button1.Location = new Point(12, 37);
            button1.Name = "button1";
            button1.Size = new Size(132, 38);
            button1.TabIndex = 10;
            button1.Text = "Designar";
            button1.UseVisualStyleBackColor = false;
            // 
            // ExibirTecnico
            // 
            AutoScaleDimensions = new SizeF(7F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkRed;
            ClientSize = new Size(771, 508);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(dataGridView1);
            Font = new Font("Times New Roman", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.White;
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
        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Button button1;
    }
}