using arbolSQL.conexionDB;
using arbolSQL.juegoAnimal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbolSQL
{
    class Program
    {
        static void juegoAnimal()
        {
            ///para parcial crear persistencia para que guarde todas las pistas 
            ///explicar como hicimos el procedimiento, y que utilizamos para guardar la informacion(sql o mongodb)
            ///dibujar el arbol en pantalla
            Console.WriteLine("Juguemos a adivinar Animales");
            Boolean otroJuego = true;
            AdivinaAnimal juego = new AdivinaAnimal();

            do
            {
                juego.jugar();
                Console.WriteLine("jugamos otra vez?");
                otroJuego = juego.respuesta();
            } while (otroJuego);
        }

        static void devuelveDatos()
        {
            Console.WriteLine("Los datos son:");
            AdivinaAnimal juego = new AdivinaAnimal();

            juego.Buscar();

        }

        static void Main(string[] args)
        {
            int salir = 0;
            int opc = 0;  

            do
            {
                Console.WriteLine("Presiona 1 y luego ENTER para acceder al Juego de Adivina el Animal.");
                Console.WriteLine("Presiona 2  y luego ENTER para devolver datos del Juego de Adivina el Animal.");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Adivina el Animal:");
                        juegoAnimal();
                        break;
                    case 2:
                        Console.WriteLine("Datos del Juego de Adivina el Animal:");
                        devuelveDatos();
                        break;
                    default:
                        Console.WriteLine("Disculpa, ingresaste mal la opcion!!!\t Intenta de nuevo.");
                        break;

                }
                Console.WriteLine("Deseas empezar desde el inicio?\n1. Si\n2. No\n");
                salir = int.Parse(Console.ReadLine());
            } while (salir != 2);
            {
                Console.WriteLine("\nPresiona ENTER nuevamente para finalizar.");
            }

            Console.ReadLine();
        }
    }
}
