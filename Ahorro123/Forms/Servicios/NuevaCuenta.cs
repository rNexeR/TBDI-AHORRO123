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
    public partial class NuevaCuenta : Form
    {
        DBManagement dbm { get; set; }
        string accion { get; set; }
        public NuevaCuenta(string ac)
        {
            InitializeComponent();
            dbm = new DBManagement();
            accion = ac;
            if (accion == "Editar")
                this.Text = "Editar Cuenta";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectionForm sf = new SelectionForm("Empleados");
            sf.ShowDialog();
            if (sf.DialogResult == DialogResult.OK)
                txtId.Text = sf.id_selection.ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (accion.Equals("Crear"))
            {
                int id = int.Parse(txtId.Text);
                Double inversion = Double.Parse(txtInversion.Text);
                Double ahorro = Double.Parse(txtAhorro.Text);
                try
                {
                    dbm.createCuentas(id, ahorro, inversion);
                    MessageBox.Show("Cuentas creadas", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleanTexts();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }else
            {
                int id_cuenta = int.Parse(txtIdCuenta.Text);
                int id_empleado = int.Parse(txtId.Text);
                Double saldo = Double.Parse(txtInversion.Text);
                string tipo = txtAhorro.Text;
                try
                {
                    dbm.updateCuentas(id_empleado, id_cuenta, saldo, tipo);
                    MessageBox.Show("Cuenta actualizada", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cleanTexts()
        {
            txtAhorro.Clear();
            txtId.Clear();
            txtInversion.Clear();
        }

        private void NuevaCuenta_Load(object sender, EventArgs e)
        {
            if (accion == "Crear")
            {
                tabPage2.Dispose();
            }
            else
            {
                label3.Text = "Saldo";
                label4.Text = "Tipo";
                txtId.ReadOnly = true;
                btnSF.Enabled = false;
            }
        }

        public void fill(Cuenta ct)
        {
            txtIdCuenta.Text = ct.id_uenta.ToString();
            txtId.Text = ct.id_empleado.ToString();
            txtInversion.Text = ct.saldo.ToString();
            txtAhorro.Text = ct.tipo;
        }
    }
}
