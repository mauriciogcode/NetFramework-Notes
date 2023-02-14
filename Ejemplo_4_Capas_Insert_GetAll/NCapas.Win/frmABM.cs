using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Layer.BC;
using Layer.Entities;

namespace NCapas.Win
{
    public partial class frmABM : Form
    {
        public frmABM()
        {
            InitializeComponent();
        }


        #region Propiedades

        int estadoABM = 0;

        #endregion


        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            habilitarOpciones(true);
            limpiarControles();

            Listar();
            CargarCombos();


        }

        private void tsbAlta_Click(object sender, EventArgs e)
        {
            estadoABM = (int)Definiciones.estadoABN.Alta;
            habilitarOpciones(false);
            habilitarControles(true);
            limpiarControles();
        }

        private void tsbBaja_Click(object sender, EventArgs e)
        {
            estadoABM = (int)Definiciones.estadoABN.Baja;
            habilitarOpciones(false);
            habilitarControles(false);
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            estadoABM = (int)Definiciones.estadoABN.Modificacion;
            habilitarOpciones(false);
            habilitarControles(true);
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            habilitarOpciones(true);

            Listar();
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            habilitarOpciones(true);

            switch (estadoABM)
            {
                case 1:
                    Alta();
                    break;
                case 2:
                    Baja();
                    break;
                case 3:
                    Modificacion();
                    break;

            }


            Listar();

        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            txtId.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            cboTipo.SelectedValue = dgv.CurrentRow.Cells[4].Value.ToString(); // trae los datos del value al cbo box sino traeria los id
        }

        #endregion


        #region Metodos

        private void habilitarOpciones(bool est)
        {

            tsbAlta.Enabled = est;
            tsbBaja.Enabled = est;

            tsbModificar.Enabled = est;
            tsbCancelar.Enabled = !est;
            tsbGuardar.Enabled = !est;

            grbListado.Enabled = est;
            grbDatos.Enabled = !est;

        }

        private void habilitarControles(bool est)
        {
            txtId.ReadOnly = true;
            txtNombre.ReadOnly = !est;
            txtDescripcion.ReadOnly = !est;
        }

        private void limpiarControles()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void Listar()
        {

            try
            {

                ExampleBC oexampleBC = new ExampleBC();
                DataTable dt = oexampleBC.GetAll();
                dgv.DataSource = null;
                dgv.DataSource = dt;
            } catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void Alta()
        {

            try
            {

                ExampleBE oexampleBE = new ExampleBE();
                oexampleBE.Name = txtNombre.Text;
                oexampleBE.Description = txtDescripcion.Text;
                oexampleBE.ExampleType = (int)cboTipo.SelectedValue;



                ExampleBC oexampleBC = new ExampleBC();
                var res = oexampleBC.Insert(oexampleBE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Baja()
        {
            try
            {

                ExampleBE oexampleBE = new ExampleBE();
                oexampleBE.Id = int.Parse(txtId.Text);



                ExampleBC oexampleBC = new ExampleBC();
                var res = oexampleBC.Delete(oexampleBE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void Modificacion()
        {

            try
            {

                ExampleBE oexampleBE = new ExampleBE();
                oexampleBE.Id = int.Parse(txtId.Text);
                oexampleBE.Name = txtNombre.Text;
                oexampleBE.Description = txtDescripcion.Text;
                oexampleBE.ExampleType = (int)cboTipo.SelectedValue;


                ExampleBC oexampleBC = new ExampleBC();
                var res = oexampleBC.Update(oexampleBE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void CargarCombos()
        {
            try
            {

                ExampleTypeBC oTipoEjemplo = new ExampleTypeBC();
                DataTable dt = oTipoEjemplo.GetAll();

                cboTipo.DataSource = dt;
                cboTipo.DisplayMember = "Nombre";
                cboTipo.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion


    }
}
