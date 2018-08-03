using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios
{
    public class LogManager : Inteldev.Core.Patrones.Singleton<LogManager>
    {
        private ObservableCollection<String> mensajes;
        private StreamWriter outfile;

        public StreamWriter Outfile
        {
            get
            {
                if (outfile == null)
                    outfile = new StreamWriter(Environment.CurrentDirectory + @"\Actualizacion Servidor - " + DateTime.Now.ToString("dd-MM-yy H-mm-ss") + ".txt");
                return outfile;
            }
        }
        public ObservableCollection<String> Mensajes
        {
            get
            {
                if (mensajes == null)
                    mensajes = new ObservableCollection<string>();
                return mensajes;
            }
        }
        public void AgregarMensaje(string mensaje)
        {
            Mensajes.Add(mensaje);
            var sb = new StringBuilder();
            sb.Append(string.Format(DateTime.Now.ToString("hh:mm:ss")));
            sb.Append(" - ");
            sb.Append(mensaje);
            sb.AppendLine();
            Outfile.Write(sb.ToString());
            Outfile.Flush();
        }
        public void AgregarMensaje(string mensaje, params object[] args)
        {
            string.Format(mensaje, args);
            Mensajes.Add(mensaje);
            var sb = new StringBuilder();
            sb.Append(string.Format(DateTime.Now.ToString("hh:mm:ss")));
            sb.Append(" - ");
            sb.Append(mensaje);
            sb.AppendLine();
            Outfile.Write(sb.ToString());
            Outfile.Flush();
        }

        public void Resetear()
        {
            this.outfile = null;
            this.mensajes.Clear();
        }

    }
}
