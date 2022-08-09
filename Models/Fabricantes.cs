using System;
using System.Collections.Generic;


namespace ApiRest.Models
{
    public partial class Fabricantes
    {
        public Fabricantes()
        {
            Terminales = new HashSet<Terminales>();
        }

        public int IdFab { get; set; }
        public string FabName { get; set; }
        public string FabDesc { get; set; }

        public virtual ICollection<Terminales> Terminales { get; set; }
    }
}
