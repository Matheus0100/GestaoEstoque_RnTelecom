namespace GestaoEstoqueRN.Views
{
    partial class AssociarAtivo
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
            button3 = new Button();
            cboAssociado = new ComboBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ButtonFace;
            button3.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(247, 111);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(93, 25);
            button3.TabIndex = 8;
            button3.Text = "ASSOCIAR";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // cboAssociado
            // 
            cboAssociado.ForeColor = Color.Black;
            cboAssociado.FormatString = "Selecione";
            cboAssociado.FormattingEnabled = true;
            cboAssociado.Location = new Point(13, 69);
            cboAssociado.Margin = new Padding(4, 3, 4, 3);
            cboAssociado.Name = "cboAssociado";
            cboAssociado.Size = new Size(327, 23);
            cboAssociado.TabIndex = 16;
            cboAssociado.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(13, 50);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(58, 16);
            label6.TabIndex = 15;
            label6.Text = "Cliente";
            label6.Visible = false;
            // 
            // AssociarAtivo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkRed;
            ClientSize = new Size(353, 148);
            Controls.Add(cboAssociado);
            Controls.Add(label6);
            Controls.Add(button3);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AssociarAtivo";
            Text = "Associar Cliente";
            FormClosing += AssociarAtivo_FormClosing;
            Load += AssociarAtivo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button button3;
        private ComboBox cboAssociado;
        private Label label6;
    }
}