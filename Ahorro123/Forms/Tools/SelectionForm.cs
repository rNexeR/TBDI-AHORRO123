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

namespace Ahorro123.Forms.Tools
{
    public partial class SelectionForm : Form
    {
        public int id_selection { get; set; }
        public string tipo { get; set; }
        DBManagement dbm { get; set; }
        public SelectionForm(string tipo)
        {
            InitializeComponent();
            dbm = new DBManagement();
            this.tipo = tipo;
        }

        private void SelectionForm_Load(object sender, EventArgs e)
        {
            if (tipo.Equals("Personas_Externas"))
                view.DataSource = dbm.getEmleados(false);
            if (tipo.Equals("Empleados"))
                view.DataSource = dbm.getPersonasE(false);
            while (view.Columns.Count > 5)
            {
                view.Columns.RemoveAt(view.Columns.Count-1);
            }
            view.AutoResizeColumns();
            int w = 0;
            for(int i = 0; i < 5; i++)
                w += view.Columns[i].Width + 16;
            this.Width = w;
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.MultiSelect = false;

            int alto = this.Size.Height;
            view.Height = alto - groupBox1.Size.Height - 30;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(view.SelectedRows.Count == 1)
            {
                id_selection = int.Parse(view.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void view_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id_selection = int.Parse(view.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult = DialogResult.OK;
            this.Close();
        }
        
    }
}
