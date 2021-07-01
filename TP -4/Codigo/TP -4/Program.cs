using System;
using System.Collections.Generic;
using System.Linq;

namespace TP__4
{
    class Program
    {

        static RegEmpresas empresasRegistradas = new RegEmpresas();
        static RegPersonas personasRegistradas = new RegPersonas();
        static RegPersonas personasIngresadas = new RegPersonas();

        static void Main(string[] args)
        {

            int op;
            string linea;

            Console.WriteLine("\t---BIENVENIDOS---");

            do
            {
                Console.WriteLine("\nIngrese la operacion a realizar: ");
                Console.WriteLine("1. Registrar persona.");
                Console.WriteLine("2. Autorizar ingreso.");
                Console.WriteLine("3. Registrar salida.");
                Console.WriteLine("4. Dar de baja empleado.");
                Console.WriteLine("5. Finalizar.");
                Console.WriteLine("");
                linea = Console.ReadLine();
                op = int.Parse(linea);

                switch (op)
                {
                    case 1:
                        RegistrarPersona();
                        break;

                    case 2:
                        AutorizarIngreso();
                        break;

                    case 3:
                        RegistrarSalida();
                        break;

                    case 4:
                        RegistrarBajaEmpleado();
                        break;

                    case 5:
                        //empresasRegistradas.MuestreoEmpresas();
                        //personasRegistradas.MuestreoPersonas();
                        //personasIngresadas.MuestreoPersonasIng();
                        //Lo anterior es para corroborar que se cargo todo bien.
                        Console.WriteLine("\nPrograma finalizado - Muchas gracias!");
                        break;

                    default:
                        Console.WriteLine("\nValor incorrecto. Ingrese nuevamente\n");
                        break;

                }
            } while (op != 5);


        }

