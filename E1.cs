using System;

namespace CalculadoraDeFracciones
{
    class Fraccion
    {
        public int Numerador { get; set; }
        public int Denominador { get; set; }
        public Fraccion(int numerador, int denominador)
        {
            Numerador = numerador;
            Denominador = denominador;
        }
        public Fraccion Sumar(Fraccion otra)
        {
            int nuevoDenominador = Denominador * otra.Denominador;
            int nuevoNumerador = Numerador * otra.Denominador + otra.Numerador * Denominador;
            return Simplificar(new Fraccion(nuevoNumerador, nuevoDenominador));
        }
        public Fraccion Restar(Fraccion otra)
        {
            int nuevoDenominador = Denominador * otra.Denominador;
            int nuevoNumerador = Numerador * otra.Denominador - otra.Numerador * Denominador;
            return Simplificar(new Fraccion(nuevoNumerador, nuevoDenominador));
        }
        public Fraccion Multiplicar(Fraccion otra)
        {
            int nuevoNumerador = Numerador * otra.Numerador;
            int nuevoDenominador = Denominador * otra.Denominador;
            return Simplificar(new Fraccion(nuevoNumerador, nuevoDenominador));
        }
        public Fraccion Dividir(Fraccion otra)
        {
            if (otra.Numerador == 0)
            {
                throw new DivideByZeroException("No se puede dividir por cero.");
            }
            
            int nuevoNumerador = Numerador * otra.Denominador;
            int nuevoDenominador = Denominador * otra.Numerador;
            return Simplificar(new Fraccion(nuevoNumerador, nuevoDenominador));
        }
        private int MCD(int a, int b)
        {
            if (b == 0)
                return a;
            return MCD(b, a % b);
        }
        private Fraccion Simplificar(Fraccion fraccion)
        {
            int mcd = MCD(fraccion.Numerador, fraccion.Denominador);
            return new Fraccion(fraccion.Numerador / mcd, fraccion.Denominador / mcd);
        }
        public override string ToString()
        {
            return $"{Numerador}/{Denominador}";
        }
    }  
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora de Fracciones");
             try
            {
                Console.Write("Ingrese el numerador de la primera fracción: ");
                int numerador1 = int.Parse(Console.ReadLine());
                
                Console.Write("Ingrese el denominador de la primera fracción: ");
                int denominador1 = int.Parse(Console.ReadLine());
                
                Console.Write("Ingrese el operador (+, -, *, /): ");
                char operador = char.Parse(Console.ReadLine());
                
                Console.Write("Ingrese el numerador de la segunda fracción: ");
                int numerador2 = int.Parse(Console.ReadLine());
                
                Console.Write("Ingrese el denominador de la segunda fracción: ");
                int denominador2 = int.Parse(Console.ReadLine());
                
                Fraccion fraccion1 = new Fraccion(numerador1, denominador1);
                Fraccion fraccion2 = new Fraccion(numerador2, denominador2);
                
                Fraccion resultado;
                
                switch (operador)
                {
                    case '+':
                        resultado = fraccion1.Sumar(fraccion2);
                        break;
                    case '-':
                        resultado = fraccion1.Restar(fraccion2);
                        break;
                    case '*':
                        resultado = fraccion1.Multiplicar(fraccion2);
                        break;
                    case '/':
                        resultado = fraccion1.Dividir(fraccion2);
                        break;
                    default:
                        Console.WriteLine("Operador inválido.");
                        return;
                }
                
                Console.WriteLine($"El resultado es: {resultado}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Asegúrese de ingresar números y operadores válidos.");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
