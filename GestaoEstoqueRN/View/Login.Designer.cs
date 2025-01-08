namespace GestaoEstoqueRN
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            txtUsuario = new TextBox();
            txtSenha = new TextBox();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            btnEntrar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(318, 339);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 2;
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsuario.Location = new Point(62, 231);
            txtUsuario.Margin = new Padding(5, 4, 5, 4);
            txtUsuario.Multiline = true;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(513, 68);
            txtUsuario.TabIndex = 1;
            // 
            // txtSenha
            // 
            txtSenha.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            txtSenha.Location = new Point(62, 381);
            txtSenha.Margin = new Padding(5, 4, 5, 4);
            txtSenha.Multiline = true;
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(513, 68);
            txtSenha.TabIndex = 2;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(62, 177);
            label2.Name = "label2";
            label2.Size = new Size(513, 49);
            label2.TabIndex = 8;
            label2.Text = "Usuário";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(62, 328);
            label3.Name = "label3";
            label3.Size = new Size(513, 49);
            label3.TabIndex = 9;
            label3.Text = "Senha";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-17, -56);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(139, 176);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.Font = new Font("Arial Rounded MT Bold", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(62, 88);
            label4.Name = "label4";
            label4.Size = new Size(513, 49);
            label4.TabIndex = 11;
            label4.Text = "ESTOQUE";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEntrar
            // 
            btnEntrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEntrar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnEntrar.Location = new Point(468, 473);
            btnEntrar.Margin = new Padding(1);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(107, 52);
            btnEntrar.TabIndex = 12;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkRed;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(632, 545);
            Controls.Add(btnEntrar);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtSenha);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            ForeColor = SystemColors.ButtonHighlight;
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            MaximumSize = new Size(650, 592);
            MinimumSize = new Size(650, 592);
            Name = "Login";
            Text = "Login";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label4;
        private Button btnEntrar;
    }
}

