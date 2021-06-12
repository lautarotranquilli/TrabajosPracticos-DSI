using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP__4
{
    class RegPersonas
    {
        private List<Persona> personasRegistradas = new List<Persona>();

        internal List<Persona> PersonasRegistradas { get => personasRegistradas; set => personasRegistradas = value; }

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

        public void AutorizacionIngreso()
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
                        if (DateTime.Compare(personas.FechaAutorizacion, fechaActual) > 0)
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
                Console.WriteLine("La persona existe, está registrada, su actividad está autorizada y su fecha de autorizacion está en orden!\n");
            }

            else
            {
                if (personaAutorizadaVencida.Dni.Equals(dniPersonas))
                {
                    Console.WriteLine("La persona existe, está registrada, su actividad está autorizada pero su fecha de autorizacion está vencida!\n");
                }

                else
                {
                    if (personaNoAutorizada.Dni.Equals(dniPersonas))
                    {
                        Console.WriteLine("La persona existe, está registrada pero su actividad NO está autorizada!\n");
                    }

                    else
                    {
                        Console.WriteLine("La persona no existe.\n");
                    }
                }
            }
        }

        public void DarDeBaja()
        {
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
            }

            else
            {
                Console.WriteLine("Empleado NO existe.");
            }

        }
    }
}