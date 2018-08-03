using Inteldev.Core.DTO;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
	public class NotaDeDebitoDeVenta : Documento
	{
		[DataMember]
		public Articulo Articulo { get; set; }
		[DataMember]

		public int? ArticuloId { get; set; }
		[DataMember]
		public int Cantidad { get; set; }
		[DataMember]
		public decimal Costo { get; set; }
		[DataMember]
		public int Numero { get; set; }
		[DataMember]
		public int PreNumero { get; set; }
	}
}
