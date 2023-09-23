using mealplanner.Domain.Entities;
using mealplanner.Domain.Enums;

namespace mealplanner.Application.FoodItems.Queries.GetFoodItemById
{
    public record RecievedFoodItemDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public Category Category { get; private set; }
        public double CaloriePr100 { get; private set; }
        public double ProteinPr100 { get; private set; }
        public double CarbohydratesPr100 { get; private set; }
        public double FatPr100 { get; private set; }

        public double? FiberPr100 { get; private set; }
        public double? SugerPr100 { get; private set; }
        public double? SaltPr100 { get; private set; }

        public RecievedFoodItemDto(FoodItem foodProduct)
        {
            Id = foodProduct.Id;
            Name = foodProduct.Name;
            Brand = foodProduct.Brand;
            Category = foodProduct.Category;
            CaloriePr100 = foodProduct.CaloriePr100;
            ProteinPr100 = foodProduct.ProteinPr100;
            CarbohydratesPr100 = foodProduct.CarbohydratesPr100;
            FatPr100 = foodProduct.FatPr100;
            FiberPr100 = foodProduct.FiberPr100;
            SugerPr100 = foodProduct.SugerPr100;
            SaltPr100 = foodProduct.SaltPr100;
        }
    }
}
