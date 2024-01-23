using FluentValidation;
using mealplanner.Domain.Entities;

namespace mealplanner.Domain.Validators
{
    public sealed class FoodItemValidator : Validator<FoodItem>
    {
        public FoodItemValidator() 
        { 
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Brand).NotNull().NotEmpty();
            RuleFor(x => x.Category).NotNull();
            RuleFor(x => x.CaloriePr100).NotNull();
            RuleFor(x => x.ProteinPr100).NotNull();
            RuleFor(x => x.CarbohydratesPr100).NotNull();
            RuleFor(x => x.FatPr100).NotNull();
        }
    }
}
