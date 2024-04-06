using Fedgroup_MVC_ClientPortal.Models.Interfaces;

namespace Fedgroup_MVC_ClientPortal.Models.ViewModels
{
    /// <summary>
    /// Viewmodel for displaying an investment with its client details
    /// </summary>
    public class ClientInvestment
    {
        public IInvestment Investment { get; set; }
        public ClientDetails Client { get; set; }

        public ClientInvestment() { }

        /// <summary>
        /// Flattens a list of clients with their investments into a single list of investments, with client details as properties
        /// </summary>
        public static List<ClientInvestment> FlattenClientListInvestments(List<Client> clients) 
        {
            if ((clients?.Count() ?? 0) == 0)
                return null;

            var result = new List<ClientInvestment>();

            clients.ForEach(c => FlattenClientInvestments(c, result));

            return result;
        }

        /// <summary>
        /// Flattens a list of clients with their investments into a single list of investments, with client details as properties, and adds them to the given list
        /// </summary>
        public static List<ClientInvestment> FlattenClientInvestments(Client client, List<ClientInvestment> listToAddTo = null)
        {
            if (listToAddTo == null)
                listToAddTo = new();

            client?.Investments?
                .ForEach(i => 
                    listToAddTo.Add(new ClientInvestment() { Client = client, Investment = i }));

            return listToAddTo;
        }
    }

    /// <summary>
    /// Viewmodel for displaying investments with their client details
    /// </summary>
    public class ClientInvestmentViewModel
    {
        public List<ClientInvestment> Investments;
        public DateTime ForecastEndDate;
    }
}
