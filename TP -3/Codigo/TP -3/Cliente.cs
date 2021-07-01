using System;
using System.Collections.Generic;
using System.Text;

namespace TP__3
{
    class Cliente
    {
        private String nombreApellido;
        private String empresa;
        private String domicilioObra;
        private String email;
        private long telefono;
        private List<Cotizacion> cotizaciones;

        public string NombreApellido { get => nombreApellido; set => nombreApellido = value; }
        public string Empresa { get => empresa; set => empresa = value; }
        public string DomicilioObra { get => domicilioObra; set => domicilioObra = value; }
        public string Email { get => email; set => email = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        internal List<Cotizacion> Cotizaciones { get => cotizaciones; set => cotizaciones = value; }

        public Cliente(string nombreApellido, string empresa, string domicilioObra, string email, long telefono)
        {
            this.nombreApellido = nombreApellido;
            this.empresa = empresa;
            this.domicilioObra = domicilioObra;
            this.email = email;
            this.telefono = telefono;
        }

        public void ToStringCliente()
        {
            Console.WriteLine("Cliente: " + nombreApellido + ".");
            Console.WriteLine("Empresa: " + empresa + ".");
            Console.WriteLine("Domicilio de la obra: " + domicilioObra + ".");
            Console.WriteLine("Email: " + email + ".");
            Console.WriteLine("Telefono: " + telefono + ".");

        }


    }
}
