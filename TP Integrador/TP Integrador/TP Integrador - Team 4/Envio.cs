using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Integrador___Team_4
{
    class Envio
    {
        private DateTime fechaSalida;
        private DateTime fechaLlegada;
        private MetodoEnvio forma;
        private Domicilio domicilio;
        private Correo correo;
        private String nombreRecibe;
        private String dniRecibe;

        public DateTime FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public DateTime FechaLlegada { get => fechaLlegada; set => fechaLlegada = value; }
        public MetodoEnvio Forma { get => forma; set => forma = value; }
        public Domicilio Domicilio { get => domicilio; set => domicilio = value; }
        public Correo Correo { get => correo; set => correo = value; }
        public String NombreRecibe { get => nombreRecibe; set => nombreRecibe = value; }
        public String DniRecibe { get => dniRecibe; set => dniRecibe = value; }

        public void NuevoEnvio()
        {
            fechaSalida = DateTime.Now;
            fechaLlegada = fechaSalida.AddDays(7);
        }

        public void EnvioADomicilio(Domicilio domicilios)
        {
            forma = MetodoEnvio.Domicilio;
            domicilio = domicilios;
        }

        public void RetiroEnSucursal(Correo correos)
        {
            forma = MetodoEnvio.Correo;
            correo = correos;
        }

        public void RecibeEnvio()
        {
            Console.WriteLine("\nIngrese el nombre de quien recibe el envio: ");
            nombreRecibe = Console.ReadLine();

            Console.WriteLine("Ingrese su DNI: ");
            dniRecibe = Console.ReadLine();
        }


        public void ToStringEnvio()
        {
            Console.Clear();
            Console.WriteLine("\t---DETALLE DEL ENVIO---\n");
            Console.WriteLine("Fecha de salida: " + fechaSalida.ToString("g"));
            Console.WriteLine("Fecha de llegada: " + fechaLlegada.ToString("g"));

            if (forma == MetodoEnvio.Domicilio)
            {
                Console.WriteLine("\n\tDomicilio");
                domicilio.ToStringDomicilio();
            }

            if (forma == MetodoEnvio.Correo)
            {
                Console.WriteLine("\n\tCorreo");
                correo.ToStringCorreo();
            }

            Console.WriteLine("\nNombre de quien recibe: " + nombreRecibe);
            Console.WriteLine("\nDni de quien recibe: " + dniRecibe);
        }
    }
    
}

enum MetodoEnvio
{
    Correo,
    Domicilio
}