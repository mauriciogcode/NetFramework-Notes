using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migracion.Entidades;

namespace Migracion.DAC
{
    public class EmpleadoDAC


    {
                string conectionString = @"Data Source=DESKTOP-CBVPLVN\SQLEXPRESS;Initial Catalog=Cba;Integrated Security=True";
        public DataTable GetAll()
        {

            string sqlSentencia = "EmpleadosGetMigrar";

            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;

            SqlCommand sqlComm = new SqlCommand(sqlSentencia, sqlCnn);
            sqlComm.CommandType = CommandType.StoredProcedure;

            sqlCnn.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = sqlComm;
            DA.Fill(ds);

            sqlCnn.Close();
            return ds.Tables[0];
        }

        public int UpdateEstado(Empleado oBE) 
        {
            try
            {

                string sqlSentencia = "Empleado_Update_Estado";

                SqlConnection sqlCnn = new SqlConnection();

                sqlCnn.ConnectionString = conectionString;

                SqlCommand sqlComm = new SqlCommand(sqlSentencia, sqlCnn);

                sqlComm.CommandType = CommandType.StoredProcedure; 

                sqlComm.Parameters.Add("@Legajo", SqlDbType.Int).Value = oBE.Legajo; // Parametro del store procedure

                sqlCnn.Open();

                var res = sqlComm.ExecuteNonQuery();

                sqlCnn.Close();

                return 1;
            }
            catch (Exception ex)
            {

                return 0;
            }


        }
    }
}
