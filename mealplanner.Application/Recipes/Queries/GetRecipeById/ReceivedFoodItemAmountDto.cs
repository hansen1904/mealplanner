using mealplanner.Application.FoodItems.Queries.GetFoodItemById;
using mealplanner.Domain.ValueObjects;

namespace mealplanner.Application.Recipes.Queries.GetRecipeById
{
    public sealed record ReceivedFoodItemAmountDto
    {
        public double Amount { get; private set; }
        public ReceivedFoodItemDto? FoodItem { get; private set; }

        public ReceivedFoodItemAmountDto(FoodItemAmount foodItemAmount)
        {
            Amount = foodItemAmount.Amount;
            FoodItem = new ReceivedFoodItemDto(foodItemAmount.FoodItem);
        }
    }
}
