using Fedgroup_MVC_ClientPortal.Models;

namespace Fedgroup_MVC_ClientPortal.DAL.Interfaces
{
    public interface IClientRepository
    {
        /// <summary>
        /// Returns a specific client
        /// </summary>
        public Client GetClient(string id);

        /// <summary>
        /// Returns a list of all clients
        /// </summary>
        public List<Client> GetClients();
    }
}
