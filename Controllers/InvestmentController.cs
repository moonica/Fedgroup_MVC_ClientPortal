using Fedgroup_MVC_ClientPortal.DAL.Interfaces;
using Fedgroup_MVC_ClientPortal.DAL.JSON;
using Fedgroup_MVC_ClientPortal.Models;
using Fedgroup_MVC_ClientPortal.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Fedgroup_MVC_ClientPortal.Controllers
{
    public class InvestmentController : Controller
    {
        private IInvestmentRepository _investmentRepo;
        private IClientRepository _clientRepo;

        public InvestmentController()
        {
            _investmentRepo = new MockInvestmentContext();
            _clientRepo = new MockClientContext();
        }

        /// <summary>
        /// Get a list of clients from the datastore with their investments, and use that to display a list of all investments
        /// </summary>
        // GET: InvestmentController
        [HttpGet]
        public ActionResult Index()
        {
            var clients = _clientRepo.GetClients();

            return View(ClientInvestment.FlattenClientListInvestments(clients));
        }

        /// <summary>
        /// Get all investments for a specific client
        /// </summary>
        // GET: InvestmentController/ClientInvestments/5
        [HttpGet]
        public ActionResult ClientInvestments(string clientId)
        {
            var client = getClient(clientId);

            if (client == null)
            {
                //TODO: inject a logger and log this error
                return View("Error");
            }

            return View("Index", ClientInvestment.FlattenClientInvestments(client));
        }

        /// <summary>
        /// Forecast the full investment amount for a specific investment and a given end date
        /// </summary>        
        // If I was implementing this purely as an API, I would use the below route; however my MVC is a bit rusty so I've gone with what works in terms of the controller and view logic
        // GET: InvestmentController/5/InvestmentForecast?endDate=x
        [HttpGet]
        public ActionResult InvestmentForecast(InvestmentViewModel model)
        {
            if (model?.Id is null)
                //TODO: inject a logger and log this error
                return View("Error");

            //mock value because the datetimepicker won't bind to the model
            if (model?.EndDate < new DateTime(1970, 1, 1))
                model.EndDate = DateTime.Now.AddDays(365);

            var inv = _investmentRepo.GetInvestment(model.Id);
            var result = inv.CalculateForecast(model.EndDate);

            return View("Forecast", new ForecastViewModel(inv) { EndDate = model.EndDate, ForecastAmount = result});
        }

        private Client getClient(string clientId)
        {
            return _clientRepo.GetClient(clientId);
        }
    }
}
