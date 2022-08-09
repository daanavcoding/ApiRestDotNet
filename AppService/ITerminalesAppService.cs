using ApiRest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.AppService
{
    interface ITerminalesAppService
    {
        List<Request> GetRequest();        
    }
}
