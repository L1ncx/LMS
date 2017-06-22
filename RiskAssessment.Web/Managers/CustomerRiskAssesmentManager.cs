using System.Collections.Generic;
using System.Linq;

namespace RiskAssessment.Web.Managers
{
        public class CustomerRiskAssesmentManager : ICustomerRiskAssesmentManager
    {
        private readonly string _event;
        private readonly List<CustomerData> _unsettled;

        public CustomerRiskAssesmentManager(string customer, string @event, List<CustomerData> settled, List<CustomerData> unsettled)
        {
            var settledData = settled;
            _event = @event;
            _unsettled = unsettled;
            Customer = customer;

            NumberOfBetsMade = settledData.Count(c => c.CustomerName == customer);
            NumberOfTimesWon = settledData.Count(c => c.CustomerName == customer && c.Win > 0);

            if (NumberOfBetsMade > 0)
            {
                AverageStake = (settledData.Where(c => c.CustomerName == customer).Sum(c => c.Stake) /
                                NumberOfBetsMade);

                IsUnusualRateWinner = CheckUnusualRateWinner();
            }
            IsCurrentWinningOnRiskAmount = CheckCurrentWinningOnRiskAmount();

            IsCurrentStakeTenTimesHigherThanAverage = CheckCurrentStakeHigherThanAverage();
            IsCurrentStakeThirtyTimesHigherThanAverage = CheckCurrentStakeHigherThanAverage(30);

        }
        public string Customer { get; set; }

        public decimal AverageStake { get; set; }
        public decimal NumberOfBetsMade { get; set; }
        public decimal NumberOfTimesWon { get; set; }

        public bool IsUnusualRateWinner { get; set; }
        public bool IsCurrentStakeTenTimesHigherThanAverage { get; set; }
        public bool IsCurrentStakeThirtyTimesHigherThanAverage { get; set; }
        public bool IsCurrentWinningOnRiskAmount { get; set; }


        // just call this methods in the constructor, i could have opt to make this interface methods 
        // for better testability, but for simplicity just made it privates

        private bool CheckUnusualRateWinner()
        {
            return ((NumberOfTimesWon / NumberOfBetsMade) * 100) > 60;
        }

        private bool CheckCurrentStakeHigherThanAverage(int multiplier = 10)
        {
            return _unsettled.Any(u =>  u.Event == _event && u.Stake > (AverageStake * multiplier));
        }

        private bool CheckCurrentWinningOnRiskAmount()
        {
            return _unsettled.Any(u => u.Event == _event && u.Win >= 1000);
        }

    }







}