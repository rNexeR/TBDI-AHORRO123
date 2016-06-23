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
    public partial class Acciones : Form
    {
        string tipo { get; set; }
        string accion { get; set; }
        DBManagement dbm { get; set; }
        public Acciones(string tipo, string accion)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.accion = accion;
            dbm = new DBManagement();
        }

        private void Acciones_Load(object sender, EventArgs e)
        {
            this.Text = "Personas Externas: ";
            if (tipo.Equals("Empleados"))
            {
                txtCorreo1.ReadOnly = true;
                txtCorreo1.Text = "No Aplica";
                this.Text = "Empleados: ";
            }else
            {
                fechaInicio.Enabled = false;
            }
            if(accion.Equals("Crear"))
            {
                this.Text += "Creacion";
                txtId.Text = "Autogenerado";
            }
            else
            {
                this.Text += "Modificacion";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(accion.Equals("Crear"))
            {
                if (tipo.Equals("Empleados"))
                {
                    Empleado emp = new Empleado();
                    emp.correo_secundario = txtCorreo2.Text;
                    emp.direccion_avenida = txtAve.Text;
                    emp.direccion_calle = txtCalle.Text;
                    emp.direccion_ciudad = txtCiudad.Text;
                    emp.direccion_departamento = txtDepto.Text;
                    emp.direccion_referencia = txtReferencia.Text;
                    emp.dirrecion_num_casa = txtNCasa.Text;
                    emp.fecha_inicio = fechaInicio.Value;
                    emp.fecha_nacimiento = fecha.Value;
                    emp.primer_apellido = txtPApellido.Text;
                    emp.primer_nombre = txtPNombre.Text;
                    emp.segundo_apellido = txtSApellido.Text;
                    emp.segundo_nombre = txtSNombre.Text;

                    dbm.createEmleado(emp);
                    MessageBox.Show("Empleado creado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleanTexts();
                    
                }else
                {
                    Persona_Externa emp = new Persona_Externa();
                    
                    emp.correo_secundario = txtCorreo2.Text;
                    emp.direccion_avenida = txtAve.Text;
                    emp.direccion_calle = txtCalle.Text;
                    emp.direccion_ciudad = txtCiudad.Text;
                    emp.direccion_departamento = txtDepto.Text;
                    emp.direccion_referencia = txtReferencia.Text;
                    emp.dirrecion_num_casa = txtNCasa.Text;
                    emp.correo_primario = txtCorreo1.Text;
                    emp.fecha_nacimiento = fecha.Value;
                    emp.primer_apellido = txtPApellido.Text;
                    emp.primer_nombre = txtPNombre.Text;
                    emp.segundo_apellido = txtSApellido.Text;
                    emp.segundo_nombre = txtSNombre.Text;

                    dbm.createPersonaE(emp);
                    MessageBox.Show("Persona Externa creada", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleanTexts();
                }
            }
            else
            {
                if (tipo.Equals("Empleados"))
                {
                    Empleado emp = new Empleado();
                    emp.id_empleado = int.Parse(txtId.Text);
                    emp.correo_secundario = txtCorreo2.Text;
                    emp.direccion_avenida = txtAve.Text;
                    emp.direccion_calle = txtCalle.Text;
                    emp.direccion_ciudad = txtCiudad.Text;
                    emp.direccion_departamento = txtDepto.Text;
                    emp.direccion_referencia = txtReferencia.Text;
                    emp.dirrecion_num_casa = txtNCasa.Text;
                    emp.fecha_inicio = fechaInicio.Value;
                    emp.fecha_nacimiento = fecha.Value;
                    emp.primer_apellido = txtPApellido.Text;
                    emp.primer_nombre = txtPNombre.Text;
                    emp.segundo_apellido = txtSApellido.Text;
                    emp.segundo_nombre = txtSNombre.Text;

                    dbm.updateEmleado(emp);
                    MessageBox.Show("Empleado modificado", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                }
                else
                {
                    Persona_Externa emp = new Persona_Externa();
                    emp.id_persona = int.Parse(txtId.Text);
                    emp.correo_secundario = txtCorreo2.Text;
                    emp.direccion_avenida = txtAve.Text;
                    emp.direccion_calle = txtCalle.Text;
                    emp.direccion_ciudad = txtCiudad.Text;
                    emp.direccion_departamento = txtDepto.Text;
                    emp.direccion_referencia = txtReferencia.Text;
                    emp.dirrecion_num_casa = txtNCasa.Text;
                    emp.correo_primario = txtCorreo1.Text;
                    emp.fecha_nacimiento = fecha.Value;
                    emp.primer_apellido = txtPApellido.Text;
                    emp.primer_nombre = txtPNombre.Text;
                    emp.segundo_apellido = txtSApellido.Text;
                    emp.segundo_nombre = txtSNombre.Text;

                    dbm.updatePersonaE(emp);
                    MessageBox.Show("Persona Externa modificada", "Accion Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void fillEmpleado(Empleado datos)
        {
            txtAve.Text = datos.direccion_avenida;
            txtCalle.Text = datos.direccion_calle;
            txtCiudad.Text = datos.direccion_ciudad;
            txtCorreo2.Text = datos.correo_secundario;
            txtDepto.Text = datos.direccion_departamento;
            txtId.Text = datos.id_empleado.ToString();
            txtNCasa.Text = datos.dirrecion_num_casa;
            txtPApellido.Text = datos.primer_apellido;
            txtPNombre.Text = datos.primer_nombre;
            txtReferencia.Text = datos.direccion_referencia;
            txtSApellido.Text = datos.segundo_apellido;
            txtSNombre.Text = datos.segundo_nombre;
            fechaInicio.Text = datos.fecha_inicio.ToString();
            fecha.Text = datos.fecha_nacimiento.ToString();
        }

        public void fillPersonaE(Persona_Externa datos)
        {
            txtAve.Text = datos.direccion_avenida;
            txtCalle.Text = datos.direccion_calle;
            txtCiudad.Text = datos.direccion_ciudad;
            txtCorreo1.Text = datos.correo_secundario;
            txtCorreo2.Text = datos.correo_secundario;
            txtDepto.Text = datos.direccion_departamento;
            txtId.Text = datos.id_persona.ToString();
            txtNCasa.Text = datos.dirrecion_num_casa;
            txtPApellido.Text = datos.primer_apellido;
            txtPNombre.Text = datos.primer_nombre;
            txtReferencia.Text = datos.direccion_referencia;
            txtSApellido.Text = datos.segundo_apellido;
            txtSNombre.Text = datos.segundo_nombre;
            fecha.Text = datos.fecha_nacimiento.ToString();
        }

        private void cleanTexts()
        {
            txtAve.Clear();
            txtCalle.Clear();
            txtCiudad.Clear();
            txtCorreo1.Clear();
            txtCorreo2.Clear();
            txtDepto.Clear();
            txtId.Clear();
            txtNCasa.Clear();
            txtPApellido.Clear();
            txtPNombre.Clear();
            txtReferencia.Clear();
            txtSApellido.Clear();
            txtSNombre.Clear();
            if (tipo.Equals("Empleados"))
            {
                txtCorreo1.ReadOnly = true;
                txtCorreo1.Text = "No Aplica";
            }
            else
            {
                fechaInicio.Enabled = false;
            }
            if (accion.Equals("Crear"))
            {
                txtId.Text = "Autogenerado";
            }
        }
    }
}
