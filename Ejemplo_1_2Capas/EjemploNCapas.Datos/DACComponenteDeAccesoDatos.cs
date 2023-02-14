using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploNCapas.Datos
{
  //  internal class DACComponenteDeAccesoDatos
    public class DACComponenteDeAccesoDatos
    {
        string conectionString = @"Data Source=DESKTOP-CBVPLVN\SQLEXPRESS;Initial Catalog=Cervantes;Integrated Security=True";

        public DataTable GetAll()
        //DataTable requiere una referencia using System.Data;

        {
            string sqlSentencia = "select * from Ejemplo";

            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;

            SqlCommand sqlComm = new SqlCommand(sqlSentencia, sqlCnn);

            sqlCnn.Open();


            // La pizzara para datos y otras cosas...
            DataSet ds = new DataSet();
            // Listado de comandos de conexion y manejo de datos
            SqlDataAdapter DA = new SqlDataAdapter();
            // Ejecuto un comando... que tiene la sentencia y la conexion
            DA.SelectCommand = sqlComm;
            // Y ordeno llenar la pizarra
            DA.Fill(ds);

            sqlCnn.Close();
            // de la pizarra solo necesito que me devuelva los datos no demas valores
            var o = ds.Tables[0];
            return ds.Tables[0]; ;
        }
    }
}
