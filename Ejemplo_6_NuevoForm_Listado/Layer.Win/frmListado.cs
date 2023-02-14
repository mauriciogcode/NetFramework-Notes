using Layer.BC;
using Layer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win
{
    public partial class frmListado : Form
    {
        public frmListado()
        {
            InitializeComponent();
        }

        private void frmListado_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void CargarCombos()
        {
            try
            {

                ExampleTypeBC oTipoEjemplo = new ExampleTypeBC();
                DataTable dt = oTipoEjemplo.GetAll();


                DataRow dtr = dt.NewRow(); // Todo esto es para que aparezca un campo vacio por defecto en el combo box
                dtr["Nombre"] = "";  // Todo esto es para que aparezca un campo vacio por defecto  en el combo box
                dt.Rows.InsertAt(dtr, 0);  // Todo esto es para que aparezca un campo vacio por defecto  en el combo box

                cboTipoEjemplo.DataSource = dt;
                cboTipoEjemplo.DisplayMember = "Nombre";
                cboTipoEjemplo.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                ExampleBE oexampleBE = new ExampleBE();

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    oexampleBE.Id = null; // se cambio el modelo con ? en el tipo de dato
                } else
                {

                oexampleBE.Id = int.Parse(txtId.Text);
                }


                if (string.IsNullOrEmpty(cboTipoEjemplo.SelectedValue.ToString()))
                {
                    oexampleBE.ExampleType = null; // se cambio el modelo con ? en el tipo de dato
                }
                else
                {
                oexampleBE.ExampleType = (int)cboTipoEjemplo.SelectedValue; // int.Parse(cboTipoEjemplo.SelectedValue.ToString());

                }


                ExampleBC oEjemploBC = new ExampleBC();
                DataTable dt = oEjemploBC.GetParam(oexampleBE);


             

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
