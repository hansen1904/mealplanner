using mealplanner.Application.Repository;
using MediatR;


namespace mealplanner.Application.Recipes.Queries.GetAllRecipe
{

    public sealed record GetAllRecipeQuery : IRequest<ReceivedListOfAllRecipeDto>
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }

    public sealed class GetAllRecipeQueryHandler : IRequestHandler<GetAllRecipeQuery, ReceivedListOfAllRecipeDto>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllRecipeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ReceivedListOfAllRecipeDto> Handle(GetAllRecipeQuery request, CancellationToken cancellationToken)
        {
            var list = _unitOfWork.RecipeRepo().GetAll(request.Offset, request.Limit);

            var response = ReceivedListOfAllRecipeDto.Create(list);

            return Task.FromResult(response);
        }
    }
}
