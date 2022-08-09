using System;



namespace ApiRest.Models
{
    public partial class Terminales
    {
        public int IdTerminal { get; set; }
        public int IdFab { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaEstado { get; set; }
        public string TerminalDesc { get; set; }
        public string TerminalName { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Fabricantes IdFabNavigation { get; set; }
    }
}
