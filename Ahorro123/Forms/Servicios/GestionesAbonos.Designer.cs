namespace Ahorro123.Forms.Servicios
{
    partial class GestionesAbonos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdCuenta = new System.Windows.Forms.TextBox();
            this.btnSF = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 46);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(113, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Lime;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(12, 16);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(95, 24);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Guardar";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 53;
            this.label1.Text = "Id Cuenta";
            // 
            // txtIdCuenta
            // 
            this.txtIdCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCuenta.Location = new System.Drawing.Point(152, 4);
            this.txtIdCuenta.Name = "txtIdCuenta";
            this.txtIdCuenta.Size = new System.Drawing.Size(162, 24);
            this.txtIdCuenta.TabIndex = 54;
            // 
            // btnSF
            // 
            this.btnSF.BackColor = System.Drawing.SystemColors.Control;
            this.btnSF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSF.ForeColor = System.Drawing.Color.Black;
            this.btnSF.Location = new System.Drawing.Point(320, 4);
            this.btnSF.Name = "btnSF";
            this.btnSF.Size = new System.Drawing.Size(33, 24);
            this.btnSF.TabIndex = 52;
            this.btnSF.Text = "...";
            this.btnSF.UseVisualStyleBackColor = false;
            this.btnSF.Click += new System.EventHandler(this.btnSF_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(152, 34);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(162, 24);
            this.txtMonto.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 51;
            this.label4.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 50;
            this.label3.Text = "Monto";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(152, 68);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(255, 74);
            this.txtDescripcion.TabIndex = 56;
            this.txtDescripcion.Text = "";
            // 
            // GestionesAbonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 194);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdCuenta);
            this.Controls.Add(this.btnSF);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "GestionesAbonos";
            this.Text = "GestionesAbonos";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdCuenta;
        private System.Windows.Forms.Button btnSF;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtDescripcion;
    }
}