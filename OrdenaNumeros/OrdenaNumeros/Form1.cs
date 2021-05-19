﻿using System;
using System.Drawing;
using System.Windows.Forms;


//Trabajo hecho por Pietro Villano y Eliana Giraldo

namespace OrdenaNumeros
{
    public partial class Form1 : Form
    {

        private Logica MiLogica;
        public Button[,] matrizBotones;


        /// <summary>
        /// Constructor de la clase Form1
        /// </summary>
        public Form1()
        {

            MiLogica = new Logica();
            InitializeComponent();
            matrizBotones = new Button[4, 4];
            InicializaMatrizBotones();
            MiLogica.InicializaMatrizValores();
            MiLogica.EvaluaCondicionVictoria();
        }

        /// <summary>
        /// Evento que se usa cuando se carga la forma por primera vez
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Se invoca la inicialización de botones
            InicializaEtiquetaBotones();
        }

        /// <summary>
        /// Inicializa la matriz de botones, con los botones del interfaz
        /// </summary>
        private void InicializaMatrizBotones()
        {
            matrizBotones[0, 0] = boton1;
            matrizBotones[0, 1] = boton2;
            matrizBotones[0, 2] = boton3;
            matrizBotones[0, 3] = boton4;

            matrizBotones[1, 0] = boton5;
            matrizBotones[1, 1] = boton6;
            matrizBotones[1, 2] = boton7;
            matrizBotones[1, 3] = boton8;

            matrizBotones[2, 0] = boton9;
            matrizBotones[2, 1] = boton10;
            matrizBotones[2, 2] = boton11;
            matrizBotones[2, 3] = boton12;

            matrizBotones[3, 0] = boton13;
            matrizBotones[3, 1] = boton14;
            matrizBotones[3, 2] = boton15;
            matrizBotones[3, 3] = boton16;
        }

