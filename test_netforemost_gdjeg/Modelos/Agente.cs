using System;
using System.Collections.Generic;

namespace test_netforemost_gdjeg.Modelos;

public partial class Agente
{
    public int IdAgente { get; set; }

    public string NombreAgente { get; set; } = null!;

    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaAnulacion { get; set; }

    public virtual ICollection<CuentasCobro> CuentasCobros { get; set; } = new List<CuentasCobro>();
}
