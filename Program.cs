using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoDef
{
    class Program
    {
        static void Main()
        {
            Inventario inventario = new Inventario();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine();
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Filtrar productos por precio");
                Console.WriteLine("3. Actualizar precio de un producto");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Mostrar resumen del inventario");
                Console.WriteLine("6. Salir");
                Console.Write("\nSeleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine();

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Agregar Producto");
                            Console.Write("Ingrese el nombre del producto: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingrese el precio del producto: ");

                            if (decimal.TryParse(Console.ReadLine(), out decimal precio) && precio > 0)
                            {
                                inventario.AgregarProducto(new Producto(nombre, precio));
                                Console.WriteLine("Producto agregado exitosamente.");
                            }
                            else
                            {
                                Console.WriteLine("Precio inválido. Intente nuevamente.");
                            }
                            Console.WriteLine();
                            break;

                        case 2:
                            Console.WriteLine("Filtrar Productos por Precio");
                            Console.Write("Ingrese el precio mínimo para filtrar: ");

                            if (decimal.TryParse(Console.ReadLine(), out decimal precioMinimo) && precioMinimo >= 0)
                            {
                                inventario.FiltrarYMostrarProductos(precioMinimo);
                            }
                            else
                            {
                                Console.WriteLine("Precio inválido. Intente nuevamente.");
                            }
                            Console.WriteLine();
                            break;

                        case 3:
                            Console.WriteLine("Actualizar Precio de Producto");
                            Console.Write("Ingrese el nombre del producto a actualizar: ");
                            nombre = Console.ReadLine();
                            Console.Write("Ingrese el nuevo precio: ");

                            if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio) && nuevoPrecio > 0)
                            {
                                inventario.ActualizarPrecio(nombre, nuevoPrecio);
                            }
                            else
                            {
                                Console.WriteLine("Precio inválido. Intente nuevamente.");
                            }
                            Console.WriteLine();
                            break;

                        case 4:
                            Console.WriteLine("Eliminar Producto");
                            Console.Write("Ingrese el nombre del producto a eliminar: ");
                            nombre = Console.ReadLine();
                            inventario.EliminarProducto(nombre);
                            Console.WriteLine();
                            break;

                        case 5:
                            Console.WriteLine("Resumen del Inventario:");
                            inventario.MostrarResumen();
                            Console.WriteLine();
                            break;

                        case 6:
                            continuar = false;
                            Console.WriteLine("\nPrograma finalizado");
                            break;

                        default:
                            Console.WriteLine("Opción inválida, vuelva a intentarlo");
                            Console.WriteLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Seleccione la opcion correcta.");
                    Console.WriteLine();
                }
            }
        }
    }

}

