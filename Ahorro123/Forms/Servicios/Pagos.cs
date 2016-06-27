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
    public partial class Pagos : Form
    {
        DBManagement dbm { get; set; }
        int id_prestamo { get; set; }
        int num_pago { get; set; }
        public Pagos()
        {
            InitializeComponent();
            dbm = new DBManagement();
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.MultiSelect = false;
            refrescar();
        }

        private void refrescar()
        {
            view.DataSource = dbm.getPagos(((Form1)MdiParent).isAdmin);
            view.AutoResizeColumns();
        }

        //Nuevo
        private void btnLogin_Click(object sender, EventArgs e)
        {
            GestionesPagos gp = new GestionesPagos("Crear");
            gp.ShowDialog();
            refrescar();
        }

        //Editar
        private void button1_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void Editar()
        {
            Pago p = new Pago();
            p.id_pago = num_pago;
            p.id_prestamo = id_prestamo;
            p.monto = Double.Parse(view.SelectedRows[0].Cells[3].Value.ToString());
            p.fecha = DateTime.Parse(view.SelectedRows[0].Cells[2].Value.ToString());
            GestionesPagos gp = new GestionesPagos("Editar");
            gp.fill(p);
            gp.ShowDialog();
            refrescar();
        }

        //Eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            if (view.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Confirme eliminacion de Pago con id " + num_pago, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        dbm.deletePago(id_prestamo, num_pago);
                        MessageBox.Show("Pago Eliminado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
        }

        //Click
        private void view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_prestamo = int.Parse(view.SelectedRows[0].Cells[0].Value.ToString());
            num_pago = int.Parse(view.SelectedRows[0].Cells[1].Value.ToString());
        }

        //DClick
        private void view_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id_prestamo = int.Parse(view.SelectedRows[0].Cells[0].Value.ToString());
            num_pago = int.Parse(view.SelectedRows[0].Cells[1].Value.ToString());
            Editar();
        }
    }
}
