using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Integrador___Team_4
{
    class Correo
    {
        private String nombre;
        private String domicilio;
        private String ciudad;
        private String provincia;
        private String telefono;
        private List<Envio> envios;

        public String Nombre { get => nombre; set => nombre = value; }
        public String Domicilio { get => domicilio; set => domicilio = value; }
        public String Ciudad { get => ciudad; set => ciudad = value; }
        public String Provincia { get => provincia; set => provincia = value; }
        public String Telefono { get => telefono; set => telefono = value; }
        public List<Envio> Envios { get => envios; set => envios = value; }

        public Correo(string nombre, string domicilio, string ciudad, string provincia, string telefono)
        {
            this.nombre = nombre;
            this.domicilio = domicilio;
            this.ciudad = ciudad;
            this.provincia = provincia;
            this.telefono = telefono;
            this.envios = new List<Envio>();
        }

        public void AgregarEnvio(Envio envio)
        {
            envios.Add(envio);
        }

        public void ToStringCorreo()
        {
            Console.WriteLine("\nNombre del correo: " + nombre);
            Console.WriteLine("\nDomicilio: " + domicilio);
            Console.WriteLine("\nCiudad: " + ciudad);
            Console.WriteLine("\nProvincia: " + provincia);
            Console.WriteLine("\nTelefono: " + telefono);
        }
    }
}
