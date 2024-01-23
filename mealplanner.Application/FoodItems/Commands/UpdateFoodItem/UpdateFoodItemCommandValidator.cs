using FluentValidation;

namespace mealplanner.Application.FoodItems.Commands.UpdateFoodItem
{
    public sealed class UpdateFoodItemCommandValidator : AbstractValidator<UpdateFoodItemCommand>
    {
        public UpdateFoodItemCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
