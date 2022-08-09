using ApiRest.ViewModels;
using System.Collections.Generic;
using System.Linq;


namespace ApiRest.Repositories
{
    public class RequestRepository
    {
        /// <summary>
        /// Consulta que devuelve los datos necesarios para listar los terminales del ejercicio.
        /// </summary>
        /// <returns></returns>
        public List<Request> Get()
        {
            using(Models.TerminalContext db = new Models.TerminalContext())
            {
                var request = (from terminales in db.Terminales 
                               join fabricantes in db.Fabricantes on terminales.IdFab equals fabricantes.IdFab 
                               join estados in db.Estados on terminales.IdEstado equals estados.IdEstado
                               select new Request
                               {
                                   NombreTerminal = terminales.TerminalName,
                                   DescripcionTerminal = terminales.TerminalDesc,
                                   NombreFabricante = fabricantes.FabName,
                                   NombreEstado = estados.EstadoName,
                                   FechaFabricacion = terminales.FechaFabricacion,
                                   FechaEstado = terminales.FechaEstado

                               }).ToList();

                return request;
            }
        }

    }
}
