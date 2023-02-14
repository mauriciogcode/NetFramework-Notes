using EjemploNCapas.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploNCapas
{
    public partial class frmNombreDeLaTabla : Form
    {
        public frmNombreDeLaTabla()
        {
            InitializeComponent();
        }

        private void frmNombreDeLaTabla_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DACComponenteDeAccesoDatos oDACComponenteDeAcceso = new DACComponenteDeAccesoDatos();
            DataTable dt = oDACComponenteDeAcceso.GetAll();

            dgv.DataSource = null;
            dgv.DataSource = dt;
        }
    }
}
