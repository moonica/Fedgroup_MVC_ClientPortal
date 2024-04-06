using Fedgroup_MVC_ClientPortal.Models.Interfaces;

namespace Fedgroup_MVC_ClientPortal.DAL.Interfaces
{
    public interface IInvestmentRepository
    {
        /// <summary>
        /// Return all investments belonging to the given client
        /// </summary>
        public List<IInvestment> GetInvestmentsByClient(string clientId);

        /// <summary>
        /// Return a list of all investments (no client data - to retrieve client investment data, retrieve clients with their investments)
        /// </summary>
        public List<IInvestment> GetInvestments();

        /// <summary>
        /// Return a specific investment (no client data - to retrieve client investment data, retrieve clients with their investments)
        /// </summary>
        public IInvestment GetInvestment(int investmentId);
    }
}
