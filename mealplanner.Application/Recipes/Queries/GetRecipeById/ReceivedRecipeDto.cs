using mealplanner.Application.FoodItems.Queries.GetFoodItemById;
using mealplanner.Domain.Entities;
using mealplanner.Domain.ValueObjects;
using System.Reflection.Metadata.Ecma335;

namespace mealplanner.Application.Recipes.Queries.GetRecipeById
{
    public sealed record ReceivedRecipeDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double TotalCalorie { get; private set; }
        public double TotalProtein { get; private set; }
        public double TotalCarbohydrates { get; private set; }
        public double TotalFat { get; private set; }

        public double? TotalFiber { get; private set; }
        public double? TotalSugar { get; private set; }
        public double? TotalSalt { get; private set; }
        public List<ReceivedFoodItemAmountDto> FoodAmount { get; private set; } = new List<ReceivedFoodItemAmountDto>();
        public List<string> Steps { get; private set; }

        public ReceivedRecipeDto(Recipe recipe)
        {
            Id = recipe.Id;
            Name = recipe.Name;
            TotalCalorie = recipe.TotalCalorie;
            TotalProtein = recipe.TotalProtein;
            TotalCarbohydrates = recipe.TotalCarbohydrates;
            TotalFat = recipe.TotalFat;
            TotalFiber = recipe.TotalFiber;
            TotalSugar = recipe.TotalSugar;
            TotalSalt = recipe.TotalSalt;
            FoodAmount = recipe.FoodAmount.Select(x => new ReceivedFoodItemAmountDto(x)).ToList();
            Steps = recipe.Steps;
        }
    }
}
