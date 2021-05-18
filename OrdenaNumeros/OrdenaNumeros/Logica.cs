using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

//Trabajo hecho por Pietro Villano y Eliana Giraldo

namespace OrdenaNumeros
{
    class Logica
    {
        public Button[,] matrizBotones;
        public int[,] matrizValores;
        public int posicionFila, posicionColumna;

        public int[,] MatrizValores
        {
            get
            {
                return matrizValores;
            }
        }

        public int PosicionFila
        {
            get
            {
                return posicionFila;
            }
        }

        public int PosicionColumna
        {
            get
            {
                return posicionColumna;
            }
        }

        public Logica()
        {

            matrizBotones = new Button[4, 4];
            posicionFila = 0;
            posicionColumna = 0;
            matrizValores = new int[4, 4];
            InicializaMatrizValores();
            EvaluaCondicionVictoria();
        }

        public void InicializaMatrizValores()
        {
            int valor = 0;

            //Inicialmente se asignan los números del 0 al 15 en toda la matriz
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrizValores[i, j] = valor;
                    valor++;
                }
            }

            //Luego, procedemos a cambiar los valores de posición de manera aleatoria

            Random aleatorio = new Random();
            int posicionHorizontal, posicionVertical, valorTemporal;

            //Aqui desordenamos la matriz, calculando posiciones horizontales y
            //verticales dentro de la matriz
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    valorTemporal = matrizValores[i, j];
                    posicionHorizontal = aleatorio.Next(4);
                    posicionVertical = aleatorio.Next(4);

                    matrizValores[i, j] = matrizValores[posicionHorizontal, posicionVertical];
                    matrizValores[posicionHorizontal, posicionVertical] = valorTemporal;
                }
            }
        }

        public void EvaluaCondicionVictoria()
        {
            //Partimos del supuesto que ya logramos la condición de victoria
            bool condicionVictoria = true;

            int valorBuscado = 0;

            //Aqui recorremos la matriz de valores buscando para cada posición si el valor está en orden
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //incrementamos el valor buscado
                    valorBuscado++;

                    //Si los valores son diferentes, entonces todavía necesitamos seguir jugando!!!
                    if (matrizValores[i, j] != valorBuscado)
                    {
                        // Validamos si estamos en la última casilla, el valor existente es 0,
                        // el valor buscado ya llegó a 16 y la condición de victoria sigue siendo true
                        if (matrizValores[i, j] == 0 && valorBuscado == 16 && condicionVictoria == true)
                            condicionVictoria = true;

                        // De lo contrario, es porque estamos en cualquier otra casilla y los valores
                        // Todavía no son iguales
                        else
                            condicionVictoria = false;
                    }
                }
            }

        }



    }
}
