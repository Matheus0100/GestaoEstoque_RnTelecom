﻿namespace GestaoEstoqueRN.Views
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            toolStrip1 = new ToolStrip();
            btnEstoque = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnEstoqueAtivos = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnDesignarTecnico = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnCadastrarClientes = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.BackColor = Color.DarkRed;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnEstoque, toolStripSeparator1, btnEstoqueAtivos, toolStripSeparator2, btnDesignarTecnico, toolStripSeparator3, btnCadastrarClientes });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(862, 47);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // btnEstoque
            // 
            btnEstoque.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnEstoque.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnEstoque.ForeColor = SystemColors.ControlLightLight;
            btnEstoque.Image = Properties.Resources.options_outline1;
            btnEstoque.ImageTransparentColor = Color.Magenta;
            btnEstoque.Margin = new Padding(20, 1, 15, 2);
            btnEstoque.Name = "btnEstoque";
            btnEstoque.Size = new Size(135, 44);
            btnEstoque.Text = "ESTOQUE";
            btnEstoque.ToolTipText = "Estoque";
            btnEstoque.Click += btnEstoque_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 47);
            // 
            // btnEstoqueAtivos
            // 
            btnEstoqueAtivos.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnEstoqueAtivos.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnEstoqueAtivos.ForeColor = SystemColors.ControlLightLight;
            btnEstoqueAtivos.ImageTransparentColor = Color.Magenta;
            btnEstoqueAtivos.Margin = new Padding(10, 1, 10, 2);
            btnEstoqueAtivos.Name = "btnEstoqueAtivos";
            btnEstoqueAtivos.Size = new Size(228, 44);
            btnEstoqueAtivos.Text = "ESTOQUE ATIVOS";
            btnEstoqueAtivos.ToolTipText = "Estoque de Ativos";
            btnEstoqueAtivos.Click += btnEstoqueAtivos_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 47);
            // 
            // btnDesignarTecnico
            // 
            btnDesignarTecnico.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDesignarTecnico.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnDesignarTecnico.ForeColor = SystemColors.ControlLightLight;
            btnDesignarTecnico.ImageTransparentColor = Color.Magenta;
            btnDesignarTecnico.Margin = new Padding(15, 1, 0, 2);
            btnDesignarTecnico.Name = "btnDesignarTecnico";
            btnDesignarTecnico.Size = new Size(332, 44);
            btnDesignarTecnico.Text = "DESIGNAR PARA TÉCNICO";
            btnDesignarTecnico.ToolTipText = "Designar Estoque / Ativo para os Técnicos";
            btnDesignarTecnico.Click += btnDesignarTecnico_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 47);
            // 
            // btnCadastrarClientes
            // 
            btnCadastrarClientes.BackColor = Color.DarkRed;
            btnCadastrarClientes.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnCadastrarClientes.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnCadastrarClientes.ForeColor = SystemColors.ButtonHighlight;
            btnCadastrarClientes.ImageTransparentColor = Color.Magenta;
            btnCadastrarClientes.Name = "btnCadastrarClientes";
            btnCadastrarClientes.Size = new Size(314, 41);
            btnCadastrarClientes.Text = "CADASTRO DE CLIENTES";
            btnCadastrarClientes.Click += btnCadastrarClientes_Click;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(862, 450);
            Controls.Add(toolStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Name = "Principal";
            Text = "Gestão de Estoque - RN Telecom";
            WindowState = FormWindowState.Maximized;
            FormClosing += Principal_FormClosing;
            Load += Principal_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btnEstoque;
        private ToolStripButton btnEstoqueAtivos;
        private ToolStripButton btnDesignarTecnico;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnCadastrarClientes;
    }
}