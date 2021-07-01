using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZXing;
using System.Drawing;

namespace TP__4
{
    class RegPersonas
    {
        private static List<Persona> personasRegistradas = new List<Persona>();
        private static List<Persona> personasIngresadas = new List<Persona>();

        internal static List<Persona> PersonasRegistradas { get => personasRegistradas; set => personasRegistradas = value; }
        internal static List<Persona> PersonasIngresadas { get => personasIngresadas; set => personasIngresadas = value; }

        public void AgregarPersona(Persona persona)
        {
            personasRegistradas.Add(persona);
        }

        public int CantidadPersonas()
        {
            return personasRegistradas.Count();
        }

        public void MuestreoPersonas()
        {
            for (int i = 0; i < personasRegistradas.Count; i++)
            {
                personasRegistradas[i].ToStringPersona();
            }
        }

        public void IngresarPersona(Persona personaIng)
        {
            personasIngresadas.Add(personaIng);
        }

        public int CantidadPersonasIng()
        {
            return personasIngresadas.Count();
        }

        public void MuestreoPersonasIng()
        {
            for (int i = 0; i < personasIngresadas.Count; i++)
            {
                personasIngresadas[i].ToStringPersona();
            }
        }


        public void AutorizacionIngreso(Persona personaAuto)
        {

            Console.Write("\tVERIFICACION DE PERSONA");

            Int32 dniPersonas;
            string linea;

            var personaAutorizadaOrden = new Persona();
            var personaAutorizadaVencida = new Persona();
            var personaNoAutorizada = new Persona();
            var personaNoExiste = new Persona();

            Console.Write("\n\nIngrese el DNI de la persona: ");
            linea = Console.ReadLine();
            dniPersonas = Int32.Parse(linea);

            foreach (var personas in personasRegistradas)
            {
                if (dniPersonas.Equals(personas.Dni))
                {
                    DateTime fechaActual;

                    fechaActual = DateTime.Today;

                    if (personas.Empresa.Actividad.Autorizacion == true)
                    {
                        if (DateTime.Compare(personas.FechaAutorizacion.AddDays(30), fechaActual) > 0)
                        {
                            personaAutorizadaOrden = personas;

                        }

                        else
                        {
                            personaAutorizadaVencida = personas;
                        }
                    }

                    else
                    {
                        personaNoAutorizada = personas;
                    }

                }

                else
                {
                    personaNoExiste = personas;
                }
            }

            if (personaAutorizadaOrden.Dni.Equals(dniPersonas))
            {
                Console.WriteLine("\nLa persona existe, está registrada, su actividad está autorizada y su fecha de autorizacion está en orden!\n");

                int opcion;
                string lineas;

                do
                {
                    Console.WriteLine("La persona está en un vehiculo?");
                    Console.WriteLine("1. Si");
                    Console.WriteLine("2. No");
                    lineas = Console.ReadLine();
                    opcion = int.Parse(lineas);

                    switch (opcion)
                    {
                        case 1:
                            Console.Write("\nIngrese la patente del vehiculo: ");
                            string patente = Console.ReadLine();
                            break;

                        case 2:
                            break;

                        default:
                            Console.WriteLine("\nError! Ingrese nuevamente.");
                            break;
                    }

                } while (opcion != 1 && opcion != 2);
                
                
                Console.Write("\nIngrese la temperatura registrada de la persona: ");
                linea = Console.ReadLine();
                decimal temperatura = decimal.Parse(linea);

                if (temperatura > 37)
                {
                    Console.WriteLine("\nSu temperatura es alta! NO PUEDE INGRESAR.");
                }

                else
                {
                    personasIngresadas.Add(personaAutorizadaOrden);

                    Console.WriteLine("\nSu temperatura es aceptada! PUEDE INGRESAR.");

                    Console.Write("\nLugar hacia donde se dirige: ");
                    string lugar = Console.ReadLine();
                }

                //Genero el codigo QR
                var qrcodeWriter = new BarcodeWriter();

                qrcodeWriter.Format = BarcodeFormat.QR_CODE;

                qrcodeWriter.Write("Autorizado").Save(@"C:\Users\lauti\Downloads\Autorizacion.jpg");

                Console.WriteLine("\nEl codigo QR fue generado!");
            }


            else
            {
                if (personaAutorizadaVencida.Dni.Equals(dniPersonas))
                {
                    Console.WriteLine("\nLa persona existe, está registrada, su actividad está autorizada pero su fecha de autorizacion está vencida!\n");
                }

                else
                {
                    if (personaNoAutorizada.Dni.Equals(dniPersonas))
                    {
                        Console.WriteLine("\nLa persona existe, está registrada pero su actividad NO está autorizada!\n");
                    }

                    else
                    {
                        Console.WriteLine("\nLa persona no existe.\n");                       
                    }
                }
            }
        }

        public void EgresoPersona()
        {

            Console.Write("\tREGISTRO DE SALIDA");

            Int32 dniRetiro;
            string linea;

            Console.Write("\nIngrese el DNI de la persona: ");
            linea = Console.ReadLine();
            dniRetiro = Int32.Parse(linea);

            var personaRetiro = new Persona();
            var personaNoIngreso = new Persona();

            foreach (var personas in personasIngresadas)
            {
                if (dniRetiro.Equals(personas.Dni))
                {
                    personaRetiro = personas;

                }

                else
                {
                    personaNoIngreso = personas;
                }

            }

            if (personaRetiro.Dni.Equals(dniRetiro))
            {
                Console.WriteLine("Se retira la persona: ");
                personaRetiro.ToStringPersona();

                DateTime fechaSalida = new DateTime();
                fechaSalida = DateTime.Now.AddHours(1);
                Console.WriteLine("Fecha y hora de salida: " + fechaSalida + "\n");

                personasIngresadas.Remove(personaRetiro);
            }

            else
            {
                Console.WriteLine("La persona no ingreso!");
            }
            

        }


        public void DarDeBaja()
        {
            Console.Write("\tBAJA DE EMPLEADO");

            Int32 dniEliminar;
            string linea;

            var bajaPersona = new Persona();

            Console.Write("\n\nIngrese el DNI de la persona a dar de baja: ");
            linea = Console.ReadLine();
            dniEliminar = Int32.Parse(linea);

            foreach (var persona in personasRegistradas)
            {

                if (dniEliminar.Equals(persona.Dni))
                {
                    bajaPersona = persona;

                }

            }

            if (dniEliminar == bajaPersona.Dni)
            {
                personasRegistradas.Remove(bajaPersona);

                Console.WriteLine("\nEmpleado fue dado de baja con exito!");
            }

            else
            {
                Console.WriteLine("\nEmpleado NO existe.");
            }

        }
    }
}