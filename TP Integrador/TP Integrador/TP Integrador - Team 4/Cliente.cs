using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Integrador___Team_4
{
    class Cliente
    {


        private String nombre; 
        private String dni;
        private List<Domicilio> domicilios;
        private List<Pedido> pedidos;
        private List<Tarjeta> tarjetas;

        public String Nombre { get => nombre;  set => nombre = value; }
        public String Dni { get => dni; set => dni = value; }
        public List<Domicilio> Domicilios { get => domicilios; set => domicilios = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }
        public List<Tarjeta> Tarjeta { get => tarjetas; set => tarjetas = value; }


        public Cliente()
        {
            this.tarjetas = new List<Tarjeta>();
            this.pedidos = new List<Pedido>();
            this.domicilios = new List<Domicilio>();
        }

        public Cliente(string nombre, string dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.tarjetas = new List<Tarjeta>();
            this.pedidos = new List<Pedido>();
            this.domicilios = new List<Domicilio>();
        }

        public void NuevoCliente()
        {
            Console.WriteLine("Ingrese el nombre: ");
            nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el DNI: ");
            dni = Console.ReadLine();
        }

        public void AgregarDomicilio(Domicilio domicilio)
        {

            domicilios.Add(domicilio);
        }

        public void AgregarTarjeta(Tarjeta tarjeta)
        {

            tarjetas.Add(tarjeta);
        }

        public void AgregarPedido(Pedido pedido)
        {

            pedidos.Add(pedido);
        }

        public void ToStringCliente()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("DNI: " + dni);
        }
    }
}
