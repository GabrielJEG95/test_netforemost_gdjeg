using System;
using System.Collections.Generic;

namespace test_netforemost_gdjeg.Modelos;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NombreCliente { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaAnulacion { get; set; }
}
