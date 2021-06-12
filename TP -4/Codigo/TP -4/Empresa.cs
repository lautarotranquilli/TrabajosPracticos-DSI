using System;
using System.Collections.Generic;
using System.Text;

namespace TP__4
{
    class Empresa
    {
        private String razonSocial;
        private long cuit;
        private String domicilio;
        private String localidad;
        private String email;
        private long telefono;
        private List<Persona> personas;
        private ActividadAutorizada actividad;

        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public long Cuit { get => cuit; set => cuit = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string Email { get => email; set => email = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        internal List<Persona> Personas { get => personas; set => personas = value; }
        internal ActividadAutorizada Actividad { get => actividad; set => actividad = value; }

        public void RegistroEmpresa()
        {
            string linea;

            Console.Write("\nIngrese razon social de la empresa: ");
            razonSocial = Console.ReadLine();

            Console.Write("Ingrese CUIT de la empresa: ");
            linea = Console.ReadLine();
            cuit = Int32.Parse(linea);

            Console.Write("Ingrese el domicilio de la empresa: ");
            domicilio = Console.ReadLine();

            Console.Write("Ingrese la localidad de la empresa: ");
            localidad = Console.ReadLine();

            Console.Write("Ingrese el telefono de la empresa: ");
            linea = Console.ReadLine();
            telefono = long.Parse(linea);

            Console.Write("Ingrese el email de la empresa: ");
            email = Console.ReadLine();

            Console.WriteLine("\n");
        }

        public void ToStringEmpresa()
        {
            Console.WriteLine("\nRazon Social: " + razonSocial);
            Console.WriteLine("Cuit: " + cuit);
            Console.WriteLine("Domicilio: " + domicilio);
            Console.WriteLine("Localidad: " + localidad);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Telefono: " + telefono);
            Console.WriteLine("Actividad: " + actividad.Nombre);

        }
    }
}
