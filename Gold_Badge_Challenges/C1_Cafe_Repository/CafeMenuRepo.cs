using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1_Cafe_Repository
{
    public class CafeMenuRepo
    {
        private List<CafeMenu> _listOfMenuItems = new List<CafeMenu>();

        //Create
        public void AddMenuItemToList(CafeMenu item)
        {
            _listOfMenuItems.Add(item);
        }

        //Read
        public List<CafeMenu> GetMenuItemsList()
        {
            return _listOfMenuItems;
        }

        //Update --> Not needed for this challenge

        //Delete
        public bool DeleteMenuItemFromList(int item)
        {
            CafeMenu menuItem = GetMenuItemByNumber(item);

            if (menuItem == null)
            {
                return false;
            }

            int initListCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(menuItem);

            if (initListCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public CafeMenu GetMenuItemByNumber(int item)
        {
            foreach (CafeMenu menuItems in _listOfMenuItems)
            {
                if(menuItems.MealNumber == item)
                {
                    return menuItems;
                }
            }

            return null;
        }

    }
}
