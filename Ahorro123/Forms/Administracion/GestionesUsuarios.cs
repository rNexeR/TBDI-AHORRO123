using ahorro123.DatabaseManager;
using Ahorro123.DatabaseManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorro123.Forms.Administracion
{
    public partial class GestionesUsuarios : Form
    {
        DBManagement dbm { get; set; }
        Usuario n { get; set; }
        string accion { get; set; }
        public GestionesUsuarios(string ac)
        {
            InitializeComponent();
            dbm = new DBManagement();
            accion = ac;
            n = new Usuario();
        }

        //Guardar
        private void btnLogin_Click(object sender, EventArgs e)
        {
            n.clave = txtClave.Text;
            n.correo_primario = txtCorreo.Text;
            n.nombre_usuario = txtName.Text;

            try
            {
                if(accion == "Crear")
                {
                    dbm.createUsuario(n);
                    MessageBox.Show("Usuario creado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dbm.updateUsuario(n);
                    MessageBox.Show("Usuario modificado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GestionesUsuarios_Load(object sender, EventArgs e)
        {

        }

        public void fill(Usuario user)
        {
            n = user;
            txtClave.Text = n.clave;
            txtCorreo.Text = n.correo_primario;
            txtName.Text = n.nombre_usuario;
        }
    }
}
