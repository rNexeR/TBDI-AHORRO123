namespace Ahorro123.Forms.Administracion
{
    partial class UsuariosRoles
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 75;
            this.label2.Text = "Correo";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(96, 6);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(264, 24);
            this.txtCorreo.TabIndex = 76;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 46);
            this.groupBox1.TabIndex = 74;
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
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(15, 36);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(193, 173);
            this.listView1.TabIndex = 77;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(214, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 23);
            this.button2.TabIndex = 78;
            this.button2.Text = "Agregar Rol";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(214, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 23);
            this.button3.TabIndex = 79;
            this.button3.Text = "Eliminar Seleccion";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // UsuariosRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 261);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.groupBox1);
            this.Name = "UsuariosRoles";
            this.Text = "UsuariosRoles";
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}