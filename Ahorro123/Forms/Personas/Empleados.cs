using ahorro123.DatabaseManager;
using Ahorro123.DatabaseManager;
using Ahorro123.Forms.Personas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorro123.Forms
{
    public partial class Empleados : Form
    {
        DBManagement dbm { get; set; }
        int id_selection { get; set; }
        public Empleados()
        {
            InitializeComponent();
            dbm = new DBManagement();
            
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            refrescar();

            viewEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            viewEmpleados.MultiSelect = false;
        }

        private void refrescar()
        {
            viewEmpleados.DataSource = dbm.getEmleados(((Form1)MdiParent).isAdmin);
            viewEmpleados.AutoResizeColumns();
        }

        private void Empleados_Resize(object sender, EventArgs e)
        {
            int alto = this.Size.Height;
            viewEmpleados.Height = alto - groupBox1.Size.Height - 30;
        }

        private void viewEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (viewEmpleados.SelectedRows.Count == 1)
            {
                id_selection = int.Parse(viewEmpleados.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void viewEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editar();
        }

        private void editar()
        {
            id_selection = int.Parse(viewEmpleados.SelectedRows[0].Cells[0].Value.ToString());

            Empleado edit = new Empleado();
            edit.id_empleado = id_selection;
            edit.primer_nombre = viewEmpleados.SelectedRows[0].Cells[1].Value.ToString();
            edit.segundo_nombre = viewEmpleados.SelectedRows[0].Cells[2].Value.ToString();
            edit.primer_apellido = viewEmpleados.SelectedRows[0].Cells[3].Value.ToString();
            edit.segundo_apellido = viewEmpleados.SelectedRows[0].Cells[4].Value.ToString();
            edit.direccion_departamento = viewEmpleados.SelectedRows[0].Cells[5].Value.ToString();
            edit.direccion_ciudad = viewEmpleados.SelectedRows[0].Cells[6].Value.ToString();
            edit.direccion_referencia = viewEmpleados.SelectedRows[0].Cells[7].Value.ToString();
            edit.direccion_calle = viewEmpleados.SelectedRows[0].Cells[8].Value.ToString();
            edit.direccion_avenida = viewEmpleados.SelectedRows[0].Cells[9].Value.ToString();
            edit.dirrecion_num_casa = viewEmpleados.SelectedRows[0].Cells[10].Value.ToString();
            edit.correo_secundario = viewEmpleados.SelectedRows[0].Cells[11].Value.ToString();
            edit.fecha_inicio = Convert.ToDateTime(viewEmpleados.SelectedRows[0].Cells[12].Value.ToString().Split(' ')[0]);
            edit.fecha_nacimiento = Convert.ToDateTime(viewEmpleados.SelectedRows[0].Cells[13].Value.ToString().Split(' ')[0]);
            //Formulario de Editar
            Acciones ac = new Acciones("Empleados", "Editar");
            ac.fillEmpleado(edit);
            ac.ShowDialog();
            refrescar();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Formulario de Creacion
            Acciones ac = new Acciones("Empleados", "Crear");
            ac.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Eliminar
            DialogResult dr = MessageBox.Show("Confirme eliminacion de Empleado con id: " + id_selection.ToString(), "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                dbm.deleteEmpleado(id_selection);
                refrescar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refrescar();
        }
    }
}
