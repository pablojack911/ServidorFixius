using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Precios
{
    public class CambioDePreciosDeVenta:DTOMaestro 
    {
        [DataMember]
        public DateTime FechaDesde { get; set; }
        [DataMember]
        public DateTime FechaHasta { get; set; }
        [DataMember]
        public TipoCambioDePreciosDeVenta TipoDeCambio { get; set; }
        [DataMember]
        public int Folder { get; set; }
        [DataMember]
        public EstadoCambioDePreciosDeVenta Estado { get; set; }
        [DataMember]
        public DataTable Items { get; set; }
    }
}
