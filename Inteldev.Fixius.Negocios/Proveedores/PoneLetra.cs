using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Fiscal;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores {
	
	public class PoneLetra : Inteldev.Fixius.Negocios.Proveedores.Interfaces.IPoneLetra   {

        public ItemLetra ItemLetra { get; set; }
        public Dictionary<ItemLetra,string> letras;

		public PoneLetra() 
		{
			//aca pongo condicion.
            this.ItemLetra = new ItemLetra();
            this.letras = new Dictionary<ItemLetra, string>();
			//agregar por cada letra que quieras
            this.letras.Add(new ItemLetra() { documento=TipoDocumento.Factura, condicionAnteIVAEmpresa= CondicionAnteIVA.ResponsableInscripto, condicionAnteIVAProveedor= CondicionAnteIVA.ResponsableInscripto},"A");
            this.letras.Add(new ItemLetra() { documento=TipoDocumento.NotaDeCredito, condicionAnteIVAEmpresa=CondicionAnteIVA.ResponsableInscripto,condicionAnteIVAProveedor=CondicionAnteIVA.ResponsableInscripto },"A");
            this.letras.Add(new ItemLetra() { documento = TipoDocumento.NotaDeDebito, condicionAnteIVAEmpresa = CondicionAnteIVA.ResponsableInscripto, condicionAnteIVAProveedor = CondicionAnteIVA.ResponsableInscripto }, "A");
            this.letras.Add(new ItemLetra() { documento=TipoDocumento.Factura, condicionAnteIVAProveedor=CondicionAnteIVA.Monotributo },"C");
            this.letras.Add(new ItemLetra() { documento= TipoDocumento.NotaDeCredito, condicionAnteIVAProveedor = CondicionAnteIVA.Monotributo }, "C");
            this.letras.Add(new ItemLetra() { documento= TipoDocumento.NotaDeDebito, condicionAnteIVAProveedor = CondicionAnteIVA.Monotributo }, "C");
            this.letras.Add(new ItemLetra() { documento = TipoDocumento.Factura, condicionAnteIVAEmpresa = CondicionAnteIVA.ResponsableInscripto, condicionAnteIVAProveedor = CondicionAnteIVA.Exento }, "A");
            this.letras.Add(new ItemLetra() { documento = TipoDocumento.NotaDeCredito, condicionAnteIVAEmpresa = CondicionAnteIVA.ResponsableInscripto, condicionAnteIVAProveedor = CondicionAnteIVA.Exento}, "A");
            this.letras.Add(new ItemLetra() { documento = TipoDocumento.NotaDeDebito, condicionAnteIVAEmpresa = CondicionAnteIVA.ResponsableInscripto, condicionAnteIVAProveedor = CondicionAnteIVA.Exento }, "A");
		}

        public string ObtenerLetra(ItemLetra condicion)
        {
            if (condicion.documento == TipoDocumento.NotaDeCreditoInterno || condicion.documento == TipoDocumento.NotadeDébitoInterno)
                return "I";
            else
            {
                var consulta = this.letras.Where(p => p.Key.documento == condicion.documento && p.Key.condicionAnteIVAProveedor == condicion.condicionAnteIVAProveedor);
                if (condicion.condicionAnteIVAProveedor != CondicionAnteIVA.Monotributo)
                {
                    consulta.Where(p => p.Key.condicionAnteIVAEmpresa == condicion.condicionAnteIVAEmpresa);
                }
                return consulta.FirstOrDefault().Value.ToString();
            }
        }
	}

}
