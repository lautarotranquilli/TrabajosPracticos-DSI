using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoPractico2
{
    class Competencia
    {
        private String nombre;
        private DateTime fecha;
        private DateTime fechaLimite;
        private String lugar;
        private decimal distanciaRecorrer;
        private List<Inscripcion> inscripciones;

        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime FechaLimite { get => fechaLimite; set => fechaLimite = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public decimal DistanciaRecorrer { get => distanciaRecorrer; set => distanciaRecorrer = value; }
        internal List<Inscripcion> Inscripciones { get => inscripciones; set => inscripciones = value; }

        public Competencia(string nombre, DateTime fecha, DateTime fechaLimite, string lugar, decimal distanciaRecorrer)
        {
            this.nombre = nombre;
            this.fecha = fecha;
            this.fechaLimite = fechaLimite;
            this.lugar = lugar;
            this.distanciaRecorrer = distanciaRecorrer;
            inscripciones = new List<Inscripcion>();
        }

        public void ToStringCompetencia()
        {
            Console.WriteLine("\nDATOS DE LA COMPETENCIA: \n");
            Console.WriteLine("Nombre: " + nombre);
            DateTime fecha = new DateTime(2021, 05, 02);
            Console.WriteLine("Fecha: " + fecha.ToShortDateString());
            DateTime fechaLimite = fecha.AddDays(-7);
            Console.WriteLine("Fecha Limite: " + fechaLimite.ToShortDateString());
            Console.WriteLine("Lugar: " + lugar);
            Console.WriteLine("Distancia a recorrer: " + distanciaRecorrer + " kilometros.");

        }
    }
}
