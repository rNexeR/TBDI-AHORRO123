namespace Ahorro123.Forms.Administracion
{
    partial class GestionesUsuarios
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 72;
            this.label2.Text = "Correo";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(156, 3);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(162, 24);
            this.txtCorreo.TabIndex = 73;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 46);
            this.groupBox1.TabIndex = 71;
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 69;
            this.label1.Text = "Clave";
            // 
            // txtClave
            // 
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(156, 33);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(162, 24);
            this.txtClave.TabIndex = 70;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(156, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(162, 24);
            this.txtName.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 67;
            this.label3.Text = "Username";
            // 
            // GestionesUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 148);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Name = "GestionesUsuarios";
            this.Text = "GestionesUsuarios";
            this.Load += new System.EventHandler(this.GestionesUsuarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
    }
}