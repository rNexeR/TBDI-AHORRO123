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

namespace Ahorro123.Forms.Reportes
{
    public partial class Ganancia_Anual : Form
    {
        DBManagement dbm;
        public Ganancia_Anual()
        {
            InitializeComponent();
            dbm = new DBManagement();
        }

        private void Ganancia_Anual_Resize(object sender, EventArgs e)
        {
            int alto = this.Size.Height;
            view.Height = alto - groupBox1.Size.Height - 30;
        }

        private void Ganancia_Anual_Load(object sender, EventArgs e)
        {

            int alto = this.Size.Height;
            view.Height = alto - groupBox1.Size.Height - 30;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int anio;
            try
            {
                anio = int.Parse(txtAnio.Text);
            }
            catch (Exception Ex)
            {
                anio = -1;
            }

            if (anio > 0)
            {
                view.DataSource = dbm.getReporteGananciasAnual(anio);
                view.AutoResizeColumns();
            }
        }
    }
}
