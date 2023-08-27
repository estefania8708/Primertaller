using System;

namespace TablasDeMultiplicarConRango
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el valor mínimo del rango: ");
            int min = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el valor máximo del rango: ");
            int max = Convert.ToInt32(Console.ReadLine());

            Random random = new Random();

            for (int numero = min; numero <= max; numero++)
            {
                int valorIncognito = random.Next(1, 11);

                Console.WriteLine($"Tabla de multiplicar para el número {numero}:");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"{numero} x {i} = {(i == valorIncognito ? "[valor]" : (numero * i).ToString())}");
                }

                Console.Write($"Resuelve: {numero} x {valorIncognito} = [valor]\nIngrese tu respuesta: ");
                int respuestaUsuario = Convert.ToInt32(Console.ReadLine());

                if (respuestaUsuario == numero * valorIncognito)
                {
                    Console.WriteLine("¡Respuesta correcta!\n");
                }
                else
                {
                    Console.WriteLine($"Respuesta incorrecta. El resultado era {numero * valorIncognito}\n");
                }
            }
        }
    }
}
