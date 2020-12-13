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
        public void AddBadgeToDictionary_ShouldGetEqual()
        {
            //Arrange            
            _badgesRepo = new BadgesRepo();

            //Act
            _badgesRepo.AddBadgeToDictionary(_badges);            
            var badge = _badgesRepo.GetBadgeByID(_badges.BadgeID);

            //Assert
            Assert.AreEqual(_badges.BadgeID, badge);
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
            _badgesRepo.AddBadgeToDictionary(_badges);
            bool added = _badgesRepo.AddDoorToExistingBadge(_badges.BadgeID, newDoors, _badges);

            //Assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void RemoveDoorFromExistingBadge()
        {
            //Arrange
            _badgesRepo = new BadgesRepo();
            List<string> doorsToRemove = new List<string>
            {
                "B1",
                "B2"
            };

            //Act
            _badgesRepo.AddBadgeToDictionary(_badges);
            bool deleted = _badgesRepo.DeleteDoorFromExistingBadge(_badges.BadgeID, doorsToRemove, _badges);

            //Assert
            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void ReadDictionaryList()
        {
            //Arrange
            _badgesRepo = new BadgesRepo();

            //Act
            _badgesRepo.AddBadgeToDictionary(_badges);
            var list = _badgesRepo.GetBadgeList();


            //Assert
            Assert.AreEqual(list.Count, _badgeDictionary.Count);
        }
    }
}
