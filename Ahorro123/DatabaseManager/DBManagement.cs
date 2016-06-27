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
            //closeConnection();
        }

        public void openConnection()
        {
            conn.Open();
        }

        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        //*****Login
        public bool dbLogin(string username, string password)
        {
            closeConnection();
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
            closeConnection();
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
        public ArrayList dbGetIdRolesByUsuario(string username)
        {
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_get_id_roles_by_user(?)";
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
                        roles.Add(DbReader.GetInt32(i));
                    }
                    catch (Exception Ex)
                    {
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
            closeConnection();
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
            closeConnection();
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
            closeConnection();
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
            closeConnection();
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
            prm.Value = nueva.fecha_inicio.Date;
            prm = command.Parameters.Add("p_fecha_nacimiento", OdbcType.Date);
            prm.Value = nueva.fecha_nacimiento.Date;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void deleteEmpleado(int id)
        {
            closeConnection();
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
        public void createTelefonoEmpleado(int id, int number)
        {
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_tels_empleados_create(?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric, 8);
            prm.Value = id;
            prm = command.Parameters.Add("p_telefono", OdbcType.Numeric, 8);
            prm.Value = number;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void updateTelefonoEmpleado(int id, int number, int n_telefono)
        {
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_tels_empleados_update(?,?,?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric, 8);
            prm.Value = id;
            prm = command.Parameters.Add("p_telefono", OdbcType.Numeric, 8);
            prm.Value = number;
            prm = command.Parameters.Add("p_n_id_empleado", OdbcType.Numeric, 8);
            prm.Value = id;
            prm = command.Parameters.Add("p_n_telefono", OdbcType.Numeric, 8);
            prm.Value = n_telefono;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void deleteTelefonoEmpleado(int id, int number)
        {
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_tels_empleados_delete(?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric, 8);
            prm.Value = id;
            prm = command.Parameters.Add("p_telefono", OdbcType.Numeric, 8);
            prm.Value = number;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public ArrayList getTelefonosEmpleado(int id)
        {
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_get_tels_empleado(?)";
            prm = command.Parameters.Add("p_id", OdbcType.Numeric, 8);
            prm.Value = id;

            OdbcDataReader DbReader = command.ExecuteReader();
            ArrayList tels = new ArrayList();
            while (DbReader.Read())
            {
                for (int i = 0; i < DbReader.FieldCount; i++)
                {
                    try
                    {
                        tels.Add(DbReader.GetInt32(i));
                    }
                    catch (Exception Ex)
                    {
                        tels.Add(Ex.Message);
                    }
                }
            }

            command.Dispose();
            conn.Close();
            DbReader.Close();
            return tels;
        }
        public Boolean empleadoHasCuentas(int id)
        {
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "{CALL fn_get_empleado_has_cuentas(?)}";
            prm = command.Parameters.Add("id", OdbcType.Numeric);
            prm.Value = id;
            OdbcDataReader DbReader = command.ExecuteReader();
            int logged = 0;
            while (DbReader.Read())
            {
                for (int i = 0; i < DbReader.FieldCount; i++)
                {
                    try
                    {
                        logged = DbReader.GetInt32(i);
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            command.Dispose();
            DbReader.Close();
            conn.Close();
            //return false;
            return logged > 0 ? true : false;
        }

        //*****Personas Externas
        public DataTable getPersonasE(Boolean isAdmin)
        {
            closeConnection();
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
            closeConnection();
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
            closeConnection();
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
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_personas_externas_update(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            prm = command.Parameters.Add("p_id_persona_externa", OdbcType.VarChar, 100);
            prm.Value = nueva.id_persona;
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
        public void createTelefonoPersonaE(int id, int number)
        {
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_tels_personase_create(?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric, 8);
            prm.Value = id;
            prm = command.Parameters.Add("p_telefono", OdbcType.Numeric, 8);
            prm.Value = number;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void updateTelefonoPersonaE(int id, int number, int n_telefono)
        {
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_tels_personase_update(?,?,?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric, 8);
            prm.Value = id;
            prm = command.Parameters.Add("p_telefono", OdbcType.Numeric, 8);
            prm.Value = number;
            prm = command.Parameters.Add("p_n_id_empleado", OdbcType.Numeric, 8);
            prm.Value = id;
            prm = command.Parameters.Add("p_n_telefono", OdbcType.Numeric, 8);
            prm.Value = n_telefono;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void deleteTelefonoPersonaE(int id, int number)
        {
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_tels_personase_delete(?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric, 8);
            prm.Value = id;
            prm = command.Parameters.Add("p_telefono", OdbcType.Numeric, 8);
            prm.Value = number;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public ArrayList getTelefonosPersonaExterna(int id)
        {
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_get_tels_persona_e(?)";
            prm = command.Parameters.Add("p_id", OdbcType.Numeric, 8);
            prm.Value = id;

            OdbcDataReader DbReader = command.ExecuteReader();
            ArrayList tels = new ArrayList();
            while (DbReader.Read())
            {
                for (int i = 0; i < DbReader.FieldCount; i++)
                {
                    try
                    {
                        tels.Add(DbReader.GetInt32(i));
                    }
                    catch (Exception Ex)
                    {
                        tels.Add(Ex.Message);
                    }
                }
            }

            command.Dispose();
            DbReader.Close();
            conn.Close();
            return tels;
        }

        //*****Abonos
        public DataTable getAbonos(Boolean isAdmin)
        {
            closeConnection();
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
        public void createAbono(Abono abono)
        {

            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_abonos_create(?,?,?)";
            prm = command.Parameters.Add("p_id_cuenta", OdbcType.Numeric);
            prm.Value = abono.id_cuenta;
            prm = command.Parameters.Add("p_monto", OdbcType.Decimal);
            prm.Value = abono.monto;
            prm = command.Parameters.Add("p_descripcion", OdbcType.VarChar, 100);
            prm.Value = abono.descripcion;

            command.ExecuteNonQuery();
            
            command.Dispose();
            conn.Close();
        }
        public void updateAbono(Abono abono)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_abonos_update(?,?,?,?)";
            prm = command.Parameters.Add("p_id_cuenta", OdbcType.Numeric);
            prm.Value = abono.id_cuenta;
            prm = command.Parameters.Add("p_fecha", OdbcType.Date);
            prm.Value = DateTime.Now.Date;
            prm = command.Parameters.Add("p_monto", OdbcType.Decimal);
            prm.Value = abono.monto;
            prm = command.Parameters.Add("p_descripcion", OdbcType.VarChar, 100);
            prm.Value = abono.descripcion;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void deleteAbono(int id_cuenta, DateTime fecha)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_abonos_delete(?,?)";
            prm = command.Parameters.Add("p_id_cuenta", OdbcType.Numeric);
            prm.Value = id_cuenta;
            prm = command.Parameters.Add("p_fecha", OdbcType.Date);
            prm.Value = fecha;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }


        //*****Cuentas
        public DataTable getCuentas(Boolean isAdmin)
        {
            closeConnection();
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
        public void createCuentas(int id, double saldo_ahorro, double saldo_inversion)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_cuentas_create(?,?,?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric);
            prm.Value = id;
            prm = command.Parameters.Add("p_fecha_apertura", OdbcType.Date);
            prm.Value = DateTime.Now.Date;
            prm = command.Parameters.Add("p_saldo", OdbcType.Decimal);
            prm.Value = saldo_ahorro;
            prm = command.Parameters.Add("p_tipo", OdbcType.VarChar, 100);
            prm.Value = "Ahorro";

            command.ExecuteNonQuery();
            
            command.Dispose();

            //Crear Cuenta Inversion
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_cuentas_create(?,?,?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric);
            prm.Value = id;
            prm = command.Parameters.Add("p_fecha_apertura", OdbcType.Date);
            prm.Value = DateTime.Now.Date;
            prm = command.Parameters.Add("p_saldo", OdbcType.Decimal);
            prm.Value = saldo_inversion;
            prm = command.Parameters.Add("p_tipo", OdbcType.VarChar, 100);
            prm.Value = "Inversion";

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void updateCuentas(int id, int id_cuenta, double saldo, string tipo)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_cuentas_update(?,?,?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric);
            prm.Value = id;
            prm = command.Parameters.Add("p_id_cuenta", OdbcType.Numeric);
            prm.Value = id_cuenta;
            prm = command.Parameters.Add("p_saldo", OdbcType.Decimal);
            prm.Value = saldo;
            prm = command.Parameters.Add("p_tipo", OdbcType.VarChar, 100);
            prm.Value = tipo;

            command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
        }
        public void deleteCuentas(int id, int id_cuenta)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_cuentas_delete(?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric);
            prm.Value = id;
            prm = command.Parameters.Add("p_id_cuenta", OdbcType.Numeric);
            prm.Value = id_cuenta;

            command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
        }

        //*****Pagos
        public DataTable getPagos(Boolean isAdmin)
        {
            closeConnection();
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
        public DataTable getPagosByPrestamo(int id)
        {
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandText = "execute procedure sp_get_pagos_by_prestamo(?)";
            prm = command.Parameters.Add("p_id", OdbcType.Numeric);
            prm.Value = id;
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }
        public void createPago(Pago pago)
        {

            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_pagos_create(?,?)";
            prm = command.Parameters.Add("p_id_prestamo", OdbcType.Numeric);
            prm.Value = pago.id_prestamo;
            prm = command.Parameters.Add("p_monto", OdbcType.Decimal);
            prm.Value = pago.monto;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void updatePago(Pago pago)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_pagos_update(?,?,?)";
            prm = command.Parameters.Add("p_id_prestamo", OdbcType.Numeric);
            prm.Value = pago.id_prestamo;
            prm = command.Parameters.Add("p_monto", OdbcType.Decimal);
            prm.Value = pago.monto;
            prm = command.Parameters.Add("p_num_pago", OdbcType.Numeric);
            prm.Value = pago.id_pago;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void deletePago(int id_prestamo, int num_pago)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_pagos_delete(?,?)";
            prm = command.Parameters.Add("p_id_prestamo", OdbcType.Numeric);
            prm.Value = id_prestamo;
            prm = command.Parameters.Add("p_num_pago", OdbcType.Numeric);
            prm.Value = num_pago;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }

        //*****Prestamos
        public DataTable getPrestamos(Boolean isAdmin)
        {
            closeConnection();
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
        public DataTable getFullPrestamos(Boolean isAdmin)
        {
            closeConnection();
            conn.Open();
            command.Connection = conn;
            command.CommandText = "select * from vw_prestamos_full";
            if (isAdmin)
                command.CommandText = "select * from vw_prestamos_full_for_admin";
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command);

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            command.Dispose();
            conn.Close();

            return ds.Tables[0];
        }
        public int createPrestamo(Prestamo pr)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_prestamos_create(?,?,?,?,?)";
            prm = command.Parameters.Add("p_fecha", OdbcType.Date);
            prm.Value = pr.fecha;
            prm = command.Parameters.Add("p_monto", OdbcType.Decimal);
            prm.Value = pr.monto;
            prm = command.Parameters.Add("p_periodos", OdbcType.Numeric);
            prm.Value = pr.periodos;
            prm = command.Parameters.Add("p_saldo", OdbcType.Decimal);
            prm.Value = pr.saldo;
            prm = command.Parameters.Add("p_tasa", OdbcType.Decimal);
            prm.Value = pr.tasa;

            OdbcDataReader DbReader = command.ExecuteReader();
            int id = 0;
            while (DbReader.Read())
            {
                for (int i = 0; i < DbReader.FieldCount; i++)
                {
                    try
                    {
                        id = DbReader.GetInt32(i);
                    }
                    catch
                    {
                        return -1;
                    }
                }
            }

            DbReader.Close();
            command.Dispose();
            conn.Close();
            return id;
        }
        public void updatePrestamo(Prestamo pr)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_prestamos_update(?,?,?,?,?,?)";
            prm = command.Parameters.Add("p_id_prestamo", OdbcType.Numeric);
            prm.Value = pr.id_prestamo;
            prm = command.Parameters.Add("p_fecha", OdbcType.Date);
            prm.Value = pr.fecha;
            prm = command.Parameters.Add("p_monto", OdbcType.Decimal);
            prm.Value = pr.monto;
            prm = command.Parameters.Add("p_periodos", OdbcType.Numeric);
            prm.Value = pr.periodos;
            prm = command.Parameters.Add("p_saldo", OdbcType.Decimal);
            prm.Value = pr.saldo;
            prm = command.Parameters.Add("p_tasa", OdbcType.Decimal);
            prm.Value = pr.tasa;

            command.ExecuteNonQuery();

            command.Dispose();
        }
        public void deletePrestamo(int id)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_prestamos_delete(?)";
            prm = command.Parameters.Add("p_id_prestamo", OdbcType.Numeric);
            prm.Value = id;

            command.ExecuteNonQuery();

            command.Dispose();
        }

        //*****Prestamos - Empleados
        public void createRelationEP(int id_empleado, int id_prestamo)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_empleados_prestamos_create(?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric);
            prm.Value = id_empleado;
            prm = command.Parameters.Add("p_id_prestamo", OdbcType.Numeric);
            prm.Value = id_prestamo;

            command.ExecuteNonQuery();

            command.Dispose();
        }
        public void deleteRelationEP(int id_empleado, int id_prestamo)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_empleados_prestamos_delete(?,?)";
            prm = command.Parameters.Add("p_id_empleado", OdbcType.Numeric);
            prm.Value = id_empleado;
            prm = command.Parameters.Add("p_id_prestamo", OdbcType.Numeric);
            prm.Value = id_prestamo;

            command.ExecuteNonQuery();

            command.Dispose();
        }

        //*****Prestamos - Empleados - PersonaE
        public void createRelationPEP(int id_persona,int id_empleado_aval, int id_prestamo, string parentesco)
        {
            closeConnection();
            conn.Open();

            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_personae_empleado_prestamo_create(?,?,?,?)";
            prm = command.Parameters.Add("p_id_empleado_aval", OdbcType.Numeric);
            prm.Value = id_empleado_aval;
            prm = command.Parameters.Add("p_id_prestamo", OdbcType.Numeric);
            prm.Value = id_prestamo;
            prm = command.Parameters.Add("p_id_persona_e", OdbcType.Numeric);
            prm.Value = id_persona;
            prm = command.Parameters.Add("p_parentesco_aval", OdbcType.VarChar, 100);
            prm.Value = parentesco;

            command.ExecuteNonQuery();

            command.Dispose();
        }
        public void updateRelationPEP(int id_persona, int id_empleado_aval, int id_prestamo, string parentesco)
        {
            closeConnection();
            conn.Open();

            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_personae_empleado_prestamo_update(?,?,?,?)";
            prm = command.Parameters.Add("p_id_empleado_aval", OdbcType.Numeric);
            prm.Value = id_empleado_aval;
            prm = command.Parameters.Add("p_id_prestamo", OdbcType.Numeric);
            prm.Value = id_prestamo;
            prm = command.Parameters.Add("p_id_persona_e", OdbcType.Numeric);
            prm.Value = id_persona;
            prm = command.Parameters.Add("p_parentesco_aval", OdbcType.VarChar, 100);
            prm.Value = parentesco;

            command.ExecuteNonQuery();

            command.Dispose();
        }
        public void deleteRelationPEP(int id_prestamo)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_personae_empleado_prestamo_delete(?)";
            prm = command.Parameters.Add("p_id_prestamo", OdbcType.Numeric);
            prm.Value = id_prestamo;

            command.ExecuteNonQuery();

            command.Dispose();
        }

        //*****Privilegios
        public DataTable getPrivilegios(Boolean isAdmin)
        {
            closeConnection();
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
            closeConnection();
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
            closeConnection();
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
        public void createUsuario(Usuario user)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_usuarios_create(?,?,?)";
            prm = command.Parameters.Add("p_correo", OdbcType.VarChar, 100);
            prm.Value = user.correo_primario;
            prm = command.Parameters.Add("p_clave", OdbcType.VarChar, 10);
            prm.Value = user.clave;
            prm = command.Parameters.Add("p_nombre", OdbcType.VarChar, 100);
            prm.Value = user.nombre_usuario;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void updateUsuario(Usuario user)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_usuarios_update(?,?,?)";
            prm = command.Parameters.Add("p_correo", OdbcType.VarChar, 100);
            prm.Value = user.correo_primario;
            prm = command.Parameters.Add("p_clave", OdbcType.VarChar, 10);
            prm.Value = user.clave;
            prm = command.Parameters.Add("p_nombre", OdbcType.VarChar, 100);
            prm.Value = user.nombre_usuario;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void deleteUsuario(string user)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_usuarios_delete(?)";
            prm = command.Parameters.Add("p_correo", OdbcType.VarChar, 100);
            prm.Value = user;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }

        //*****RelationUR
        public void createRelationUR(int id_rol, string user)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_usuarios_roles_create(?,?)";
            prm = command.Parameters.Add("p_id_usuario", OdbcType.VarChar, 100);
            prm.Value = user;
            prm = command.Parameters.Add("p_id_rol", OdbcType.VarChar, 10);
            prm.Value = id_rol;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }
        public void deleteRelationUR(int id_rol, string user)
        {
            closeConnection();
            conn.Open();
            //Crear Cuenta Ahorro
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "execute procedure sp_usuarios_roles_delete(?,?)";
            prm = command.Parameters.Add("p_id_usuario", OdbcType.VarChar, 100);
            prm.Value = user;
            prm = command.Parameters.Add("p_id_rol", OdbcType.VarChar, 10);
            prm.Value = id_rol;

            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }

        //*****Reportes
        public DataTable getReporteCierreAnual(int anio)
        {
            closeConnection();
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
            closeConnection();
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
            closeConnection();
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
            closeConnection();
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
