using ahorro123.DatabaseManager;
using Ahorro123.DatabaseManager;
using Ahorro123.Forms;
using Ahorro123.Forms.Administracion;
using Ahorro123.Forms.Personas;
using Ahorro123.Forms.Reportes;
using Ahorro123.Forms.Servicios;
using Ahorro123.Forms.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorro123
{
    public partial class Form1 : Form
    {
        public string user { get; set; }
        public Boolean isAdmin { get; set; }
        public ArrayList roles { get; set; }
        public ArrayList privilegios { get; set; }
        DBManagement dbm { get; set; }
        public Form1()
        {
            InitializeComponent();
            user = null;
            isAdmin = false;
            roles = new ArrayList();
            privilegios = new ArrayList();
            dbm = new DBManagement();
        }

        private void iniciarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.MdiParent = this;
            login.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.MdiParent = this;
            login.Show();
        }

        public void Login(string username, ArrayList roles, ArrayList privi)
        {
            this.user = username;
            this.roles = roles;
            this.privilegios = privi;
            if(user != null)
            {
                this.iniciarSesionToolStripMenuItem.Visible = false;
                this.cerrarSesionToolStripMenuItem.Visible = true;
                StatusLabel.BackColor = Color.Green;
                statusStrip1.BackColor = Color.Green;

                string rolM = "Sin rol";
                if (roles.Count > 0)
                    rolM = "";
                foreach (string r in roles)
                {
                    rolM += r + ", ";
                }

                rolM = rolM.Substring(0, rolM.Length -2);

                StatusLabel.Text = "Sesion Iniciada, Usuario: " + username + " [" + rolM + "]";
                changePermissionUser();
            }
            
            
        }

        private void changePermissionUser()
        {
            isAdmin = false;
            if(roles.Count > 0)
            {
                foreach (string r in roles)
                {
                    switch (r)
                    {
                        case "Administrador":
                            personasToolStripMenuItem.Enabled = true;
                            serviciosToolStripMenuItem.Enabled = true;
                            reportesToolStripMenuItem.Enabled = true;
                            administracionToolStripMenuItem1.Enabled = true;
                            isAdmin = true;
                            break;
                        case "Empleado":
                            personasToolStripMenuItem.Enabled = true;
                            serviciosToolStripMenuItem.Enabled = true;
                            break;
                        case "Auditor":
                            reportesToolStripMenuItem.Enabled = true;
                            break;
                    }
                }
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                user = null;
                this.iniciarSesionToolStripMenuItem.Visible = true;
                this.cerrarSesionToolStripMenuItem.Visible = false;
                StatusLabel.BackColor = Color.DodgerBlue;
                statusStrip1.BackColor = Color.DodgerBlue;
                StatusLabel.Text = "Sin sesion iniciada";
                cerrarSession();
                Login login = new Forms.Login();
                login.MdiParent = this;
                login.Show();
            }
        }

        private void cerrarSession()
        {
            personasToolStripMenuItem.Enabled = false;
            serviciosToolStripMenuItem.Enabled = false;
            reportesToolStripMenuItem.Enabled = false;
            administracionToolStripMenuItem1.Enabled = false;

            user = null;
            isAdmin = false;
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleados emp = new Empleados();
            emp.MdiParent = this;
            emp.Show();
        }

        private void personasExternasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas_Externas pe = new Personas_Externas();
            pe.MdiParent = this;
            pe.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios u = new Usuarios();
            u.MdiParent = this;
            u.Show();
        }

        private void cierreAnualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cierre_Anual ca = new Cierre_Anual();
            ca.MdiParent = this;
            ca.Show();
        }

        private void gananciasAnualesPorPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ganancia_Anual ga = new Ganancia_Anual();
            ga.MdiParent = this;
            ga.Show();
        }

        private void inversionPorEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inversiones_Empleado ie = new Inversiones_Empleado();
            ie.MdiParent = this;
            ie.Show();
        }

        private void nuevasAfiliacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuevas_Afiliaciones na = new Nuevas_Afiliaciones();
            na.MdiParent = this;
            na.Show();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cuentas ct = new Cuentas();
            ct.MdiParent = this;
            ct.Show();
        }

        private void crearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NuevaCuenta nv = new NuevaCuenta("Crear");
            nv.ShowDialog();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prestamos p = new Prestamos();
            p.MdiParent = this;
            p.Show();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionesPrestamos gp = new GestionesPrestamos("Crear");
            gp.ShowDialog();
        }

        private void listarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Pagos p = new Pagos();
            p.MdiParent = this;
            p.Show();
        }

        private void listarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Abonos a = new Abonos();
            a.MdiParent = this;
            a.Show();
        }

        private void crearToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GestionesPagos gp = new GestionesPagos("Crear");
            gp.ShowDialog();
        }

        private void crearToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GestionesAbonos ga = new GestionesAbonos("Crear");
            ga.ShowDialog();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Roles r = new Roles();
            r.MdiParent = this;
            r.Show();
        }

        private void privilegiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Privilegios p = new Privilegios();
            p.MdiParent = this;
            p.Show();
        }
    }
}
