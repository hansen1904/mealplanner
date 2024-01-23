using mealplanner.Application.Repository;
using mealplanner.Domain.Enums;
using mealplanner.Domain.ValueObjects;
using MediatR;

namespace mealplanner.Application.Recipes.Commands.UpdateRecipe
{
    public sealed record UpdateRecipeCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public RecipeType? Type { get; set; }
        public List<FoodItemAmount>? ListOfFood { get; set; }
        public List<string>? Steps { get; set; }
    }

    public sealed class UpdateRecipeCommandEventHandler : IRequestHandler<UpdateRecipeCommand>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateRecipeCommandEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = _unitOfWork.RecipeRepo().GetById(request.Id);

            if (recipe != null)
            {
                recipe.Update(
                    request.Name,
                    request.Type,
                    request.ListOfFood,
                    request.Steps);

                _unitOfWork.RecipeRepo().Update(recipe);
                _unitOfWork.Save();
            }

            return Task.CompletedTask;
        }
    }
}
