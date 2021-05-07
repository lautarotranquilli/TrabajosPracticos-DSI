using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TP__4
{
    class Persona
    {
        private String nombreApellido;
        private Int32 dni;
        private String domicilio;
        private long telefono;
        private String email;
        private ActividadAutorizada actividad;

        public string NombreApellido { get => nombreApellido; set => nombreApellido = value; }

        public string Domicilio { get => domicilio; set => domicilio = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        internal ActividadAutorizada Actividad { get => actividad; set => actividad = value; }
        public Int32 Dni { get => dni; set => dni = value; }

        public Persona(ActividadAutorizada actividad)
        {
            this.actividad = actividad;
        }

        public void RegistrarPersona()
        {
            string linea;

            Console.Write("\nIngrese nombre y apellido de la persona: ");
            nombreApellido = Console.ReadLine();

            Console.Write("Ingrese DNI de la persona: ");
            linea = Console.ReadLine();
            dni = Int32.Parse(linea);

            Console.Write("Ingrese el domicilio de la persona: ");
            domicilio = Console.ReadLine();

            Console.Write("Ingrese el telefono de la persona: ");
            linea = Console.ReadLine();
            telefono = long.Parse(linea);

            Console.Write("Ingrese el email de la persona: ");
            email = Console.ReadLine();

            Console.WriteLine("Ingrese la actividad que realiza la persona\n");
            actividad.ListaActividades();

            Console.WriteLine("\n");
        }


        public void ToStringPersona()
        {
            Console.WriteLine("\nNombre y apellido: " + nombreApellido);
            Console.WriteLine("DNI: " + dni);
            Console.WriteLine("Domicilio: " + domicilio);
            Console.WriteLine("Telefono: " + telefono);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Actividad: " + actividad.Nombre);

            if (Actividad.Autorizacion == true)
            {
                Console.WriteLine("Persona autorizada para circular.");

            }

            else
            {
                Console.WriteLine("Persona no autorizada para circular.");
            }
        }
    }
}