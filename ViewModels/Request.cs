using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.ViewModels
{
    public class Request
    {
        public string NombreTerminal { get; set; }
        public string DescripcionTerminal { get; set; }
        public string NombreFabricante { get; set; }
        public string NombreEstado { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaEstado { get; set; }

    }
}
