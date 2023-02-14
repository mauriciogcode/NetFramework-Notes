using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplo_3_Capas_Consola.Datos;

namespace Ejemplo_3_Capas_Consola.Negocio
{
    //class EjemploBC
    public class EjemploBC
    {
        public DataTable GetAll()
        {
            EjemploDAC oEjemploDAC = new EjemploDAC();
            DataTable dt = oEjemploDAC.GetAll();
           return dt;
        }
    }
}
