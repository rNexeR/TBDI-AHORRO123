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

namespace Ahorro123.Forms.Servicios
{
    public partial class Abonos : Form
    {
        DBManagement dbm { get; set; }
        int id_selection { get; set; }
        public Abonos()
        {
            InitializeComponent();
            dbm = new DBManagement();
        }

        private void Abonos_Load(object sender, EventArgs e)
        {
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.MultiSelect = false;
            refrescar();
        }

        private void refrescar()
        {
            view.DataSource = dbm.getAbonos(((Form1)MdiParent).isAdmin);
            view.AutoResizeColumns();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            GestionesAbonos ga = new GestionesAbonos("Crear");
            ga.ShowDialog();
            refrescar();
        }

        private void view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_selection = int.Parse(view.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void view_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id_selection = int.Parse(view.SelectedRows[0].Cells[0].Value.ToString());
            Editar();
        }

        private void Editar()
        {
            Abono editar = new Abono();
            editar.id_cuenta = id_selection;
            editar.monto = Double.Parse(view.SelectedRows[0].Cells[1].Value.ToString());
            editar.fecha = DateTime.Parse(view.SelectedRows[0].Cells[2].Value.ToString());
            editar.descripcion = view.SelectedRows[0].Cells[3].Value.ToString();
            GestionesAbonos ga = new GestionesAbonos("Editar");
            ga.Fill(editar);
            ga.ShowDialog();
            refrescar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (view.Rows.Count > 0)
            {
                DateTime fecha = DateTime.Parse(view.SelectedRows[0].Cells[2].Value.ToString());
                DialogResult dr = MessageBox.Show("Confirme eliminacion de abono con id " + id_selection, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        dbm.deleteAbono(id_selection, fecha);
                        MessageBox.Show("Abono Eliminado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refrescar();
        }
    }
}
