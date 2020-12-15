using C3_Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace C3_Badges_UnitTests
{
    [TestClass]
    public class BadgesTests
    {
        private Badges _badges;
        private BadgesRepo _badgesRepo;
        
        private Dictionary<int, Badges> _badgeDictionary = new Dictionary<int, Badges>();

        [TestInitialize]
        public void Setup()
        {
            _badgesRepo = new BadgesRepo();

            List<string> badges = new List<string>
            {
                "A1",
                "A2",
                "B1",
                "B2"
            };

            int badgeID = 12345;

            _badges = new Badges(badgeID, badges);
            
            _badgesRepo.AddBadgeToDictionary(_badges);  //Seeds the dictionary for testing                   
        }
        
        
        [TestMethod]
        public void AddBadgeToDictionary_ShouldReturnTrue()
        {
            //Arrange            
            _badgesRepo = new BadgesRepo();

            //Act
            bool wasAdded = _badgesRepo.AddBadgeToDictionary(_badges); //Adds _badges data (from initialize section) to the dictionary           

            //Assert
            Assert.IsTrue(wasAdded); //Verifies the new badge data was added
        }

        [TestMethod]
        public void AddDoorToExistingBadge_ShouldReturnTrue()
        {
            //Arrange            
            List<string> newDoors = new List<string>
            {
                "B3",
                "B4",
                "B5"
            };

            //Act            
            bool added = _badgesRepo.AddDoorToExistingBadge(_badges.BadgeID, newDoors, _badges); //Adds new doors to the existing badge from initialize section

            //Assert
            Assert.IsTrue(added); //Verifies doors were added
        }

        [TestMethod]
        public void RemoveDoorFromExistingBadge_ShouldReturnTrue()
        {
            //Arrange            
            List<string> doorsToRemove = new List<string>
            {
                "B1",
                "B2"
            };

            //Act            
            bool deleted = _badgesRepo.DeleteDoorFromExistingBadge(_badges.BadgeID, doorsToRemove, _badges); //Deletes B1,B2 from the list established in the 
                                                                                                             //initialize test method data

            //Assert
            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void ReadDictionaryList_ShouldBeTrue()
        {
            //Arrange - Done in initialize section           

            //Act            
            var list = _badgesRepo.GetBadgeList(); //returns the badges in the dictionary

            //Assert
            Assert.IsTrue(list.Count == 1); //Verifies that the badge from the initialize test method was added and the count is  
                                                                 //equal to (1) since only one badge was initialized
        }

        [TestMethod]
        public void GetBadgeByID_ShouldBeEqual()
        {
            //Arrange - Done in initialize section

            //Act
            int badgeID = _badgesRepo.GetBadgeByID(_badges.BadgeID);

            //Assert
            Assert.AreEqual(12345, badgeID); //Verifies the initialized badge number 12345 was returned from the GetBadgeByID method
        }
    }
}
