using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Contabilidad
{
    public class BuscadorDTOConceptoDeMovimiento : BuscadorDTO<Inteldev.Fixius.Modelo.Financiero.ConceptoDeMovimiento, Inteldev.Fixius.Servicios.DTO.Financiero.ConceptoDeMovimiento>
    {
        /// <summary>
        /// Lo cree pero no lo estamos usando
        /// </summary>
        /// <param name="buscadorEntidad"></param>
        /// <param name="mapeador"></param>
        public BuscadorDTOConceptoDeMovimiento(IBuscador<Inteldev.Fixius.Modelo.Financiero.ConceptoDeMovimiento> buscadorEntidad, IMapeadorGenerico<Inteldev.Fixius.Modelo.Financiero.ConceptoDeMovimiento, Inteldev.Fixius.Servicios.DTO.Financiero.ConceptoDeMovimiento> mapeador)
            : base(buscadorEntidad, mapeador)
        {

        }

        public override List<Servicios.DTO.Financiero.ConceptoDeMovimiento> BuscarLista(object param, Core.CargarRelaciones cargarEntidades)
        {
            var listaConceptos = new List<Servicios.DTO.Financiero.ConceptoDeMovimiento>();
            var query = this.BuscadorEntidad.ConsultaSimple(Core.CargarRelaciones.CargarTodo);
            var lista = (from c in query
                         select c).ToList();
            //return this.Mapeador.ToListDto(this.BuscadorEntidad.BuscarLista(c=>c.)
            listaConceptos = this.Mapeador.ToListDto(lista);
            return listaConceptos;
        }
    }
}
