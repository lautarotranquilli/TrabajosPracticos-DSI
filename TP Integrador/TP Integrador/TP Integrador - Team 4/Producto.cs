using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Integrador___Team_4
{
    class Producto
    {
        private String nombre;
        private String descripcion;
        private decimal precio;
        private Pedido pedidos;

        public String Nombre { get => nombre; set => nombre = value; }
        public String Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public Pedido Pedidos { get => pedidos; set => pedidos = value; }

        public Producto(string nombre, string descripcion, decimal precio)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public void ToStringProducto()
        {
            Console.WriteLine("\nNombre: " + nombre);
            Console.WriteLine("Descripcion: " + descripcion);
            Console.WriteLine("Precio: " + precio);

        }
    }
}
