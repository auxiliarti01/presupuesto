using CargaPresupuesto.Datos;
using CargaPresupuesto.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;
using System.Globalization;
using System.Data.SqlClient;


namespace CargaPresupuesto.Vista
{
    public partial class frmPresupuesto : Form
    {
        public frmPresupuesto()
        {
            InitializeComponent();
        }


        private void frmPresupuesto_Load(object sender, EventArgs e)
        {
            btnModificar.Visible = false;
            llenarcombo();
            llenarcombocargaranios();
            llenarcombomeses();

            lblUsuario.Text = Environment.UserName;
            // dgvPresupuesto.Columns["PRESUPUESTO"].DefaultCellStyle.Format = "C";
            // cargaranio();
            //MessageBox.Show("Prueba de  Git");
           
        }


        private void btnInsertar_Click(object sender, EventArgs e)
        {
            insertarcargapresupuesto();
            //insertarpresupuesto();
            
            //BuscarporDistrito();
        }

        private void insertarcargapresupuesto()
        {
            
            try
            {
                CADPresupuesto funcion = new CADPresupuesto();
                DataTable dt;
                DataColumn column;
                DataRow row;

                dt = new DataTable();
                column = new DataColumn();
                column.DataType = Type.GetType("System.Int32");
                column.ColumnName = "ID";
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = Type.GetType("System.Int32");
                column.ColumnName = "ANO";
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = Type.GetType("System.Int32");
                column.ColumnName = "MES";
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = "VENDEDOR_CODIGO";
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = Type.GetType("System.Int32");
                column.ColumnName = "PRESUPUESTO";
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = Type.GetType("System.DateTime");
                column.ColumnName = "FECHA_CREA";
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = Type.GetType("System.DateTime");
                column.ColumnName = "FECHA_MODIFICA";
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = "USUARIO_CREACION";
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = "USUARIO_MOFICACION";
                dt.Columns.Add(column);

                foreach (DataGridViewRow data in dgvPresupuesto.Rows)
                {
                    row = dt.NewRow();
                    row["ID"] = data.Cells["ID"].Value;
                    row["ANO"] = data.Cells["AÑO"].Value;
                    row["MES"] = data.Cells["MES"].Value;
                    row["VENDEDOR_CODIGO"] = data.Cells["CODIGO VENDEDOR"].Value;
                    row["PRESUPUESTO"] = data.Cells["PRESUPUESTO"].Value;
                    row["FECHA_CREA"] = data.Cells["FECHA CREACION"].Value;
                    row["FECHA_MODIFICA"] = DateTime.Now;
                    row["USUARIO_CREACION"] = data.Cells["USUARIO CREACION"].Value;
                    row["USUARIO_MOFICACION"] = lblUsuario.Text;
                    dt.Rows.Add(row);
                    
                }
               int mes =int.Parse(cmbMes.Text);
               //int ano=int.Parse(cmbAnio.Text);
                if (funcion.Insertar2(dt, mes))
                {
                    MessageBox.Show("PRESUPUESTO INGRESADO CORRECTAMENTE", "PRESUPUESTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("no es posible");
                }

                // 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                
            }
        }

        /*private void insertarpresupuesto()
        {
            CADPresupuesto funcion = new CADPresupuesto();
            try
            {
                DateTime fecha = DateTime.Now;
                string usuario = Environment.UserName;

                foreach (DataGridViewRow row in dgvPresupuesto.Rows)
                 {

                    
                    
                    CADMestra.Abrir();
                    SqlCommand cmd = new SqlCommand("spInsertar_Presupuesto", CADMestra.conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(row.Cells["ID"].Value));
                    cmd.Parameters.AddWithValue("@ANIO", Convert.ToInt32(row.Cells["AÑO"].Value));
                    cmd.Parameters.AddWithValue("@MES", Convert.ToInt32(row.Cells["MES"].Value));
                    cmd.Parameters.AddWithValue("@VENDEDOR_CODIGO", Convert.ToString(row.Cells["CODIGO VENDEDOR"].Value));
                    cmd.Parameters.AddWithValue("@PRESUPUESTO", Convert.ToInt32(row.Cells["PRESUPUESTO"].Value));
                    //cmd.Parameters.AddWithValue("@FECHA_CREA", Convert.ToDateTime(row.Cells["FECHA CREACION"].Value));
                    cmd.Parameters.AddWithValue("@USUARIO_CREACION", usuario);
                    cmd.Parameters.AddWithValue("@USUARIO_MODIFICACION", usuario);
                    cmd.ExecuteNonQuery();


                    //DateTime fecha = DateTime.Now;
                    // string usuario = Environment.UserName;
                    // lPresupuesto presupuesto = new lPresupuesto();

                    // presupuesto.FechaCreacion = fecha;
                    // presupuesto.UsuarioCreacion = usuario;
                    // presupuesto.CodigoVendedor = Convert.ToString(row.Cells["CODIGO VENDEDOR"].Value);
                    // presupuesto.Ano = Convert.ToInt32(row.Cells["AÑO"].Value);
                    // presupuesto.Mes = Convert.ToInt32(row.Cells["MES"].Value);
                    // presupuesto.Presupuesto =Convert.ToInt32(row.Cells["PRESUPUESTO"].Value);
                    // fecha = Convert.ToDateTime(row.Cells["FECHA CREACION"].Value);
                    // usuario =Convert.ToString(row.Cells["USUARIO CREACION"].Value);

                    // funcion.Insertar(presupuesto);

                 }


                //int index = 0;
                //DateTime fecha = DateTime.Now;
                //string usuario = Environment.UserName;
                //lPresupuesto presupuesto = new lPresupuesto();
                //presupuesto.FechaCreacion = fecha;
                //presupuesto.UsuarioCreacion = usuario;
                //presupuesto.CodigoVendedor = dgvPresupuesto.Rows[index].Cells["CODIGO VENDEDOR"].Value.ToString();
                //presupuesto.Ano = int.Parse(dgvPresupuesto.Rows[index].Cells["AÑO"].Value.ToString());
                //presupuesto.Mes = int.Parse(dgvPresupuesto.Rows[index].Cells["MES"].Value.ToString());
                //presupuesto.Presupuesto = int.Parse(dgvPresupuesto.Rows[index].Cells["PRESUPUESTO"].Value.ToString());
                //fecha = DateTime.Parse(dgvPresupuesto.Rows[index].Cells["FECHA CREACION"].Value.ToString());
                //usuario =dgvPresupuesto.Rows[index].Cells["FECHA CREACION"].Value.ToString();
                //funcion.Insertar(presupuesto);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }*/

        private void mostrarpresupuesto()
        {
            CADPresupuesto funcion = new CADPresupuesto();
            try
            {
                foreach (DataGridViewRow row in dgvPresupuesto.Rows)
                {
                    string usuario = Environment.UserName;
                    lPresupuesto presupuesto = new lPresupuesto();
                    presupuesto.Id = Convert.ToInt32(row.Cells["ID"].Value);
                    //if (row.Cells["ID"].Value.Equals(presupuesto.Id))
                    //{
                    presupuesto.Presupuesto = Convert.ToInt32(row.Cells["PRESUPUESTO"].Value);
                    //presupuesto.FechaModificacion = Convert.ToDateTime(row.Cells["FECHA MODIFICACION"].Value);
                    presupuesto.UsuarioModificacion = usuario;
                    funcion.Modificar(presupuesto);
                    //}

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarPresupuesto()
        {
            DataTable dt = new DataTable();
            CADPresupuesto funcion = new CADPresupuesto();
            dt = funcion.MostrarPresupuesto();
            dgvPresupuesto.DataSource = dt;
            //dgvPresupuesto.DataMember = "pag";

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void BuscarPresupuesto()
        {
            DataTable dt;
            CADPresupuesto funcion = new CADPresupuesto();
            dt = funcion.BuscarPresupuesto(txtBuscar.Text);
            dgvPresupuesto.DataSource = dt;
        }

        private void BuscarporDistrito()
        {
            string usuario = Environment.UserName;
            DateTime fecha = DateTime.Today;
            

            string tex = cmbAnio.Text;
            if (cmbAnio.Text == "- Todos -")
            {
                tex = cmbAnio.ValueMember = "0";
            }
            DataTable dt;
            CADPresupuesto funcion = new CADPresupuesto();
            dt = funcion.BuscarDistrito(cmbDistrito.ValueMember, tex, cmbMes.ValueMember,lblUsuario.Text);
            dgvPresupuesto.DataSource = dt;  
                for (int i = 0; i <= dgvPresupuesto.Columns.Count - 1; i++)
                {

                    dgvPresupuesto.Columns[i].ReadOnly = dgvPresupuesto.Columns[i].Name.Equals("PRESUPUESTO") ? false : true;


                }
           
            /*foreach (DataGridViewRow row in dgvPresupuesto.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["FECHA CREACION"].Value = fecha.ToShortDateString();
                    row.Cells["FECHA MODIFICACION"].Value = fecha.ToShortDateString();
                    row.Cells["USUARIO CREACION"].Value = usuario;
                    row.Cells["USUARIO MODIFICACION"].Value = usuario;

                }
            }*/




            //dgvPresupuesto.Columns[8].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            //dgvPresupuesto.Columns[8].DefaultCellStyle.Format = "C2";


        }
        private void agregarcolumnsvacias()
        {
            
        }
        private void pcbBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                MessageBox.Show("El Campo de Busqueda Esta Vacío", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBuscar.Focus();
            }
            else
            {
                BuscarPresupuesto();
                //MostrarPresupuesto();
            }

            //BuscarPresupuesto();
        }

        private void cmbDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbDistrito.Text)
            {

                case "CENTRO":
                    cmbDistrito.ValueMember = "CENTRO";
                    break;
                case "NORTE":
                    cmbDistrito.ValueMember = "NORTE";
                    break;
                case "SUR":
                    cmbDistrito.ValueMember = "SUR";
                    break;
                case "NORORIENTE":
                    cmbDistrito.ValueMember = "NORORIENTE";
                    break;
                default:
                    cmbDistrito.ValueMember = "0";
                    break;
            }
        }


        private void llenarcombo()
        {

            this.cmbDistrito.SelectedItem = "- Todos -";
            cmbDistrito.ValueMember = "0";
            this.cmbDistrito.Text = "- Todos -";

            this.cmbDistrito.Items.Add("- Todos -");
            this.cmbDistrito.Items.Add("CENTRO");
            this.cmbDistrito.Items.Add("NORTE");
            this.cmbDistrito.Items.Add("NORORIENTE");
            this.cmbDistrito.Items.Add("SUR");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void btnmaxi_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;

            }
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarporDistrito();

        }

        private void llenarcombocargaranios()
        {
            try
            {
                DateTime dato = DateTime.Now;
                int anio = int.Parse(dato.ToString("yyyy"));
                cmbAnio.ValueMember = "0";
                cmbAnio.SelectedItem = "- Todos -";
                cmbAnio.Text = "- Todos -";
                cmbAnio.Items.Add("- Todos -");
                for (int i = 2018; i <= anio; i++)
                {

                    cmbAnio.Items.Add(i);
                }
                if (cmbAnio.Text == "- Todos -")
                {
                    cmbAnio.ValueMember = "0";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void llenarcombomeses()
        {
            cmbMes.SelectedItem = "- Todos-";
            cmbMes.ValueMember = "0";
            cmbMes.Text = "- Todos -";

            cmbMes.Items.Add("- Todos -");
            cmbMes.Items.Add("1");
            cmbMes.Items.Add("2");
            cmbMes.Items.Add("3");
            cmbMes.Items.Add("4");
            cmbMes.Items.Add("5");
            cmbMes.Items.Add("6");
            cmbMes.Items.Add("7");
            cmbMes.Items.Add("8");
            cmbMes.Items.Add("9");
            cmbMes.Items.Add("10");
            cmbMes.Items.Add("11");
            cmbMes.Items.Add("12");

        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbMes.Text)
            {
                case "12":
                    cmbMes.ValueMember = "12";
                    break;
                case "11":
                    cmbMes.ValueMember = "11";
                    break;
                case "10":
                    cmbMes.ValueMember = "10";
                    break;
                case "9":
                    cmbMes.ValueMember = "9";
                    break;
                case "8":
                    cmbMes.ValueMember = "8";
                    break;
                case "7":
                    cmbMes.ValueMember = "7";
                    break;
                case "6":
                    cmbMes.ValueMember = "6";
                    break;
                case "5":
                    cmbMes.ValueMember = "5";
                    break;
                case "4":
                    cmbMes.ValueMember = "4";
                    break;
                case "3":
                    cmbMes.ValueMember = "3";
                    break;
                case "2":
                    cmbMes.ValueMember = "2";
                    break;
                case "1":
                    cmbMes.ValueMember = "1";
                    break;
                default:
                    cmbMes.ValueMember = "0";
                    break;

            }

        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tex = cmbAnio.Text;
        }

        private void deshabilitarcolumnas()
        {


            //dgvPresupuesto.Columns["CODIGO VENDEDOR"].ReadOnly = true;
            //this.dgvPresupuesto.Columns[0].ReadOnly = false;
            //dgvPresupuesto.SelectedColumns[0].ReadOnly = false;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            mostrarpresupuesto();
            MessageBox.Show("PRESUPUESTO MODIFICADO CORRECTAMENTE", "MODIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //BuscarporDistrito();
        }

        private void dgvPresupuesto_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvPresupuesto.Columns[8].DefaultCellStyle.Format = "#.###";
        }

        private void dgvPresupuesto_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            dgvPresupuesto.Columns[8].DefaultCellStyle.Format = "#.###";
            if (e.Control is TextBox)
            {
                TextBox txt = e.Control as TextBox;
                if (object.ReferenceEquals(dgvPresupuesto.CurrentCell.ValueType, typeof(System.Int32)))
                {
                    txt.KeyPress += OnlyNumbers_keyPress;
                }
                else
                {
                    txt.KeyPress -= OnlyNumbers_keyPress;
                    ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Normal;
                }
            }
        }

        private void OnlyNumbers_keyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {

                e.Handled = true;

                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void dgvPresupuesto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvPresupuesto.Columns[e.ColumnIndex].Name == "PRESUPUESTO")
            {
                dgvPresupuesto.Columns[8].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("es-CO");
                dgvPresupuesto.Columns[8].DefaultCellStyle.Format = "C0";
            }

        }

        private void dgvPresupuesto_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //string usuario = Environment.UserName;
            //DateTime fecha = DateTime.Now;
            //e.Row.Cells["FECHA_CREA"].Value = fecha;
        }

        private void dgvPresupuesto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCambioPresupuesto frmCambio = new frmCambioPresupuesto();
            frmCambio.txtCodigo.Text = dgvPresupuesto.SelectedCells[1].Value.ToString();
            
            frmCambio.ShowDialog();
        }
    }
}
