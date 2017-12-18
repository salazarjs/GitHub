using System;

namespace EjercicioNumeroBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FASE1: Ejercicio 2 - Convertir a numero Binario \n");

            var numerodado = 0;

            //captura de numero a validar
            Console.Write("Escribe un numero para convertir: ");
            numerodado = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");

            //determinar el tamaño del arreglo
            int calculo = tamArreglo(numerodado);

            //realizar el calculo
            NumeroBinario(numerodado, calculo);

            Console.WriteLine("\n");
            Console.Write("Finalizar... presiona ENTER");
            Console.ReadLine();
        }

        public static int tamArreglo(int numeroDado)
        {
            int resultado = 0;
            int vDiv = 0;

            resultado = numeroDado;

            if ((resultado ==1) || (resultado == 0))
            {
                return vDiv;
            }
            else
            {
                do
                {
                    resultado = resultado / 2;
                    vDiv = vDiv + 1;

                } while (resultado != 0);
                return vDiv;
            }
        }

        public static void NumeroBinario(int numeroDado, int calculo)
        {
            int res = 0;
            int c = 0;
            int compara = 0;
            int alrrevez;
            int[] vectorResultado;
            int[] Binario;

            if (calculo == 0)
            {
                vectorResultado = new int[1];
                Binario = new int[1];
                alrrevez = 0;
            }
            else
            {
                vectorResultado = new int[calculo];
                Binario = new int[calculo];
                alrrevez = calculo - 1;
            }
          
            res = numeroDado;

            if (numeroDado != 0)
            {           
                do
                {
                    vectorResultado[c] = res;
                    c = c + 1;
                    res = res / 2;

                } while (res != 0);
            }
            else
            {
                vectorResultado[c] = res;
            }

            for (int i = 0; i < vectorResultado.Length; i++)
            {
                compara = vectorResultado[i] % 2;

                if (compara == 0)
                {
                    Binario[alrrevez] = 0;
                }
                else
                {
                    Binario[alrrevez] = 1;
                }

                alrrevez = alrrevez - 1;
            }

            Console.Write("Numero DECIMAL: " + numeroDado + " equivale a: ");

            foreach (var item in Binario)
            {
                Console.Write(item);
            }
        }
    }
}