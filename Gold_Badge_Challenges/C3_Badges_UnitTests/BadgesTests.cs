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
            List<string> badges = new List<string>
            {
                "A1",
                "A2",
                "B1",
                "B2"
            };

            int badgeID = 12345;

            _badges = new Badges(badgeID, badges);
            
            _badgeDictionary.Add(_badges.BadgeID, _badges);                     
        }
        
        
        [TestMethod]
        public void AddBadgeToDictionary_ShouldBeEqual()
        {
            //Arrange            
            _badgesRepo = new BadgesRepo();

            //Act
            _badgesRepo.AddBadgeToDictionary(_badges); //Adds _badges data to dictionary           
            var badge = _badgesRepo.GetBadgeByID(_badges.BadgeID); //sets Badge equal to ID added

            //Assert
            Assert.AreEqual(_badges.BadgeID, badge); //Verifies the new badge data was added
        }

        [TestMethod]
        public void AddDoorToExistingBadge_ShouldReturnTrue()
        {
            //Arrange
            _badgesRepo = new BadgesRepo();
            List<string> newDoors = new List<string>
            {
                "B3",
                "B4",
                "B5"
            };

            //Act
            _badgesRepo.AddBadgeToDictionary(_badges); //Adds the _badges data to the dictionary
            bool added = _badgesRepo.AddDoorToExistingBadge(_badges.BadgeID, newDoors, _badges); //Adds new doors to the existing badge

            //Assert
            Assert.IsTrue(added); //Verifies doors were added
        }

        [TestMethod]
        public void RemoveDoorFromExistingBadge_ShouldReturnTrue()
        {
            //Arrange
            _badgesRepo = new BadgesRepo();
            List<string> doorsToRemove = new List<string>
            {
                "B1",
                "B2"
            };

            //Act
            _badgesRepo.AddBadgeToDictionary(_badges); //Adds the _badges from initialize test to dictionary with existing doors. 
            bool deleted = _badgesRepo.DeleteDoorFromExistingBadge(_badges.BadgeID, doorsToRemove, _badges); //Deletes B1,B2 from the list established in the initialize test method data

            //Assert
            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void ReadDictionaryList_ShouldBeEqual()
        {
            //Arrange
            _badgesRepo = new BadgesRepo();

            //Act
            _badgesRepo.AddBadgeToDictionary(_badges); //Adds the _badges object created in the initialize method
            var list = _badgesRepo.GetBadgeList(); //returns the badges in the dictionary


            //Assert
            Assert.AreEqual(list.Count, _badgeDictionary.Count); //Verifies that the badge from the initialize test method was added and the count is equal to the dictionary count 
                                                                 //that was created in the initialize test method
        }
    }
}
