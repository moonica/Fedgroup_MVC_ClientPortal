namespace Fedgroup_MVC_ClientPortal.Models
{
    public static class InvestmentFactory
    {
        /// <summary>
        /// Creates an instance of an Investment class depending on the investment type
        /// </summary>
        public static Investment CreateInvestment(InvestmentType investmentType)
        {
            switch (investmentType)
            {
                case InvestmentType.CompoundedMonthly:
                    return new MonthlyCompoundedInvestment();

                case InvestmentType.CompoundedAnnually:
                    return new AnnualCompoundedInvestment();

                case InvestmentType.Simple:
                default:
                    return new SimpleInvestment();
            }
        }
    }
}
