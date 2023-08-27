using System;

namespace NumeroEspecial
{
    class Program
    {
        static bool EsEspecial(int numero)
        {
            if (numero % 5 != 0)
            {
                return false;
            }
            if (numero % 2 == 0 || numero % 3 == 0)
            {
                return false;
            }
            int sumaDigitos = 0;
            foreach (char digito in numero.ToString())
            {
                sumaDigitos += int.Parse(digito.ToString());
            }
            if (sumaDigitos <= 10)
            {
                return false;
            }
            
            return true;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Ingresa un número: ");
                int numeroUsuario = int.Parse(Console.ReadLine());

                if (EsEspecial(numeroUsuario))
                {
                    Console.WriteLine($"{numeroUsuario} es un número especial.");
                }
                else
                {
                    Console.WriteLine($"{numeroUsuario} no es un número especial.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ingresa un número válido.");
            }
        }
    }
}
