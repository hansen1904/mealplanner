using mealplanner.Application.Repository;
using mealplanner.Domain.Enums;
using MediatR;

namespace mealplanner.Application.Recipes.Queries.GetRecipeByType
{
    public sealed record GetRecipeByTypeQuery : IRequest<ReceivedRecipeByTypeDto>
    {
        public RecipeType Type { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }

    public sealed class GetFoodProductByCategoryQueryHandler : IRequestHandler<GetRecipeByTypeQuery, ReceivedRecipeByTypeDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFoodProductByCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ReceivedRecipeByTypeDto> Handle(GetRecipeByTypeQuery request, CancellationToken cancellationToken)
        {
            var list = _unitOfWork.RecipeRepo().GetAllByType(request.Type, request.Offset, request.Limit);

            var response = ReceivedRecipeByTypeDto.Create(list);

            return Task.FromResult(response);
        }
    }
}
