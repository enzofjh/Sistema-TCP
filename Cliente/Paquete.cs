using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    public class Paquete
    {
        public string Comando { get; set; }
        public string Contenido { get; set; }

        public Paquete()
        {

        }

        public Paquete(string comando, string contenido)
        {
            Comando = comando;
            Contenido = contenido;
        }

        public Paquete(string datos) // ej: login:usuario,contrasena
        {
            int sepIndex = datos.IndexOf(":", StringComparison.Ordinal);
            Comando = datos.Substring(0, sepIndex);
            Contenido = datos.Substring(Comando.Length + 1);
        }

        public string Serializar()
        {
            return string.Format("{0}:{1}", Comando, Contenido);
        }

        public static implicit operator string(Paquete paquete)
        {
            return paquete.Serializar();
        }
    }
}
