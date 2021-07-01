using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoPractico2
{
    class Inscripcion
    {
        private EstadoInscripcion estado;
        private TimeSpan tiempoRegistrado;
        private Competidor competidores;
        private Competencia competencias;


        public TimeSpan TiempoRegistrado { get => tiempoRegistrado; set => tiempoRegistrado = value; }
        internal EstadoInscripcion Estado { get => estado; set => estado = value; }

        public Inscripcion(EstadoInscripcion estado, TimeSpan tiempoRegistrado, Competidor competidores, Competencia competencias)
        {
            this.tiempoRegistrado = tiempoRegistrado;
            this.competidores = competidores;
            this.competencias = competencias;
            this.estado = estado;
        }


        public void ToStringInscripcion()
        {
            competidores.ToStringCompetidor();
            competencias.ToStringCompetencia();

            Console.WriteLine("\nRESULTADO INSCRIPCION:\n");
            Console.WriteLine("Tiempo registrado: " + tiempoRegistrado);
            Console.WriteLine("Estado inscripcion: " + estado);
        }
    }

    enum EstadoInscripcion
    {
        Inscripto,
        Participo,
        Ausente,
        Abandono
    }
}
