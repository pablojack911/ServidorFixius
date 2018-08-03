using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Locacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    public class ClienteBusqueda : DTOMaestro
    {
        [DataMember]
        private string razonSocial;
        [IncluirEnBuscador]
        public string RazonSocial
        {
            get { return razonSocial; }
            set
            {
                razonSocial = value;
                this.OnPropertyChanged("RazonSocial");
            }
        }

        [DataMember]
        [IncluirEnBuscador]
        public String Apellido { get; set; }
        [DataMember]
        [IncluirEnBuscador]
        public Domicilio Domicilio { get; set; }//ok

        [DataMember]
        private string cuit;
        [IncluirEnBuscador]
        public string Cuit
        {
            get { return cuit; }
            set
            {
                cuit = value;
                this.OnPropertyChanged("Cuit");
                this.OnPropertyChanged("CondicionAnteIva");
                this.OnPropertyChanged("PorcentajePercepcionManual");
            }
        }
        [DataMember]
        private string numeroDocumentoCliente;
        [IncluirEnBuscador]
        public string NumeroDocumentoCliente
        {
            get { return numeroDocumentoCliente; }
            set
            {
                numeroDocumentoCliente = value;
                this.OnPropertyChanged("NumeroDocumentoCliente");
                this.OnPropertyChanged("CondicionAnteIva");
            }
        }
        [DataMember]
        [IncluirEnBuscador]
        public String NombreFantasia { get; set; }

        //[DataMember]
        //private string codigoDeTarjeta;
        //[IncluirEnBuscador]
        //public string CodigoDeTarjeta
        //{
        //    get { return codigoDeTarjeta; }
        //    set { codigoDeTarjeta = value; }
        //}

    }
}
