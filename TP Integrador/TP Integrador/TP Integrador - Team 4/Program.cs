using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TP_Integrador___Team_4
{
    public class Program
    {
        static List<Producto> productos = new List<Producto>();

        static void Main(string[] args)
        {
            Pedido pedido = DeserializarCarritoDTO();
            Cliente cliente = DeserializarClienteDTO();
            pedido.Clientes = cliente;

            int opcion;
            string linea;
            
            do 
            {
                Console.WriteLine("\t---mateAR---\n");
                Console.WriteLine("¿Desea confirmar la compra?");
                Console.WriteLine("1. Confirmar.");
                Console.WriteLine("2. Cancelar.");
                linea = Console.ReadLine();
                opcion = int.Parse(linea);
                Console.Clear();
           
                switch (opcion)
                {
                    case 1:
                        SeleccionarMetodoDePago();
                        break;

                    case 2:
                        Console.WriteLine("\nOperacion cancelada.");
                        //Vuelve al carrito de compras
                        break;

                    default:
                        Console.WriteLine("\nOpcion incorrecta. Ingrese nuevamente!\n");
                        break;
                }

            } while (opcion != 1 && opcion != 2);
        }

        public static void SeleccionarMetodoDePago()
        {
            int opcionPago;
            string linea;
            decimal total = 0M;

            DateTime vencimiento1 = new DateTime(2023, 12, 20);
            DateTime vencimiento2 = new DateTime(2024, 08, 12);
            DateTime fechaPedido = DateTime.Now;

            Cliente cliente1 = new Cliente("Lautaro Tranquilli", "42000111", "Cordoba");
            Cliente cliente2 = new Cliente("Maria Casas", "22159753", "Santa Fe");

            Producto producto1 = new Producto("Mate120", "Mate de vidrio", 2520.0M);
            Producto producto2 = new Producto("Mate360", "Mate de madera", 7260.0M);

            total = producto1.Precio + producto2.Precio;

            Pedido pedido = new Pedido(total, fechaPedido);

            productos.Add(producto1);
            productos.Add(producto2);

            do
            {
                Console.WriteLine("Seleccionar forma de pago: ");
                Console.WriteLine("1. Efectivo.");
                Console.WriteLine("2. Tarjeta de Debito.");
                Console.WriteLine("3. Tarjeta de Credito.");
                Console.WriteLine("4. Cancelar.");
                linea = Console.ReadLine();
                opcionPago = int.Parse(linea);
                Console.Clear();

                switch (opcionPago)
                {
                    case 1:
                        Pago pagoEfectivo = new Pago(total, fechaPedido, null);
                        Cliente cliente3 = new Cliente("Nicolas Martinez", "35850255", "Cordoba");

                        pagoEfectivo.PagoEnEfectivo();

                        SeleccionarMetodoDeEnvio(pedido,cliente3,pagoEfectivo);

                        break;

                    case 2:
                        int opcion;

                        Tarjeta tarjeta1 = new Tarjeta("123456789", "Lautaro Tranquilli", 42000111, "Santander Rio", vencimiento1, 123, TipoTarjeta.Debito, cliente1);
                        cliente1.AgregarTarjeta(tarjeta1);

                        do
                        {
                            Console.WriteLine("¿Desea usar la tarjeta registrada? A continuacion, las tarjetas de debito registradas: ");
                            tarjeta1.ToStringTarjeta();
                            Console.WriteLine("\n1. Si.");
                            Console.WriteLine("2. No. Deseo agregar una nueva.");
                            opcion = int.Parse(Console.ReadLine());
                            Console.Clear();

                            if (opcion == 1)
                            {
                                Pago pagoConDebito = new Pago(total,fechaPedido,tarjeta1);

                                pagoConDebito.PagoTarjetaDebito();
                                
                                SeleccionarMetodoDeEnvio(pedido,cliente1,pagoConDebito);
                            }

                            else if (opcion == 2)
                            {
                                Cliente clienteNuevo = new Cliente();
                                Tarjeta tarjetaNueva = new Tarjeta(clienteNuevo);

                                tarjetaNueva.NuevaTarjeta();

                                Pago pagoTarjetaNueva = new Pago(total, fechaPedido, tarjetaNueva);

                                pagoTarjetaNueva.PagoTarjetaDebito();

                                SeleccionarMetodoDeEnvio(pedido,clienteNuevo,pagoTarjetaNueva);
                            }

                            else
                            {
                                Console.WriteLine("\nOpcion incorrecta, ingrese nuevamente.");
                            }

                        } while (opcion != 1 && opcion != 2);

                        break;

                    case 3:
                        Tarjeta tarjeta2 = new Tarjeta("987654321", "Mario Tranquilli", 18222333, "Macro", vencimiento2, 456, TipoTarjeta.Credito, cliente2);
                        cliente2.AgregarTarjeta(tarjeta2);

                        do
                        {
                            Console.WriteLine("¿Desea usar la tarjeta registrada? A continuacion, las tarjetas de credito registradas: ");
                            tarjeta2.ToStringTarjeta();
                            Console.WriteLine("\n1. Si.");
                            Console.WriteLine("2. No. Deseo agregar una nueva.");
                            opcion = int.Parse(Console.ReadLine());
                            Console.Clear();

                            if (opcion == 1)
                            {
                                Pago pagoConCredito = new Pago(total, fechaPedido, tarjeta2);

                                pagoConCredito.PagoTarjetaCredito();

                                SeleccionarMetodoDeEnvio(pedido,cliente2,pagoConCredito);
                            }

                            else if (opcion == 2)
                            {
                                Cliente clienteNuevo = new Cliente();
                                Tarjeta tarjetaNueva = new Tarjeta(clienteNuevo);

                                tarjetaNueva.NuevaTarjeta();

                                Pago pagoTarjetaNueva = new Pago(total, fechaPedido, tarjetaNueva);

                                pagoTarjetaNueva.PagoTarjetaCredito();

                                SeleccionarMetodoDeEnvio(pedido,clienteNuevo,pagoTarjetaNueva);
                            }

                            else
                            {
                                Console.WriteLine("\nOpcion incorrecta, ingrese nuevamente.");
                            }

                        } while (opcion != 1 && opcion != 2);

                        break;

                    case 4:
                        Console.WriteLine("\nOperacion cancelada.");
                        break;

                    default:
                        Console.WriteLine("\nOpcion incorrecta. Ingrese nuevamente!\n");
                        break;
                
                }

            } while (opcionPago != 1 && opcionPago != 2 && opcionPago != 3 && opcionPago != 4);

        }

        public static void SeleccionarMetodoDeEnvio(Pedido pedido, Cliente cliente, Pago pago)
        {
            Envio envio = new Envio();

            envio.NuevoEnvio();
            envio.PromocionesEnvio();

            string linea;
            int opcionEnvio;

            do
            {
                Console.WriteLine("\nSeleccionar metodo de envio: ");
                Console.WriteLine("1. Envio a domicilio.");
                Console.WriteLine("2. Retiro en sucursal.");
                Console.WriteLine("3. Cancelar.");
                linea = Console.ReadLine();
                opcionEnvio = int.Parse(linea);
                Console.Clear();

                switch (opcionEnvio)
                {
                    case 1:
                        Cliente clienteNuevo = new Cliente();
                        Domicilio domicilio = new Domicilio();

                        domicilio.NuevoDomicilio();
                        clienteNuevo.AgregarDomicilio(domicilio);
                        envio.EnvioADomicilio(domicilio);
                        

                        break;

                    case 2:
                        int opcionCorreo;

                        Correo correo1 = new Correo("OCA", "Peru 580", "San Francisco", "Cordoba", "3564112233");
                        Correo correo2 = new Correo("Andreani", "Salta 1250", "San Francisco", "Cordoba", "3564123456");

                        do
                        {
                            Console.WriteLine("Seleccione la sucursal de retiro, a continuacion las sucursales disponibles: ");
                            correo1.ToStringCorreo();
                            Console.WriteLine("\n-----------------------------------------------------------------");
                            correo2.ToStringCorreo();
                            Console.WriteLine("\n1. OCA");
                            Console.WriteLine("2. Andreani");
                            opcionCorreo = int.Parse(Console.ReadLine());

                            if (opcionCorreo == 1)
                            {
                                envio.RetiroEnSucursal(correo1);
                                correo1.AgregarEnvio(envio);
                            }

                            else if (opcionCorreo == 2)
                            {
                                envio.RetiroEnSucursal(correo2);
                                correo2.AgregarEnvio(envio);
                            }

                            else
                            {
                                Console.WriteLine("\nOpcion incorrecta. Ingrese nuevamente!\n");
                            }

                        } while (opcionCorreo != 1 && opcionCorreo != 2);

                        break;

                    case 3:
                        Console.WriteLine("\nOperacion cancelada.");
                        break;

                    default:
                        Console.WriteLine("\nOpcion incorrecta. Ingrese nuevamente!\n");
                        break;
                }

            } while (opcionEnvio != 1 && opcionEnvio != 2 && opcionEnvio != 3);

            envio.RecibeEnvio();
            cliente.AgregarPedido(pedido);
            envio.ToStringEnvio();
            pedido.ToStringPedido(cliente, productos, pago);
        }

        static Pedido DeserializarCarritoDTO()
        {
            var carritoDTO = File.ReadAllText("carritoDTO.txt");
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm:ss" };
            var pedido = JsonConvert.DeserializeObject<Pedido>(carritoDTO, dateTimeConverter);

            return pedido;
        }

        static Cliente DeserializarClienteDTO()
        {
            var clienteDTO = File.ReadAllText("clienteDTO.txt");
            var cliente = JsonConvert.DeserializeObject<Cliente>(clienteDTO);

            return cliente;
        }
    }
}
