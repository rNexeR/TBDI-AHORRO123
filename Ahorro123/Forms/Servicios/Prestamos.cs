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
    public partial class Prestamos : Form
    {
        DBManagement dbm { get; set; }
        int id_prestamo { get; set; }
        int id_solicitante { get; set; }
        string tipo_persona { get; set; }
        public Prestamos()
        {
            InitializeComponent();
            dbm = new DBManagement();
        }

        private void refrescar()
        {
            view.DataSource = dbm.getFullPrestamos(((Form1)MdiParent).isAdmin);
            view.AutoResizeColumns();
        }

        private void Prestamos_Load(object sender, EventArgs e)
        {
            refrescar();

            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.MultiSelect = false;
            
        }

        private void view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (view.SelectedRows.Count == 1)
            {
                id_prestamo = int.Parse(view.SelectedRows[0].Cells[0].Value.ToString());
                id_solicitante = int.Parse(view.SelectedRows[0].Cells[3].Value.ToString());
                tipo_persona = view.SelectedRows[0].Cells[2].Value.ToString();
            }
        }

        private void view_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Editar();
        }

        private void Prestamos_Resize(object sender, EventArgs e)
        {
            int alto = this.Size.Height;
            view.Height = alto - groupBox1.Size.Height - 30;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            GestionesPrestamos gp = new GestionesPrestamos("Crear");
            gp.ShowDialog();
            refrescar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Editar()
        {
            GestionesPrestamos gp = new GestionesPrestamos(tipo_persona, "Editar");
            Prestamo pr = new Prestamo();
            pr.id_prestamo = id_prestamo;
            pr.monto = Double.Parse(view.SelectedRows[0].Cells[5].Value.ToString());
            pr.periodos = int.Parse(view.SelectedRows[0].Cells[6].Value.ToString());
            pr.tasa = Double.Parse(view.SelectedRows[0].Cells[7].Value.ToString());
            pr.saldo = Double.Parse(view.SelectedRows[0].Cells[8].Value.ToString());
            if (tipo_persona == "Empleado")
            {
                gp.Fill(pr, id_solicitante);
            }
            else
            {
                int aval = 0;
                string parentesco = "";
                gp.Fill(pr, id_solicitante, aval, parentesco);
            }
            gp.ShowDialog();
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
                DialogResult dr = MessageBox.Show("Confirme eliminacion de prestamo con id " + id_prestamo, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        dbm.deletePrestamo(id_prestamo);
                        MessageBox.Show("Prestamo Eliminado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
        }
    }
}
