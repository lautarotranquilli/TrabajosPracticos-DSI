using System;
using System.Collections.Generic;
using TP_Integrador___Team_4;
using Xunit;

namespace TestsProject
{
    public class UnitTest1
    {
        [Fact]
        public void VerificarMontoTotal()
        {
            Producto producto1 = new Producto("Mate120", "Mate de vidrio", 2520.0M);
            Producto producto2 = new Producto("Mate360", "Mate de madera", 1260.0M);

            decimal total = producto1.Precio + producto2.Precio;

            Assert.Equal(3780.0M, total);
        }

        [Fact]
        public void AgregarProductos()
        {
            List<Producto> productos = new List<Producto>();

            Producto producto1 = new Producto("Mate120", "Mate de vidrio", 2520.0M);
            Producto producto2 = new Producto("Mate360", "Mate de madera", 1260.0M);

            productos.Add(producto1);
            productos.Add(producto2);

            Assert.Equal(2, productos.Count);


        }

        [Fact]
        public void VerificarCodigoPagoEnEfectivo()
        {
            Pedido pedido = new Pedido(7750.0M, DateTime.Now);
            Pago pago = new Pago(pedido.MontoFinal, DateTime.Now, null);

            int codigo = pago.PagoEnEfectivo();

            Assert.NotEqual(0M, codigo);
        }

        [Fact]
        public void VerificarCostoEnvioConMontoAlto_MismaProvincia()
        {
            Pedido pedido = new Pedido(7750.0M, DateTime.Now);
            Envio envio = new Envio();
            Cliente cliente = new Cliente("Nicolas Martinez", "35850255", "Cordoba");
            Correo correo = new Correo("Andreani", "Salta 1250", "San Francisco", "Cordoba", "3564123456");

            envio.RetiroEnSucursal(correo);

            decimal costoEnvio = envio.CalcularCostoEnvio(pedido.MontoFinal, cliente.Provincia);

            Assert.Equal(0M, costoEnvio);
        }

        [Fact]
        public void VerificarCostoEnvioConMontoAlto_DistintaProvincia()
        {
            Pedido pedido = new Pedido(7750.0M, DateTime.Now);
            Envio envio = new Envio();
            Cliente cliente = new Cliente("Maria Casas", "22159753", "Santa Fe");
            Correo correo = new Correo("OCA", "Peru 580", "San Francisco", "Cordoba", "3564112233");

            envio.RetiroEnSucursal(correo);

            decimal costoEnvio = envio.CalcularCostoEnvio(pedido.MontoFinal, cliente.Provincia);

            Assert.NotEqual(0M, costoEnvio);
        }

        [Fact]
        public void VerificarCostoEnvioConMontoBajo()
        {
            Pedido pedido = new Pedido(2550.0M, DateTime.Now);
            Envio envio = new Envio();
            Cliente cliente = new Cliente("Lautaro Tranquilli", "42000111", "Cordoba");
            Correo correo = new Correo("Andreani", "Salta 1250", "San Francisco", "Cordoba", "3564123456");

            envio.RetiroEnSucursal(correo);

            decimal costoEnvio = envio.CalcularCostoEnvio(pedido.MontoFinal, cliente.Provincia);

            Assert.Equal(250.0M, costoEnvio);
        }

        [Fact]
        public void VerificarCostoEnvioConMontoAlto()
        {
            Pedido pedido = new Pedido(12860.0M, DateTime.Now);
            Envio envio = new Envio();
            Cliente cliente = new Cliente("Mariano Perez", "42012345", "Cordoba");
            Correo correo = new Correo("OCA", "Peru 580", "San Francisco", "Cordoba", "3564112233");

            envio.RetiroEnSucursal(correo);

            decimal costoEnvio = envio.CalcularCostoEnvio(pedido.MontoFinal, cliente.Provincia);

            Assert.Equal(0M, costoEnvio);
        }
    }
}
