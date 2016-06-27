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
    public partial class Cuentas : Form
    {
        DBManagement dbm { get; set; }
        int id_cuenta { get; set; }
        int id_empleado { get; set; }
        public Cuentas()
        {
            InitializeComponent();
            dbm = new DBManagement();
        }

        private void Cuentas_Load(object sender, EventArgs e)
        {
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.MultiSelect = false;
            refrescar();
        }

        private void refrescar()
        {
            view.DataSource = dbm.getCuentas(((Form1)MdiParent).isAdmin);
            view.AutoResizeColumns();
        }

        private void Cuentas_Resize(object sender, EventArgs e)
        {
            int alto = this.Size.Height;
            view.Height = alto - groupBox1.Size.Height - 30;
        }

        private void view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (view.SelectedRows.Count == 1)
            {
                id_cuenta = int.Parse(view.SelectedRows[0].Cells[0].Value.ToString());
                id_empleado = int.Parse(view.SelectedRows[0].Cells[1].Value.ToString());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            NuevaCuenta nv = new NuevaCuenta("Crear");
            nv.ShowDialog();
            refrescar();
        }

        private void editar()
        {
            if(view.Rows.Count > 0)
            {
                Cuenta ct = new Cuenta();
                ct.id_empleado = id_empleado;
                ct.id_uenta = id_cuenta;
                ct.saldo = Double.Parse(view.SelectedRows[0].Cells[4].Value.ToString());
                ct.tipo = view.SelectedRows[0].Cells[3].Value.ToString();
                NuevaCuenta nv = new NuevaCuenta("Editar");
                nv.fill(ct);
                nv.ShowDialog();
                refrescar();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void view_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id_cuenta = int.Parse(view.SelectedRows[0].Cells[0].Value.ToString());
            id_empleado = int.Parse(view.SelectedRows[0].Cells[1].Value.ToString());
            editar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (view.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Confirme eliminacion de cuenta id " + id_cuenta, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    try
                    {
                        dbm.deleteCuentas(id_empleado, id_cuenta);
                        MessageBox.Show("Cuenta Eliminada", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
            }
        }
    }
}
