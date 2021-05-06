using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TP__4
{
    class ActividadAutorizada
    {
        private String nombre;
        private Boolean autorizacion;
        private List<Persona> personas;

        public bool Autorizacion { get => autorizacion; set => autorizacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        internal List<Persona> Personas { get => personas; set => personas = value; }

        public ActividadAutorizada(string nombre)
        {
            this.nombre = nombre;
        }

        public void ListaActividades()
        {
            int opcion;
            string i;

            do
            {
                Console.WriteLine("Lista de actividades autorizadas\n");
                Console.WriteLine("1. Deportes");
                Console.WriteLine("2. Religion");
                Console.WriteLine("3. Educacion");
                Console.WriteLine("4. Politica");
                Console.WriteLine("5. Otra");
                Console.Write("\nElija una opcion: ");
                i = Console.ReadLine();
                opcion = int.Parse(i);

                switch (opcion)
                {
                    case 1:
                        autorizacion = true;
                        nombre = "Deportes";
                        break;

                    case 2:
                        autorizacion = true;
                        nombre = "Religion";
                        break;

                    case 3:
                        autorizacion = true;
                        nombre = "Educacion";
                        break;

                    case 4:
                        autorizacion = true;
                        nombre = "Politica";
                        break;

                    case 5:
                        autorizacion = false;
                        nombre = "Otra";
                        break;

                    default:
                        Console.WriteLine("\nOpcion incorrecta, ingrese nuevamente la actividad.\n");
                        break;

                } 
            } while (opcion < 0 || opcion > 5);

        }
    }
}
