using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using test_netforemost_gdjeg.Modelos;
using test_netforemost_gdjeg.Modelos.dto;

namespace test_netforemost_gdjeg  
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var context = new TestNetforemostGdjegContext();

            await ejecutarSPSaldos();
            consultaSaldosAgentes();

            async Task ejecutarSPSaldos()
            {

                    await context.Database.ExecuteSqlRawAsync("exec saldosGestores");

                    Console.WriteLine("Ejecución completada\n");
                
            }

            void consultaSaldosAgentes()
            {
                var cuentas_cobro = context.CuentasCobros.Select(s => new dtoCuentaCobro
                {
                    IdCuenta = s.IdCuentaCliente,
                    Cliente =s.IdCuentaClienteNavigation.IdClienteNavigation.NombreCliente,
                    IdAgente = s.IdAgente,
                    Agente = s.IdAgenteNavigation.NombreAgente,
                    Saldo = s.IdCuentaClienteNavigation.Saldo
                    
                }).ToList();

                foreach (var item in cuentas_cobro)
                {
                    Console.WriteLine($"IDCuenta: {item.IdCuenta}, Cliente: {item.Cliente} IdAgente: {item.IdAgente}, Agente: {item.Agente}, Saldo: {item.Saldo}");
                }
            }
        }

        
    }
}
