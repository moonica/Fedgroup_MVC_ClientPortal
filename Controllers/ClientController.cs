using Fedgroup_MVC_ClientPortal.DAL.Interfaces;
using Fedgroup_MVC_ClientPortal.DAL.JSON;
using Fedgroup_MVC_ClientPortal.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Fedgroup_MVC_ClientPortal.Controllers
{
    public class ClientController : Controller
    {
        private IClientRepository _repository;

        public ClientController() 
        {
            _repository = new MockClientContext();
        }

        /// <summary>
        /// Display a list of clients from data store
        /// </summary>
        // GET: ClientController
        [HttpGet]
        public ActionResult Index()
        {
            var clients = _repository.GetClients();

            return View(clients);
            //this model could have been a dedicated ClientViewModel but for this simple implementation, there's no other fields I found I needed that would justify the extra class
        }
    }
}

