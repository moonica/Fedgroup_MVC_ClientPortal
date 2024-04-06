using Fedgroup_MVC_ClientPortal.Models.Interfaces;

namespace Fedgroup_MVC_ClientPortal.Models
{
    /// <summary>
    /// A simple structure for client particulars
    /// </summary>
    public class ClientDetails
    {
        public string IdNumber;
        public string FirstName;
        public string LastName;
    }

    /// <summary>
    /// A model for storing a client with their particulars and a list of their investments
    /// </summary>
    public class Client : ClientDetails
    { 
        public List<IInvestment> Investments;
    }
}
