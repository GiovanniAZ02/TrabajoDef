using System;
using System.Collections.Generic;
using System.Linq;

public class Inventario
{
    private List<Producto> productos = new List<Producto>();

    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
        Console.WriteLine("Producto agregado exitosamente.");
        Console.WriteLine();
    }

    public void FiltrarYMostrarProductos(decimal precioMinimo)
    {
        var productosFiltrados = productos.Where(p => p.Precio > precioMinimo).OrderBy(p => p.Precio);
        Console.WriteLine($"Productos con precio mayor a {precioMinimo}:");

        foreach (var producto in productosFiltrados)
        {
            producto.MostrarInformacion();
        }

        if (!productosFiltrados.Any())
        {
            Console.WriteLine("No hay productos que cumplan con el filtro.");
        }

        Console.WriteLine();
    }

    public void ActualizarPrecio(string nombre, decimal nuevoPrecio)
    {
        var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (producto != null)
        {
            producto.Precio = nuevoPrecio;
            Console.WriteLine("Precio actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }

        Console.WriteLine();
    }

    public void EliminarProducto(string nombre)
    {
        var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (producto != null)
        {
            productos.Remove(producto);
            Console.WriteLine("Producto eliminado.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }

        Console.WriteLine();
    }

    public void MostrarResumen()
    {
        Console.WriteLine($"Número total de productos: {productos.Count}");

        if (productos.Any())
        {
            Console.WriteLine($"Precio promedio: {productos.Average(p => p.Precio):C}");
            Console.WriteLine($"Producto con precio más alto: {productos.Max(p => p.Precio):C}");
            Console.WriteLine($"Producto con precio más bajo: {productos.Min(p => p.Precio):C}");

            Console.WriteLine("Lista de Productos:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"- {producto.Nombre} (Precio: {producto.Precio:C})");
            }
        }
        else
        {
            Console.WriteLine("No hay productos en el inventario.");
        }

        Console.WriteLine();
    }
}


