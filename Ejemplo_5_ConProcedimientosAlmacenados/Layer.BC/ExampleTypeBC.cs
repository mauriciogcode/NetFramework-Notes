using Layer.DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.BC
{
    public class ExampleTypeBC
    {
        public DataTable GetAll()
        {
            ExampleTypeDAC oTipoejemploDAC = new ExampleTypeDAC();
            return oTipoejemploDAC.GetAll();
        }
    }
}
