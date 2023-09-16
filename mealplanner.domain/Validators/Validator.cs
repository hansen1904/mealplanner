using FluentValidation;
using FluentValidation.Results;

namespace mealplanner.Domain.Validators
{
    public abstract class Validator<T> : AbstractValidator<T>
    {
        protected override void RaiseValidationException(ValidationContext<T> context, ValidationResult result)
        {
            var ex = new ValidationException(result.Errors);
            var message = "Validation failed:";

            foreach (var error in ex.Errors)
            {
                message += "\n -- " + error.ErrorMessage;
            }

            throw new ArgumentException(message, ex);
        }
    }
}
