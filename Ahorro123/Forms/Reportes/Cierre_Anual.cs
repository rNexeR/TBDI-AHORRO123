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
    public partial class Cierre_Anual : Form
    {
        DBManagement dbm;
        public Cierre_Anual()
        {
            InitializeComponent();
            dbm = new DBManagement();
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
            
            if ( anio > 0)
            {
                view.DataSource = dbm.getReporteCierreAnual(anio);
                view.AutoResizeColumns();
            }
        }

        private void Cierre_Anual_Resize(object sender, EventArgs e)
        {
            int alto = this.Size.Height;
            view.Height = alto - groupBox1.Size.Height - 30;
        }

        private void Cierre_Anual_Load(object sender, EventArgs e)
        {
            int alto = this.Size.Height;
            view.Height = alto - groupBox1.Size.Height - 30;
        }
    }
}
