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
        private ClaimMenu items;

        [TestInitialize]
        public void Arrange()
        {
            DateTime accident = new DateTime(2020, 12, 05);

            _queueRepoTests = new ClaimMenuRepo();
            ClaimMenu claim = new ClaimMenu("KA1345", ClaimType.Auto, "Wreck on 65", 23450.00m, accident, DateTime.Now, true);
            
            _queueRepoTests.AddNewClaim(claim);
            seeClaim = new Queue<ClaimMenu>();
            
        }

        [TestMethod]
        public void AddNewClaimToQueue_ShouldReturnTrue()
        {
            //Arrange
            DateTime theft = new DateTime(2020, 12, 08);
            ClaimMenu claim = new ClaimMenu("BC1200", ClaimType.Theft, "Stolen grill", 234.00m, theft, DateTime.Now, true);

            

            //Act            
            bool wasAdded = _queueRepoTests.AddNewClaim(claim); //This adds a 2nd claim to the queue            

            //Assert            
            Assert.IsTrue(wasAdded); //Verifies that the "BC1200" claim was added to the queue

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
        public void RemoveFromQueue_ShouldReturnTrue()
        {
            //Arrange - Done in initialize section                    

            //Act            
            bool wasRemoved = _queueRepoTests.RemoveFromQueue(); //Removes the initialized claim "KA1345" from the queue (first in, first out)
            

            //Assert
            Assert.IsTrue(wasRemoved); //Verifies that a claim was removed from the queue
        }

        [TestMethod]
        public void GetClaimListByID_ShouldGetAreEqual()
        {
            //Arrange
            string claimID = "KA1345";

            //Act
            items = _queueRepoTests.GetClaimListByID(claimID);

            //Assert
            Assert.AreEqual(claimID, items.ClaimID); //Verifies the claim ID's match
        }
    }
}
