using ahorro123.DatabaseManager;
using Ahorro123.DatabaseManager;
using Ahorro123.Forms.Tools;
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
    public partial class GestionesAbonos : Form
    {
        DBManagement dbm { get; set; }
        string accion { get; set; }
        Abono abono { get; set; }
        public GestionesAbonos(string accion)
        {
            InitializeComponent();
            dbm = new DBManagement();
            this.accion = accion;
            abono = new Abono();
        }

        private void btnSF_Click(object sender, EventArgs e)
        {
            SelectionForm sf = new SelectionForm("Cuentas");
            sf.ShowDialog();
            if (sf.DialogResult == DialogResult.OK)
                txtIdCuenta.Text = sf.id_selection.ToString();
        }

        public void Fill(Abono editar)
        {
            abono = editar;
            txtIdCuenta.ReadOnly = true;
            txtIdCuenta.Text = abono.id_cuenta.ToString();
            txtDescripcion.Text = abono.descripcion;
            txtMonto.Text = abono.monto.ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                abono.id_cuenta = int.Parse(txtIdCuenta.Text);
                abono.monto = Double.Parse(txtMonto.Text);
                abono.descripcion = txtDescripcion.Text;
            }
            catch
            {
                return;
            }

            try
            {
                if (accion == "Crear")
                {
                    dbm.createAbono(abono);
                    MessageBox.Show("Abono creado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dbm.updateAbono(abono);
                    MessageBox.Show("Abono modificado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}
