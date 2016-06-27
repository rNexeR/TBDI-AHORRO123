namespace Ahorro123.Forms.Administracion
{
    partial class Usuarios
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
            this.view = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // view
            // 
            this.view.AllowUserToAddRows = false;
            this.view.AllowUserToDeleteRows = false;
            this.view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.view.Dock = System.Windows.Forms.DockStyle.Top;
            this.view.Location = new System.Drawing.Point(0, 0);
            this.view.Name = "view";
            this.view.ReadOnly = true;
            this.view.Size = new System.Drawing.Size(515, 363);
            this.view.TabIndex = 2;
            this.view.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.view_CellClick);
            this.view.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.view_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 369);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 45);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lime;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(414, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 24);
            this.button3.TabIndex = 9;
            this.button3.Text = "Refrescar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(313, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 24);
            this.button2.TabIndex = 8;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(113, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "Editar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(12, 16);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(95, 24);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Nuevo";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(212, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 24);
            this.button4.TabIndex = 10;
            this.button4.Text = "Roles";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 414);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.view);
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView view;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button button4;
    }
}