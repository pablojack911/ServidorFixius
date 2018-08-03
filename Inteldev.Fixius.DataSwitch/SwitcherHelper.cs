using Inteldev.Fixius.Datos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.DataSwitch
{
    /// <summary>
    /// Contiene una lista de las propiedades. Sirve para saber si tenes que grabar solamente en el 
    /// contexto inicial o no.
    /// </summary>
    public class SwitcherHelper
    {
        private List<string> listaPropiedades;

        public SwitcherHelper(Type contexto)
        {
            this.listaPropiedades = new List<string>();
            foreach (var item in contexto.GetProperties())
	        {
                    listaPropiedades.Add(item.Name.ToLower());
	        }
        }

        public List<string> getPropiedades()
        {
            return this.listaPropiedades;
        }
    }
}
