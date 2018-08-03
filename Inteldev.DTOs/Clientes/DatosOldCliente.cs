using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Fixius.Servicios.DTO.Logistica;
using Inteldev.Fixius.Servicios.DTO.Precios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    public class DatosOldCliente : DTOBase
    {
        [DataMember]
        public string CodigoAnterior { get; set; }
        [DataMember]
        private string domicilio;

        public string Domicilio
        {
            get { return domicilio; }
            set
            {
                domicilio = value;
                this.OnPropertyChanged("Domicilio");
            }
        }

        [DataMember]
        public bool AplicaDescRango { get; set; }
        [DataMember]
        public bool PreventaSalon { get; set; }
        [DataMember]
        public bool Temporal { get; set; }
        [DataMember]
        public bool Potencial { get; set; }
        [DataMember]
        public bool EsProveedor { get; set; }
        [DataMember]
        public bool NoVisitar { get; set; }
        [DataMember]
        public bool ControlaCheques { get; set; }
        [DataMember]
        public string CodigoCIA { get; set; }
        [DataMember]
        public string SucursalCIA { get; set; }
        [DataMember]
        public string CodigoCDA { get; set; }
        [DataMember]
        public bool VendeAlcohol { get; set; }
        [DataMember]
        public bool TodosLosArticulo { get; set; }
        [DataMember]
        public bool NoRelacionarLogistica { get; set; }
        [DataMember]
        public bool NoTomarRecargoLogistica { get; set; }
        [DataMember]
        public ListaDePreciosDeVenta ListaDePreciosDeVenta { get; set; }
        [DataMember]
        public int? ListaDePrecioId { get; set; }
        [DataMember]
        public RutaDeVenta RutaDeVenta { get; set; }
        [DataMember]
        public int? RutaDeVentaId { get; set; }
        [DataMember]
        public bool PermiteVentaEnDiferentesEmpresas { get; set; }
        [DataMember]
        public bool CortaTicketPorImporte { get; set; }
        [DataMember]
        public bool PermitePagoConCheques { get; set; }
        [DataMember]
        public bool RequiereTarjetaEncargado { get; set; }
        [DataMember]
        public bool NoInformaDatosEnTicket { get; set; }
        [DataMember]
        public Empresa Empresa { get; set; }

        //[DataMember]
        //public int? ZonaGeograficaId { get; set; }
        //[DataMember]
        //private ZonaGeografica zonaGeografica;

        //public ZonaGeografica ZonaGeografica
        //{
        //    get { return zonaGeografica; }
        //    set
        //    {
        //        zonaGeografica = value;
        //        this.OnPropertyChanged("ZonaGeografica");
        //    }
        //}

        [DataMember]

        private string domicilioDeEntrega;

        public string DomicilioDeEntrega
        {
            get { return domicilioDeEntrega; }
            set
            {
                domicilioDeEntrega = value;
                this.OnPropertyChanged("DomicilioDeEntrega");
            }
        }



    }
}
