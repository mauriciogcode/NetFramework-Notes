using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCapas.Negocio;

namespace NCapas.Win
{
    public partial class frmEjemploList : Form
    {
        public frmEjemploList()
        {
            InitializeComponent();
        }

        private void frmEjemploList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                //EjemploDAC oEjemploDAC = new EjemploDAC();
                //DataTable dt = oEjemploDAC.GetAll();

                EjemploBC oEjemploBC = new EjemploBC();
                DataTable dt = oEjemploBC.GetAll();

                dgv.DataSource = null;
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
