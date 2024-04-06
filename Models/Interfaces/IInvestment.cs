namespace Fedgroup_MVC_ClientPortal.Models.Interfaces
{
    public interface IInvestment
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public decimal InvestmentAmount { get; set; }
        public decimal InterestRate_Annual { get; set; }
        public InvestmentType InvestmentType { get; }

        public double? CalculateForecast(DateTime endDate);
    }

}
