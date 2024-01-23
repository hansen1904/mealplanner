using FluentValidation;
using mealplanner.Domain.Entities;

namespace mealplanner.Domain.Validators
{
    public sealed class RecipeValidator : Validator<Recipe>
    {
        public RecipeValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Type).NotNull();
        }
    }
}
