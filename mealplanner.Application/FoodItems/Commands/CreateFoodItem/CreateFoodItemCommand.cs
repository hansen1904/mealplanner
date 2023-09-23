using mealplanner.Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace mealplanner.Application.FoodItems.Commands.CreateFoodItem
{
    public class CreateFoodItemCommand : IRequest<CreateFoodItemResponse>
    {
        [Required]
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Category { get; set; }
        public double CaloriePr100 { get; set; }
        public double ProteinPr100 { get; set; }
        public double CarbohydratesPr100 { get; set; }
        public double FatPr100 { get; set; }
        public double? FiberPr100 { get; set; }
        public double? SugarPr100 { get; set; }
        public double? SaltPr100 { get; set; }
    }

    public class CreateFoodItemCommandEventHandler : IRequestHandler<CreateFoodItemCommand, CreateFoodItemResponse>
    {

        public CreateFoodItemCommandEventHandler()
        {

        }

        public Task<CreateFoodItemResponse> Handle(CreateFoodItemCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();

            return Task.FromResult(new CreateFoodItemResponse(id));
        }
    }
}
