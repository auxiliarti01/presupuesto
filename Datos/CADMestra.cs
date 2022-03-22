using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CargaPresupuesto.Datos
{
    internal static class CADMestra
    {
        public static SqlConnection conexion = new SqlConnection(@"Data Source=ECARBD;Initial Catalog=ADATEC;Integrated Security=false; UID=gestion_movilidad;Password=M0v1l.3Car%");

        public static void Abrir()
        {
            if(conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }

        }
        public static void Cerrar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
