using C2_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace C2_Claims_UnitTests
{
    [TestClass]
    public class ClaimMenuRepoTests
    {
        private ClaimMenu _queueClaims;
        private ClaimMenuRepo _queueRepo;

        [TestInitialize]
        public void Arrange()
        {
            DateTime accident = new DateTime(2020, 11, 14);

            _queueRepo = new ClaimMenuRepo();
            _queueClaims = new ClaimMenu("KA1345", ClaimType.Auto, "Wreck on 65", 23450.00m, accident, DateTime.Now, true);

            _queueRepo.AddNewClaim(_queueClaims);
        }

        [TestMethod]
        public void AddToQueue()
        {
            ClaimMenu claimMenu = new ClaimMenu();

        }
    }
}
