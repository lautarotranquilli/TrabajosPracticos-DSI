using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Integrador___Team_4
{
    public class Envio
    {
        private DateTime fechaSalida;
        private DateTime fechaLlegada;
        internal MetodoEnvio forma;
        private Domicilio domicilio;
        private Correo correo;
        private String nombreRecibe;
        private String dniRecibe;
        private decimal costo;

        public DateTime FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public DateTime FechaLlegada { get => fechaLlegada; set => fechaLlegada = value; }
        internal MetodoEnvio Forma { get => forma; set => forma = value; }
        public Domicilio Domicilio { get => domicilio; set => domicilio = value; }
        public Correo Correo { get => correo; set => correo = value; }
        public String NombreRecibe { get => nombreRecibe; set => nombreRecibe = value; }
        public String DniRecibe { get => dniRecibe; set => dniRecibe = value; }
        public decimal Costo { get => costo; set => costo = value; }

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

        public void PromocionesEnvio()
        {
            Console.WriteLine("\t---PROMOCIONES---\n");
            Console.WriteLine("Compras mayores a $5000, el envío es gratuito a sucursales de tu provincia.");
            Console.WriteLine("Compras mayores a $10000, el envío es gratuito a todo el país.");
        }

        public decimal CalcularCostoEnvio(decimal total, string provinciaCliente)
        {
            decimal costoEnvioDomicilio = 450.0M;
            decimal costoEnvioCorreo = 250.0M;

            if (forma == MetodoEnvio.Domicilio)
            {
                if (total >= 5000 || total >= 10000)
                {
                    costo = 0M;
                }

                else
                {
                    costo = costoEnvioDomicilio;
                }
            }

            else
            {
                if (total >= 10000 || (total >= 5000 && provinciaCliente == correo.Provincia))
                {
                    costo = 0M;
                }

                else
                {
                    costo = costoEnvioCorreo;
                }
            }

            return costo;
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
            Console.WriteLine("\nCosto del envio: $" + costo);

        }
    }
    
}

enum MetodoEnvio
{
    Correo,
    Domicilio
}