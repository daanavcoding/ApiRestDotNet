using ApiRest.AppService;
using ApiRestDanielDelViso;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TerminalesController : ControllerBase
    {
        /// <summary>
        /// Método Get para acceder a la request que genera la lista de terminales de la base de datos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        { 
            TerminalesAppService terminal = new TerminalesAppService();
            var request = terminal.GetRequest();
            CacheModel.Add("Terminales",request);
            //Implementación para que utilice la caché, la otra manera sería: return Ok(request);
            return Ok(CacheModel.Get("Terminales"));            
        }
    }
}
