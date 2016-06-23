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

namespace Ahorro123.Forms.Reportes
{
    public partial class Inversiones_Empleado : Form
    {
        DBManagement dbm;
        public Inversiones_Empleado()
        {
            InitializeComponent();
            dbm = new DBManagement();
        }

        private void Inversiones_Empleado_Load(object sender, EventArgs e)
        {
            int alto = this.Size.Height;
            view.Height = alto - groupBox1.Size.Height - 30;
        }

        private void Inversiones_Empleado_Resize(object sender, EventArgs e)
        {
            int alto = this.Size.Height;
            view.Height = alto - groupBox1.Size.Height - 30;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectionForm sf = new SelectionForm("Empleados");
            sf.ShowDialog();
            if (sf.DialogResult == DialogResult.OK)
                txtId.Text = sf.id_selection.ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int id;
            string nombre = txtNombre.Text;
            try
            {
                id = int.Parse(txtId.Text);
            }
            catch(Exception Ex)
            {
                id = -1;
            }

            view.DataSource = dbm.getReporteInversiones(id, nombre);
            view.AutoResizeColumns();
        }
    }
}
