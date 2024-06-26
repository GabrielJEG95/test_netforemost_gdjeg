using System;
using System.Collections.Generic;

namespace test_netforemost_gdjeg.Modelos;

public partial class CuentasCobro
{
    public int IdCuentaCobro { get; set; }

    public int IdAgente { get; set; }

    public int IdCuentaCliente { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Agente IdAgenteNavigation { get; set; } = null!;

    public virtual CuentasCliente IdCuentaClienteNavigation { get; set; } = null!;
}
