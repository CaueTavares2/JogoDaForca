
namespace JogoDaForca
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPalavra = new System.Windows.Forms.Label();
            this.lblTentativas = new System.Windows.Forms.Label();
            this.lblLetrasTentadas = new System.Windows.Forms.Label();
            this.txtLetra = new System.Windows.Forms.TextBox();
            this.btnTentar = new System.Windows.Forms.Button();
            this.btnNovoJogo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPalavra
            // 
            this.lblPalavra.AutoSize = true;
            this.lblPalavra.Location = new System.Drawing.Point(53, 112);
            this.lblPalavra.Name = "lblPalavra";
            this.lblPalavra.Size = new System.Drawing.Size(50, 20);
            this.lblPalavra.TabIndex = 0;
            this.lblPalavra.Text = "label1";
            this.lblPalavra.Click += new System.EventHandler(this.lblPalavra_Click);
            // 
            // lblTentativas
            // 
            this.lblTentativas.AutoSize = true;
            this.lblTentativas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTentativas.Location = new System.Drawing.Point(30, 23);
            this.lblTentativas.Name = "lblTentativas";
            this.lblTentativas.Size = new System.Drawing.Size(50, 20);
            this.lblTentativas.TabIndex = 1;
            this.lblTentativas.Text = "label2";
            this.lblTentativas.Click += new System.EventHandler(this.lblTentativas_Click);
            // 
            // lblLetrasTentadas
            // 
            this.lblLetrasTentadas.AutoSize = true;
            this.lblLetrasTentadas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLetrasTentadas.Location = new System.Drawing.Point(30, 65);
            this.lblLetrasTentadas.Name = "lblLetrasTentadas";
            this.lblLetrasTentadas.Size = new System.Drawing.Size(50, 20);
            this.lblLetrasTentadas.TabIndex = 2;
            this.lblLetrasTentadas.Text = "label3";
            this.lblLetrasTentadas.Click += new System.EventHandler(this.lblLetrasTentadas_Click);
            // 
            // txtLetra
            // 
            this.txtLetra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLetra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLetra.Location = new System.Drawing.Point(204, 220);
            this.txtLetra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLetra.Name = "txtLetra";
            this.txtLetra.Size = new System.Drawing.Size(141, 29);
            this.txtLetra.TabIndex = 3;
            this.txtLetra.TextChanged += new System.EventHandler(this.txtLetra_TextChanged);
            // 
            // btnTentar
            // 
            this.btnTentar.FlatAppearance.BorderSize = 0;
            this.btnTentar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnTentar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTentar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTentar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTentar.Location = new System.Drawing.Point(217, 302);
            this.btnTentar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTentar.Name = "btnTentar";
            this.btnTentar.Size = new System.Drawing.Size(128, 37);
            this.btnTentar.TabIndex = 4;
            this.btnTentar.Text = "Tentar";
            this.btnTentar.UseVisualStyleBackColor = true;
            this.btnTentar.Click += new System.EventHandler(this.btnTentar_Click);
            // 
            // btnNovoJogo
            // 
            this.btnNovoJogo.FlatAppearance.BorderSize = 0;
            this.btnNovoJogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnNovoJogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnNovoJogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoJogo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNovoJogo.Location = new System.Drawing.Point(217, 367);
            this.btnNovoJogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNovoJogo.Name = "btnNovoJogo";
            this.btnNovoJogo.Size = new System.Drawing.Size(128, 43);
            this.btnNovoJogo.TabIndex = 5;
            this.btnNovoJogo.Text = "Novo Jogo";
            this.btnNovoJogo.UseVisualStyleBackColor = true;
            this.btnNovoJogo.Click += new System.EventHandler(this.btnNovoJogo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTentativas);
            this.groupBox1.Controls.Add(this.lblLetrasTentadas);
            this.groupBox1.Location = new System.Drawing.Point(371, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status do Jogo";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(601, 446);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNovoJogo);
            this.Controls.Add(this.btnTentar);
            this.Controls.Add(this.txtLetra);
            this.Controls.Add(this.lblPalavra);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPalavra;
        private System.Windows.Forms.Label lblTentativas;
        private System.Windows.Forms.Label lblLetrasTentadas;
        private System.Windows.Forms.TextBox txtLetra;
        private System.Windows.Forms.Button btnTentar;
        private System.Windows.Forms.Button btnNovoJogo;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

