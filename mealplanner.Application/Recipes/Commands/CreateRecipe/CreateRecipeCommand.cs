using mealplanner.Application.Repository;
using mealplanner.Domain.Entities;
using mealplanner.Domain.Enums;
using mealplanner.Domain.ValueObjects;
using MediatR;

namespace mealplanner.Application.Recipes.Commands.CreateRecipe
{
    public sealed record CreateRecipeCommand : IRequest
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public List<FoodItemAmountRequest> ListOfFoodItem { get; set; }
    }

    public sealed record FoodItemAmountRequest
    {
        public Guid FoodItem { get; set; }
        public double Amount { get; set; }
    }

    public sealed class CreateRecipe : IRequestHandler<CreateRecipeCommand>
    {
        private IUnitOfWork _unitOfWork;

        public CreateRecipe(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            RecipeType type = RecipeType.None;
            try
            {
                type = (RecipeType)request.Type;
            }
            catch (Exception)
            {

                throw new Exception("Couldn't find recipe type");
            }

            var listOfFoodItem = new List<FoodItemAmount>();
            
            foreach (var item in request.ListOfFoodItem)
            {
                var foundFoodItem = _unitOfWork.FoodItemRepo().GetById(item.FoodItem);

                var newFoodItemAmount = FoodItemAmount.Create(foundFoodItem, item.Amount);
                listOfFoodItem.Add(newFoodItemAmount);
            };

            var model = Recipe.Create(
                request.Name,
                type
            );
            _unitOfWork.RecipeRepo().Create(model);
            _unitOfWork.Save();

            model.Update(null, null, listOfFoodItem, null);
            _unitOfWork.RecipeRepo().Update(model);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }
    }
}
