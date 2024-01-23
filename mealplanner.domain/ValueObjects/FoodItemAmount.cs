using mealplanner.Domain.Base;
using mealplanner.Domain.Entities;

namespace mealplanner.Domain.ValueObjects
{
    public sealed class FoodItemAmount : ValueObject
    {
        public Guid Id { get; set; }
        public double Amount { get; private set; }
        public Guid FoodItemId { get; set; }
        public FoodItem FoodItem { get; private set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        private FoodItemAmount()
        {
        }

        public static FoodItemAmount Create(FoodItem foodItem, double amount)
        {
            return new FoodItemAmount()
            {
                FoodItem = foodItem,
                Amount = amount,
                RecipeId = Guid.NewGuid(),
                FoodItemId = Guid.NewGuid()
            };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FoodItem;
            yield return Amount;
        }
    }
}
