using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaPresupuesto.Logica
{
    class lPresupuesto
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public string CodigoVendedor { get; set; }
        public int Presupuesto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string distrito { get;set; }
        public string UsuarioCreacion { get; set; }

        public string UsuarioModificacion { get; set; }

        public lPresupuesto()
        {

        }
        
        public lPresupuesto(int id,int ano,int mes,string codigo_vendedor,int presupuesto,DateTime fechacreacion,DateTime fechamodificacion,string usuariocreacion,string usuariomodificacion)
        {
            this.Id = id;
            this.Ano = ano;
            this.Mes = mes;
            this.CodigoVendedor = codigo_vendedor;
            this.Presupuesto = presupuesto;
            this.FechaCreacion = fechacreacion;
            this.FechaModificacion = fechamodificacion;
            this.UsuarioCreacion = usuariocreacion;
            this.UsuarioModificacion = usuariomodificacion;
        }

    }
}
