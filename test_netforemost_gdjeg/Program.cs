using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System;
using test_netforemost_gdjeg.Modelos;

namespace test_netforemost_gdjeg  
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new TestNetforemostGdjegContext())
            {
                //var clientes = context.Clientes.ToList();
                //foreach (var item in clientes)
                //{
                //    Console.WriteLine($"ID: {item.IdCliente}, Name: {item.NombreCliente}, Creación: {item.FechaCreacion}");
                //}

                

            }
        }
    }
}
