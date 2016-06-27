using ahorro123.DatabaseManager;
using Ahorro123.DatabaseManager;
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

namespace Ahorro123.Forms.Personas
{
    public partial class Acciones : Form
    {
        string tipo { get; set; }
        string accion { get; set; }
        DBManagement dbm { get; set; }
        ArrayList tels { get; set; }
        public Acciones(string tipo, string accion)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.accion = accion;
            dbm = new DBManagement();
            tels = new ArrayList();
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
                groupBox2.Visible = false;
                this.Width = this.Width - groupBox2.Width;
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
                    
                    foreach (int n in tels)
                    {
                        try
                        {
                            dbm.createTelefonoEmpleado(emp.id_empleado, n);
                        }
                        catch(Exception Ex)
                        {
                        }

                    }

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

                    foreach (int n in tels)
                    {
                        try
                        {
                            dbm.createTelefonoPersonaE(emp.id_persona, n);
                        }
                        catch (Exception Ex)
                        {
                        }

                    }

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
            fechaInicio.Value = datos.fecha_inicio.Date;
            fecha.Value = datos.fecha_nacimiento.Date;
            tels = dbm.getTelefonosEmpleado(datos.id_empleado);
            f5ListView();
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
            fecha.Value = datos.fecha_nacimiento.Date;
            tels = dbm.getTelefonosPersonaExterna(datos.id_persona);
            f5ListView();
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

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.MultiSelect = false;
            
            int tel;
            try
            {
                tel = int.Parse(txtTel.Text);
            }
            catch(Exception Ex)
            {
                return;
            }
            tels.Add(tel);
            f5ListView();
        }

        private void f5ListView()
        {
            listView1.Clear();
            if(tels.Count > 0)
                foreach (int n in tels){
                    listView1.Items.Add(n.ToString());
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int tel = 0;
                try
                {
                    tel = int.Parse(listView1.SelectedItems[0].Text);
                    tels.Remove(tel);
                    if (tipo.Equals("Empleados"))
                        dbm.deleteTelefonoEmpleado(int.Parse(txtId.Text), tel);
                    else
                        dbm.deleteTelefonoPersonaE(int.Parse(txtId.Text), tel);
                    f5ListView();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show("Error en eliminar telefono: " + Ex.Message + " |" + tel.ToString());
                }
                
            }
        }
    }
}
