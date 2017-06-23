namespace RiskAssessment.Web.Managers
{
    public interface ICustomerRiskAssesmentManager
    {
        decimal AverageStake { get; set; }
        string Customer { get; set; }
        bool IsCurrentStakeTenTimesHigherThanAverage { get; set; }
        bool IsCurrentStakeThirtyTimesHigherThanAverage { get; set; }
        bool IsCurrentWinningOnRiskAmount { get; set; }
        bool IsUnusualRateWinner { get; set; }
        decimal NumberOfBetsMade { get; set; }
        decimal NumberOfTimesWon { get; set; }
    }
}