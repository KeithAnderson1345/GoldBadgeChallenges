using C2_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace C2_Claims_UnitTests
{
    [TestClass]
    public class ClaimMenuRepoTests
    {
        private ClaimMenuRepo _queueRepoTests;
        private Queue<ClaimMenu> seeClaim;

        [TestInitialize]
        public void Arrange()
        {
            DateTime accident = new DateTime(2020, 12, 05);

            _queueRepoTests = new ClaimMenuRepo();
            ClaimMenu Claim = new ClaimMenu("KA1345", ClaimType.Auto, "Wreck on 65", 23450.00m, accident, DateTime.Now, true);
            
            _queueRepoTests.AddNewClaim(Claim);
            seeClaim = new Queue<ClaimMenu>();
            
        }

        [TestMethod]
        public void AddNewClaimToQueue_ShouldGetNotNull()
        {
            //Arrange
            DateTime theft = new DateTime(2020, 12, 08);
            ClaimMenu claim = new ClaimMenu("BC1200", ClaimType.Theft, "Stolen grill", 234.00m, theft, DateTime.Now, true);

            

            //Act            
            _queueRepoTests.AddNewClaim(claim); //This adds a 2nd claim to the queue
            ClaimMenu getClaimID = _queueRepoTests.GetClaimListByID("BC1200"); //This tests the Helper method in the repository as well

            //Assert
            
            Assert.IsNotNull(getClaimID); //Verifies that the "BC1200" claim was added to the queue and could be retrieved by the GetClaimListByID method

        }

        [TestMethod]
        public void GetClaimsList_ShouldGetIsTrue()
        {
            //Arrange
            //Done in Initialize section

            //Act
            seeClaim = _queueRepoTests.GetClaimsList();


            //Assert
            Assert.IsTrue(seeClaim.Count == 1); //There should only be one claim in the queue that was set in the initialize test

        }

        [TestMethod]
        public void RemoveFromQueue_()
        {
            //Arrange
            DateTime theft = new DateTime(2020, 12, 08);
            ClaimMenu claim = new ClaimMenu("BC1200", ClaimType.Theft, "Stolen grill", 234.00m, theft, DateTime.Now, true);
            ClaimMenu testClaim = new ClaimMenu();
            

            //Act
            _queueRepoTests.AddNewClaim(claim); //Adds new claim "BC1200" to the queue. There should now be 2 total claims
            _queueRepoTests.RemoveFromQueue(); //Removes the initialized claim "KA1345" from the queue (first in, first out)
            testClaim = _queueRepoTests.GetClaimListByID("BC1200");

            //Assert
            Assert.IsTrue(testClaim.ClaimID == "BC1200"); //Verifies that "BC1200" was still in the queue after the removal
        }
    }
}
