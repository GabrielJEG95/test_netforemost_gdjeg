using System;
using System.Collections.Generic;

namespace test_netforemost_gdjeg.Modelos;

public partial class CuentasCliente
{
    public int IdCuenta { get; set; }

    public int IdCliente { get; set; }

    public int Saldo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<CuentasCobro> CuentasCobros { get; set; } = new List<CuentasCobro>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
