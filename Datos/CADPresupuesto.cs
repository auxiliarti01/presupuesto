using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CargaPresupuesto.Logica;
using System.Windows.Forms;
using System.Data;

namespace CargaPresupuesto.Datos
{
    class CADPresupuesto
    {
        public void Insertar(lPresupuesto presupuesto)
        {
            try
            {

                CADMestra.Abrir();
                SqlCommand cmd = new SqlCommand("spInsertar_Presupuesto", CADMestra.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ANIO", presupuesto.Ano);
                cmd.Parameters.AddWithValue("@MES", presupuesto.Mes);
                cmd.Parameters.AddWithValue("@VENDEDOR_CODIGO", presupuesto.CodigoVendedor);
                cmd.Parameters.AddWithValue("@PRESUPUESTO", presupuesto.Presupuesto);
                cmd.Parameters.AddWithValue("@FECHA_CREA", presupuesto.FechaCreacion);
                cmd.Parameters.AddWithValue("@USUARIO_CREACION", presupuesto.UsuarioCreacion);
                cmd.ExecuteNonQuery();
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //return false;
            }
            finally
            {
                CADMestra.Cerrar();
            }
        }
        public bool Insertar2(DataTable dt,int mes)
        {
            try
            {
               
                CADMestra.Abrir();
                SqlCommand cmd = new SqlCommand("spInsertar_Presupuesto", CADMestra.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TABLA_PRESUPUESTO", dt);
                cmd.Parameters.AddWithValue("@MES",mes);
                //cmd.Parameters.AddWithValue("@ANO", ano);
                if(cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
               
            }
            finally
            {
                CADMestra.Cerrar();
            }
        }
        public void Modificar(lPresupuesto presupuesto)
        {
            try
            {
                CADMestra.Abrir();
                SqlCommand cmd = new SqlCommand("spModificar_Presupuesto",CADMestra.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", presupuesto.Id);
                cmd.Parameters.AddWithValue("@PRESUPUESTO", presupuesto.Presupuesto);
                cmd.Parameters.AddWithValue("@USUARIO_MODIFICACION", presupuesto.UsuarioModificacion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                CADMestra.Cerrar();
            }
        }

        

        public DataTable MostrarPresupuesto()
        {
            try
            {

                CADMestra.Abrir();
                SqlCommand cmd = new SqlCommand("spMostrar_presupuestos", CADMestra.conexion);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter data = new SqlDataAdapter(cmd);
                    data.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                CADMestra.Cerrar();
            }
        }
        public DataTable BuscarPresupuesto(string letra)
        {
            try
            {
                CADMestra.Abrir();
                SqlCommand cmd = new SqlCommand("spBuscar_presupuesto", CADMestra.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LETRA", letra);
                if(cmd.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter data = new SqlDataAdapter(cmd);
                    data.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
                
            }
            finally
            {
                CADMestra.Cerrar();
            }
        }

        //public DataTable LlenarCombo()
        //{
        //    try
        //    {
        //        CADMestra.Abrir();
        //        SqlCommand cmd = new SqlCommand("SELECT DISTINCT EMPRESA_CODIGO,VENDEDOR_REGION " +
        //            "FROM VENDEDORES " +
        //            "WHERE VENDEDOR_REGION IN('CENTRO','NORORIENTE','NORTE','SUR')", CADMestra.conexion);
        //        if (cmd.ExecuteNonQuery() != 0)
        //        {
        //            DataTable dt = new DataTable();
        //            SqlDataAdapter data = new SqlDataAdapter(cmd);
        //            data.Fill(dt);
        //            return dt;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }
        //    finally
        //    {
        //        CADMestra.Cerrar();
        //    }
            
        //}

        public DataTable BuscarDistrito(string distrito,string anio,string mes,string usuario)
        {
            try
            {
                CADMestra.Abrir();
                SqlCommand cmd = new SqlCommand("spBuscar_presupuesto_cmb", CADMestra.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DISTRITO", distrito);
                cmd.Parameters.AddWithValue("@ANIO", anio);
                cmd.Parameters.AddWithValue("@MES", mes);
                cmd.Parameters.AddWithValue("@USUARIO", usuario);
                if(cmd.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter data = new SqlDataAdapter(cmd);
                    data.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
                
            }
            finally
            {
                CADMestra.Cerrar();
            }
        }

        public DataTable MostrarAnio()
        {
            try
            {
                CADMestra.Abrir();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT ANO FROM VENDEDORES_PRESUPUESTO", CADMestra.conexion);
                if(cmd.ExecuteNonQuery() != 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter data = new SqlDataAdapter(cmd);
                    data.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;

            }
            finally
            {
                CADMestra.Cerrar();
            }
        }

        public bool ModificarPresupuesto2(lPresupuesto lpresupuesto)
        {
            try
            {
                CADMestra.Abrir();
                SqlCommand cmd = new SqlCommand("spModificarPresupuesto2", CADMestra.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CODIGO", lpresupuesto.CodigoVendedor);
                cmd.Parameters.AddWithValue("@ANIO", lpresupuesto.Ano);
                cmd.Parameters.AddWithValue("@MES", lpresupuesto.Mes);
                cmd.Parameters.AddWithValue("@PRESUPUESTO", lpresupuesto.Presupuesto);
                if(cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CADMestra.Cerrar();
            }

        }
    }
}
