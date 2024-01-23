using mealplanner.Application.Repository;
using MediatR;

namespace mealplanner.Application.FoodItems.Commands.UpdateFoodItem
{
    public sealed record UpdateFoodItemCommand : IRequest
    {
        public Guid Id { get; set; }
        public double? CaloriePr100 { get; set; }
        public double? ProteinPr100 { get; set; }
        public double? CarbohydratesPr100 { get; set; }
        public double? FatPr100 { get; set; }

        public double? FiberPr100 { get; set; }
        public double? SugarPr100 { get; set; }
        public double? SaltPr100 { get; set; }
    }

    public sealed class UpdateFoodItemCommandEventHandler : IRequestHandler<UpdateFoodItemCommand>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateFoodItemCommandEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateFoodItemCommand request, CancellationToken cancellationToken)
        {
            var foodItem = _unitOfWork.FoodItemRepo().GetById(request.Id);
            
            if (foodItem != null)
            {

                foodItem.Update(request.CaloriePr100, request.ProteinPr100, request.CarbohydratesPr100, request.FatPr100, request.FiberPr100, request.SugarPr100, request.SaltPr100);

                _unitOfWork.FoodItemRepo().Update(foodItem);
                _unitOfWork.Save();

            }            

            return Task.CompletedTask;
        }
    }
}
