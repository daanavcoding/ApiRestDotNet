using ApiRest.ViewModels;
using System.Collections.Generic;

namespace ApiRest.AppService
{
    public class TerminalesAppService : ITerminalesAppService
    {
        private readonly Repositories.RequestRepository rep = null;
        public TerminalesAppService() 
        {
           rep = new Repositories.RequestRepository();
        }

        public List<Request> GetRequest()
        {
            var request = rep.Get();
            return request;
        }
    }
}
