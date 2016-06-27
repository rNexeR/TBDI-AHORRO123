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
    public partial class Usuarios : Form
    {
        DBManagement dbm { get; set; }
        string user { get; set; }
        public Usuarios()
        {
            InitializeComponent();
            dbm = new DBManagement();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.MultiSelect = false;
            refrescar();
        }

        private void refrescar()
        {
            view.DataSource = dbm.getUsuarios(((Form1)MdiParent).isAdmin);
            view.AutoResizeColumns();
        }

        //Nuevo
        private void btnLogin_Click(object sender, EventArgs e)
        {
            GestionesUsuarios gu = new GestionesUsuarios("Crear");
            gu.ShowDialog();
            refrescar();
        }

        //Editar
        private void button1_Click(object sender, EventArgs e)
        {
            Editar();
        }

        //Eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            if (view.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Confirme eliminacion de Usuario con id " + user, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        dbm.deleteUsuario(user);
                        MessageBox.Show("Usuario Eliminado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            refrescar();
        }

        private void Editar()
        {
            Usuario u = new Usuario();
            u.correo_primario = user;
            u.nombre_usuario = view.SelectedRows[0].Cells[1].Value.ToString();
            u.clave = view.SelectedRows[0].Cells[1].Value.ToString();

            GestionesUsuarios gu = new GestionesUsuarios("Editar");
            gu.fill(u);
            gu.ShowDialog();
            refrescar();
        }

        //Refrescar
        private void button3_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        private void view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            user = view.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UsuariosRoles ur = new UsuariosRoles(user);
            ur.ShowDialog();
            refrescar();
        }
    }
}
