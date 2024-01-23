using FluentValidation;

namespace mealplanner.Application.FoodItems.Commands.CreateFoodItem
{
    public sealed class CreateFoodItemCommandValidator : AbstractValidator<CreateFoodItemCommand>
    {
        public CreateFoodItemCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Brand).NotEmpty();
            RuleFor(x => x.Category).NotEmpty().InclusiveBetween(0, 3);
            RuleFor(x => x.CaloriePr100).NotEmpty();
            RuleFor(x => x.ProteinPr100).NotEmpty();
            RuleFor(x => x.CarbohydratesPr100).NotEmpty();
            RuleFor(x => x.FatPr100).NotEmpty();
        }
    }
}
