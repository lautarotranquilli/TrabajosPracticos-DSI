using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Integrador___Team_4
{
    class Pago
    {
        private decimal monto;
        private DateTime fecha;
        private MetodoPago metodo;
        private Tarjeta tarjetas;
        private int codigoPagoEfectivo;
        private List<Cuota> cuotas;

        public decimal Monto { get => monto; set => monto = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public MetodoPago Metodo { get => metodo; set => metodo = value; }
        public Tarjeta Tarjetas { get => tarjetas; set => tarjetas = value; }
        public int CodigoPagoEfectivo { get => codigoPagoEfectivo; set => codigoPagoEfectivo = value; }
        public List<Cuota> Cuotas { get => cuotas; set => cuotas = value; }

        public Pago(decimal monto, DateTime fecha, Tarjeta tarjetas)
        {
            this.monto = monto;
            this.fecha = fecha;
            this.tarjetas = tarjetas;
            this.codigoPagoEfectivo = new Random().Next(0,999999999);
            this.cuotas = new List<Cuota>();
        }

        public void PagoEnEfectivo()
        {
            metodo = MetodoPago.Efectivo;
        }

        public void PagoTarjetaDebito()
        {
            metodo = MetodoPago.Debito;
        }

        public void PagoTarjetaCredito()
        {
            int opcion;
            metodo = MetodoPago.Credito;

            do
            {
                Console.WriteLine("Seleccione la cantidad de cuotas a pagar: ");
                Console.WriteLine("1. 1 cuota de $: " + monto);
                Console.WriteLine("2. 3 cuotas de $: " + (monto / 3) * 1.05M);        //Interes del 5%
                Console.WriteLine("3. 6 cuotas de $: " + (monto / 6) * 1.10M);        //Interes del 10%
                Console.WriteLine("4. 12 cuotas de $: " + (monto / 12) * 1.15M);      //Interes del 15%
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Cuota cuotaUno = new Cuota(monto, fecha, true);
                        cuotas.Add(cuotaUno);

                        break;

                    case 2:
                        decimal cadaCuotaTres;

                        for (int i = 0; i < 3; i++)
                        {
                            cadaCuotaTres = (monto / 3) * 1.05M;

                            Cuota cuotaTres = new Cuota(cadaCuotaTres, fecha, true);
                            cuotas.Add(cuotaTres);
                        }

                        break;

                    case 3:
                        decimal cadaCuotaSeis;

                        for (int i = 0; i < 6; i++)
                        {
                            cadaCuotaSeis = (monto / 6) * 1.10M;

                            Cuota cuotaSeis = new Cuota(cadaCuotaSeis, fecha, true);
                            cuotas.Add(cuotaSeis);
                        }

                        break;

                    case 4:
                        decimal cadaCuotaDoce;

                        for (int i = 0; i < 12; i++)
                        {
                            cadaCuotaDoce = (monto / 12) * 1.15M;

                            Cuota cuotaDoce = new Cuota(cadaCuotaDoce, fecha, true);
                            cuotas.Add(cuotaDoce);

                        }

                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta. Ingrese nuevamente!");
                        break;
                }

            } while (opcion != 1 && opcion != 2 && opcion != 3 && opcion != 4);
        }

        public void ToStringPagoEnEfectivo()
        {
            Console.WriteLine("\n\t---DETALLE DEL PAGO---\n");
            Console.WriteLine("El monto es: " + monto);
            Console.WriteLine("Fecha: " + fecha.ToString("g"));
            Console.WriteLine("Usted eligio el metodo: " + metodo);
            Console.WriteLine("Su codigo para abonar es: " + codigoPagoEfectivo);
        }

        public void ToStringPagoTarjetaDebito()
        {
            Console.WriteLine("\n\t---DETALLE DEL PAGO---\n");
            Console.WriteLine("El monto es: 1 cuota de " + monto);
            Console.WriteLine("Fecha: " + fecha.ToString("g"));
            Console.WriteLine("Usted eligio el metodo: " + metodo);
            Console.WriteLine("Tarjeta utilizada: ");
            tarjetas.ToStringTarjeta();
        }

        public void ToStringPagoTarjetaCredito(decimal montoTotal)
        {
            Console.WriteLine("\n\t---DETALLE DEL PAGO---\n");
            
            if (cuotas.Count == 1)
            {
                Console.WriteLine("El monto es: 1 cuota de $" + monto);
            }
            else if (cuotas.Count == 3)
            {
                Console.WriteLine("El monto es: 3 cuotas de $" + (monto / 3) * 1.05M);
            }
            else if (cuotas.Count == 6)
            {
                Console.WriteLine("El monto es: 6 cuotas de $" + (monto / 6) * 1.10M);
            }
            else 
            {
                Console.WriteLine("El monto es: 12 cuotas de $" + (monto / 12) * 1.15M);
            }
            
            Console.WriteLine("Fecha: " + fecha.ToString("g"));
            Console.WriteLine("Usted eligio el metodo: " + metodo);
            Console.WriteLine("El monto total a pagar es: " + montoTotal);
            Console.WriteLine("\t\nTarjeta utilizada");
            tarjetas.ToStringTarjeta();

        }
    }
}

enum MetodoPago 
{
    Efectivo,
    Debito,
    Credito
}
