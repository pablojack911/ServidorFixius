using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO
{
    public class ConfiguraEmpresa : DTOMaestro, INotifyPropertyChanged
    {
        
        public Empresa Empresa { get; set; }
        public int? EmpresaId { get; set; }
        private Contexto contexto { get; set; }
        public Contexto Contexto { get { return contexto; } set 
        {
            this.contexto = value;
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs("Contexto"));
        } }
        
        public int? ContextoId { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
