using Migracion.BC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migracion.WIN
{
    public partial class frmWindowsForm : Form
    {

        DataTable dt = new DataTable();//dt global

        public frmWindowsForm()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EmpleadoBC oEmpleadoBC = new EmpleadoBC();
            dt = oEmpleadoBC.GetAll();
            dgv.DataSource = null;
            dgv.DataSource = dt;

            // Voy a hacer un dt global para no recorrer la grilla. por eso se puede hacer en la parte de arriba
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EmpleadoMigradoBC oEmpleadoMigradoBC = new EmpleadoMigradoBC();
            oEmpleadoMigradoBC.Insert(dt);

            dgv.DataSource = null;
        }
    }
}
