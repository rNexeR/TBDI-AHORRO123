using ahorro123.DatabaseManager;
using Ahorro123.DatabaseManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorro123.Forms
{
    public partial class Login : Form
    {
        DBManagement dbm { get; set; }
        public Login()
        {
            InitializeComponent();
            dbm = new DBManagement();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            ArrayList roles, privilegios;
            if (dbm.dbLogin(username, password))
            {
                StatusLabel.BackColor = Color.Green;
                statusStrip1.BackColor = Color.Green;
                StatusLabel.Text = "Inicio de sesion exitosa";
                roles = dbm.dbGetRolesByUsuario(username);
                privilegios = dbm.dbGetPrivilegiosByUsuario(username);
                ((Form1)this.MdiParent).Login(username, roles, privilegios);
                this.Close();
            }
            else
            {
                StatusLabel.BackColor = Color.Red;
                statusStrip1.BackColor = Color.Red;
                StatusLabel.Text = "Credenciales Invalidas";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
