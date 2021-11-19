using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Integrador___Team_4
{
    public class Pedido
    {
        private decimal montoFinal;
        private DateTime fecha;
        private Cliente clientes;
        private List<Producto> productos;
        private Pago pagos;

        public decimal MontoFinal { get => montoFinal; set => montoFinal = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Cliente Clientes { get => clientes; set => clientes = value; }
        public List<Producto> Productos { get => productos; set => productos = value; }
        public Pago Pagos { get => pagos; set => pagos = value; }

        public Pedido(decimal montoFinal, DateTime fecha)
        {
            this.montoFinal = montoFinal;
            this.Fecha = fecha;
        }

        public void ToStringPedido(Cliente cliente, List<Producto> productos, Pago pago)
        {
            Console.WriteLine("\n\t---DETALLE DEL PEDIDO---\n");
            Console.WriteLine("\tProductos");
            for (int i = 0; i < productos.Count; i++)
            {
                productos[i].ToStringProducto();
            }

            clientes = cliente;
            Console.WriteLine("\nCliente\n");
            cliente.ToStringCliente();

            Console.WriteLine("\nMonto total: " + montoFinal);
            Console.WriteLine("Fecha: " + fecha);

            if (pago.Metodo == MetodoPago.Efectivo)
            {
                pago.ToStringPagoEnEfectivo();
            }

            else if (pago.Metodo == MetodoPago.Debito)
            {
                pago.ToStringPagoTarjetaDebito();
            }

            else
            {
                if (pago.Cuotas.Count == 1)
                {
                    pago.ToStringPagoTarjetaCredito(montoFinal);
                }
                else if (pago.Cuotas.Count == 3)
                {
                    pago.ToStringPagoTarjetaCredito(montoFinal * 1.05M);
                }
                else if (pago.Cuotas.Count == 6)
                {
                    pago.ToStringPagoTarjetaCredito(montoFinal * 1.10M);
                }
                else
                {
                    pago.ToStringPagoTarjetaCredito(montoFinal * 1.15M);
                }
            }
        }
    }
}
