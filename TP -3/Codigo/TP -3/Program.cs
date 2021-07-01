using System;
using System.Collections;
using System.Collections.Generic;

namespace TP__3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creo una lista donde se van a guardar todas las cotizaciones.

            List<Cotizacion> cotizaciones = new List<Cotizacion>();
            
            //Instancia de dos clientes.

            Cliente cliente1 = new Cliente("Lautaro Tranquilli", "El Norte", "Cabrera 3139", "lauti@gmail.com", 15223344);
            Cliente cliente2 = new Cliente("Carlos Perez", "Akron", "Lima 821", "carlos@gmail.com", 15123456);

            //Instancia de dos materiales aislantes.

            MaterialAislante material1 = new MaterialAislante("Lana de vidrio", 150);
            MaterialAislante material2 = new MaterialAislante("Espuma", 230);

            //Instancia de lista de espesor de aplicacion segun precios por metro cuadrado.

            Espesor espesor1 = new Espesor(50, 53.60);
            Espesor espesor2 = new Espesor(70, 87.00);
            Espesor espesor3 = new Espesor(100, 117.49);
            Espesor espesor4 = new Espesor(120, 128.48);
            Espesor espesor5 = new Espesor(160, 143.05);
            Espesor espesor6 = new Espesor(200, 180.79);

            //Instancia de dos cotizaciones para luego mostrarlas en pantalla.

            Cotizacion cotizacion1 = new Cotizacion(120, cliente1, espesor2, material2);
            cotizacion1.ToStringCotizacion();

            Cotizacion cotizacion2 = new Cotizacion(3, cliente2, espesor6, material1);
            cotizacion2.ToStringCotizacion();

            //Agrego a la lista cotizaciones las cotizaciones anteriormente instanciadas.

            cotizaciones.Add(cotizacion1);
            cotizaciones.Add(cotizacion2);

        }
    }
}
