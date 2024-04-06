using Fedgroup_MVC_ClientPortal.Models.Interfaces;

namespace Fedgroup_MVC_ClientPortal.Models.ViewModels
{
    /// <summary>
    /// Viewmodel used to display an investment with its details and forecast value
    /// </summary>
    public class ForecastViewModel : InvestmentContext
    {
        public double? ForecastAmount;
        public DateTime EndDate;
        public string Sender;
        public InvestmentType InvestmentType {  get; set; } //override the readonly value from the base class

        public ForecastViewModel() { }

        public ForecastViewModel(IInvestment investment)
        {
            Id = investment.Id;
            InvestmentAmount = investment.InvestmentAmount;
            InvestmentType = investment.InvestmentType;
            InterestRate_Annual = investment.InterestRate_Annual;
            StartDate = investment.StartDate;
        }
    }
}
