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

namespace Ahorro123.Forms.Personas
{
    public partial class Personas_Externas : Form
    {
        DBManagement dbm { get; set; }
        int id_selection { get; set; }
        public Personas_Externas()
        {
            InitializeComponent();
            dbm = new DBManagement();
        }

        private void Personas_Externas_Load(object sender, EventArgs e)
        {
            refrescar();
            viewPersonasE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            viewPersonasE.MultiSelect = false;
        }

        private void refrescar()
        {
            viewPersonasE.DataSource = dbm.getPersonasE(((Form1)MdiParent).isAdmin);
            viewPersonasE.AutoResizeColumns();
        }

        private void Personas_Externas_Resize(object sender, EventArgs e)
        {
            int alto = this.Size.Height;
            viewPersonasE.Height = alto - groupBox1.Size.Height - 30;
        }

        private void viewPersonasE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (viewPersonasE.SelectedRows.Count == 1)
            {
                id_selection = int.Parse(viewPersonasE.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Acciones ac = new Acciones("Personas Externas", "Crear");
            ac.ShowDialog();
            refrescar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Acciones ac = new Acciones("Personas Externas", "Editar");
            ac.ShowDialog();
            refrescar();
        }

        private void viewPersonasE_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editar();
            refrescar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        private void editar()
        {
            id_selection = int.Parse(viewPersonasE.SelectedRows[0].Cells[0].Value.ToString());

            Persona_Externa edit = new Persona_Externa();
            edit.id_persona = id_selection;
            edit.primer_nombre = viewPersonasE.SelectedRows[0].Cells[1].Value.ToString();
            edit.segundo_nombre = viewPersonasE.SelectedRows[0].Cells[2].Value.ToString();
            edit.primer_apellido = viewPersonasE.SelectedRows[0].Cells[3].Value.ToString();
            edit.segundo_apellido = viewPersonasE.SelectedRows[0].Cells[4].Value.ToString();
            edit.direccion_departamento = viewPersonasE.SelectedRows[0].Cells[5].Value.ToString();
            edit.direccion_ciudad = viewPersonasE.SelectedRows[0].Cells[6].Value.ToString();
            edit.direccion_referencia = viewPersonasE.SelectedRows[0].Cells[7].Value.ToString();
            edit.direccion_calle = viewPersonasE.SelectedRows[0].Cells[8].Value.ToString();
            edit.direccion_avenida = viewPersonasE.SelectedRows[0].Cells[9].Value.ToString();
            edit.dirrecion_num_casa = viewPersonasE.SelectedRows[0].Cells[10].Value.ToString();
            edit.correo_primario = viewPersonasE.SelectedRows[0].Cells[11].Value.ToString();
            edit.correo_secundario = viewPersonasE.SelectedRows[0].Cells[12].Value.ToString();
            edit.fecha_nacimiento = Convert.ToDateTime(viewPersonasE.SelectedRows[0].Cells[13].Value.ToString().Split(' ')[0]);
            //Formulario de Editar
            Acciones ac = new Acciones("Persona Externa", "Editar");
            ac.fillPersonaE(edit);
            ac.ShowDialog();
            refrescar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Confirme eliminacion de Persona Externa con id: " + id_selection.ToString(), "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                dbm.deletePersonaExterna(id_selection);
                refrescar();
            }
        }
    }
}
