using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totito_IA
{
    class Juego
    {

        public bool Ganador(string[] tablero, string jugador)
        {

            if (tablero[0] == jugador && tablero[4] == jugador && jugador == tablero[8])
            {
                return true;
            }
            if (tablero[2] == jugador && tablero[4] == jugador && jugador == tablero[6])
            {
                return true;
            }
            for (int i = 0; i < 9; i += 3)
            {

                if (tablero[i] == jugador && tablero[i + 1] == jugador && jugador == tablero[i + 2])
                {
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (tablero[i] == jugador && tablero[i + 3] == jugador && jugador == tablero[i + 6])
                {
                    return true;
                }
            }
            return false;

        }

        public bool Tablero_lleno(string[] tablero)
        {
            for (int i = 0; i < tablero.Length; i++)
            {
                if (tablero[i] == "") return false;
            }
            return true;
        }

        public string[] Reset()
        {
            string[] tablero = { "", "", "", "", "", "", "", "", "" };
            return tablero;
        }

        public int[] Disponibles(string[] tablero)
        {
            List<int> disponibles = new List<int>();
            for (int i = 0; i < tablero.Length; i++)
            {
                if (tablero[i] == "") disponibles.Add(i);
            }
            return disponibles.ToArray();
        }

        public Casilla Minimax(string human_jugador, string jugador, string[] tablero)
        {
            string max_jugador = human_jugador;
            string other_jugador = jugador == "X" ? "O" : "X";
            bool resultado = Ganador(tablero, other_jugador);
            int[] casilla_disponibles =  Disponibles(tablero);
            if (resultado)
            {
                if (jugador == max_jugador)
                {
                    Casilla next_mov = new Casilla(-1, (-1 * (casilla_disponibles.Length + 1)));
                    return next_mov;
                }
                else
                {
                    Casilla next_mov = new Casilla(-1, (1 * (casilla_disponibles.Length + 1)));
                    return next_mov;
                }
            }
            else if (Tablero_lleno(tablero))
            {
                Casilla next_mov = new Casilla(-1, 0);
                return next_mov;
            } 

            Casilla mejor = null;
            if (jugador == max_jugador)
            {
                mejor = new Casilla(-1, double.NegativeInfinity);
            }
            else
            {
                mejor = new Casilla(-1, double.PositiveInfinity);
            }

            Casilla sin_score = null;
            foreach (int mov in casilla_disponibles)
            {
                string[] new_tablero = new string[tablero.Length]; ;
                Array.Copy(tablero, new_tablero, tablero.Length);
                new_tablero[mov] = jugador;
                sin_score = Minimax(human_jugador, other_jugador, new_tablero);
                sin_score.Posicion = mov;
                if (jugador == max_jugador)
                { 
                    if (sin_score.Puntos >  mejor.Puntos)
                    {
                        mejor = sin_score;
                    }
                }
                else
                {
                    if (sin_score.Puntos < mejor.Puntos)
                    {
                        mejor = sin_score;
                    }
                }
            }
            return mejor;
        }


    }
}
