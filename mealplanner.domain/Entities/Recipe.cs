using mealplanner.Domain.Base;
using mealplanner.Domain.Enums;
using mealplanner.Domain.ValueObjects;

namespace mealplanner.Domain.Entities
{
    public sealed class Recipe : AuditableEntity
    {
        public string Name { get; private set; }
        public RecipeType Type { get; private set; }
        public double TotalCalorie { get; private set; }
        public double TotalProtein { get; private set; }
        public double TotalCarbohydrates { get; private set; }
        public double TotalFat { get; private set; }

        public double? TotalFiber { get; private set; }
        public double? TotalSugar { get; private set; }
        public double? TotalSalt { get; private set; }

        public List<FoodItemAmount> FoodAmount { get; private set; } = new List<FoodItemAmount>();
        public List<string> Steps { get; private set; }

        private Recipe()
        {
        }

        public static Recipe Create(string name, RecipeType type)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is invalid");
            }

            var recipe = new Recipe()
            {
                Name = name,
                Type = type,
                Steps = new List<string>()
            };

            return recipe;
        }

        public void Update(
            string? Name,
            RecipeType? Type,
            List<FoodItemAmount>? ListOfFood,
            List<string>? Steps)
        {
            if (Name is not null)
            {
                this.Name = Name;
            }

            if (Type is not null)
            {
                this.Type = (RecipeType)Type;
            }

            if (ListOfFood is not null)
            {
                UpdateMacros(ListOfFood);
            }

            if (Steps is not null)
            {
                this.Steps = Steps;
            }
        }

        private void CalculateMacros(List<FoodItemAmount> listOfFoodItems)
        {
            this.TotalCalorie = listOfFoodItems.Sum(fi => (fi.FoodItem.CaloriePr100 / 100) * fi.Amount);
            this.TotalProtein = listOfFoodItems.Sum(fi => (fi.FoodItem.ProteinPr100 / 100) * fi.Amount);
            this.TotalCarbohydrates = listOfFoodItems.Sum(fi => (fi.FoodItem.CarbohydratesPr100 / 100) * fi.Amount);
            this.TotalFat = listOfFoodItems.Sum(fi => (fi.FoodItem.FatPr100 / 100) * fi.Amount);

            this.TotalFiber = listOfFoodItems.Sum(fi => (fi.FoodItem.FiberPr100 / 100) * fi.Amount ?? 0);
            this.TotalFat = listOfFoodItems.Sum(fi => (fi.FoodItem.SugarPr100 / 100) * fi.Amount ?? 0);
            this.TotalFat = listOfFoodItems.Sum(fi => (fi.FoodItem.SaltPr100 / 100) * fi.Amount ?? 0);

            this.FoodAmount.AddRange(listOfFoodItems);
        }

        private void UpdateMacros(List<FoodItemAmount> listOfFoodItems)
        {
            this.TotalCalorie = listOfFoodItems.Sum(fi => (fi.FoodItem.CaloriePr100 / 100) * fi.Amount);
            this.TotalProtein = listOfFoodItems.Sum(fi => (fi.FoodItem.ProteinPr100 / 100) * fi.Amount);
            this.TotalCarbohydrates = listOfFoodItems.Sum(fi => (fi.FoodItem.CarbohydratesPr100 / 100) * fi.Amount);
            this.TotalFat = listOfFoodItems.Sum(fi => (fi.FoodItem.FatPr100 / 100) * fi.Amount);

            this.TotalFiber = listOfFoodItems.Sum(fi => (fi.FoodItem.FiberPr100 / 100) * fi.Amount ?? 0);
            this.TotalFat = listOfFoodItems.Sum(fi => (fi.FoodItem.SugarPr100 / 100) * fi.Amount ?? 0);
            this.TotalFat = listOfFoodItems.Sum(fi => (fi.FoodItem.SaltPr100 / 100) * fi.Amount ?? 0);

            FoodAmount.Clear();
            this.FoodAmount.AddRange(listOfFoodItems);
        }
    }
}
