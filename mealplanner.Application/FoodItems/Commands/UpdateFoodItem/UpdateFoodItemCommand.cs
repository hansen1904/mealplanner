using MediatR;

namespace mealplanner.Application.FoodItems.Commands.UpdateFoodItem
{
    public class UpdateFoodItemCommand : IRequest
    {
        public Guid Id { get; set; }
        public double? CaloriePr100 { get; set; }
        public double? ProteinPr100 { get; set; }
        public double? CarbohydratesPr100 { get; set; }
        public double? FatPr100 { get; set; }

        public double? FiberPr100 { get; set; }
        public double? SugerPr100 { get; set; }
        public double? SaltPr100 { get; set; }
    }

    public class UpdateFoodItemCommandEventHandler : IRequestHandler<UpdateFoodItemCommand>
    {
        public UpdateFoodItemCommandEventHandler()
        {

        }

        public Task Handle(UpdateFoodItemCommand request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
