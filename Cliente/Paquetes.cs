using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cliente
{
    public class Paquetes
    {
        public static Paquete InicioSesion(string email, string password)
        {
            var package = new List<string> { email, password };
            return new Paquete("login", Mapa.Serializar(package));
        }
    }
}
