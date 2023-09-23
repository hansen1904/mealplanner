using FluentValidation;
using mealplanner.Domain.Base;
using mealplanner.Domain.Enums;
using mealplanner.Domain.Validators;

namespace mealplanner.Domain.Entities
{
    public class FoodItem : AuditableEntity
    {
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

        private FoodItem()
        { 
        }

        public static FoodItem Create(
            string name, 
            string brand,
            Category category, 
            double caloriePr100, 
            double proteinPr100, 
            double carbohydratesPr100, 
            double fatPr100, 
            double? fiberPr100, 
            double? sugerPr100, 
            double? saltPr100)
        {
            var model = new FoodItem()
            {
                Name = name,
                Brand = brand,
                Category = category,
                CaloriePr100 = caloriePr100,
                ProteinPr100 = proteinPr100,
                CarbohydratesPr100 = carbohydratesPr100,
                FatPr100 = fatPr100,
                FiberPr100 = fiberPr100,
                SugerPr100 = sugerPr100,
                SaltPr100 = saltPr100,
            };

            var validator = new FoodItemValidator();

            validator.ValidateAndThrow(model);

            return model;
        }

    }
}
