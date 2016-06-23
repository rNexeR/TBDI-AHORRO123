using ahorro123.DatabaseManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorro123.DatabaseManager
{
    class DBManagement
    {
        public string conectar { get; set; }
        public OdbcConnection conn { get; set; }
        public OdbcCommand command { get; set; }
        public OdbcParameter prm { get; set; }

        public DBManagement()
        {
            conectar = "FileDsn=C:/Users/Nexer/Documents/informix32b.dsn;UID=informix;PWD=NexeR2995";
            conn = new OdbcConnection();
            conn.ConnectionString = conectar;
            command = new OdbcCommand();
            prm = new OdbcParameter();
        }

        ~DBManagement()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                closeConnection();
        }

        public void openConnection()
        {
            conn.Open();
        }

        public void closeConnection()
        {
            conn.Close();
        }

        //*****Login
        public bool dbLogin(string username, string password)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "{CALL fn_login(?,?)}";
            prm = command.Parameters.Add("p_username", OdbcType.VarChar, 100);
            prm.Value = username;
            prm = command.Parameters.Add("p_password", OdbcType.VarChar, 100);
            prm.Value = password;
            OdbcDataReader DbReader = command.ExecuteReader();
            int logged = 0;
            string resultado = "";
            while (DbReader.Read())
            {
                for (int i = 0; i < DbReader.FieldCount; i++)
                {
                    try
                    {
                        logged = DbReader.GetInt32(i);
                    }
                    catch (Exception Ex)
                    {
                        return false;
                    }
                }
            }
            Console.WriteLine(resultado);
            command.Dispose();
            DbReader.Close();
            conn.Close();
            //return false;
            return logged == 1 ? true : false;
        }

        public ArrayList dbGetRolesByUsuario(string username)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_get_roles_by_user(?)";
            prm = command.Parameters.Add("p_username", OdbcType.VarChar, 100);
            prm.Value = username;
            OdbcDataReader DbReader = command.ExecuteReader();
            ArrayList roles = new ArrayList();
            while (DbReader.Read())
            {
                for (int i = 0; i < DbReader.FieldCount; i++)
                {
                    try
                    {
                        roles.Add(DbReader.GetString(i));
                    }
                    catch (Exception Ex)
                    {
                        roles.Add(Ex.Message);
                    }
                }
            }
            command.Dispose();
            DbReader.Close();
            conn.Close();
            return roles;
        }

        public ArrayList dbGetPrivilegiosByUsuario(string username)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_get_privilegios_by_user(?)";
            prm = command.Parameters.Add("p_username", OdbcType.VarChar, 100);
            prm.Value = username;
            OdbcDataReader DbReader = command.ExecuteReader();
            ArrayList privilegios = new ArrayList();
            while (DbReader.Read())
            {
                for (int i = 0; i < DbReader.FieldCount; i++)
                {
                    try
                    {
                        privilegios.Add(DbReader.GetString(i));
                    }
                    catch (Exception Ex)
                    {
                        privilegios.Add(Ex.Message);
                    }
                }
            }
            command.Dispose();
            DbReader.Close();
            conn.Close();
            return privilegios;
        }

        //*****Empleados
        public DataTable getEmleados(Boolean isAdmin)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select * from vw_empleados";
            if (isAdmin)
                command.CommandText = "select * from vw_empleados_for_admin";
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }
        public void createEmleado(Empleado nueva)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_empleados_create(?,?,?,?,?,?,?,?,?,?,?,?,?)";
            prm = command.Parameters.Add("p_primer_nombre", OdbcType.VarChar, 100);
            prm.Value = nueva.primer_nombre;
            prm = command.Parameters.Add("p_segundo_nombre", OdbcType.VarChar, 100);
            prm.Value = nueva.segundo_nombre;
            prm = command.Parameters.Add("p_primer_apellido", OdbcType.VarChar, 100);
            prm.Value = nueva.primer_apellido;
            prm = command.Parameters.Add("p_segundo_apellido", OdbcType.VarChar, 100);
            prm.Value = nueva.segundo_apellido;
            prm = command.Parameters.Add("p_departamento", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_departamento;
            prm = command.Parameters.Add("p_ciudad", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_ciudad;
            prm = command.Parameters.Add("p_referencia", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_referencia;
            prm = command.Parameters.Add("p_calle", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_calle;
            prm = command.Parameters.Add("p_avenida", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_avenida;
            prm = command.Parameters.Add("p_num_casa", OdbcType.VarChar, 100);
            prm.Value = nueva.dirrecion_num_casa;
            prm = command.Parameters.Add("p_correo_secundario", OdbcType.VarChar, 100);
            prm.Value = nueva.correo_secundario;
            prm = command.Parameters.Add("p_fecha_inicio", OdbcType.Date);
            prm.Value = nueva.fecha_inicio;
            prm = command.Parameters.Add("p_fecha_nacimiento", OdbcType.Date);
            prm.Value = nueva.fecha_nacimiento;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void updateEmleado(Empleado nueva)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_empleados_update(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.VarChar, 100);
            prm.Value = nueva.id_empleado;
            prm = command.Parameters.Add("p_primer_nombre", OdbcType.VarChar, 100);
            prm.Value = nueva.primer_nombre;
            prm = command.Parameters.Add("p_segundo_nombre", OdbcType.VarChar, 100);
            prm.Value = nueva.segundo_nombre;
            prm = command.Parameters.Add("p_primer_apellido", OdbcType.VarChar, 100);
            prm.Value = nueva.primer_apellido;
            prm = command.Parameters.Add("p_segundo_apellido", OdbcType.VarChar, 100);
            prm.Value = nueva.segundo_apellido;
            prm = command.Parameters.Add("p_departamento", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_departamento;
            prm = command.Parameters.Add("p_ciudad", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_ciudad;
            prm = command.Parameters.Add("p_referencia", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_referencia;
            prm = command.Parameters.Add("p_calle", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_calle;
            prm = command.Parameters.Add("p_avenida", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_avenida;
            prm = command.Parameters.Add("p_num_casa", OdbcType.VarChar, 100);
            prm.Value = nueva.dirrecion_num_casa;
            prm = command.Parameters.Add("p_correo_secundario", OdbcType.VarChar, 100);
            prm.Value = nueva.correo_secundario;
            prm = command.Parameters.Add("p_fecha_inicio", OdbcType.Date);
            prm.Value = nueva.fecha_inicio;
            prm = command.Parameters.Add("p_fecha_nacimiento", OdbcType.Date);
            prm.Value = nueva.fecha_nacimiento;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void deleteEmpleado(int id)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_empleados_delete(?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.VarChar, 100);
            prm.Value = id;
            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }

        //*****Personas Externas
        public DataTable getPersonasE(Boolean isAdmin)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select * from vw_personase";
            if (isAdmin)
                command.CommandText += "_for_admin";
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }
        public void createPersonaE(Persona_Externa nueva)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_personas_externas_create(?,?,?,?,?,?,?,?,?,?,?,?,?)";
            prm = command.Parameters.Add("p_primer_nombre", OdbcType.VarChar, 100);
            prm.Value = nueva.primer_nombre;
            prm = command.Parameters.Add("p_segundo_nombre", OdbcType.VarChar, 100);
            prm.Value = nueva.segundo_nombre;
            prm = command.Parameters.Add("p_primer_apellido", OdbcType.VarChar, 100);
            prm.Value = nueva.primer_apellido;
            prm = command.Parameters.Add("p_segundo_apellido", OdbcType.VarChar, 100);
            prm.Value = nueva.segundo_apellido;
            prm = command.Parameters.Add("p_departamento", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_departamento;
            prm = command.Parameters.Add("p_ciudad", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_ciudad;
            prm = command.Parameters.Add("p_referencia", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_referencia;
            prm = command.Parameters.Add("p_calle", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_calle;
            prm = command.Parameters.Add("p_avenida", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_avenida;
            prm = command.Parameters.Add("p_num_casa", OdbcType.VarChar, 100);
            prm.Value = nueva.dirrecion_num_casa;
            prm = command.Parameters.Add("p_correo_secundario", OdbcType.VarChar, 100);
            prm.Value = nueva.correo_secundario;
            prm = command.Parameters.Add("p_fecha_nacimiento", OdbcType.Date);
            prm.Value = nueva.fecha_nacimiento;
            prm = command.Parameters.Add("p_correo_primario", OdbcType.VarChar, 100);
            prm.Value = nueva.correo_primario;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void deletePersonaExterna(int id)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_personas_externas_delete(?)";
            prm = command.Parameters.Add("p_id_persona_externa", OdbcType.VarChar, 100);
            prm.Value = id;
            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void updatePersonaE(Persona_Externa nueva)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_personas_externas_update(?,?,?,?,?,?,?,?,?,?,?,?,?)";
            prm = command.Parameters.Add("p_primer_nombre", OdbcType.VarChar, 100);
            prm.Value = nueva.primer_nombre;
            prm = command.Parameters.Add("p_segundo_nombre", OdbcType.VarChar, 100);
            prm.Value = nueva.segundo_nombre;
            prm = command.Parameters.Add("p_primer_apellido", OdbcType.VarChar, 100);
            prm.Value = nueva.primer_apellido;
            prm = command.Parameters.Add("p_segundo_apellido", OdbcType.VarChar, 100);
            prm.Value = nueva.segundo_apellido;
            prm = command.Parameters.Add("p_departamento", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_departamento;
            prm = command.Parameters.Add("p_ciudad", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_ciudad;
            prm = command.Parameters.Add("p_referencia", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_referencia;
            prm = command.Parameters.Add("p_calle", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_calle;
            prm = command.Parameters.Add("p_avenida", OdbcType.VarChar, 100);
            prm.Value = nueva.direccion_avenida;
            prm = command.Parameters.Add("p_num_casa", OdbcType.VarChar, 100);
            prm.Value = nueva.dirrecion_num_casa;
            prm = command.Parameters.Add("p_correo_secundario", OdbcType.VarChar, 100);
            prm.Value = nueva.correo_secundario;
            prm = command.Parameters.Add("p_fecha_nacimiento", OdbcType.Date);
            prm.Value = nueva.fecha_nacimiento;
            prm = command.Parameters.Add("p_correo_primario", OdbcType.VarChar, 100);
            prm.Value = nueva.correo_primario;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }

        //*****Abonos
        public DataTable getAbonos(Boolean isAdmin)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select * from vw_abonos";
            if (isAdmin)
                command.CommandText = "select * from vw_abonos_for_admin";
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }

        //*****Cuentas
        public DataTable getCuentas(Boolean isAdmin)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select * from vw_cuentas";
            if (isAdmin)
                command.CommandText = "select * from vw_cuentas_for_admin";
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }

        //*****Pagos
        public DataTable getPagos(Boolean isAdmin)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select * from vw_pagos";
            if (isAdmin)
                command.CommandText = "select * from vw_pagos_for_admin";
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }

        //*****Prestamos
        public DataTable getPrestamos(Boolean isAdmin)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select * from vw_prestamos";
            if (isAdmin)
                command.CommandText = "select * from vw_prestamos_for_admin";
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }

        //*****Privilegios
        public DataTable getPrivilegios(Boolean isAdmin)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select * from vw_privilegios";
            if (isAdmin)
                command.CommandText += "_for_admin";
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }

        //*****Roles
        public DataTable getRoles(Boolean isAdmin)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select * from vw_roles";
            if (isAdmin)
                command.CommandText += "_for_admin";
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }

        //*****Usuarios
        public DataTable getUsuarios(Boolean isAdmin)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select * from vw_usuarios";
            if (isAdmin)
                command.CommandText += "_for_admin";
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }

        //*****Reportes
        public DataTable getReporteCierreAnual(int anio)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure rep_cierre_anual(?)";
            prm = command.Parameters.Add("anio", OdbcType.Numeric, 8);
            prm.Value = anio;
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }

        public DataTable getReporteGananciasAnual(int anio)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure rep_ganancias_anuales(?)";
            prm = command.Parameters.Add("anio", OdbcType.Numeric, 8);
            prm.Value = anio;
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }

        public DataTable getReporteInversiones(int id_empleado, string nombre)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure rep_afiliaciones_empleado(?, ?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric, 8);
            prm.Value = id_empleado > 0 ? id_empleado: -1;
            prm = command.Parameters.Add("nombre_emplado", OdbcType.VarChar, 100);
            prm.Value = nombre;
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }

        public DataTable getReporteNuevasAfiliaciones(int anio)
        {
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure rep_nuevas_afiliaciones(?)";
            prm = command.Parameters.Add("anio", OdbcType.Numeric, 8);
            prm.Value = anio;
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }

    }
}
