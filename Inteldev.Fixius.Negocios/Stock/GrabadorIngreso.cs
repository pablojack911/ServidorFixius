using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Stock
{
    public class GrabadorIngreso : GrabadorDTO<Modelo.Stock.Ingreso, Servicios.DTO.Stock.Ingreso>
    {
        public GrabadorIngreso(IGrabador<Ingreso> grabadorEntidad, IMapeadorGenerico<Modelo.Stock.Ingreso, Servicios.DTO.Stock.Ingreso> mapeador)
            : base(grabadorEntidad, mapeador)
        {

        }
        public override Core.DTO.Carriers.GrabadorCarrier Grabar(Servicios.DTO.Stock.Ingreso dto, Core.DTO.Usuarios.Usuario Usuario)
        {
            //fijarse si esta confirmada o no. 
            //si esta confirmada generar movimiento de stock
            //sino graba normalemnte
            //esta confirmado, creo movimiento stock
            //if (dto.Confirmado)
            //{
            //    //el ingreso es nuevo
            //    var creadorRecibo = FabricaNegocios._Resolver<ICreadorDTO<Modelo.Stock.ReciboStock, Servicios.DTO.Stock.ReciboStock>>();
            //    var grabadorRecibo = FabricaNegocios._Resolver<IGrabadorDTO<Modelo.Stock.ReciboStock, Servicios.DTO.Stock.ReciboStock>>();
            //    var buscadorArticulo = FabricaNegocios._Resolver<IBuscadorDTO<Inteldev.Fixius.Modelo.Articulos.Articulo, Inteldev.Fixius.Servicios.DTO.Articulos.Articulo>>();
            //    if (dto.Id == 0)
            //    {
            //        var creadorMovimiento = FabricaNegocios._Resolver<ICreadorDTO<Modelo.Stock.Movimiento, Servicios.DTO.Stock.Movimiento>>();
            //        var grabadorMovimiento = FabricaNegocios._Resolver<IGrabadorDTO<Modelo.Stock.Movimiento, Servicios.DTO.Stock.Movimiento>>();
            //        var buscadorNumero = FabricaNegocios._Resolver<IBuscadorDTO<Inteldev.Core.Modelo.Numerador, Inteldev.Core.DTO.Numerador>>();
            //        var reciboStock = creadorRecibo.Crear().GetEntidad();
            //        reciboStock.OrdenesDeCompra = dto.OrdenesDeCompra;
            //        //reciboStock.Sucursal = dto.Sucursal;
            //        reciboStock.IngresoId = dto.Id;
            //        var numero = buscadorNumero.BuscarLista(dto.SucursalId, Core.CargarRelaciones.NoCargarNada).Where(p => p.TipoDocumento == Core.DTO.Documentos.ReciboStock).FirstOrDefault();
            //        if (numero != null)
            //        {
            //            reciboStock.Numero = numero.Numero + 1;
            //        }
            //        else
            //            reciboStock.Numero = 0;
            //        var movimiento = creadorMovimiento.Crear().GetEntidad();
            //        movimiento.Deposito = dto.Deposito;
            //        foreach (DataRow item in dto.Items.Rows)
            //        {
            //            string corArt = (string)item["Articulo"];
            //            int bultos = (int)item["Bultos"];
            //            var row = movimiento.DetalleMovimiento.NewRow();
            //            row["Articulo"] = corArt;
            //            row["Cantidad"] = bultos;
            //            movimiento.DetalleMovimiento.Rows.Add(row);
            //        }
            //        reciboStock.MovimientoStock = movimiento;
            //        //grabadorMovimiento.Grabar(movimiento,Usuario);
            //        grabadorRecibo.Grabar(reciboStock, Usuario);
            //        //aca tengo que revisar las facturas
            //        var buscadorFacturas = FabricaNegocios._Resolver<IBuscadorFactura>();
            //        foreach (var factura in dto.Facturas)
            //        {
            //            var fact = buscadorFacturas.BuscaFactura(factura.Proveedor.Id, factura.Prenumero, factura.Numero);
            //            if (fact != null)
            //            {
            //                //se cago todo. Cargar un grabador carrier y mandar todo al carajo jaja
            //                GrabadorCarrier grabadorCarrier = new GrabadorCarrier();
            //                grabadorCarrier.setError(true);
            //                grabadorCarrier.setMensaje("Facturas Duplicadas");
            //                return grabadorCarrier;
            //            }
            //        }
            //    }
            //    //esta editando ingreso
            //    else
            //    {
            //        var buscadorRecibo = FabricaNegocios._Resolver<IBuscadorRecibo>();
            //        Inteldev.Fixius.Modelo.Stock.ReciboStock recibo = buscadorRecibo.BuscaReciboIngreso(dto.Id);
            //        var grabadorMovimiento = FabricaNegocios._Resolver<IGrabador<Inteldev.Fixius.Modelo.Stock.Movimiento>>();
            //        var mapeadorUsuario = FabricaNegocios._Resolver<IMapeadorGenerico<Inteldev.Core.Modelo.Usuarios.Usuario, Inteldev.Core.DTO.Usuarios.Usuario>>();
            //        foreach (DataRow item in dto.Items.Rows)
            //        {
            //            if (item.RowState != DataRowState.Unchanged && item.RowState != DataRowState.Detached)
            //            {
            //                var codArt = (string)item["Articulo"];
            //                var movimiento = recibo.MovimientoStock;
            //                DetalleMovimiento detalleMovimiento = movimiento.DetalleMovimiento.FirstOrDefault(p => p.Articulo.Codigo == codArt);
            //                detalleMovimiento.Cantidad = (int)item["Bultos"];
            //                grabadorMovimiento.Grabar(movimiento, mapeadorUsuario.DtoToEntidad(Usuario));
            //            }
            //        }
            //    }
            //}
            return base.Grabar(dto, Usuario);
        }
    }
}
