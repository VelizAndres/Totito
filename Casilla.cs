using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totito_IA
{
    public class Casilla
    {
        double puntos;
        int posicion;

        public double Puntos { get => puntos; set => puntos = value; }
        public int Posicion { get => posicion; set => posicion = value; }

        public Casilla(int position, double score)
        {
            this.posicion = position;
            this.puntos = score;
        }
    }
}
