using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpIntegrador
{
    class Program
    {
        
        static void Main(string[] args)

        {
            tienda tienda = new tienda();
            string select;
            //CARGAMOS PRODUCTOS Y TARJETAS INICIALES
            tienda.agregarProducto("remera", "Adidas", "M", 500);
            tienda.agregarProducto("pantalon", "Adidas", "L", 800);
            tienda.agregarProducto("short", "Nike", "S", 750);
            promocion prom = tienda.agregarPromocion(tienda.EncontrarProducto(1), 10);
            tienda.agregarCliente(38369636, "Santiago", "Ponce de Leon", (DateTime.Parse("10/06/1994")));
            tienda.agregarCliente(38254179, "Martin", "Venturino", (DateTime.Parse("28/04/1992")));

            tarjeta Tar1 = tienda.agregarTarjeta("VISA", "Galicia");
            Tar1.AgregarFormaPago(6, 20);
            Tar1.AgregarFormaPago(12, 30);

            tarjeta Tar2 = tienda.agregarTarjeta("MasterCard", "Santander");
            Tar2.AgregarFormaPago(3, 10);
            Tar2.AgregarFormaPago(9, 25);
            Tar2.AgregarBeneficio(9, 20);

            
            carro carro = tienda.agregarCarro();

            bool salir = false;
            while(salir == false)
            {
                Console.Clear();
                Console.WriteLine("*****\t\t\tTienda\t\t\t*****\n");
                Console.WriteLine("¿A qué módulo desea ingresar?\n");
                Console.WriteLine("1) Productos y Promociones\n2) Compras\n3) Tarjetas de Crédito\n4) Administración\n5) Salir del sistema");
                select = Console.ReadLine();

                switch (select)
                {
                    case "1":                                                                             //Módulo producto
                        ModuloProducto(carro, tienda);
                        break;
                    case "2":                                                                             //Módulo Compras
                        ModuloCompras(carro, tienda);
                        break;
                    case "3":                                                                             //Módulo Tarjetas
                        ModuloTarjetas(carro, tienda);
                        break;
                    case "4":                                                                             //Módulo administrativo
                        ModuloAdministrativo(tienda);
                        break;
                    case "5":                                                                             //Salir del sistema
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("La opción ingresada no es válida.\n");
                        Console.ReadKey();
                        break;
                }
            }
            Console.WriteLine("\n\nGracias, vuelva prontos.");
            Console.ReadKey();
        }

        static void ModuloProducto(carro carro, tienda tienda)
        {
            bool salir = false;
            while (salir == false)
            {
                Console.Clear();
                Console.WriteLine("*****\t\t\tMODULO PRODUCTO\t\t\t*****\n");
                Console.WriteLine("¿Qué desea hacer?\n");
                Console.WriteLine("1) Dar de alta Productos\n2) Dar de alta Promociones\n3) Listar Productos\n4) Listar Promociones\n5) Volver");
                string select = Console.ReadLine();

                switch (select)
                {
                    case "1":                                                                      //Agregar productos
                        AgregarProducto(tienda);
                        break;

                    case "2":                                                                     //Agregar promociones
                        AgregarPromocion(tienda);
                        break;

                    case "3":                                                                     //Listar productos
                        ListarProductos(tienda);
                        Console.WriteLine("Presione cualquier tecla para volver.");
                        Console.ReadKey();
                        break;
                    case "4":                                                                     //Listar promociones
                        ListarPromociones(tienda);
                        Console.WriteLine("Presione cualquier tecla para volver.");
                        Console.ReadKey();
                        break;
                    case "5":                                                                     //Volver
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("La opción ingresada no es válida.\n");
                        Console.ReadKey();
                        break;

                }
            }
        }

        static void ModuloCompras(carro carro, tienda tienda)
        {
            string select, select2;
            bool salir = false;
            while (salir == false)
            {
                 bool salir2 = false;
                 Console.Clear();
                 Console.WriteLine("*****\t\t\tMODULO COMPRAS\t\t\t*****\n");
                 Console.WriteLine("¿Qué desea hacer?\n");
                 Console.WriteLine("1) Agregar productos al carro\n2) Identificar Cliente\n3) Volver");
                 select = Console.ReadLine();
        
                switch (select)
                {
                    
                    case "1":
                        while (salir2 == false)
                        {
                            Console.Clear();
                            Console.WriteLine("*****\t\t\tSUBMODULO CARRO\t\t\t*****\n");
                            Console.WriteLine("¿Qué desea hacer?\n");
                            Console.WriteLine("1) Agregar producto al carro\n2) Quitar producto del carro\n3) Listar productos en carro\n4) Volver");
                            select2 = Console.ReadLine();

                            switch (select2)
                            {

                                case "1":                                                                     //Agregar producto a carro
                                    AgregarProductoCarro(carro, tienda);
                                    break;

                                case "2":                                                                     //Quitar producto de carro
                                    QuitarProductoCarro(carro);

                                    break;
                                case "3":                                                                     //Listar productos de carro
                                    ListarProductosCarro(carro);
                                    Console.WriteLine("Presione cualquier tecla para volver.");
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    salir2 = true;
                                    break;
                                default:
                                    Console.WriteLine("La opción ingresada no es válida.\n");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        break;

                    case "2":
                        int dni;
                        Console.WriteLine("Total de compra: {0}", carro.VerTotal());      // Hay que agregar variable
                        Console.WriteLine("Ingrese DNI:");
                        try
                        {
                            dni = int.Parse(Console.ReadLine());
                            EncontrarOAgregarCliente(dni, carro, tienda);
                        }
                        catch
                        {
                            Console.WriteLine("Error al ingresar datos. Por favor reintente la operacion.");
                            Console.ReadKey();
                        }
                        break;

                    case "3":                                                                     //Volver
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("La opción ingresada no es válida.\n");
                        Console.ReadKey();
                        break;
                }
             }
         }

        static void ModuloTarjetas(carro carro, tienda tienda)
        {
            string select;
            bool salir = false;
            while (salir == false)
            {
                Console.Clear();
                Console.WriteLine("*****\t\t\tMODULO TARJETAS\t\t\t*****\n");
                Console.WriteLine("¿Qué desea hacer?\n");
                Console.WriteLine("1) Agregar tarjeta\n2) Agregar beneficio\n3) Listar tarjetas\n4) Listar tarjetas con beneficios\n5) Volver");
                select = Console.ReadLine();

                switch (select)
                {
                    case "1":                                                                      //Agregar tarjeta

                        AgregarTarjeta(tienda);
                        break;

                    case "2":                                                                     //Agregar beneficio

                        AgregarBeneficio(tienda);
                        break;

                    case "3":                                                                     //Listar tarjetas
                        ListarTarjetas(tienda);
                        Console.WriteLine("Presione cualquier tecla para volver.");
                        Console.ReadKey();
                        break;

                    case "4":                                                                     //Listar tarjetas con beneficios
                        ListarBeneficios(tienda);
                        Console.WriteLine("Presione cualquier tecla para volver.");
                        Console.ReadKey();
                        break;

                    case "5":                                                                     //Volver
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("La opción ingresada no es válida.\n");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ModuloAdministrativo(tienda tienda)
        {
            string select;
            bool salir = false;
            while (salir == false)
            {
                Console.Clear();
                Console.WriteLine("*****\t\t\tMODULO ADMINISTRATIVO\t\t\t*****\n");
                Console.WriteLine("¿Qué desea hacer?\n");
                Console.WriteLine("1) Total vendido en la tienda On-line\n2) Total vendido por cliente\n3) Total vendido por tarjeta\n4) Volver");
                select = Console.ReadLine();

                switch (select)
                {
                    case "1":                                                                     //Total vendido en toda la tienda
                        Console.WriteLine("Total vendido en la tienda es de: ${0}",tienda.TotalVendido);    //Agregar variable
                        Console.ReadKey();
                        break;
                    case "2":                                                                     //Total vendido por cliente
                        ListarClientesPorCompra(tienda);
                        Console.WriteLine("Presione cualquier tecla para volver.");
                        Console.ReadKey();
                        break;
                    case "3":                                                                     //Total vendido por tarjeta
                        ListarTarjetasPorCompra(tienda);
                        Console.WriteLine("Presione cualquier tecla para volver.");
                        Console.ReadKey();
                        break;
                    case "4":                                                                     //Volver
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("La opción ingresada no es válida.\n");
                        Console.ReadKey();
                        break;
                }
            }
        }

        //FUNCIONES MODULO PRODUCTO
        static void AgregarProducto(tienda tienda)
        {
            string tipo;
            string marca;
            string talle;
            float precio;

            
            Console.WriteLine("Ingrese tipo de producto");
                          tipo = Console.ReadLine();
            Console.WriteLine("Ingrese marca de producto");
                          marca = Console.ReadLine();
            Console.WriteLine("Ingrese talle de producto");
                          talle = Console.ReadLine();
            Console.WriteLine("Ingrese precio del producto");
            try
            {
                precio = float.Parse(Console.ReadLine());
                tienda.agregarProducto(tipo, marca, talle, precio);
                Console.WriteLine("\nProducto Agregado.");
                Console.ReadKey();
            }
            catch {
                Console.WriteLine("Error al ingresar datos. Por favor reintente la operacion.");
                Console.ReadKey();
            }
        }

        static void AgregarPromocion(tienda tienda)
        {
            int numProd;
            int descuento;
            try { 
            Console.WriteLine("Seleccione un producto para la promo:");
                            ListarProductos(tienda);
                            numProd = int.Parse(Console.ReadLine());
            Console.WriteLine("Indique porcentaje de descuento");
                            descuento = int.Parse(Console.ReadLine());
            producto prod = tienda.EncontrarProducto(numProd);
            promocion promo = tienda.agregarPromocion(prod , descuento);
            Console.WriteLine("\nPromocion Agregada.");
            Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Error al ingresar datos. Por favor reintente la operacion.");
                Console.ReadKey();
            }
        }

        static void ListarProductos(tienda tienda)
        {
            int num = 1;
            foreach (tienda.InfoProducto i in tienda.VerProductos())
            {
                Console.WriteLine("{0})[Producto Tipo= {1}, Marca = {2}, Talle = {3}, Precio = {4}, Descuento = {5}]\n", num, i.tipo, i.marca, i.talle, i.precio, i.descuento);
                num++;
            }
        }

        static void ListarPromociones(tienda tienda)
        {
            int num = 1;
            foreach (tienda.InfoProducto i in tienda.VerProductos())
            {
                if (i.descuento != 0)
                {
                    Console.WriteLine("{0})[Producto Tipo= {1}, Marca = {2}, Talle = {3}, Precio = {4}, Descuento = {5}]\n", num, i.tipo, i.marca, i.talle, i.precio, i.descuento);
                    num++;
                }
            }
        }

        //FUNCIONES MODULO COMPRAS
        static void AgregarProductoCarro(carro carro, tienda tienda)
        {
            int numProd, cantidad;
            try
            {
                Console.WriteLine("Seleccione un producto para agregar al carro");
                ListarProductos(tienda);
                numProd = int.Parse(Console.ReadLine());
                producto prod = tienda.EncontrarProducto(numProd);
                Console.WriteLine("Indique cantidad a comprar");
                cantidad = int.Parse(Console.ReadLine());
                carro.agregarProducto(prod, cantidad);
                Console.WriteLine("Producto agregado al carro.");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Error al ingresar datos. Por favor reintente la operacion.");
                Console.ReadKey();
            }
        }

        static void ListarProductosCarro(carro carro)
        {
            int num = 1;
            foreach (carro.InfoProducto i in carro.VerProductos())
            {
                Console.WriteLine("Cantidad: {0}[Producto Tipo= {1}, Marca = {2}, Talle = {3}, Precio = {4}, Descuento = {5}]\n", i.cantidad, i.tipo, i.marca, i.talle, i.precio, i.descuento);
                num++;
            }
        }

        static void QuitarProductoCarro(carro carro)
        {
            int numProd, cantidad;
            try
            {
                Console.WriteLine("Seleccione un producto para quitar al carro");
                ListarProductosCarro(carro);
                numProd = int.Parse(Console.ReadLine());
                Console.WriteLine("Indique cantidad a quitar");
                cantidad = int.Parse(Console.ReadLine());
                carro.QuitarProducto(numProd, cantidad);
                Console.WriteLine("Producto quitado del carro.");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Error al ingresar datos. Por favor reintente la operacion.");
                Console.ReadKey();
            }
        }

        static void EncontrarOAgregarCliente(int dni, carro carro, tienda tienda)
        {
            cliente client;
            string nombre, apellido;
            int tarjeta, cuotas;
            DateTime dia;
            string day;
            try
            {
                client = tienda.EncontrarCliente(dni);
                if (client == null)
                {
                    Console.WriteLine("Nuevo Cliente, ingrese sus datos:\n Ingrese Nombre:");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese Apellido:");
                    apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese Fecha de Nacimiento (DD/MM/AA):");
                    day = Console.ReadLine();
                    DateTime.TryParse(day, out dia);
                    client = tienda.agregarCliente(dni, nombre, apellido, dia);
                    Console.WriteLine("Cliente agregado exitosamente");

                }
                else
                {
                    Console.WriteLine("Ciente existente"); //Agregar datos de cliente en impresion
                    Console.WriteLine("[Cliente Nombre= {0}, Apellido = {1}, Dni={2}, Nacimiento = {3}, TtalGastado = {4}]\n", client.Nombre, client.Apellido, client.DNI, client.Nacimiento, client.TotalGastado);
                }

                Console.WriteLine("Seleccione una tarjeta para abonar:");
                ListarTarjetas(tienda);
                tarjeta = int.Parse(Console.ReadLine());
                Console.WriteLine("Indique cantidad de cuotas:");
                cuotas = int.Parse(Console.ReadLine());
                tarjeta tar = tienda.EncontrarTarjeta(tarjeta);
                int interes = tar.EncontrarFormadePago(cuotas);
                if (interes == -1)
                {
                    Console.WriteLine("Error al ingresar datos. Por favor reintente la operacion.");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("En {0} cuotas tiene un interes de {1}%", cuotas, interes);
                Console.WriteLine("En el carro hay un total de ${0}", carro.VerTotal());
                float TotalCompra = ((carro.VerTotal()) * (1 + ((float)interes / 100)));
                Console.WriteLine("Precio total financiado: ${0}, en {1} cuotas de ${2}", TotalCompra, cuotas, (TotalCompra / cuotas));
                Console.WriteLine("Confirma la compra? (S/N)");
                string confirma = Console.ReadLine();
                switch (confirma)
                {
                    case "s":
                    case "S":
                        client.ActualizarTotalGastado(TotalCompra);
                        tar.ActualizarTotalGastado(TotalCompra);
                        tienda.ActualizarTotalGastado(TotalCompra);
                        carro.vaciarcarro();

                        Console.WriteLine("Felicidades por su compra, carro vacio!");
                        Console.ReadKey();
                        break;
                    case "n":
                    case "N":
                        Console.WriteLine("Tomese su tiempo, no hay apuro. Cuanto mas compre, mejor!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Caracter ingresado no valido, reintente la operacion.");
                        Console.ReadKey();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Error al ingresar datos. Por favor reintente la operacion.");
                Console.ReadKey();
            }
        }

        //FUNCIONES MODULO TARJETA
        static void AgregarTarjeta(tienda tienda)
        {
            string nombre;
            string banco;
            int num;

            Console.WriteLine("Ingrese tarjeta:");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Banco:");
            banco = Console.ReadLine();
            tarjeta Tarjeta = tienda.agregarTarjeta(nombre, banco);
            try
            {
                Console.WriteLine("Ingrese cantidad de formas de pago:");
                num = int.Parse(Console.ReadLine());
                
                for (int i = 1; i <= num; i++)
                {
                    int numcuotas, interes;
                    Console.WriteLine("Forma de pago # " + i.ToString());       //Agregar ciclo for con cantidad de formas de pago
                    Console.WriteLine("Ingrese # de cuotas:");
                    numcuotas = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese interes por cuota:");
                    interes = int.Parse(Console.ReadLine());
                    Tarjeta.AgregarFormaPago(numcuotas, interes);
                }
                Console.WriteLine("\nTarjeta Agregada.");
                Console.ReadKey();
            }
            catch
            {
                tienda.QuitarTarjeta(Tarjeta);
                Console.WriteLine("Error al ingresar datos. Por favor reintente la operacion.");
                Console.ReadKey();
            }
        }

        static void AgregarBeneficio(tienda tienda)
        {
            int numTarjeta, numCuotas, interes;
            try
            {
                Console.WriteLine("Seleccione una tarjeta para el beneficio:");
                ListarTarjetas(tienda);
                numTarjeta = int.Parse(Console.ReadLine());
                Console.WriteLine("Indique cantidad de cuotas:");
                numCuotas = int.Parse(Console.ReadLine());
                Console.WriteLine("Indique interés por cuota:");
                interes = int.Parse(Console.ReadLine());
                tarjeta tarjeta = tienda.EncontrarTarjeta(numTarjeta);
                tarjeta.AgregarBeneficio(numCuotas, interes);
                Console.WriteLine("\nBeneficio Agregado.");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Error al ingresar datos. Por favor reintente la operacion.");
                Console.ReadKey();
            }
        }

        static void ListarTarjetas(tienda tienda)
        {
            int num = 1;
            foreach (tienda.InfoTarjeta i in tienda.VerTarjetas())
            {
                tarjeta tarjeta = tienda.EncontrarTarjeta(num);
                Console.WriteLine("{0})[Tarjeta Nombre= {1}, Banco = {2}, Formas de Pago = {3}, Total Compras = {4}]\n", num, i.nombre, i.banco, i.formasdepago, tarjeta.Total);
                foreach (tarjeta.InfoFormadePago f in tarjeta.VerFormasdePago())
                {
                    Console.WriteLine("\t\t{0} cuotas con {1}% de interes\n", f.numcuotas, f.interes);
                }
                num++;
            }
        }

        static void ListarBeneficios(tienda tienda)
        {
            int num = 1;
            foreach (tienda.InfoTarjeta i in tienda.VerTarjetas())
            {
                tarjeta tarjeta = tienda.EncontrarTarjeta(num);
                foreach (tarjeta.InfoFormadePago f in tarjeta.VerFormasdePago())
                {
                    if (f.beneficio == true)
                    {
                        Console.WriteLine("{0})[Tarjeta Nombre= {1}, Banco = {2}, Formas de Pago = {3}, Total Compras = ${4}]\n", num, i.nombre, i.banco, i.formasdepago, tarjeta.Total);
                        Console.WriteLine("\t\t{0} cuotas con {1}% de interes\n", f.numcuotas, f.interes);
                    }
                }
                num++;
            }
        }

        //FUNCIONES MODULO ADMINISTRATIVO
        static void ListarTarjetasPorCompra(tienda tienda)
        {
            int num = 1;
            foreach (tienda.InfoTarjeta i in tienda.VerTarjetas())
            {
                tarjeta tarjeta = tienda.EncontrarTarjeta(num);
                Console.WriteLine("{0})[Tarjeta Nombre= {1}, Banco = {2}, Total Compras = ${3}]\n", num, i.nombre, i.banco, tarjeta.Total);
                num++;
            }
        }

        static void ListarClientesPorCompra(tienda tienda)
        {
            int num = 1;
            foreach (tienda.InfoCliente i in tienda.VerClientes())
            {
                Console.WriteLine("{0})[Cliente Nombre= {1}, Apellido = {2}, Dni = {3}, Nacimiento {4}, Total Compras = ${5}]\n", num, i.nombre, i.apellido, i.dni, i.nacimiento, i.total);
                num++;
            }
        }
    }
}
