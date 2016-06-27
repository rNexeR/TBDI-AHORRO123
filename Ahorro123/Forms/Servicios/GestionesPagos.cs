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
    public partial class GestionesPagos : Form
    {
        DBManagement dbm { get; set; }
        Pago pago { get; set; }
        string accion { get; set; }
        public GestionesPagos(string acc)
        {
            InitializeComponent();
            dbm = new DBManagement();
            pago = new Pago();
            accion = acc;
        }

        public void fill(Pago editar)
        {
            pago = editar;
            txtNPago.Text = pago.id_pago.ToString();
            txtIdPrestamo.Text = pago.id_prestamo.ToString();
            txtMonto.Text = pago.monto.ToString();
        }

        private void btnSF_Click(object sender, EventArgs e)
        {
            SelectionForm sf = new SelectionForm("Prestamos");
            sf.ShowDialog();
            if (sf.DialogResult == DialogResult.OK)
                txtIdPrestamo.Text = sf.id_selection.ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            pago.id_prestamo = int.Parse(txtIdPrestamo.Text);
            if(accion == "Editar")
                pago.id_pago = int.Parse(txtNPago.Text);
            pago.monto = Double.Parse(txtMonto.Text);

            try
            {
                if (accion == "Crear")
                {
                    dbm.createPago(pago);
                    MessageBox.Show("Pago creado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dbm.updatePago(pago);
                    MessageBox.Show("Pago modificado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
