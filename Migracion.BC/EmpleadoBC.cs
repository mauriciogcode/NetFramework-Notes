using Migracion.DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migracion.BC
{
    public class EmpleadoBC
    {
        public DataTable GetAll()
        {
            EmpleadoDAC oEmpleadoDAC = new EmpleadoDAC();
            return oEmpleadoDAC.GetAll();

        }

       

    }
}
