using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    public class Puntuacion
    {
        public string Nombre { get; set; }
        public int CantidadPuntos { get; set; }
        public Puntuacion()
        {
            Nombre = "AAA";
            CantidadPuntos = 0;
        }
        public Puntuacion(string nombre, int puntos)
        {
            Nombre = nombre;
            CantidadPuntos = puntos;
        }

    }
}
