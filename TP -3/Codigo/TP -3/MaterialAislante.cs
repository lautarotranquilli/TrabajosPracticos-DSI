using System;
using System.Collections.Generic;
using System.Text;

namespace TP__3
{
    class MaterialAislante
    {
        private String tipo;
        private double costoBolsa;
        private List<Cotizacion> cotizaciones;

        public string Tipo { get => tipo; set => tipo = value; }
        public double CostoBolsa { get => costoBolsa; set => costoBolsa = value; }
        internal List<Cotizacion> Cotizaciones { get => cotizaciones; set => cotizaciones = value; }

        public MaterialAislante(String tipo, double costoBolsa)
        {
            this.tipo = tipo;
            this.costoBolsa = costoBolsa;
        }

        public void ToStringMaterial()
        {
            Console.WriteLine("Tipo de material: " + tipo + ".");
            Console.WriteLine("Costo por bolsa: $" + costoBolsa + ".");
        }
    }
}
