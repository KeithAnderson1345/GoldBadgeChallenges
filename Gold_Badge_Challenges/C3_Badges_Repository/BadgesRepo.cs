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
        public bool AddBadgeToDictionary(Badges badges)
        {
            int initCount = _dictionaryOfBadges.Count;
            _dictionaryOfBadges.Add(badges.BadgeID, badges);
            if (initCount < _dictionaryOfBadges.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
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
