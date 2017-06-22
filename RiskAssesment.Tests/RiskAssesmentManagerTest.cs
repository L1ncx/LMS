using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiskAssessment.Web.Controllers;
using RiskAssessment.Web.Managers;
using RiskAssessment.Web.Models;

namespace RiskAssesment.Tests
{

    [TestClass]
    public class RiskAssesmentManagerTest
    {

        [TestMethod]
        public void WhenCustomerIsUnusualRateWinner()
        {
            // arrange 
            List<CustomerData> settledData = new List<CustomerData>()
            {
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 100},
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 100},
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 100},
            };

            var crm = new CustomerRiskAssesmentManager("Karlo", "Event1", settledData, new List<CustomerData>());

            Assert.IsTrue(crm.IsUnusualRateWinner);
        }

        [TestMethod]
        public void WhenCustomerIsNotUnusualRateWinner()
        {
            // arrange 
            List<CustomerData> settledData = new List<CustomerData>()
            {
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 100},
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = -100},
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = -100},
            };

            //act
            var crm = new CustomerRiskAssesmentManager("Karlo", "Event1", settledData, new List<CustomerData>());

            Assert.IsFalse(crm.IsUnusualRateWinner);
        }

        [TestMethod]
        public void WhenCustomerIsCurrentWinningOnRiskAmount()
        {
            // arrange 
            List<CustomerData> unsettledData = new List<CustomerData>()
            {
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 100},
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 200},
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 1000},
            };

            var crm = new CustomerRiskAssesmentManager("Karlo",  "Event1", new List<CustomerData>(), unsettledData);

            Assert.IsTrue(crm.IsCurrentWinningOnRiskAmount);
        }

        [TestMethod]
        public void WhenCustomerIsNotCurrentWinningOnRiskAmount()
        {
            // arrange 
            List<CustomerData> unsettledData = new List<CustomerData>()
            {
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 100},
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 200},
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 300},
            };

            var crm = new CustomerRiskAssesmentManager("Karlo", "Event1", new List<CustomerData>(), unsettledData);

            Assert.IsFalse(crm.IsCurrentWinningOnRiskAmount);
        }

        [TestMethod]
        public void WhenCurrentStakeIsTenTimesHigherThanAverage()
        {
            // arrange 
            List<CustomerData> settledData = new List<CustomerData>()
            {
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 100},
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 100},
            };
            List<CustomerData> unsettledData = new List<CustomerData>()
            {
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 1001,Win = 100},
            };

            var crm = new CustomerRiskAssesmentManager("Karlo", "Event1", settledData, unsettledData);

            Assert.IsTrue(crm.IsCurrentStakeTenTimesHigherThanAverage);
        }


        [TestMethod]
        public void WhenCurrentStakeIsThirtyTimesHigherThanAverage()
        {
            // arrange 
            List<CustomerData> settledData = new List<CustomerData>()
            {
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 100},
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 100,Win = 100},
            };
            List<CustomerData> unsettledData = new List<CustomerData>()
            {
                new CustomerData { CustomerName = "Karlo", Event = "Event1",Participant = "Participant1",Stake = 3001,Win = 1000},
            };

            var crm = new CustomerRiskAssesmentManager("Karlo", "Event1", settledData, unsettledData);

            Assert.IsTrue(crm.IsCurrentStakeThirtyTimesHigherThanAverage);
        }

    }
}
