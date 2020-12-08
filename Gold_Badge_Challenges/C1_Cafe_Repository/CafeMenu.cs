using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1_Cafe_Repository
{
    public class CafeMenu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> MealIngredients { get; set; } = new List<string>();
        public decimal MealPrice { get; set; }

        public CafeMenu() { }

        public CafeMenu(int mealNumber, string mealName, string mealDescription, List<string> mealIngredients, decimal mealPrice)
        {
            MealNumber = MealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
        }

    }
}
