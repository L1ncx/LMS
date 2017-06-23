using RiskAssessment.Web.Managers;

namespace RiskAssessment.Web.Models
{
    public class CustomerViewModel
    {
        public CustomerViewModel(CustomerData customerData, ICustomerRiskAssesmentManager crm)
        {
            CustomerName = crm.Customer;
            IsCurrentStakeTenTimesHigherThanAverage = crm.IsCurrentStakeTenTimesHigherThanAverage.ToYesNoString();
            IsCurrentStakeThirtyTimesHigherThanAverage = crm.IsCurrentStakeThirtyTimesHigherThanAverage.ToYesNoString();
            IsCurrentWinningOnRiskAmount = crm.IsCurrentWinningOnRiskAmount.ToYesNoString();
            IsUnusualRateWinner = crm.IsUnusualRateWinner.ToYesNoString();

            Event = customerData.Event;
            Stake = customerData.Stake;
            Participant = customerData.Participant;
            Win = customerData.Win;

            FontColor = crm.IsUnusualRateWinner ? "#FF0000" : "#000000";
        }

        public string CustomerName { get; set; }
        public string Event { get; set; }
        public string Participant { get; set; }
        public decimal Stake { get; set; }
        public decimal Win { get; set; }
        

        public string IsUnusualRateWinner { get; set; }
        public string IsCurrentStakeTenTimesHigherThanAverage { get; set; }
        public string IsCurrentStakeThirtyTimesHigherThanAverage { get; set; }
        public string IsCurrentWinningOnRiskAmount { get; set; }

        public string FontColor { get; set; }
    }

    public static class BooleanExtensions
    {
        public static string ToYesNoString(this bool value)
        {
            return value ? "Yes" : "No";
        }
    }

}