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

        public void BuscarDni()
        {
            Int32 dniPersonas;
            string linea;

            Console.Write("\n\nIngrese el DNI de la persona: ");
            linea = Console.ReadLine();
            dniPersonas = Int32.Parse(linea);

            foreach (var personas in personasRegistradas)
            {
                if (dniPersonas.Equals(personas.Dni))
                {
                    if (personas.Actividad.Autorizacion == true)
                    {
                        Console.WriteLine("LA PERSONA EXISTE, ESTA AUTORIZADA Y REGISTRADA.\n");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("LA PERSONA EXISTE PERO NO ESTA AUTORIZADA.\n");
                        break;
                    }

                }

                else
                {
                    if (personas.Actividad.Autorizacion == false)
                    {
                        Console.WriteLine("LA PERSONA NO EXISTE.\n");
                        break;
                    }
                }
            }

        }
    }
}