        /// <summary>
        /// Asigna los valores de la matrizValores como etiquetas de los
        /// botones en la matrizBotones
        /// </summary>
        private void InicializaEtiquetaBotones()
        {
            //Recalculamos la matriz de valores
            MiLogica.InicializaMatrizValores();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //El botón que tenga el valor 0, se verá como vacío
                    //para que el usuario pueda "desplazar" el valor allí
                    if (MiLogica.matrizValores[i, j] == 0)
                        matrizBotones[i, j].Text = "";
                    else
                        matrizBotones[i, j].Text = MiLogica.matrizValores[i, j].ToString();
                }
            }
        }

        /// <summary>
        /// Evento para reiniciar el juego desde la barra de Menus - ItemReiniciaJuego
        /// </summary>
        private void menuItemReiniciaJuego_Click(object sender, EventArgs e)
        {
            //Se invoca la inicialización de botones
            InicializaEtiquetaBotones();

            //Se activan los botones para que puedan ser usados 
            ActivaBotones();

            //Se le coloca el color de fondo predeterminado
            InicializaFondoBotones();

            //Se da la notificación si el valor se encuentra en la posición correcta
            NotificaPosicionCorrectaValor();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(1, 0, 0);
        }

        private void boton2_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(2, 0, 1);
        }

        private void boton3_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(3, 0, 2);
        }

        private void boton4_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(4, 0, 3);
        }

        private void boton5_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(5, 1, 0);
        }

        private void boton6_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(6, 1, 1);
        }

        private void boton7_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(7, 1, 2);
        }

        private void boton8_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(8, 1, 3);
        }

        private void boton9_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(9, 2, 0);
        }

        private void boton10_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(10, 2, 1);
        }

        private void boton11_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(11, 2, 2);
        }

        private void boton12_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(12, 2, 3);
        }

        private void boton13_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(13, 3, 0);
        }

        private void boton14_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(14, 3, 1);
        }

        private void boton15_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(15, 3, 2);
        }

        private void boton16_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(16, 3, 3);
        }

        /// <summary>
        /// Evento para item salir que cierra la aplicación
        /// </summary>
        private void menuItemSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }





        /// <summary>
        /// Evalua información asociada al botón presionado
        /// </summary>
        /// <param name="numeroBoton">Consecutivo del botón presionado</param>
        /// <param name="datoFila">Fila en la matriz a la que pertenece el botón</param>
        /// <param name="datoColumna">Columna en la matriz a la que pertenece el botón</param>
        private void EvaluaBotonPresionado(int numeroBoton, int datoFila, int datoColumna)
        {
            MiLogica.posicionFila = datoFila;
            MiLogica.posicionColumna = datoColumna;

            //Aqui evaluamos en la matrizValores, la posición correspondiente al botón presionado
            EvaluaPosicion();

            //Finalmente, se da la notificación si el valor se encuentra en la posición correcta
            NotificaPosicionCorrectaValor();
        }

        /// <summary>
        /// Evalua si la posición presionada está adjacente al espacio disponible para usar
        /// </summary>
        public void EvaluaPosicion()
        {
            int valorTemporal = 0;

            //Validamos el valor superior a donde presionamos si está el cero
            if (MiLogica.posicionFila > 0)
            {
                if (MiLogica.matrizValores[MiLogica.posicionFila - 1, MiLogica.posicionColumna] == 0)
                {
                    valorTemporal = MiLogica.matrizValores[MiLogica.posicionFila, MiLogica.posicionColumna];
                    MiLogica.matrizValores[MiLogica.posicionFila, MiLogica.posicionColumna] = 0;
                    MiLogica.matrizValores[MiLogica.posicionFila - 1, MiLogica.posicionColumna] = valorTemporal;
                }
            }

            //Validamos el valor inferior a donde presionamos si está el cero
            if (MiLogica.posicionFila < 3)
            {
                if (MiLogica.matrizValores[MiLogica.posicionFila + 1, MiLogica.posicionColumna] == 0)
                {
                    valorTemporal = MiLogica.matrizValores[MiLogica.posicionFila, MiLogica.posicionColumna];
                    MiLogica.matrizValores[MiLogica.posicionFila, MiLogica.posicionColumna] = 0;
                    MiLogica.matrizValores[MiLogica.posicionFila + 1, MiLogica.posicionColumna] = valorTemporal;
                }
            }

            //Validamos el valor izquierdo a donde presionamos si está el cero
            if (MiLogica.posicionColumna > 0)
            {
                if (MiLogica.matrizValores[MiLogica.posicionFila, MiLogica.posicionColumna - 1] == 0)
                {
                    valorTemporal = MiLogica.matrizValores[MiLogica.posicionFila, MiLogica.posicionColumna];
                    MiLogica.matrizValores[MiLogica.posicionFila, MiLogica.posicionColumna] = 0;
                    MiLogica.matrizValores[MiLogica.posicionFila, MiLogica.posicionColumna - 1] = valorTemporal;
                }
            }

            //Validamos el valor derecho a donde presionamos si está el cero
            if (MiLogica.posicionColumna < 3)
            {
                if (MiLogica.matrizValores[MiLogica.posicionFila, MiLogica.posicionColumna + 1] == 0)
                {
                    valorTemporal = MiLogica.matrizValores[MiLogica.posicionFila, MiLogica.posicionColumna];
                    MiLogica.matrizValores[MiLogica.posicionFila, MiLogica.posicionColumna] = 0;
                    MiLogica.matrizValores[MiLogica.posicionFila, MiLogica.posicionColumna + 1] = valorTemporal;
                }
            }

            //Finalmente actualizamos etiquetas de los botones
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (MiLogica.matrizValores[i, j] == 0)
                        matrizBotones[i, j].Text = "";
                    else
                        matrizBotones[i, j].Text = MiLogica.matrizValores[i, j].ToString();
                }
            }

            //Y valoramos la condición de victoria
            MiLogica.EvaluaCondicionVictoria();
        }

        public void NotificaPosicionCorrectaValor()
        {

            int[,] valoresEsperados = new int[4, 4];
            int valor = 1;

            int totalFilas = valoresEsperados.GetLength(0);
            int totalColumnas = valoresEsperados.GetLength(1);

            //Aqui llenamos la matriz de los valores esperados
            for (int i = 0; i < totalFilas; i++)
                for (int j = 0; j < totalColumnas; j++)
                {
                    valoresEsperados[i, j] = valor;
                    valor++;
                }

            //Al finalizar el juego, en la posición 4,4 se encuentra el 0
            valoresEsperados[3, 3] = 0;

            //Ahora comparamos con los valores actuales para saber si están en la posición correcta
            for (int i = 0; i < totalFilas; i++)
                for (int j = 0; j < totalColumnas; j++)
                {
                    if (MiLogica.matrizValores[i, j] == valoresEsperados[i, j])
                        matrizBotones[i, j].BackColor = Color.LightGreen;
                    else
                        matrizBotones[i, j].BackColor = Color.LightGray;

                    //El botón que tiene el 0 no deberá cambiar de color
                    if (MiLogica.matrizValores[i, j] == 0)
                        matrizBotones[i, j].BackColor = Color.LightGray;
                }
        }
        /// <summary>
        /// Esta función valida si todos los números están organizados
        /// </summary>


        /// <summary>
        /// Esta función inactiva los botones para ser utilizados en el juego
        /// </summary>
        private void InactivaBotones()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matrizBotones[i, j].Enabled = false;
        }

        /// <summary>
        /// Esta función activa los botones para ser utilizados en el juego
        /// </summary>
        private void ActivaBotones()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matrizBotones[i, j].Enabled = true;
        }

        /// <summary>
        /// Notifica que el número se encuentra en la posición correcta, cambiando el color de fondo del botón
        /// </summary>
        /// <summary>
        /// Método que inicializa el fondo de los botones con un color gris claro
        /// </summary>
        private void InicializaFondoBotones()
        {
            int totalFilas = matrizBotones.GetLength(0);
            int totalColumnas = matrizBotones.GetLength(1);

            //Asignamos a todos los botones gris claro como color de fondo
            for (int i = 0; i < totalFilas; i++)
                for (int j = 0; j < totalColumnas; j++)
                    matrizBotones[i, j].BackColor = Color.LightGray
        }
    }
    public bool ElCeroEstaAqui(int datoFila, int datoColumna)
    {​​​​​​
            bool siEsta = false;

        if (matrizValores[datoFila, datoColumna] == 0)

            siEsta = true;

        return siEsta;
    }​​​​​​

}
