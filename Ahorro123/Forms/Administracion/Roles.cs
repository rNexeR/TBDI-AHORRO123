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

namespace Ahorro123.Forms.Administracion
{
    public partial class Roles : Form
    {
        DBManagement dbm { get; set; }
        public Roles()
        {
            InitializeComponent();
            dbm = new DBManagement();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Roles_Load(object sender, EventArgs e)
        {
            view.DataSource = dbm.getRoles(((Form1)MdiParent).isAdmin);
        }
    }
}
