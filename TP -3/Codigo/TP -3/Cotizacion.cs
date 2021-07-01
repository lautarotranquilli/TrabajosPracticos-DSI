using System;
using System.Collections.Generic;
using System.Text;

namespace TP__3
{
    class Cotizacion
    {
        private DateTime fecha;
        private DateTime fechaVenc;
        private double precioTotal;
        private double metrosCuadrados;
        private int cantBolsas;
        private Cliente cliente;
        private Espesor espesor;
        private MaterialAislante materialAislante;

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime FechaVenc { get => fechaVenc; set => fechaVenc = value; }
        public double PrecioTotal { get => precioTotal; set => precioTotal = value; }
        public double MetrosCuadrados { get => metrosCuadrados; set => metrosCuadrados = value; }
        public int CantBolsas { get => cantBolsas; set => cantBolsas = value; }
        internal Cliente Cliente { get => cliente; set => cliente = value; }
        internal Espesor Espesor { get => espesor; set => espesor = value; }
        internal MaterialAislante MaterialAislante { get => materialAislante; set => materialAislante = value; }

        public Cotizacion(double metrosCuadrados, Cliente cliente, Espesor espesor, MaterialAislante materialAislante)
        {
            this.fecha = DateTime.Now;
            this.fechaVenc = fecha.AddDays(30);
            this.metrosCuadrados = metrosCuadrados;
            this.cliente = cliente;
            this.espesor = espesor;
            this.materialAislante = materialAislante;
        }

        public void calculoBolsas()
        {
            if (metrosCuadrados <= 4.5)
            {
                cantBolsas = 1;
            }

            else
            {
                cantBolsas = (int)(metrosCuadrados / (espesor.NumEspesor * 4.5 / 100));
            }
        }

        public void ToStringCotizacion()
        {
            
            Console.WriteLine("\n\t-----COTIZACION-----\n");


            Console.WriteLine("Fecha de emision: " + fecha);
            Console.WriteLine("Fecha de vencimiento: " + fechaVenc);

            Console.WriteLine("\nDatos del cliente\n");
            cliente.ToStringCliente();

            Console.WriteLine("\nDatos del material\n");
            materialAislante.ToStringMaterial();

            Console.WriteLine("\nMetros cuadrados a cubrir: " + metrosCuadrados + " metros cuadrados.");

            Console.WriteLine("\nDatos del espesor\n");
            espesor.ToStringEspesor();

            calculoBolsas();
            Console.WriteLine("\nCantidad de bolsas: " + cantBolsas);

            precioTotal = espesor.precioAplicacion(metrosCuadrados) + (cantBolsas * materialAislante.CostoBolsa);

            Console.WriteLine("\nPRECIO TOTAL: $" + precioTotal);

        }
    }
}
