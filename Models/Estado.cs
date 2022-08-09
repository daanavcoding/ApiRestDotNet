using System.Collections.Generic;


namespace ApiRest.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Terminales = new HashSet<Terminales>();
        }

        public int IdEstado { get; set; }
        public string EstadoName { get; set; }
        public string EstadoDesc { get; set; }

        public virtual ICollection<Terminales> Terminales { get; set; }
    }
}
