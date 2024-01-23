using mealplanner.Application.Repository;
using MediatR;

namespace mealplanner.Application.Recipes.Queries.GetRecipeById
{
    public sealed record GetRecipeByIdQuery : IRequest<ReceivedRecipeDto?>
    {
        public Guid Id { get; set; }
    }

    public sealed class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, ReceivedRecipeDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecipeByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ReceivedRecipeDto?> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            var model = _unitOfWork.RecipeRepo().GetById(request.Id);

            ReceivedRecipeDto response = null!;

            if (model != null)
            {
                response = new ReceivedRecipeDto(model);
            }

            return Task.FromResult(response);
        }
    }
}

