using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layer.Entities;

namespace Layer.DAC
{
    public class ExampleDAC
    {
        string conectionString = @"Data Source=DESKTOP-CBVPLVN\SQLEXPRESS;Initial Catalog=Cervantes;Integrated Security=True";

        public DataTable GetAll()
        {

            // string sqlSentencia = "SELECT e.Id, e.Nombre, e.Descripcion, t.Nombre as TipoEjemplo,e.TipoEjemplo as IdTipoEjemplo FROM Ejemplo as e INNER JOIN TipoEjemplo as t on t.Id = e.TipoEjemplo";

            string sqlSentencia = "SP_EjemploGetAllInner";

            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;

            SqlCommand sqlComm = new SqlCommand(sqlSentencia, sqlCnn);

            sqlComm.CommandType = CommandType.StoredProcedure; // Solo para los store procedures

            sqlCnn.Open();

            DataSet ds = new DataSet();

            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = sqlComm;
            DA.Fill(ds);

            sqlCnn.Close();
            return ds.Tables[0];
        }


        public int Insert(ExampleBE exampleBE) // se usa int para devolver un numero
        {
            try
            {

              //  string sqlSentencia = "insert into ejemplo(Nombre, Descripcion, TipoEjemplo) values('" + exampleBE.Name + "', '" + exampleBE.Description + "'," + exampleBE.ExampleType + ")";
                string sqlSentencia = "SP_EjemploInsert";


                SqlConnection sqlCnn = new SqlConnection();

                sqlCnn.ConnectionString = conectionString;

                SqlCommand sqlComm = new SqlCommand(sqlSentencia, sqlCnn);


                sqlComm.CommandType = CommandType.StoredProcedure; // Solo para los store procedures
               // sqlComm.Parameters.Add("@Id", SqlDbType.Int).Value = exampleBE.Id; // No va el id es un insert

                sqlComm.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = exampleBE.Name; // Parametro del store procedure
                sqlComm.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = exampleBE.Description; // Parametro del store procedure
                sqlComm.Parameters.Add("@TipoEjemplo", SqlDbType.Int).Value = exampleBE.ExampleType; // Parametro del store procedure

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

        public int Delete(ExampleBE exampleBE) // se usa int para devolver un numero
        {
            try
            {
               // string sqlSentencia = "delete from ejemplo where id = (' + exampleBE.Id ')";
                string sqlSentencia = "SP_EjemploDelete";



                SqlConnection sqlCnn = new SqlConnection();

                sqlCnn.ConnectionString = conectionString;

                SqlCommand sqlComm = new SqlCommand(sqlSentencia, sqlCnn);

                sqlComm.CommandType = CommandType.StoredProcedure; // Solo para los store procedures

                sqlComm.Parameters.Add("@Id", SqlDbType.Int).Value = exampleBE.Id; // Parametro del store procedure


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

        public int Update(ExampleBE exampleBE) // se usa int para devolver un numero
        {
            try
            {

                //string sqlSentencia = "update Ejemplo set Nombre = '" + exampleBE.Name + "', Descripcion = '" + exampleBE.Description + "', TipoEjemplo = '" + exampleBE.ExampleType + "where Id =" + exampleBE.Id;
                string sqlSentencia = "SP_EjemploUpdate";

                SqlConnection sqlCnn = new SqlConnection();

                sqlCnn.ConnectionString = conectionString;

                SqlCommand sqlComm = new SqlCommand(sqlSentencia, sqlCnn);

                sqlComm.CommandType = CommandType.StoredProcedure; // Solo para los store procedures

                sqlComm.Parameters.Add("@Id", SqlDbType.Int).Value = exampleBE.Id; // Parametro del store procedure
                sqlComm.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = exampleBE.Name; // Parametro del store procedure
                sqlComm.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = exampleBE.Description; // Parametro del store procedure
                sqlComm.Parameters.Add("@TipoEjemplo", SqlDbType.Int).Value = exampleBE.ExampleType; // Parametro del store procedure



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
