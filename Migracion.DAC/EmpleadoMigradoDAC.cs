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
    public class EmpleadoMigradoDAC
    {
        string conectionString = @"Data Source=DESKTOP-CBVPLVN\SQLEXPRESS;Initial Catalog=BsAs;Integrated Security=True";

        public int Insert(EmpleadoMigrado obe) // se usa int para devolver un numero
        {
            try
            {

                //  string sqlSentencia = "insert into ejemplo(Nombre, Descripcion, TipoEjemplo) values('" + exampleBE.Name + "', '" + exampleBE.Description + "'," + exampleBE.ExampleType + ")";
                string sqlSentencia = "spEmpleadoMigrate_i";


                SqlConnection sqlCnn = new SqlConnection();

                sqlCnn.ConnectionString = conectionString;

                SqlCommand sqlComm = new SqlCommand(sqlSentencia, sqlCnn);


                sqlComm.CommandType = CommandType.StoredProcedure; // Solo para los store procedures
                                                                   // sqlComm.Parameters.Add("@Id", SqlDbType.Int).Value = exampleBE.Id; // No va el id es un insert

                sqlComm.Parameters.Add("@Legajo", SqlDbType.Int).Value = obe.Legajo; // Parametro del store procedure
                sqlComm.Parameters.Add("@CUIL", SqlDbType.NVarChar).Value = obe.Cuil; // Parametro del store procedure
                sqlComm.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = obe.Nombre; // Parametro del store procedure
                sqlComm.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = obe.Apellido; // Parametro del store procedure
                sqlComm.Parameters.Add("@Sexo", SqlDbType.NVarChar).Value = obe.Sexo; // Parametro del store procedure
                sqlComm.Parameters.Add("@FechaNac", SqlDbType.DateTime).Value = obe.FechaNac; // Parametro del store procedure

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
