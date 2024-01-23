using mealplanner.Domain.Entities;
using mealplanner.Domain.Enums;

namespace mealplanner.Test
{
    public class Any
    {
        public String String()
        {
            return "sdd";
        }

        public FoodCategory FoodCategory()
        {
            return new FoodCategory();
        }

        public FoodItem FoodItem()
        {
            return mealplanner.Domain.Entities.FoodItem
                .Create(
                String(),
                String(),
                FoodCategory(),
                0.0,
                0.0,
                0.0,
                0.0,
                0.0,
                0.0,
                0.0);
        }

    }
}
