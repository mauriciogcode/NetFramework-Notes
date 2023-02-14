using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migracion.Entidades
{
    public class EmpleadoMigrado
    {
        public int Id { get; set; }

        public int Legajo { get; set; }

        public string Cuil { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Sexo { get; set; }
        public DateTime FechaNac { get; set; }



    }
}
