using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Totito_IA
{
    public partial class Form1 : Form
    {
        string[] tablero = { "", "", "", "", "", "", "", "", "" };
        string human = "";
        string bot = "";
        bool human_turno = false;
        bool lleno_tablero = false;
        Juego juego = new Juego();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Iniciar_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (rand.Next(2) == 1) human_turno = true;
            else human_turno = false;
            if (rand.Next(2) == 0) human = "X";
            else human = "O";
            bot = human == "X" ? "O" : "X";

            Asignar_Texto();

            btn_Iniciar.Enabled = false;
            btn_reset.Enabled = true;

            if (!human_turno)
            {
                string[] tabla = new string[tablero.Length];
                Array.Copy(tablero, tabla, tablero.Length);
                tablero = Maquina_Move(juego.Minimax(human, bot, tabla), tablero);
            }
            cuadricula.Enabled = true;

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            tablero = juego.Reset();
            human = "";
            bot = "";
            Lbl_Resultado.Text = "";
            lleno_tablero = false;
            Asignar_Texto();
            Borrar_Tablero();
            btn_Iniciar.Enabled = true;
            btn_reset.Enabled = false;
            cuadricula.Enabled = false;
        }

        private void Asignar_Texto()
        {
            Lbl_humano.Text = human;
            Lbl_maquina.Text = bot;
            Lbl_comienza.Text = human_turno ? human : bot;
        }

        private void Borrar_Tablero()
        {
            btn_00.Text = "";
            btn_01.Text = "";
            btn_02.Text = "";
            btn_10.Text = "";
            btn_11.Text = "";
            btn_12.Text = "";
            btn_20.Text = "";
            btn_21.Text = "";
            btn_22.Text = "";

            btn_00.Enabled = true;
            btn_01.Enabled = true;
            btn_02.Enabled = true;
            btn_10.Enabled = true;
            btn_11.Enabled = true;
            btn_12.Enabled = true;
            btn_20.Enabled = true;
            btn_21.Enabled = true;
            btn_22.Enabled = true;


        }
        private void btn_00_Click(object sender, EventArgs e)
        {
            Marcar(0, human);
            Modificar_Tablero(0);
        }

        private void btn_01_Click(object sender, EventArgs e)
        {
            Marcar(1, human);
            Modificar_Tablero(1);
        }

        private void btn_02_Click(object sender, EventArgs e)
        {
            Marcar(2, human);
            Modificar_Tablero(2);
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            Marcar(3, human);
            Modificar_Tablero(3);

        }

        private void btn_11_Click(object sender, EventArgs e)
        {
            Marcar(4, human);
            Modificar_Tablero(4);

        }

        private void btn_12_Click(object sender, EventArgs e)
        {
            Marcar(5, human);
            Modificar_Tablero(5);
        }

        private void btn_20_Click(object sender, EventArgs e)
        {
            Marcar(6, human);
            Modificar_Tablero(6);
        }

        private void btn_21_Click(object sender, EventArgs e)
        {
            Marcar(7, human);
            Modificar_Tablero(7);

        }

        private void btn_22_Click(object sender, EventArgs e)
        {
            Marcar(8, human);
            Modificar_Tablero(8);
        }


        public void Modificar_Tablero(int posicion)
        {
            tablero[posicion] = human;

            bool Resultado = juego.Ganador(tablero, human);
            if (!Resultado)
            {
                lleno_tablero = juego.Tablero_lleno(tablero);
                if (lleno_tablero)
                {
                    Console.WriteLine("Empate");
                    Lbl_Resultado.Text = "Empate";
                }
                else
                {
                    string[] tabla = new string[tablero.Length];
                    Array.Copy(tablero, tabla, tablero.Length);
                    tablero = Maquina_Move(juego.Minimax(human, bot, tabla), tablero);
                    Resultado = juego.Ganador(tablero, bot);
                    if (Resultado)
                    {
                        Lbl_Resultado.Text = "Ganador Maquina";
                        Console.WriteLine("Ganador es " + bot);
                        lleno_tablero = true;
                    }
                    lleno_tablero = juego.Tablero_lleno(tablero);
                    if (lleno_tablero)
                    {
                        Console.WriteLine("Empate");
                        Lbl_Resultado.Text = "Empate";
                    }
                }
            }
            else
            {
                Lbl_Resultado.Text = "Ganador Humano";
                Console.WriteLine("Ganador es " + human);
                lleno_tablero = true;
            }

        }

        public string[] Maquina_Move(Casilla movimiento, string[] tabla)
        {
            tabla[movimiento.Posicion] = bot;
            Marcar(movimiento.Posicion, bot);
            return tabla;
        }

        private void Marcar(int posicion, string jugador)
        {
            int fila = posicion / 3;
            int col = posicion % 3;
            if (fila == 0)
            {
                if (col == 0)
                {
                    btn_00.Text = jugador;
                    btn_00.Enabled = false;
                }
                else if (col == 1)
                {
                    btn_01.Text = jugador;
                    btn_01.Enabled = false;
                }
                else
                {
                    btn_02.Text = jugador;
                    btn_02.Enabled = false;
                }
            }
            else if (fila == 1)
            {
                if (col == 0)
                {
                    btn_10.Text = jugador;
                    btn_10.Enabled = false;
                }
                else if (col == 1)
                {
                    btn_11.Text = jugador;
                    btn_11.Enabled = false;
                }
                else
                {
                    btn_12.Text = jugador;
                    btn_12.Enabled = false;
                }
            }
            else
            {
                if (col == 0)
                {
                    btn_20.Text = jugador;
                    btn_20.Enabled = false;
                }
                else if (col == 1)
                {
                    btn_21.Text = jugador;
                    btn_21.Enabled = false;
                }
                else
                {
                    btn_22.Text = jugador;
                    btn_22.Enabled = false;
                }
            }

        }
    }


}
