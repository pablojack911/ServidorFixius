using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
	public class MercaderiaNoIngesada
	{
       public Articulo Articulo {get;set;}
       [ForeignKey("Articulo")]
       public int ArticuloId {get;set;}
       public int Cantidad {get;set;}
       public Motivo Motivo {get;set;}
       [ForeignKey("MotivoId")]
       public int MotivoId {get;set;}
	}
}
