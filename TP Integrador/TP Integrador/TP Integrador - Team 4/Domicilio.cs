using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Integrador___Team_4
{
    class Domicilio
    {
        private String calle;
        private int numero;
        private String ciudad;
        private String provincia;
        private int codPostal;
        private int piso;
        private String departamento;
        private Cliente clientes;
        private List<Envio> envios;

        public String Calle { get => calle; set => calle = value; }
        public int Numero { get => numero; set => numero = value; }
        public String Ciudad { get => ciudad; set => ciudad = value; }
        public String Provincia { get => provincia; set => provincia = value; }
        public int CodPostal { get => codPostal; set => codPostal = value; }
        public int Piso { get => piso; set => piso = value; }
        public String Departamento { get => departamento; set => departamento = value; }
        public Cliente Clientes { get => clientes; set => clientes = value; }
        public List<Envio> Envios { get => envios; set => envios = value; }

        public void NuevoDomicilio()
        {
            Console.WriteLine("Ingrese la calle: ");
            calle = Console.ReadLine();

            Console.WriteLine("\nIngrese el numero: ");
            numero = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese la ciudad: ");
            ciudad = Console.ReadLine();

            Console.WriteLine("\nIngrese la provincia: ");
            provincia = Console.ReadLine();

            Console.WriteLine("\nIngrese el codigo postal: ");
            codPostal = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese el piso: ");
            piso = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese el departamento: ");
            departamento = Console.ReadLine();

            Console.WriteLine("\nIngrese el cliente");
            Cliente clienteNuevo = new Cliente();
            clienteNuevo.NuevoCliente();
            clientes = clienteNuevo;
        }

        public void ToStringDomicilio()
        {
            Console.WriteLine("\nCalle: " + calle);
            Console.WriteLine("\nNumero: " + numero);   
            Console.WriteLine("\nCiudad: " + ciudad);          
            Console.WriteLine("\nProvincia: " + provincia);            
            Console.WriteLine("\nCodigo postal: " + codPostal);         
            Console.WriteLine("\nPiso: " + piso);           
            Console.WriteLine("\nDepartamento: " + departamento);
            Console.WriteLine("\nCliente");
            clientes.ToStringCliente();
        }
    }
}
