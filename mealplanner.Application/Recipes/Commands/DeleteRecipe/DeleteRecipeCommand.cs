using mealplanner.Application.Repository;
using MediatR;

namespace mealplanner.Application.Recipes.Commands.DeleteRecipe
{
    public sealed record DeleteRecipeCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public sealed class DeleteRecipeCommandEventHandler : IRequestHandler<DeleteRecipeCommand>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteRecipeCommandEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {

            _unitOfWork.RecipeRepo().Delete(request.Id);
            _unitOfWork.Save();

            return Task.CompletedTask;
        }
    }
}
