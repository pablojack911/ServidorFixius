using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Preventa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorPreventistasFox : MapeadorFox<Preventista>
    {
        public MapeadorPreventistasFox(IDao con, String empresa, string entidad)
            : base("operator", "select * from operator order by codigo GROUP BY CODIGO where cargo = 1", "codigo", con, empresa, entidad)
        {
        }

        protected override Preventista Mapear(Preventista entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();

            // Mobile
            entidad.Usuario = registro["user"].ToString().Trim();
            entidad.Password = registro["pass"].ToString().Trim();
            entidad.Foto = registro["Foto"].ToString().Trim();

            //direccion y coordenada
            entidad.Domicilio = registro["domicilio"].ToString().Trim();
            #region Obtener coordenada en base a direccion

            if (entidad.Domicilio != string.Empty)
            {
                var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}", Uri.EscapeDataString(entidad.Domicilio + "," + " Mar del Plata"));
                double lat = 0;
                double lng = 0;
                //34.6000° S, 58.3833° W ARGENTINA
                var request = WebRequest.Create(requestUri);
                try
                {
                    var response = request.GetResponse();
                    var xdoc = XDocument.Load(response.GetResponseStream());

                    switch (xdoc.Element("GeocodeResponse").Element("status").Value)
                    {
                        case "OK":
                            var result = xdoc.Element("GeocodeResponse").Element("result");
                            var locationElement = result.Element("geometry").Element("location");
                            lat = double.Parse(locationElement.Element("lat").Value, CultureInfo.InvariantCulture);
                            lng = double.Parse(locationElement.Element("lng").Value, CultureInfo.InvariantCulture);
                            entidad.Latitud = lat;
                            entidad.Longitud = lng;

                            break;
                        default:
                            break;
                    }
                }
                catch (Exception exc)
                {

                }
            }
            #endregion

            // Datos Anteriores
            if (entidad.DatosOldPreventa == null)
                entidad.DatosOldPreventa = new DatosOldPreventa();

            entidad.DatosOldPreventa.EsSupervisor = ObtenerBoolDeString(registro["essupervisor"].ToString());
            entidad.DatosOldPreventa.Inactivo = ObtenerBoolDeString(registro["inactivo"].ToString());



            return entidad;


        }
    }
}
