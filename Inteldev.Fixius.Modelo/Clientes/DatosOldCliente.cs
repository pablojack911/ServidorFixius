using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Fixius.Modelo.Logistica;
using Inteldev.Fixius.Modelo.Precios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Clientes
{
    public class DatosOldCliente : EntidadBase
    {
        public string CodigoAnterior { get; set; }
        public string Domicilio { get; set; }
        public bool AplicaDescRango { get; set; }
        public bool PreventaSalon { get; set; }
        public bool Temporal { get; set; }
        public bool Potencial { get; set; }
        public bool EsProveedor { get; set; }
        public bool NoVisitar { get; set; }
        public bool ControlaCheques { get; set; }
        public string CodigoCIA { get; set; }
        public string SucursalCIA { get; set; }
        public string CodigoCDA { get; set; }
        public bool VendeAlcohol { get; set; }
        public bool TodosLosArticulo { get; set; }
        public bool NoRelacionarLogistica { get; set; }
        public bool NoTomarRecargoLogistica { get; set; }
        //[ForeignKey("ZonaGeografica")]
        //public int? ZonaGeograficaId { get; set; }
        //public ZonaGeografica ZonaGeografica { get; set; }
        public ListaDePreciosDeVenta ListaDePreciosDeVenta { get; set; }
        [ForeignKey("ListaDePreciosDeVenta")]
        public int? ListaDePrecioId { get; set; }
        public RutaDeVenta RutaDeVenta { get; set; }
        [ForeignKey("RutaDeVenta")]
        public int? RutaDeVentaId { get; set; }
        public bool PermiteVentaEnDiferentesEmpresas { get; set; }
        public bool CortaTicketPorImporte { get; set; }
        public bool PermitePagoConCheques { get; set; }
        public bool RequiereTarjetaEncargado { get; set; }
        public bool NoInformaDatosEnTicket { get; set; }
        public string Empresa { get; set; }
        public string DomicilioDeEntrega { get; set; }
    }
}
