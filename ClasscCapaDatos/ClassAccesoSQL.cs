using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ClasscCapaDatos
{
    public class ClassAccesoSQL
    {
        // Propiedad privada que almacenará la conexión de la base de datos
        private SqlConnection Connection;
        // Método que realiza la conexión a SQL Server ocupando el Web.config
        private void OpenConnection()
        {
            string conn_string = ConfigurationManager.ConnectionStrings["conn_covid"].ConnectionString;
            this.Connection = new SqlConnection(conn_string);
            this.Connection.Open();
        }
        // Método privado que retorna una DataSet que va depender de cuantos Querys le mandes.
        public DataSet QueryDataSet(List<string> listQuery, ref string message, List<SqlParameter> listParameter)
        {
            SqlCommand command = null;
            SqlDataAdapter adapter = null;
            DataSet dataSet = new DataSet();
            OpenConnection();

            if (this.Connection == null)
            {
                message = "La conexión con la base de datos no ha sido exitosa";
                dataSet = null;
            }
            else
            {
                int counter = 1;
                foreach (string query in listQuery)
                {
                    command = new SqlCommand(query, this.Connection);
                    adapter = new SqlDataAdapter(command);

                    foreach (SqlParameter parameter in listParameter)
                        command.Parameters.Add(parameter);

                    try
                    {
                        adapter.Fill(dataSet, "Consulta" + counter);
                        message = "El DataSet se lleno";
                    }
                    catch (Exception a)
                    {
                        message = "Error: " + a.Message;
                    }
                    counter++;
                }
                this.Connection.Close();
                this.Connection.Dispose();
            }
            return dataSet;
        }
        // Método que retorna una DataTable de una consulta SQL, igualmente se tomó en cuenta la seguridad a la hora de las inyecciones SQL 
        public DataTable QueryDataTable(string querySql, ref string message, List<SqlParameter> listParameter)
        {
            SqlCommand command = null;
            DataTable table = null;
            OpenConnection();

            if (this.Connection == null)
            {
                message = "No hay conexion a la BD";
                table = null;
            }
            else
            {
                command = new SqlCommand(querySql, this.Connection);

                foreach (SqlParameter p in listParameter)
                {
                    command.Parameters.Add(p);
                }

                try
                {
                    table = new DataTable();
                    table.Load(command.ExecuteReader());
                    command.Dispose();
                    message = "Consulta Correcta con DataReader un total de filas " + table.Rows.Count;
                }
                catch (Exception ex)
                {
                    table = null;
                    message = "Error: " + ex.Message;
                }
                this.Connection.Close();
                this.Connection.Dispose();
            }
            return table;
        }
        // A la hora de realizar una modificación en la base de datos no necesitamos devolver una tabla, si no una bandera que nos ayudará a saber si lo realizo correctamente 
        public Boolean modification(string querySql, ref string mensaje, List<SqlParameter> listParameter)
        {
            Boolean flag = false;
            SqlCommand command = null;
            this.OpenConnection();

            if (this.Connection != null)
            {
                command = new SqlCommand();
                command.CommandText = querySql;
                command.Connection = this.Connection;

                foreach (SqlParameter p in listParameter)
                    command.Parameters.Add(p);

                try
                {
                    command.ExecuteNonQuery();
                    flag = true;
                    mensaje = "Modificación correcta.";
                }
                catch (Exception f)
                {
                    flag = false;
                    mensaje = "ERROR: " + f.Message;
                }
            }
            else
            {
                flag = false;
                mensaje = "No hay conexión a la BD.";
            }
            return flag;
        }
    }
}
