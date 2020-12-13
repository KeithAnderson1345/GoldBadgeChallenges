using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Badges_Repository
{
    public class BadgesRepo
    {
        private Dictionary<int, Badges> _dictionaryOfBadges = new Dictionary<int, Badges>();

        //Create
        public void AddBadgeToDictionary(Badges badges)
        {
            _dictionaryOfBadges.Add(badges.BadgeID, badges);
        }

        //Read
        public Dictionary<int, Badges> GetBadgeList()
        {
            return _dictionaryOfBadges;
        }

        //Update
        public bool AddDoorToExistingBadge(int badgeID, List<string> doors, Badges newBadges)
        {
            int existingBadge = GetBadgeByID(badgeID);
            if(existingBadge != 0)
            {
                foreach (var door in doors)
                    newBadges.DoorNames.Add(door);
               
                _dictionaryOfBadges[badgeID].DoorNames = newBadges.DoorNames;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteDoorFromExistingBadge(int badgeID, List<string> doors, Badges newBadges)
        {
            int existingBadge = GetBadgeByID(badgeID);
            if (existingBadge != 0)
            {
                foreach (var door in doors)
                    newBadges.DoorNames.Remove(door);

                _dictionaryOfBadges[badgeID].DoorNames = newBadges.DoorNames;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public int GetBadgeByID(int badgeID)
        {
            foreach(KeyValuePair<int, Badges> badge in _dictionaryOfBadges)
            {
                if(badge.Key == badgeID)
                {
                    return badge.Key;
                }
            }
            return 0;
        }

    }
}
