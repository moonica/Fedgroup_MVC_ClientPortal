using Fedgroup_MVC_ClientPortal.DAL.Interfaces;
using Fedgroup_MVC_ClientPortal.Models;
using Fedgroup_MVC_ClientPortal.Models.Interfaces;

namespace Fedgroup_MVC_ClientPortal.DAL.JSON
{
    public class MockClientContext : IClientRepository
    {
        private Dictionary<int, Client> _clients;
        private Dictionary<int, IInvestment> _investments;
        private readonly int CLIENT_COUNT = 5;

        public MockClientContext()
        {
            //set up a mock list of clients
            _clients = new Dictionary<int, Client>()
            {
                { 1, new Client() { FirstName = "Anna", LastName = "Appleton", IdNumber="1", Investments = new List<IInvestment>() } },
                { 2, new Client() { FirstName = "Ben", LastName = "Booysens", IdNumber="2", Investments = new List<IInvestment>() } },
                { 3, new Client() { FirstName = "Charles", LastName = "Chetty", IdNumber="3", Investments = new List<IInvestment>() } },
                { 4, new Client() { FirstName = "Dimakatso", LastName = "Davis", IdNumber="4", Investments = new List<IInvestment>() } },
                { 5, new Client() { FirstName = "Erika", LastName = "Edwards", IdNumber="5", Investments = new List<IInvestment>() } }
            };

            //set up a random selection of investments (ignoring the InvestmentFactory entirely, because this was much simpler to instantiate with values ¯\_(ツ)_/¯
            _investments = new Dictionary<int, IInvestment>
            {
                { 1, new SimpleInvestment() { Id=1, InterestRate_Annual=(0.1M), InvestmentAmount=1000, StartDate=new DateTime(2011,01,01) } },
                { 2, new AnnualCompoundedInvestment() { Id=2, InterestRate_Annual=(0.22M), InvestmentAmount=2200, StartDate=new DateTime(2022,02,03) } },
                { 3, new MonthlyCompoundedInvestment() { Id=3, InterestRate_Annual=(0.13M), InvestmentAmount=3030, StartDate=new DateTime(2003,03,03) } },
                { 4, new SimpleInvestment() { Id=4, InterestRate_Annual=(0.14M), InvestmentAmount=40004, StartDate=new DateTime(2014,04,04) } },
                { 5, new MonthlyCompoundedInvestment() { Id=5, InterestRate_Annual=(0.05M), InvestmentAmount=500000, StartDate=new DateTime(1995,05,05) } },
                { 6, new AnnualCompoundedInvestment() { Id=6, InterestRate_Annual=(0.006M), InvestmentAmount=6000, StartDate=new DateTime(2006,06,06) } }
            };

            for (int i = 1; i <= CLIENT_COUNT; i++)
            {
                _clients[i].Investments.Add(_investments[i]);
            }
            _clients.Last().Value.Investments.Add(_investments.Last().Value);
        }

        public Client GetClient(string id)
        {
            if (!int.TryParse(id, out int intId))
                return null;

            return _clients[intId];
        }

        public List<Client> GetClients()
        {
            return _clients.Values.ToList<Client>();
        }

        #region INTERNAL FUNCTIONS for easily mocking investment data

        internal Dictionary<int, IInvestment> GetInvestmentDictionary()
        {
            return _investments;
        }

        internal Dictionary<int, Client> GetClientDictionary()
        {
            return _clients;
        }

        #endregion INTERNAL FUNCTIONS for easily mocking investment data
    }
}
