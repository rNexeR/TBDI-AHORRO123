using Ahorro123.DatabaseManager;
using Ahorro123.Forms.Tools;
using System;
using System.Collections;
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
    public partial class UsuariosRoles : Form
    {
        DBManagement dbm { get; set; }
        string user { get; set; }
        ArrayList roles;
        public UsuariosRoles(string id)
        {
            InitializeComponent();
            dbm = new DBManagement();
            user = id;
            //roles = new ArrayList();
            roles = dbm.dbGetIdRolesByUsuario(user);
            listView1.MultiSelect = false;
            txtCorreo.Text = id;
            refrescar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectionForm sf = new SelectionForm("Roles");
            sf.ShowDialog();
            if (sf.DialogResult == DialogResult.OK)
                roles.Add(sf.id_selection);
            refrescar();
        }

        private void refrescar()
        {
            listView1.Clear();
            foreach (int n in roles)
            {
                listView1.Items.Add(n.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int rol = -1;
                try
                {
                    rol = int.Parse(listView1.SelectedItems[0].Text);
                    roles.Remove(rol);
                    dbm.deleteRelationUR(rol, user);
                    refrescar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Error en eliminar rol: " + Ex.Message + " |" + rol.ToString());
                }

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int n in roles)
                {
                    dbm.createRelationUR(n, user);
                }
                    MessageBox.Show("Roles asignado exitosamente", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }
        }
    }
}