        public static void RegistrarPersona()
        {

            var actividad1 = new ActividadAutorizada();
            var actividad2 = new ActividadAutorizada();
            var actividad3 = new ActividadAutorizada();
            var actividad4 = new ActividadAutorizada();
            var actividad5 = new ActividadAutorizada();

            actividad1.Nombre = "Deportes";
            actividad1.Autorizacion = true;
            actividad2.Nombre = "Religion";
            actividad2.Autorizacion = true;
            actividad3.Nombre = "Politica";
            actividad3.Autorizacion = true;
            actividad4.Nombre = "Educacion";
            actividad4.Autorizacion = true;
            actividad5.Nombre = "Otras";
            actividad5.Autorizacion = false;

            var empresa1 = new Empresa();
            var empresa2 = new Empresa();
            var empresa3 = new Empresa();
            var empresaNueva = new Empresa();

            empresa1.RazonSocial = "Lauti SA";
            empresa1.Cuit = 123456;
            empresa1.Domicilio = "Cabrera 3000";
            empresa1.Localidad = "San Francisco";
            empresa1.Email = "lauti@gmail.com";
            empresa1.Telefono = 15123456;
            empresa1.Actividad = actividad1;

            empresa2.RazonSocial = "Manu SA";
            empresa2.Cuit = 789123;
            empresa2.Domicilio = "San Juan 1120";
            empresa2.Localidad = "San Francisco";
            empresa2.Email = "manu@gmail.com";
            empresa2.Telefono = 15102030;
            empresa2.Actividad = actividad5;

            empresa3.RazonSocial = "Felipe SA";
            empresa3.Cuit = 159753;
            empresa3.Domicilio = "Lima 775";
            empresa3.Localidad = "Santa Fe";
            empresa3.Email = "feli@gmail.com";
            empresa3.Telefono = 15708090;
            empresa3.Actividad = actividad2;


            empresasRegistradas.RegistrarEmpresa(empresa1); //Empresa registrada.
            empresasRegistradas.RegistrarEmpresa(empresa2); //Empresa registrada.
            empresasRegistradas.RegistrarEmpresa(empresa3); //Empresa registrada.

            string opcion;

            Console.WriteLine("\tREGISTRO DE PERSONAS");

            var persona = new Persona();

            persona.RegistroPersona();

            Console.Write("Ingrese la fecha de autorizacion (DD/MM/AAAA) de la persona (tiene vigencia por un mes): ");
            persona.FechaAutorizacion = DateTime.Parse(Console.ReadLine());

            //Console.WriteLine(persona.FechaAutorizacion.ToShortDateString()); Corroboro que se ingreso bien la fecha.

            Console.Write("Ingrese la empresa en donde trabaja el empleado: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "Lauti SA":
                    persona.Empresa = empresa1;

                    Console.WriteLine("\nLa persona pertenece a una empresa que existe en el sistema!\n");

                    personasRegistradas.AgregarPersona(persona);

                    break;

                case "Manu SA":
                    persona.Empresa = empresa2;

                    Console.WriteLine("\nLa persona pertenece a una empresa que existe en el sistema!\n");

                    personasRegistradas.AgregarPersona(persona);

                    break;

                case "Felipe SA":
                    persona.Empresa = empresa3;

                    Console.WriteLine("\nLa persona pertenece a una empresa que existe en el sistema!\n");

                    personasRegistradas.AgregarPersona(persona);

                    break;

                default:
                    persona.Empresa = empresaNueva;

                    Console.WriteLine("\nLa persona pertenece a una empresa que no existe en el sistema, debe registrarla!\n");

                    empresaNueva.RegistroEmpresa();

                    int op;
                    string i;

                    do
                    {
                        Console.WriteLine("Lista de actividades autorizadas\n");
                        Console.WriteLine("1. Deportes");
                        Console.WriteLine("2. Religion");
                        Console.WriteLine("3. Educacion");
                        Console.WriteLine("4. Politica");
                        Console.WriteLine("5. Otra");
                        Console.Write("\nElija una opcion: ");
                        i = Console.ReadLine();
                        op = int.Parse(i);
                        Console.Write("\n");
                        switch (op)
                        {
                            case 1:
                                empresaNueva.Actividad = actividad1;
                                break;

                            case 2:
                                empresaNueva.Actividad = actividad2;
                                break;

                            case 3:
                                empresaNueva.Actividad = actividad3;
                                break;

                            case 4:
                                empresaNueva.Actividad = actividad4;
                                break;

                            case 5:
                                empresaNueva.Actividad = actividad5;
                                break;

                            default:
                                Console.WriteLine("\nOpcion incorrecta, ingrese nuevamente la actividad.\n");
                                break;

                        }


                    } while (op < 0 || op > 5);

                    empresasRegistradas.RegistrarEmpresa(empresaNueva);
                    personasRegistradas.AgregarPersona(persona);

                    break;
            }

        }

        static public void AutorizarIngreso()
        {

            if (personasRegistradas.CantidadPersonas() > 0)
            {
                var personaAutorizada = new Persona();

                DateTime fechaIngreso = new DateTime();
                fechaIngreso = DateTime.Now;
                Console.WriteLine("\nFecha de ingreso: " + fechaIngreso + "\n");

                personasRegistradas.AutorizacionIngreso(personaAutorizada);
            }

            else
            {
                Console.WriteLine("No hay ninguna persona ingresada, por favor ingrese nuevamente!\n");
            }
        }

        static public void RegistrarSalida()
        {

            if (personasIngresadas.CantidadPersonasIng() > 0)
            {
                personasIngresadas.EgresoPersona();
            }

            else
            {
                Console.WriteLine("No hay ninguna persona ingresada, por favor ingrese nuevamente!\n");
            }
        }

        static public void RegistrarBajaEmpleado()
        {

            if (personasRegistradas.CantidadPersonas() > 0)
            {
                personasRegistradas.DarDeBaja();
            }

            else
            {
                Console.WriteLine("No hay ninguna persona ingresada, por favor ingrese nuevamente!\n");
            }
        }

    }
}