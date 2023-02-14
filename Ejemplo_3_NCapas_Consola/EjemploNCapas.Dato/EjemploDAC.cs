using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ejemplo_3_Capas_Consola.Datos
{
   public class EjemploDAC
    {
        string conectionString = @"Data Source=DESKTOP-CBVPLVN\SQLEXPRESS;Initial Catalog=Cervantes;Integrated Security=True";

        public DataTable GetAll()
        {
            string sqlSentencia = "select * from Ejemplo";

            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;

            SqlCommand sqlComm = new SqlCommand(sqlSentencia, sqlCnn);

            sqlCnn.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = sqlComm;
            DA.Fill(ds);

            sqlCnn.Close();

            return ds.Tables[0]; ;
        }

    }
}
