using Migracion.DAC;
using Migracion.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migracion.BC
{
    public class EmpleadoMigradoBC
    {
        public void Insert(DataTable dt)
        {

            foreach (DataRow dr in dt.Rows)
            {


                EmpleadoMigrado oempladomigrado = new EmpleadoMigrado();

                oempladomigrado.Legajo = (int)dr[0]; // se castea (int) por que el dr devuevle un objeto.
                                            // Dr[0] dice de la fila esa, traeme la primera columna.
                                            // Ese objeto devolvemelo como numero
                                            // Tambien se puede poner el nombre en vez de [0]

                oempladomigrado.Cuil = dr[1].ToString();
                oempladomigrado.Nombre = (string)dr[2]; // O to string()
                oempladomigrado.Apellido = (string)dr[3];
                oempladomigrado.Sexo = (string)dr[4];
                oempladomigrado.FechaNac = (DateTime)dr[5];



                EmpleadoMigradoDAC oEmpleadoMigradoDAC = new EmpleadoMigradoDAC();
                oEmpleadoMigradoDAC.Insert(oempladomigrado);

                Empleado oEmpleado = new Empleado();
                oEmpleado.Legajo = oempladomigrado.Legajo;

                EmpleadoDAC oEmpleadoDAC = new EmpleadoDAC();
                oEmpleadoDAC.UpdateEstado(oEmpleado);
            }


        }
    }
}
