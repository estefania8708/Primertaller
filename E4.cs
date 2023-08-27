using System;

namespace JuegoAdivinanza
{
    class Program
    {
        static void Main(string[] args)
        {
            string fraseOriginal = "El gato juega en el jardin";
            string[] palabrasOcultas = { "gato", "en", "jardin" };
            string[] fraseOculta = { "El", "_____", "juega", "_____", "el", "_____" };

            int intentosRestantes = 10;
            int palabrasAdivinadas = 0;

            Console.WriteLine("Bienvenido al juego de adivinanza de palabras.");
            Console.WriteLine("Completa la frase: ");
            Console.WriteLine(string.Join(" ", fraseOculta));

            while (intentosRestantes > 0 && palabrasAdivinadas < palabrasOcultas.Length)
            {
                Console.Write("Ingresa una palabra: ");
                string palabraIngresada = Console.ReadLine().ToLower(); 

                if (Array.IndexOf(palabrasOcultas, palabraIngresada) != -1)
                {
                    int indice = Array.IndexOf(palabrasOcultas, palabraIngresada);
                    if (fraseOculta[2 * indice + 1] == "_____")
                    {
                        fraseOculta[2 * indice + 1] = palabraIngresada;
                        palabrasAdivinadas++;
                        Console.WriteLine("¡Correcto! Has adivinado una palabra.");
                    }
                    else
                    {
                        Console.WriteLine("Ya habías adivinado esa palabra previamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrecto. Pierdes un intento.");
                    intentosRestantes--;
                }

                Console.WriteLine($"Intentos restantes: {intentosRestantes}");
            }

            if (palabrasAdivinadas == palabrasOcultas.Length)
            {
                Console.WriteLine("¡Felicitaciones! Has adivinado todas las palabras.");
                Console.WriteLine("La frase completa es:");
                Console.WriteLine(string.Join(" ", fraseOculta));
            }
            else
            {
                Console.WriteLine("Has agotado tus intentos. ¡Juego terminado!");
            }
        }
    }
}
