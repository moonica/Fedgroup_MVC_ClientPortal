using Fedgroup_MVC_ClientPortal.Models.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fedgroup_MVC_ClientPortal.Models
{
    public enum InvestmentType
    {
        Simple,
        CompoundedMonthly,
        CompoundedAnnually
    }

    /// <summary>
    /// A simple investment class for investments with their basic properties
    /// </summary>
    public class InvestmentContext
    {
        internal InvestmentType _investmentType;

        /// <summary>
        /// Dictionary of natural language names for different investment types, for display
        /// </summary>
        private static Dictionary<InvestmentType, string> _investmentTypeNames = new()
        {
            { InvestmentType.Simple, "Simple" },
            { InvestmentType.CompoundedMonthly, "Compounded Monthly" },
            { InvestmentType.CompoundedAnnually, "Compounded Annually" }
        };

        /// <summary>
        /// Unique ID for an investment
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date the investment was made
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The principle amount initially invested
        /// </summary>
        public decimal InvestmentAmount { get; set; }

        /// <summary>
        /// The interest rate (as a percentage per annum) 
        /// </summary>
        public decimal InterestRate_Annual { get; set; }

        /// <summary>
        /// Investment type (simple, compounded monthly, compounded annually). An enum value of type InvestmentType. Readonly - the type should not be set manually but determined by which type of investment is being instantiated (eg. using the InvestmentFactory)
        /// </summary>
        public InvestmentType InvestmentType { get { return _investmentType; } }

        public string InvestmentTypeName
        {
            get
            {
                return _investmentTypeNames[InvestmentType];
            }
        }

        /// <summary>
        /// Returns the friendly name of an investment type enum value
        /// </summary>
        public static string GetInvestmentTypeName(InvestmentType investmentType)
        {
            return _investmentTypeNames[investmentType];
        }
    }

    /// <summary>
    /// An abstract base class that is an implementation of the IInvestment class. This class allows the use of different investment objects to be used in the views and viewmodels of the application. It is not intended to be created as a concrete investment.
    /// </summary>
    public abstract class Investment : InvestmentContext, IInvestment
    {
        internal Investment(InvestmentType investmentType)
        {
            _investmentType = investmentType;
        }

        public abstract double? CalculateForecast(DateTime endDate);

        /// <summary>
        /// Performs validation checks on an end date before it is used in eg. forecasting, to ensure it's in the future and after an investment's start date
        /// </summary>
        internal bool validateEndDate(DateTime endDate, DateTime startDate)
        {
            return
                endDate.CompareTo(DateTime.Now) >= 0
                &&
                endDate.CompareTo(startDate) >= 0;
        }

        /// <summary>
        /// Calculates compound interest calculations for different frequencies (eg. compounded monthly or annually) using the formula [A = P * (1 + r/n)^(n*t)]. This is a base/reusable method intended for reuse by specialised Investment classes, not for directly performing end-user calculations.
        /// </summary>
        internal double? calculateCompoundedInterest(DateTime endDate, int compoundFrequency)
        {
            if (!validateEndDate(endDate, StartDate))
                return null;

            // A = P * (1 + r/n)^(n*t) where A = Final amount, P = Initial principal balance, r = Interest rate, n = Number of times interest applied per time period, t = Number of time periods elapsed

            var numberOfYears = endDate.Subtract(StartDate).TotalDays / 365;

            double? forecast = (double)InvestmentAmount * Math.Pow((1 + (double)InterestRate_Annual / compoundFrequency), (compoundFrequency * numberOfYears));

            return forecast;
        }

    }

    /// <summary>
    /// An investment class that inherits from Investment, that uses simple interest
    /// </summary>
    public class SimpleInvestment : Investment
    {
        public SimpleInvestment(): base(InvestmentType.Simple) { }        

        /// <summary>
        /// Calculates simple interest earned for a given investment and end date and returns the forecast amount (principle + interest)
        /// </summary>
        public override double? CalculateForecast(DateTime endDate)
        {
            if (!validateEndDate(endDate, StartDate))
                return null;

            //Simple Interest Rate = (Principle * Rate of Interest * Time Period (years))/ 100
            var numberOfYears = endDate.Subtract(StartDate).TotalDays / 365;
            var interest = (double)InvestmentAmount * (double)InterestRate_Annual * numberOfYears / 100;

            double? forecast = interest + (double)InvestmentAmount;
            return forecast;
        }
    }

    /// <summary>
    /// An investment class that inherits from Investment, that uses compound interest compounded monthly
    /// </summary>
    public class MonthlyCompoundedInvestment : Investment
    {
        public MonthlyCompoundedInvestment() : base(InvestmentType.CompoundedMonthly) { }

        /// <summary>
        /// Calculates compound interest earned for a given investment and end date, where interest is compounded monthly, using the formula [A = P * (1 + r/n)^(n*t)]. Returns the forecast amount (principle + interest)
        /// </summary>
        public override double? CalculateForecast(DateTime endDate)
        {
            return calculateCompoundedInterest(endDate, 12);
        }
    }

    public class AnnualCompoundedInvestment : Investment
    {
        public AnnualCompoundedInvestment() : base(InvestmentType.CompoundedAnnually) { }

        /// <summary>
        /// Calculates compound interest earned for a given investment and end date, where interest is compounded annually, using the formula [A = P * (1 + r/n)^(n*t)]. Returns the forecast amount (principle + interest)
        /// </summary>
        public override double? CalculateForecast(DateTime endDate)
        {
            return calculateCompoundedInterest(endDate, 1);
        }
    }
}
