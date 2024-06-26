using System;
using System.Collections.Generic;

namespace test_netforemost_gdjeg.Modelos;

public partial class CuentasCliente
{
    public int IdCuenta { get; set; }

    public int IdCliente { get; set; }

    public int Saldo { get; set; }

    public DateTime FechaCreacion { get; set; }
}
