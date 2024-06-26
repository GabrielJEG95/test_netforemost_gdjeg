using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_netforemost_gdjeg.Modelos.dto
{
    public class dtoCuentaCobro
    {
        public int IdAgente { get; set; }
        public int IdCuenta { get;set; }
        public string? Agente {  get; set; } 
        public int Saldo { get; set; }
    }
}
