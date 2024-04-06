using Fedgroup_MVC_ClientPortal.Models.Interfaces;

namespace Fedgroup_MVC_ClientPortal.Models.ViewModels
{
    /// <summary>
    /// Viewmodel used to display a simple investment structure without client details, but with optional end date for calculating a forecast
    /// </summary>
    public class InvestmentViewModel : InvestmentContext
    {
        public DateTime EndDate;

        public InvestmentViewModel() { }

        public InvestmentViewModel(IInvestment investment)
        {
            Id = investment.Id;
        }

        public InvestmentViewModel(int investmentId)
        {
            Id = investmentId;
        }
    }
}
