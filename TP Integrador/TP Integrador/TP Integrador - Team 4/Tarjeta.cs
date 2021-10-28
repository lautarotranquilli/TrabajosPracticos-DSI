using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Integrador___Team_4
{
    class Tarjeta
    {
        private String numero;
        private String titular;
        private int dniTitular;
        private String banco;
        private DateTime vencimiento;
        private int codSeguridad;
        private Cliente clientes;
        private TipoTarjeta tipo;
        private List<Pago> pagos;
        
        public String Numero { get => numero; set => numero = value; }
        public String Titular { get => titular; set => titular = value; }
        public int DniTitular { get => dniTitular; set => dniTitular = value; }
        public String Banco { get => banco; set => banco = value; }
        public DateTime Vencimiento { get => vencimiento; set => vencimiento = value; }
        public int CodSeguridad { get => codSeguridad; set => codSeguridad = value; }
        public Cliente Clientes { get => clientes; set => clientes = value; }
        public TipoTarjeta Tipo { get => tipo; set => tipo = value; }
        public List<Pago> Pagos { get => pagos; set => pagos = value; }

        public Tarjeta(Cliente clientes)
        {
            this.clientes = clientes;
        }

        public Tarjeta(string numero, string titular, int dniTitular, string banco, DateTime vencimiento, int codSeguridad, TipoTarjeta tipo, Cliente cliente)
        {
            Numero = numero;
            Titular = titular;
            DniTitular = dniTitular;
            Banco = banco;
            Vencimiento = vencimiento;
            CodSeguridad = codSeguridad;
            Clientes = cliente;
            Tipo = tipo;
        }

        public void NuevaTarjeta()
        {
            Console.WriteLine("Ingrese el numero de la tarjeta: ");
            Numero = Console.ReadLine();

            Console.WriteLine("\nIngrese el nombre del titular de la tarjeta: ");
            Titular = Console.ReadLine();

            Console.WriteLine("\nIngrese el DNI del titular: ");
            DniTitular = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese el nombre del banco: ");
            Banco = Console.ReadLine();

            do
            {
                Console.WriteLine("\nIngrese el vencimiento de la tarjeta: ");
                Vencimiento = DateTime.Parse(Console.ReadLine());

            } while (DateTime.Now > Vencimiento); //Verificar que la tarjeta no esté vencida.
            

            Console.WriteLine("\nIngrese el codigo de seguridad de la tarjeta: ");
            CodSeguridad = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese el cliente");
            Clientes.NuevoCliente();

            int tipos;

            do
            {
                Console.WriteLine("Ingrese el tipo de tarjeta: ");
                Console.WriteLine("1. Debito.");
                Console.WriteLine("2. Credito.");
                tipos = int.Parse(Console.ReadLine());

                if (tipos == 1)
                {
                    Tipo = TipoTarjeta.Debito;
                }

                else if (tipos == 2)
                {
                    Tipo = TipoTarjeta.Credito;
                }

                else
                {
                    Console.WriteLine("Opcion incorrecta, ingrese nuevamente.");
                }

            } while (tipos != 1 && tipos != 2);
        }

        public void ToStringTarjeta()
        {
            Console.WriteLine("\nNumero de tarjeta: " + numero);
            Console.WriteLine("\nNombre del titular de la tarjeta: " + titular);
            Console.WriteLine("\nDNI del titular de la tarjeta: " + dniTitular);
            Console.WriteLine("\nNombre del banco: " + banco);
            Console.WriteLine("\nVencimiento de la tarjeta: " + vencimiento.ToString("d"));
            Console.WriteLine("\nCodigo de seguridad: " + codSeguridad);
            Console.WriteLine("\nTipo de tarjeta: " + tipo);
            Console.WriteLine("\nCliente"); 
            clientes.ToStringCliente();
        }
    }
}

enum TipoTarjeta
{
    Debito,
    Credito
}
