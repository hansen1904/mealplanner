using mealplanner.Application.FoodItems.Commands.CreateFoodItem;
using mealplanner.Application.FoodItems.Commands.DeleteFoodItem;
using mealplanner.Application.FoodItems.Commands.ReadExcelFile;
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
    public class FoodItemsController : ApiControllerBase
    {
        private readonly ILogger<FoodItemsController> _logger;

        public FoodItemsController(ILogger<FoodItemsController> logger)
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
            _logger.LogInformation("Received request about creating food item");

            await Mediator.Send(command);

            _logger.LogInformation("Successful created food item");

            return Created("", null);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Receiving a food item by id",
            Description = "Requires admin privileges",
            OperationId = "GetFoodItem"
        )]
        [SwaggerResponse((int)HttpStatusCode.OK, "The food item was received", typeof(ReceivedFoodItemDto))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "The food item was not found")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> GetFoodItemById(Guid id)
        {
            _logger.LogInformation("Received request about getting food item with id {Id}", id);

            var foodItem = await Mediator.Send(new GetFoodItemByIdQuery { id = id });

            if (foodItem is null)
            {
                _logger.LogInformation("Didn't find a food item with id {id}", id);
                return NotFound();
            }

            _logger.LogInformation("Found a food item with id {id}", id);

            return Ok(foodItem);
        }

        [HttpGet("All")]
        [SwaggerOperation(
            Summary = "Receiving a list of all food item",
            Description = "Requires admin privileges",
            OperationId = "GetListOfAllFoodItem"
        )]
        [SwaggerResponse((int)HttpStatusCode.OK, "List of all food item was received", typeof(ReceivedListOfAllFoodItemDto))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Couldn't find any food item")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> GetListOfAllFoodItems(int offset, int limit)
        {
            _logger.LogInformation("Received request about getting list of all food items");

            var listOfFoodItems = await Mediator.Send(new GetAllFoodItemQuery() { Offset = offset, Limit = limit });

            if (listOfFoodItems is null)
            {
                _logger.LogInformation("Couldn't find any food items");
                return NotFound();
            }

            _logger.LogInformation("Found {count} food items ", listOfFoodItems.ReceivedFoodItem.Count);

            return Ok(listOfFoodItems);
        }

        [HttpGet("ByCategory/{category}")]
        [SwaggerOperation(
            Summary = "Receiving a list of food item by category",
            Description = "Requires admin privileges",
            OperationId = "GetListOfFoodItemsByCategory"
        )]
        [SwaggerResponse((int)HttpStatusCode.OK, "List of food item by category was received", typeof(ReceivedFoodItemByCategoryDto))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Couldn't find any food item with the given category")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> GetListOfFoodItemsByCategory(FoodCategory category, int offset, int limit)
        {
            _logger.LogInformation("Received request about getting list of food items with category {Category}", category);

            var listOfFoodItems = await Mediator.Send(new GetFoodItemByCategoryQuery { Category = category, Offset = offset, Limit = limit });

            if (listOfFoodItems is null)
            {
                _logger.LogInformation("Didn't find any food item with category {category}", category);
                return NotFound();
            }

            _logger.LogInformation("Found {count} food items with category {category}", listOfFoodItems.ReceivedFoodItem.Count, category);

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
            _logger.LogInformation("Received request about updating food item with id {Id}", command.Id);

            await Mediator.Send(command);

            _logger.LogInformation("Successful update food item with id {id}", command.Id);

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
            _logger.LogInformation("Received request about deleting food item with id {Id}", command.Id);

            await Mediator.Send(command);

            _logger.LogInformation("Successful deleted food item with id {id}", command.Id);

            return Ok();
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Read Excel File",
            Description = "Requires admin privileges",
            OperationId = "ReadExcelFile"
        )]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "The food item was deleted", typeof(string))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> ReadExcelFile()
        {

            var request = new ReadExcelFileCommand();

            await Mediator.Send(request);

            return Ok();
        }
    }
}
