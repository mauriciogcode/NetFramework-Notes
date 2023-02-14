using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCapas.Datos;

namespace NCapas.Negocio
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
