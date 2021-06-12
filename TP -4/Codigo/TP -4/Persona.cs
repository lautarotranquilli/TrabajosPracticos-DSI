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
        private DateTime fechaAutorizacion;
        private Empresa empresa;

        public string NombreApellido { get => nombreApellido; set => nombreApellido = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public Int32 Dni { get => dni; set => dni = value; }
        public DateTime FechaAutorizacion { get => fechaAutorizacion; set => fechaAutorizacion = value; }
        internal Empresa Empresa { get => empresa; set => empresa = value; }

        public void RegistroPersona()
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
        }

        public void ToStringPersona()
        {
            Console.WriteLine("\nNombre y apellido: " + nombreApellido);
            Console.WriteLine("DNI: " + dni);
            Console.WriteLine("Domicilio: " + domicilio);
            Console.WriteLine("Telefono: " + telefono);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Empresa: " + empresa.RazonSocial);
            Console.WriteLine("Fecha de autorizacion: " + fechaAutorizacion.ToShortDateString());
            Console.WriteLine("\n");
        }
    }
}