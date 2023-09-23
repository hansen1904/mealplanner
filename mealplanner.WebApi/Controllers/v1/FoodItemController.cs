using mealplanner.Application.FoodItems.Commands.CreateFoodItem;
using mealplanner.Application.FoodItems.Commands.DeleteFoodItem;
using mealplanner.Application.FoodItems.Commands.UpdateFoodItem;
using mealplanner.Application.FoodItems.Queries.GetAllFoodItem;
using mealplanner.Application.FoodItems.Queries.GetFoodItemByCategory;
using mealplanner.Application.FoodItems.Queries.GetFoodItemById;
using mealplanner.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace mealplanner.WebApi.Controllers.v1
{
    public class FoodItemController : ApiControllerBase
    {
        private readonly ILogger<FoodItemController> _logger;

        public FoodItemController(ILogger<FoodItemController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new food item",
            Description = "Requires admin privileges",
            OperationId = "CreateFoodItem"
        )]
        [SwaggerResponse((int)HttpStatusCode.Created, "The food item was created")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> CreateFoodItem(CreateFoodItemCommand command)
        {
            _logger.LogInformation("Recived request about creating food item");
            var id = await Mediator.Send(command);

            return Created("", id);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Reciving a food item by id",
            Description = "Requires admin privileges",
            OperationId = "GetFoodItem"
        )]
        [SwaggerResponse((int)HttpStatusCode.OK, "The food item was recieved", typeof(RecievedFoodItemDto))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "The food item was not found")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> GetFoodItemById(Guid id)
        {
            _logger.LogInformation("Received request about getting food item with id {Id}", id);
            var foodItem = await Mediator.Send(new GetFoodItemByNameQuery { id = id });

            if (foodItem is null)
            {
                return NotFound();
            }

            return Ok(foodItem);
        }

        [HttpGet("All")]
        [SwaggerOperation(
            Summary = "Reciving a list of all food item",
            Description = "Requires admin privileges",
            OperationId = "GetListOfAllFoodItem"
        )]
        [SwaggerResponse((int)HttpStatusCode.OK, "List of all food item was recieved", typeof(RecievedListOfAllFoodItemDto))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Couldn't find any food item")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> GetListOfAllFoodItems()
        {
            _logger.LogInformation("Received request about getting list of all food items");
            var listOfFoodItem = await Mediator.Send(new GetAllFoodItemQuery { });

            if (listOfFoodItem is null)
            {
                return NotFound();
            }

            return Ok(listOfFoodItem);
        }

        [HttpGet("ByCategory/{category}")]
        [SwaggerOperation(
            Summary = "Reciving a list of food item by category",
            Description = "Requires admin privileges",
            OperationId = "GetListOfFoodItemsByCategory"
        )]
        [SwaggerResponse((int)HttpStatusCode.OK, "List of food item by category was recieved", typeof(RecievedFoodItemByCategoryDto))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Couldn't find any food item with the given category")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> GetListOfFoodItemsByCategory(Category category)
        {
            _logger.LogInformation("Received request about getting list of food items with category {Category}", category);
            var listOfFoodItems = await Mediator.Send(new GetFoodItemByCategoryQuery { Category = category });

            if (listOfFoodItems is null)
            {
                return NotFound();
            }

            return Ok(listOfFoodItems);
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Update a food item by id",
            Description = "Requires admin privileges",
            OperationId = "UpdateFoodItem"
        )]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "The food item was updated")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> UpdateFoodItem(UpdateFoodItemCommand command)
        {
            _logger.LogInformation("Recived request about updating food item with id {Id}", command.Id);
            await Mediator.Send(command);

            return NoContent();
        }


        [HttpDelete]
        [SwaggerOperation(
            Summary = "Delete food item",
            Description = "Requires admin privileges",
            OperationId = "DeleteFoodItem"
        )]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "The food item was deleted", typeof(string))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> DeleteFoodItem(DeleteFoodItemCommand command)
        {
            _logger.LogInformation("Recived request about deleting food item with id {Id}", command.Id);
            await Mediator.Send(command);

            return Ok();
        }
    }
}
