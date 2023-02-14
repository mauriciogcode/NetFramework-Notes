using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplo_3_Capas_Consola.Negocio;

namespace Ejemplo_3_Capas_Consola.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoadData();
            //Si da error es por que no es static

        }


        private static void LoadData()
        {
            EjemploBC ejemploBC = new EjemploBC();
            DataTable dt = ejemploBC.GetAll();

            foreach (DataRow oRow in dt.Rows)
            {
                Console.WriteLine(oRow["Nombre"]);
            }

            Console.ReadLine();

        }
    }
}
