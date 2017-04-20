using System;
using System.Collections.Generic;
using System.Text;

namespace Cliente
{
    public static class Mapa
    {
        public static string Serializar(List<string> lista)
        {
            if (lista.Count == 0)
            {
                return "";
            }

            bool esElPrimero = true;
            var salida = new StringBuilder();

            foreach (var linea in lista)
            {
                if (esElPrimero)
                {
                    salida.Append(linea);
                    esElPrimero = false;
                }
                else
                {
                    salida.Append(string.Format(",{0}",linea));
                }
            }
            return salida.ToString();
        }

        public static List<string> Deserializar(this string entrada)
        {
            string str = entrada;
            var list = new List<string>();

            if (string.IsNullOrEmpty(str))
            {
                return list;
            }

            try
            {
                foreach (string linea in entrada.Split(','))
                {
                    list.Add(linea);
                }
            }
            catch
            {
                return null;
            }
            return list;
        }
    }
}
