using System;
using System.Collections.Generic;
using System.Linq;

namespace TP__4
{
    class Program
    {
        static RegPersonas personasRegistradas = new RegPersonas();

        static void Main(string[] args)
        {
            int op;
            string linea;

            do
            {
                Console.WriteLine("Ingrese la operacion a realizar: ");
                Console.WriteLine("1. Registrar persona.");
                Console.WriteLine("2. Autorizar ingreso.");
                Console.WriteLine("3. Finalizar.");
                Console.WriteLine("");
                linea = Console.ReadLine();
                op = int.Parse(linea);

                switch (op)
                {
                    case 1:
                        RegistrarPersona();
                        break;

                    case 2:
                        AutorizarIngreso();
                        break;

                    case 3:
                        //personasRegistradas.MuestreoPersonas(); Corroborar que se ingresaron correctamente las personas.
                        Console.WriteLine("\nPrograma finalizado - Muchas gracias!");
                        break;

                    default:
                        Console.WriteLine("\nValor incorrecto. Ingrese nuevamente\n");
                        break;

                }
            } while (op != 3);



        }

        public static void RegistrarPersona()
        {
            int n;

            Console.WriteLine("\tREGISTRO DE PERSONAS\n");

            Console.Write("Cuantas personas desea ingresar: ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var actividad = new ActividadAutorizada("Deporte");
                _ = new ActividadAutorizada("Religion");
                _ = new ActividadAutorizada("Educacion");
                _ = new ActividadAutorizada("Politica");

                var persona = new Persona(actividad);

                Console.Write("\n\tPERSONA {0}", i+1);
                persona.RegistrarPersona();

                if (persona.Actividad.Autorizacion == true)
                {
                    Console.WriteLine("PERSONA AUTORIZADA PARA CIRCULAR.\n");
                    personasRegistradas.AgregarPersona(persona);

                }

                else
                {
                    Console.WriteLine("PERSONA NO AUTORIZADA PARA CIRCULAR.\n");
                    personasRegistradas.AgregarPersona(persona);
                }
            }
                
        }

        public static void AutorizarIngreso()
        {
            Console.Write("\tVERIFICACION DE PERSONA");

            personasRegistradas.BuscarDni();
        }
    }
}
