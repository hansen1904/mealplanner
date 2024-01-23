using FluentValidation;
using mealplanner.Domain.Base;
using mealplanner.Domain.Enums;
using mealplanner.Domain.Validators;
using mealplanner.Domain.ValueObjects;

namespace mealplanner.Domain.Entities
{
    public sealed class FoodItem : AuditableEntity
    {
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public FoodCategory Category { get; private set; }
        public double CaloriePr100 { get; private set; }
        public double ProteinPr100 { get; private set; }
        public double CarbohydratesPr100 { get; private set; }
        public double FatPr100 { get; private set; }

        public double? FiberPr100 { get; private set; }
        public double? SugarPr100 { get; private set; }
        public double? SaltPr100 { get; private set; }
        public List<FoodItemAmount> FoodAmount { get; private set; } = new List<FoodItemAmount>();

        private FoodItem()
        { 
        }

        public static FoodItem Create(
            string name, 
            string brand,
            FoodCategory category, 
            double caloriePr100, 
            double proteinPr100, 
            double carbohydratesPr100, 
            double fatPr100, 
            double? fiberPr100, 
            double? sugarPr100, 
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
                SugarPr100 = sugarPr100,
                SaltPr100 = saltPr100,
            };

            var validator = new FoodItemValidator();

            validator.ValidateAndThrow(model);

            return model;
        }

        public FoodItem Update(
            double? caloriePr100, 
            double? proteinPr100, 
            double? carbohydratesPr100, 
            double? fatPr100, 
            double? fiberPr100,
            double? sugarPr100, 
            double? saltPr100)
        {
            if (caloriePr100 is not null)
            {
                this.CaloriePr100 = (double)caloriePr100;
            }

            if (proteinPr100 is not null)
            {
                this.ProteinPr100 = (double)proteinPr100;
            }

            if (carbohydratesPr100 is not null)
            {
                this.CarbohydratesPr100 = (double)carbohydratesPr100;
            }

            if (fatPr100 is not null)
            {
                this.FatPr100 = (double)fatPr100;
            }

            if (fiberPr100 is not null)
            {
                this.FiberPr100 = (double)fiberPr100;
            }

            if (sugarPr100 is not null)
            {
                this.SugarPr100 = (double)sugarPr100;
            }

            if (saltPr100 is not null)
            {
                this.SaltPr100 = (double)saltPr100;
            }

            return this;
        }

    }
}
