using System;
using System.Collections.Generic;
using System.Text;

namespace TP__3
{
    class Espesor
    {
        private int numEspesor;
        private double precioEspesor;
        private List<Cotizacion> cotizaciones;

        public int NumEspesor { get => numEspesor; set => numEspesor = value; }
        public double PrecioEspesor { get => precioEspesor; set => precioEspesor = value; }
        internal List<Cotizacion> Cotizaciones { get => cotizaciones; set => cotizaciones = value; }

        public Espesor(int cantEspesor, double precioEspesor)
        {
            this.numEspesor = cantEspesor;
            this.precioEspesor = precioEspesor;
        }

        public double precioAplicacion(double metrosCuadrados)
        {
            double precAplic;

            switch (numEspesor)
            {
                case 50:
                    precAplic = 53.60 * metrosCuadrados;
                    return precAplic;

                case 70:
                    precAplic = 87.00 * metrosCuadrados;
                    return precAplic;

                case 100:
                    precAplic = 117.49 * metrosCuadrados;
                    return precAplic;

                case 120:
                    precAplic = 128.48 * metrosCuadrados;
                    return precAplic;

                case 160:
                    precAplic = 143.05 * metrosCuadrados;
                    return precAplic;

                case 200:
                    precAplic = 180.79 * metrosCuadrados;
                    return precAplic;

                default:
                    return 0;
            }
        }

        public void ToStringEspesor()
        {
            Console.WriteLine("Espesor: " + numEspesor + " mm.");
            Console.WriteLine("Precio: $" + precioEspesor + ".");
        }

    }
}
