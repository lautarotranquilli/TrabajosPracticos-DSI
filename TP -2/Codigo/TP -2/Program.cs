using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabajoPractico2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Inscripcion> inscripciones = new List<Inscripcion>();

            DateTime fechaNacimiento1 = new DateTime(2000, 04, 18);
            DateTime fechaNacimiento2 = new DateTime(2000, 02, 18);
            DateTime fechaNacimiento3 = new DateTime(1998, 08, 12);
            DateTime fechaNacimiento4 = new DateTime(2000, 06, 01);

            Competidor competidor1 = new Competidor("Lautaro Tranquilli", 42638897, "lauti@gmail.com", 15608163, fechaNacimiento1, "A+", "Masculino");
            Competidor competidor2 = new Competidor("Lucia Perez", 42588789, "luci@gmail.com", 15124578, fechaNacimiento2, "A+", "Femenino");
            Competidor competidor3 = new Competidor("Mario Juarez", 40258741, "mario@gmail.com", 15784512, fechaNacimiento3, "A-", "Masculino");
            Competidor competidor4 = new Competidor("Martina Mare", 42123456, "martina@gmail.com", 15785634, fechaNacimiento4, "0+", "Femenino");

            Competencia competencia1 = new Competencia("10k Santa Fe", DateTime.Now.AddDays(10), DateTime.Now.AddDays(5), "Santa Fe", 10);

            TimeSpan time1 = new TimeSpan(01, 25, 36);
            TimeSpan time2 = new TimeSpan(00, 58, 25);
            TimeSpan time3 = new TimeSpan(02, 10, 20);
            TimeSpan time4 = new TimeSpan(00, 38, 17);
            TimeSpan time5 = new TimeSpan(10, 00, 00); //Ausentes.


            Inscripcion inscripcion1 = new Inscripcion(EstadoInscripcion.Participo, time1, competidor1, competencia1);
            //inscripcion1.ToStringInscripcion();
      
            Inscripcion inscripcion2 = new Inscripcion(EstadoInscripcion.Participo, time2, competidor2, competencia1);
            //inscripcion2.ToStringInscripcion();

            Inscripcion inscripcion3 = new Inscripcion(EstadoInscripcion.Participo, time3, competidor3, competencia1);
            //inscripcion3.ToStringInscripcion();

            Inscripcion inscripcion4 = new Inscripcion(EstadoInscripcion.Ausente, time5, competidor4, competencia1);
            //inscripcion4.ToStringInscripcion();

            inscripciones.Add(inscripcion1);
            inscripciones.Add(inscripcion2);
            inscripciones.Add(inscripcion3);
            inscripciones.Add(inscripcion4);

            List<Inscripcion> inscripcions = inscripciones.OrderBy(x => x.TiempoRegistrado).ToList();

            for (int i = 0; i < 3; i++)
            {
                Console.Write("\n\tPUESTO " + (i + 1).ToString());

                inscripcions[i].ToStringInscripcion();

            }//En este for lo que muestro son las 3 mejores inscripciones segun el tiempo en el que tardaron.

            for (int i = 0; i < inscripciones.Count; i++)
            {
                if (inscripciones[i].Estado == EstadoInscripcion.Ausente)
                {
                    Console.Write("\n\tPUESTO " + (i + 1).ToString());
                    inscripciones[i].ToStringInscripcion();
                }
                
            } //En este for lo que muestro son las inscripciones cuyo estado es igual a ausente.

        }
    }
}
