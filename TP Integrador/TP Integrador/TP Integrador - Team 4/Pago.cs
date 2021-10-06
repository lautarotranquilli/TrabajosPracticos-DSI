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

        public Pago(decimal monto, DateTime fecha, Tarjeta tarjeta, int codigoPagoEfectivo)
        {
            this.monto = monto;
            this.fecha = fecha;
            this.tarjetas = tarjeta;
            this.codigoPagoEfectivo = codigoPagoEfectivo;
        }

        public void PagoEnEfectivo()
        {
            metodo = MetodoPago.Efectivo;
        }

        public void ToStringPagoEnEfectivo()
        {

            Console.WriteLine("\n\t---DETALLE DEL PAGO---\n");
            Console.WriteLine("El monto es: " + monto);
            Console.WriteLine("Fecha: " + fecha.ToString("g"));
            Console.WriteLine("Usted eligio el metodo: " + metodo);
            Console.WriteLine("Su codigo para abonar es: " + codigoPagoEfectivo);
        }
    }
}

enum MetodoPago 
{
    Efectivo,
    Debito,
    Credito
}
