using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoPractico2
{
    class Competidor
    {
        private String nombreApellido;
        private int dni;
        private String email;
        private long telefono;
        private DateTime fechaNacimiento;
        private String grupoSanguineo;
        private String sexo;
        private List<Inscripcion> inscripciones;

        public string NombreApellido { get => nombreApellido; set => nombreApellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public string Email { get => email; set => email = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string GrupoSanguineo { get => grupoSanguineo; set => grupoSanguineo = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        internal List<Inscripcion> Inscripciones { get => inscripciones; set => inscripciones = value; }

        public Competidor(string nombreApellido, int dni, string email, long telefono, DateTime fechaNacimiento, string grupoSanguineo, string sexo)
        {
            this.nombreApellido = nombreApellido;
            this.dni = dni;
            this.email = email;
            this.telefono = telefono;
            this.fechaNacimiento = fechaNacimiento;
            this.grupoSanguineo = grupoSanguineo;
            this.sexo = sexo;
            inscripciones = new List<Inscripcion>();
        }

        public void ToStringCompetidor()
        {
            Console.WriteLine("\nDATOS DEL COMPETIDOR: \n");
            Console.WriteLine("Nombre y apellido: " + nombreApellido);
            Console.WriteLine("DNI: " + dni);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Telefono: " + telefono);
            Console.WriteLine("Fecha de nacimiento: " + fechaNacimiento.ToShortDateString());
            Console.WriteLine("Grupo sanguineo: " + grupoSanguineo);
            Console.WriteLine("Sexo: " + sexo);
        }
    }

}
