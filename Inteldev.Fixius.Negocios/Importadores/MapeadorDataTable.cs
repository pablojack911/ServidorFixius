using Inteldev.Core.DTO;
using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios.Mapeador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Core.Extenciones;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Negocios.Proveedores.Mapeadores;
using Microsoft.Practices.Unity;


namespace Inteldev.Fixius.Negocios
{
    /// <summary>
    /// Clase abstracta para mapear DataTable a la Entidad.
    /// Quien quiera hacer este tipo de cosas, deberá heredar de esta clase, porque los metodos de sincronizar
    /// detalle y cargar data table, no se pueden hacen con reflexion y ninguna otra cosa rara. Los tenes que
    /// escribir a manopla. Por eso es abstracta.
    /// El resto si se hace por reflexion
    /// </summary>
    /// <typeparam name="TEntidad">pasame aca el modelo</typeparam>
    /// <typeparam name="TDto">pasame el pedorro dto que tiene el datatable</typeparam>
    public abstract class MapeadorDataTable<TEntidad, TDto> : IMapeadorGenerico<TEntidad, TDto>
        where TEntidad : EntidadBase
        where TDto : DTOBase
    {
        private string empresa;

        public MapeadorDataTable()
        {
            throw new NotImplementedException();
        }

        public MapeadorDataTable(string empresa)
        {
            this.columnasDataTable = new Dictionary<string, Type>();
            this.listasDetalle = new List<string>();
            this.entrar = true;
            this.empresa = empresa;
            if (this.empresa == null)
                throw new NoNullAllowedException();
        }

        protected Dictionary<string, Type> columnasDataTable { get; set; }

        /// <summary>
        /// contiene los nombres de las collecciones que corresponden al datatable del dto.
        /// </summary>
        protected List<string> listasDetalle { get; set; }

        private bool entrar;

        //aca estan los dos putos metodos que tengo que implementar en los hijos.
        //llamado por a dto -> entidad
        protected abstract void sincronizarDetalle(DataTable dataTable, PropertyInfo propiedadEntidad, object entidad);

        //llamado por entidad -> dto
        protected abstract void cargarDataTable(DataTable tabla, ICollection<EntidadBase> items);

        //nada mas lo llama entidad -> dto
        protected DataTable CrearDataTable()
        {
            var dataTable = new DataTable("Detalle");
            foreach (var item in this.columnasDataTable)
            {
                dataTable.Columns.Add(new DataColumn(item.Key, item.Value));
            }
            return dataTable;
        }

        /// <summary>
        /// Metodo super loco que le pasas dos propertyInfo de Reflexion y te devuelve el mapeador
        /// instanciadito listo para que lo uses. WARNING devuelve un dynamic, asi que no la cagues.
        /// </summary>
        /// <param name="propiedadEntidad">propiedad reflexion de la prop de la entidad</param>
        /// <param name="propiedadDto">propiedad reflexcion de la prop del dto</param>
        /// <returns>FUCKING DYNAMIC!! asi que tene cuidado.</returns>
        private dynamic getMapeador(PropertyInfo propiedadEntidad, PropertyInfo propiedadDto)
        {
            //aca no me deja instanciar una interfaz.
            //de alguna manera tengo que llamar a unity para que me de el objeto concreto
            var mapeadorTypeGenerico = typeof(IMapeadorGenerico<,>);
            //que pasa si propiedadEntidad es una puta colleccion?
            Type typeEntidad;
            Type typeDto;
            if (propiedadEntidad.PropertyType.Namespace == "System.Collections.Generic")
            {
                typeEntidad = propiedadEntidad.PropertyType.GetGenericArguments().FirstOrDefault();
                typeDto = propiedadDto.PropertyType.GetGenericArguments().FirstOrDefault();
            }
            else
            {
                typeEntidad = propiedadEntidad.PropertyType;
                typeDto = propiedadDto.PropertyType;
            }
            Type[] param = { typeEntidad, typeDto };
            //le tengo que pasar la entidad y la empresa.
            var mapeadorType = mapeadorTypeGenerico.MakeGenericType(param);
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", typeEntidad.Name) };
            return FabricaNegocios.Instancia.Resolver(mapeadorType, parameters);
        }

        private void dataDatableDTOtoEntidad(PropertyInfo propiedadDto, object dto, object entidad, PropertyInfo propiedadEntidad)
        {
            var data = propiedadDto.GetValue(dto) as DataTable;
            List<EntidadBase> lista = (propiedadEntidad.GetValue(entidad) as IEnumerable<object>).Cast<EntidadBase>().ToList();
            this.sincronizarDetalle(data, propiedadEntidad, entidad);
        }

        public TEntidad DtoToEntidad(TDto dto, TEntidad entidad)
        {
            var dtoType = dto.GetType();
            var entidadType = entidad.GetType();
            var propiedadesDTO = dtoType.GetProperties();
            var propiedadesEntidad = entidadType.GetProperties();
            foreach (PropertyInfo propiedadEntidad in propiedadesEntidad)
            {
                var propiedadDto = propiedadesDTO.FirstOrDefault(p => p.Name == propiedadEntidad.Name);
                if (propiedadEntidad.PropertyType.GetProperty("Count") != null)
                {
                    object valor = null;
                    if (propiedadDto != null)
                        valor = propiedadDto.GetValue(dto);
                    else
                    {
                        //entras aca cuando no encontras la propiedaddto. Eso es porque es el detalle.
                        propiedadDto = propiedadesDTO.FirstOrDefault(p => p.Name == "Detalle");
                        this.dataDatableDTOtoEntidad(propiedadDto, dto, entidad, propiedadEntidad);
                    }
                    if (valor != null)
                    {
                        var mapeadorColleccion = this.getMapeador(propiedadEntidad, propiedadDto);
                        //aca tengo que castear o lo que sea
                        propiedadEntidad.SetValue(entidad, mapeadorColleccion.ToListEntidad(valor));
                    }
                }
                //puede ser una entidad o una propiedad pedorra cualquiera
                else
                {
                    //es entidad
                    if (propiedadEntidad.PropertyType.IsSubclassOf(typeof(EntidadBase)))
                    {
                        var mapeador = this.getMapeador(propiedadEntidad, propiedadDto);
                        object value = propiedadDto.GetValue(dto);
                        if (value != null)
                            propiedadEntidad.SetValue(entidad, mapeador.DtoToEntidad(value));
                    }
                    //pfff... propiedad pedorra...
                    else
                    {
                        //aca si no encuentra la propiedad tira null.
                        //podria buscar la propiedad en listadetalle no???
                        if (propiedadDto == null)
                        {
                            propiedadDto = propiedadesDTO.FirstOrDefault(p => p.Name == "Detalle");
                        }
                        if (propiedadDto.PropertyType == typeof(DataTable))
                        {
                            this.dataDatableDTOtoEntidad(propiedadDto, dto, entidad, propiedadEntidad);
                        }
                        else
                        {
                            //que pasa si es un enum??
                            propiedadEntidad.SetValue(entidad, propiedadDto.GetValue(dto));
                        }

                    }
                }
            }
            //tengo que llamar a sincronizar detalle
            return entidad;
        }

        public TEntidad DtoToEntidad(TDto dto)
        {
            return this.DtoToEntidad(dto, Activator.CreateInstance<TEntidad>());
        }

        public TDto EntidadToDto(TEntidad entidad, TDto dto)
        {
            var dtoType = dto.GetType();
            var entidadType = entidad.GetType();
            var propiedadesDTO = dtoType.GetProperties();
            var propiedadesEntidad = entidadType.GetProperties();
            var valueDataTable = this.CrearDataTable();
            var resultado = new List<EntidadBase>();
            foreach (PropertyInfo propiedadDto in propiedadesDTO)
            {
                var propiedadEntidad = propiedadesEntidad.FirstOrDefault(p => p.Name == propiedadDto.Name);
                dynamic valorEnt;
                if (propiedadEntidad == null)
                {
                    if (entrar && listasDetalle.Count != 0)
                    {
                        foreach (var item in listasDetalle)
                        {
                            valorEnt = propiedadesEntidad.FirstOrDefault(p => p.Name == item).GetValue(entidad);
                            foreach (var elemento in valorEnt)
                            {
                                resultado.Add(elemento);
                            }
                        }
                        this.entrar = false;
                    }
                    valorEnt = null;
                }
                else
                    valorEnt = propiedadEntidad.GetValue(entidad);

                if (propiedadDto.PropertyType == typeof(DataTable))
                {
                    //tengo que llamar a cargar dataTable
                    this.cargarDataTable(valueDataTable, resultado);
                    propiedadDto.SetValue(dto, valueDataTable);
                }

                if (valorEnt != null)
                {
                    if (((object)valorEnt).EsColeccion())
                    {
                        if (valorEnt.Count != 0)
                        {
                            if (propiedadDto.PropertyType == typeof(DataTable))
                            {
                                //NO HAGAN ESTO EN CASA CHICOS!!!
                                foreach (var item in valorEnt)
                                {
                                    resultado.Add(item);
                                }
                            }
                            else
                            {
                                var mapeadorColleccion = this.getMapeador(propiedadEntidad, propiedadDto);
                                var re = mapeadorColleccion.ToListDto(valorEnt);
                                propiedadDto.SetValue(dto, re);
                            }
                        }
                    }
                    else
                    {
                        //es entidad
                        if (propiedadDto.PropertyType.IsSubclassOf(typeof(DTOBase)))
                        {
                            var mapeador = this.getMapeador(propiedadEntidad, propiedadDto);
                            var valor = (Modelo.Proveedores.Proveedor)propiedadEntidad.GetValue(entidad);
                            if (valor != null)
                                propiedadDto.SetValue(dto, mapeador.EntidadToDto(valor));
                        }
                        //pfff... propiedad pedorra...
                        else
                        {
                            //que pasa si es un enum??
                            propiedadDto.SetValue(dto, valorEnt);
                        }
                    }
                }
            }
            return dto;
        }

        public TDto EntidadToDto(TEntidad entidad)
        {
            return this.EntidadToDto(entidad, Activator.CreateInstance<TDto>());
        }

        public List<TDto> ToListDto(List<TEntidad> listaEntidades)
        {
            var result = new List<TDto>();
            foreach (var item in listaEntidades)
            {
                result.Add(this.EntidadToDto(item));
            }
            return result;
        }

        public List<TEntidad> ToListEntidad(List<TDto> listaDto)
        {
            var result = new List<TEntidad>();
            foreach (var item in listaDto)
            {
                result.Add(this.DtoToEntidad(item));
            }
            return result;
        }


        public List<TEntidad> ToListEntidad(object listaDto)
        {
            throw new NotImplementedException();
        }


        public TEntidad DtoToEntidad(object dto)
        {
            throw new NotImplementedException();
        }


        public AutoMapper.IMappingEngine MotorDeMapeador()
        {
            return Mapeador.Instancia.Engine;
        }
    }
}
