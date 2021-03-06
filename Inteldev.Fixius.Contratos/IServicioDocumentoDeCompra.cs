﻿using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Inteldev.Fixius.Contratos
{
    [ServiceContract]
    public interface IServicioDocumentoDeCompra
    {
        [OperationContract]
        DocumentoCompra BuscarOCrearDocumentoDeCompra(string empresa, string sucursal, int provId, int tipoDoc, string preNro, string nro);
    }
}
