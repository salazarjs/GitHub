using System;

namespace EjercicioDadoPerfecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("FASE 1: Ejercicio 1 - Numero perfecto \n");

            var numerodado = 0;
          
            //captura de numero a validar
            Console.Write("Escribe un numero: ");
            
            numerodado = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n");

            //Revisar si es perfecto o no el numero dado 
            if (NumeroPerfecto(numerodado))
            {
                Console.WriteLine("Numero " + numerodado + " es numero PERFECTO");
            }
            else
            {
                Console.WriteLine("Numero " + numerodado + " NO es numero PERFECTO");
            }
            
            Console.WriteLine("\n");
            Console.Write("Finalizar... presiona ENTER");
            Console.ReadLine();
        }

        public static Boolean NumeroPerfecto(int numeroDado)
        {
            var suma = 0;

            for (int i = 1; i < numeroDado; i++)
            {
                if ((numeroDado % i) == 0)
                {
                    suma = suma + i;
                }
            }

            if (numeroDado == suma)
            {
                return true;
            }

            return false;
        }
    }
}