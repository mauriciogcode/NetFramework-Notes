using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layer.DAC;
using Layer.Entities;

namespace Layer.BC
{
    public class ExampleBC
    {

        public DataTable GetAll()
        {
            ExampleDAC oejemploDAC = new ExampleDAC();
            return oejemploDAC.GetAll();
        }

        public int Insert(ExampleBE exampleBE)
        {
            ExampleDAC oejemploDAC = new ExampleDAC();
            return oejemploDAC.Insert(exampleBE);


        }

        public int Delete(ExampleBE exampleBE)
        {
            ExampleDAC oejemploDAC = new ExampleDAC();
            return oejemploDAC.Delete(exampleBE);


        }

        public int Update(ExampleBE exampleBE)
        {
            ExampleDAC oejemploDAC = new ExampleDAC();
            return oejemploDAC.Update(exampleBE);


        }

        public DataTable GetId(ExampleBE exampleBE)
        {
            ExampleDAC oejemploDAC = new ExampleDAC();
            return oejemploDAC.GetId(exampleBE);
        }

        public DataTable GetParam(ExampleBE exampleBE)
        {
            ExampleDAC oejemploDAC = new ExampleDAC();
            return oejemploDAC.GetParam(exampleBE);
        }
    }
}
