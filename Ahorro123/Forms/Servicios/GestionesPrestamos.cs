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
    public partial class GestionesPrestamos : Form
    {
        DBManagement dbm { get; set; }
        Prestamo prestamo { get; set; }
        relationEP ep { get; set; }
        relationPEP pep { get; set; }
        string accion { get; set; }
        string tipo_persona { get; set; }
        public GestionesPrestamos(string tipo, string accion)
        {
            dbm = new DBManagement();
            InitializeComponent();
            txtExterna.Enabled = false;
            btnExterna.Enabled = false;
            txtParentesco.Enabled = false;
            lblEmpleado.Text = "Id Empleado";
            this.accion = accion;
            tipo_persona = tipo;
            prestamo = new Prestamo();
            ep = new relationEP();
            pep = new relationPEP();
        }

        public GestionesPrestamos(string accion)
        {
            dbm = new DBManagement();
            InitializeComponent();
            txtExterna.Enabled = false;
            btnExterna.Enabled = false;
            txtParentesco.Enabled = false;
            lblEmpleado.Text = "Id Empleado";
            this.accion = accion;
            prestamo = new Prestamo();
            ep = new relationEP();
            pep = new relationPEP();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtExterna.Enabled = false;
            btnExterna.Enabled = false;
            txtParentesco.Enabled = false;
            lblEmpleado.Text = "Id Empleado";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtExterna.Enabled = true;
            btnExterna.Enabled = true;
            txtParentesco.Enabled = true;
            lblEmpleado.Text = "Id Aval";
        }

        private void GestionesPrestamos_Load(object sender, EventArgs e)
        {
            if (accion == "Crear")
            {
                tabPage2.Dispose();
            }
            else
            {
                if (tipo_persona == "Empleado")
                {
                    radioButton1.Enabled = false;
                    radioButton1.Checked = true;
                    radioButton2.Enabled = false;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton1.Enabled = false;
                    radioButton1.Checked = false;
                    radioButton2.Enabled = false;
                    radioButton2.Checked = true;
                }
            }
        }

        public void Fill(Prestamo pr, int sol)
        {
            prestamo.id_prestamo = pr.id_prestamo;
            txtId.Text = pr.id_prestamo.ToString();
            txtMonto.Text = pr.monto.ToString();
            txtPeriodos.Text = pr.periodos.ToString();
            txtSaldo.Text = pr.saldo.ToString();
            txtTasa.Text = pr.tasa.ToString();
            txtEmpleado.Text = sol.ToString();
            ep.id_empleado = sol;
        }
        public void Fill(Prestamo pr, int sol, int aval, string parentesco)
        {
            prestamo.id_prestamo = pr.id_prestamo;
            txtId.Text = pr.id_prestamo.ToString();
            txtMonto.Text = pr.monto.ToString();
            txtPeriodos.Text = pr.periodos.ToString();
            txtSaldo.Text = pr.saldo.ToString();
            txtTasa.Text = pr.tasa.ToString();
            pep.id_aval = aval;
            pep.id_personae = sol;
            pep.parentesco = parentesco;
            txtEmpleado.Text = aval.ToString();
            txtExterna.Text = sol.ToString();
            txtParentesco.Text = parentesco;
        }

        private void txtEmpleado_TextChanged(object sender, EventArgs e)
        {
            int id_empleado;
            try
            {
                id_empleado = int.Parse(txtEmpleado.Text);
                pep.id_aval = id_empleado;
                ep.id_empleado = id_empleado;
            }
            catch(Exception Ex)
            {
                return;
            }
            if (radioButton1.Checked)
            {
                if (dbm.empleadoHasCuentas(id_empleado))
                {
                    txtTasa.Text = "2%";
                    prestamo.tasa = 0.02;
                }
                else
                {
                    txtTasa.Text = "3%";
                    prestamo.tasa = 0.03;
                }
            }
        }

        private void btnAval_Click(object sender, EventArgs e)
        {
            SelectionForm sf = new SelectionForm("Empleados");
            sf.ShowDialog();
            if (sf.DialogResult == DialogResult.OK)
                txtEmpleado.Text = sf.id_selection.ToString();
        }

        private void btnExterna_Click(object sender, EventArgs e)
        {
            SelectionForm sf = new SelectionForm("Personas_Externas");
            sf.ShowDialog();
            if (sf.DialogResult == DialogResult.OK)
                txtExterna.Text = sf.id_selection.ToString();
        }

        private void txtExterna_TextChanged(object sender, EventArgs e)
        {
            int id_externo;
            try
            {
                id_externo = int.Parse(txtExterna.Text);
                pep.id_personae = id_externo;
            }
            catch (Exception Ex)
            {
                return;
            }
            if (radioButton2.Checked)
            {
                txtTasa.Text = "4%";
                prestamo.tasa = 0.04;
            }
        }

        private void txtPeriodos_TextChanged(object sender, EventArgs e)
        {
            int periodos;
            try
            {
                periodos = int.Parse(txtPeriodos.Text);
            }
            catch
            {
                return;
            }
            prestamo.periodos = periodos;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            prestamo.fecha = DateTime.Now.Date;
            prestamo.monto = Double.Parse(txtMonto.Text);
            prestamo.tasa = prestamo.tasa * prestamo.periodos;
            prestamo.saldo = prestamo.tasa * prestamo.monto + prestamo.monto;
            txtTasa.Text = prestamo.tasa.ToString();
            txtSaldo.Text = prestamo.saldo.ToString();
            string parentesco = txtParentesco.Text;
            if (accion == "Crear")
            {
                try
                {
                    prestamo.id_prestamo = dbm.createPrestamo(prestamo);
                    if (radioButton1.Checked)
                        dbm.createRelationEP(ep.id_empleado, prestamo.id_prestamo);
                    else
                        dbm.createRelationPEP(pep.id_personae, pep.id_aval, prestamo.id_prestamo, parentesco);
                    MessageBox.Show("Prestamo creado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(prestamo.id_prestamo + " " +Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }else
            {
                try
                {
                    dbm.updatePrestamo(prestamo);
                    if (radioButton2.Checked)
                        dbm.updateRelationPEP(pep.id_personae, pep.id_aval, prestamo.id_prestamo, parentesco);
                    MessageBox.Show("Prestamo modificado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
