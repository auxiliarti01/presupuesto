using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using CargaPresupuesto.Datos;
using CargaPresupuesto.Logica;

namespace CargaPresupuesto.Vista
{
    public partial class frmCambioPresupuesto : Form
    {
        public frmCambioPresupuesto()
        {
            InitializeComponent();
        }

        private void frmCambioPresupuesto_Load(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("¿ESTAS SEGURO DE ACTUALIZAR PRESUPUESTO?", "PRESUPUESTO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                ModificarPres();
            } 
        }

        private void ModificarPres()
        {
            lPresupuesto presupuesto = new lPresupuesto();
            CADPresupuesto funcion = new CADPresupuesto();

            presupuesto.CodigoVendedor = txtCodigo.Text;
            presupuesto.Ano =int.Parse(txtAnio.Text);
            presupuesto.Mes = int.Parse(txtMes.Text);
            presupuesto.Presupuesto = int.Parse(txtPresupuesto.Text);
            if (funcion.ModificarPresupuesto2(presupuesto))
            {
                MessageBox.Show("PRESUPUESTO MODIFICADO PARA : " + txtNombreUsuario.Text, " MODIFICADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }
        
    }
}
