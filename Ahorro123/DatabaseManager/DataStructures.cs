using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ahorro123.DatabaseManager
{
    public class Auditoria
    {
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_actualizacion { get; set; }
        public int id_empleado_creador { get; set; }
        public int id_empleado_actualizador { get; set; }
    }

    public class Abono : Auditoria
    {
        public int id_cuenta { get; set; }
        public Double monto { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
    }

    public class Cuenta : Auditoria
    {
        public int id_uenta { get; set; }
        public int id_empleado { get; set; }
        public DateTime fecha_apertura { get; set; }
        public Double saldo { get; set; }
        public string tipo { get; set; }
    }

    public class Persona : Auditoria
    {
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string direccion_calle { get; set; }
        public string direccion_avenida { get; set; }
        public string dirrecion_num_casa { get; set; }
        public string direccion_ciudad { get; set; }
        public string direccion_departamento { get; set; }
        public string direccion_referencia { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string correo_secundario { get; set; }
    }

    public class Empleado : Persona
    {
        public int id_empleado { get; set; }
        public DateTime fecha_inicio { get; set; }
    }

    public class Usuario: Auditoria
    {
        public string correo_primario { get; set; }
        public string nombre_usuario { get; set; }
        public string clave { get; set; }
    }

    public class Persona_Externa : Persona
    {
        public int id_persona { get; set; }
        public string correo_primario { get; set; }
    }

    public class Pago : Auditoria
    {
        public int id_pago { get; set; }
        public int id_prestamo { get; set; }
        public DateTime fecha { get; set; }
        public Double monto { get; set; }
    }

    public class Prestamo : Auditoria
    {
        public int id_prestamo { get; set; }
        public DateTime fecha { get; set; }
        public Double monto { get; set; }
        public int periodos { get; set; }
        public Double saldo { get; set; }
        public Double tasa { get; set; }
    }

    public class Privilegio : Auditoria
    {
        public int id_privilegio { get; set; }
        public string nombre { get; set; }
    }

    public class Rol : Auditoria
    {
        public int id_rol { get; set; }
        public string nombre { get; set; }
    }

    public class tel_empleado : Auditoria
    {
        public int id_empleado { get; set; }
        public int num_telefono { get; set; }
    }

    public class tel_personae : Auditoria
    {
        public int id_persona_externa { get; set; }
        public int num_telefono { get; set; }
    }

    public class relationEP : Auditoria
    {
        public int id_empleado { get; set; }
        public int id_prestamo { get; set; }
    }

    public class relationPEP : Auditoria
    {
        public int id_aval { get; set; }
        public int id_prestamo { get; set; }
        public int id_personae { get; set; }
        public string parentesco { get; set; }
    }
}