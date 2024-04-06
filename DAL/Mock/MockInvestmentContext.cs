using Fedgroup_MVC_ClientPortal.DAL.Interfaces;
using Fedgroup_MVC_ClientPortal.Models;
using Fedgroup_MVC_ClientPortal.Models.Interfaces;

namespace Fedgroup_MVC_ClientPortal.DAL.JSON
{
    public class MockInvestmentContext : IInvestmentRepository
    {        
        private Dictionary<int, IInvestment> _allInvestments = null;
        private Dictionary<int, Client> _allClients = null;

        //Leverage the prep work done in the client context class to easily return clients and their investments, just for this mock implementation
        private MockClientContext _clientRepo = new MockClientContext();

        public MockInvestmentContext() { }

        public IInvestment GetInvestment(int investmentId)
        {
            _allInvestments = _allInvestments ?? _clientRepo.GetInvestmentDictionary();

            if (_allInvestments.ContainsKey(investmentId))
                return _allInvestments[investmentId];
            else
                return null;
        }

        public List<IInvestment> GetInvestments()
        {
            _allInvestments = _allInvestments ?? _clientRepo.GetInvestmentDictionary();
            return _allInvestments.Values.ToList();
        }

        public List<IInvestment> GetInvestmentsByClient(string clientId)
        {
            _allClients = _allClients ?? _clientRepo.GetClientDictionary();

            if (int.TryParse(clientId, out int intId) && _allClients.ContainsKey(intId))
                return _allClients[intId].Investments;
            else
                return null;
        }
    }
}
