using mealplanner.Application.FoodItems.Commands.DeleteFoodItem;
using mealplanner.Application.Recipes.Commands.CreateRecipe;
using mealplanner.Application.Recipes.Commands.DeleteRecipe;
using mealplanner.Application.Recipes.Commands.UpdateRecipe;
using mealplanner.Application.Recipes.Queries.GetAllRecipe;
using mealplanner.Application.Recipes.Queries.GetRecipeById;
using mealplanner.Application.Recipes.Queries.GetRecipeByType;
using mealplanner.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace mealplanner.WebApi.Controllers.v1
{
    public class RecipesController : ApiControllerBase
    {
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(ILogger<RecipesController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new recipe",
            Description = "Requires admin privileges",
            OperationId = "CreateRecipe"
        )]
        [SwaggerResponse((int)HttpStatusCode.Created, "The recipe was created")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> CreateRecipe(CreateRecipeCommand request)
        {
            _logger.LogInformation("Received request about creating recipe");

            await Mediator.Send(request);

            _logger.LogInformation("Successful created recipe");

            return Created("", null);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Receiving a recipe by id",
            Description = "Requires admin privileges",
            OperationId = "GetRecipeById"
        )]
        [SwaggerResponse((int)HttpStatusCode.OK, "The recipe was received", typeof(ReceivedRecipeDto))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "The recipe was not found")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> GetRecipeById(Guid id)
        {
            _logger.LogInformation("Received request about getting recipe with id {Id}", id);

            var recipe = await Mediator.Send(new GetRecipeByIdQuery { Id = id });

            if (recipe is null)
            {
                _logger.LogInformation("Didn't find a recipe with id {id}", id);
                return NotFound();
            }

            _logger.LogInformation("Found a recipe with id {id}", id);

            return Ok(recipe);
        }

        [HttpGet("All")]
        [SwaggerOperation(
            Summary = "Receiving a list of all recipe",
            Description = "Requires admin privileges",
            OperationId = "GetListOfAllRecipes"
        )]
        [SwaggerResponse((int)HttpStatusCode.OK, "List of all recipe was received", typeof(ReceivedListOfAllRecipeDto))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Couldn't find any recipe")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> GetListOfAllRecipes(int offset, int limit)
        {
            _logger.LogInformation("Received request about getting list of all recipes");

            var listOfRecipe = await Mediator.Send(new GetAllRecipeQuery() { Offset = offset, Limit = limit });

            if (listOfRecipe is null)
            {
                _logger.LogInformation("Couldn't find any recipes");
                return NotFound();
            }

            _logger.LogInformation("Found {count} recipes ", listOfRecipe.ReceivedRecipe.Count);

            return Ok(listOfRecipe);
        }

        [HttpGet("ByType/{type}")]
        [SwaggerOperation(
            Summary = "Receiving a list of recipe by type",
            Description = "Requires admin privileges",
            OperationId = "GetListOfRecipesByType"
        )]
        [SwaggerResponse((int)HttpStatusCode.OK, "List of recipe by type was received", typeof(ReceivedRecipeByTypeDto))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Couldn't find any recipe with the given type")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> GetListOfRecipesByType(RecipeType type, int offset, int limit)
        {
            _logger.LogInformation("Received request about getting list of recipes with type {Type}", type);

            var listOfRecipe = await Mediator.Send(new GetRecipeByTypeQuery { Type = type, Offset = offset, Limit = limit });

            if (listOfRecipe is null)
            {
                _logger.LogInformation("Didn't find any recipe with type {Type}", type);
                return NotFound();
            }

            _logger.LogInformation("Found {count} recipes with type {Type}", listOfRecipe.ReceivedRecipe.Count, type);

            return Ok(listOfRecipe);
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Update a recipe by id",
            Description = "Requires admin privileges",
            OperationId = "UpdateRecipe"
        )]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "The recipe was updated")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> UpdateRecipe(UpdateRecipeCommand command)
        {
            _logger.LogInformation("Received request about updating recipe with id {Id}", command.Id);

            await Mediator.Send(command);

            _logger.LogInformation("Successful update recipe with id {id}", command.Id);

            return NoContent();
        }

        [HttpDelete]
        [SwaggerOperation(
            Summary = "Delete recipe",
            Description = "Requires admin privileges",
            OperationId = "DeleteRecipe"
        )]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "The recipe was deleted", typeof(string))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "The request data is invalid")]
        public async Task<IActionResult> DeleteRecipe(DeleteRecipeCommand command)
        {
            _logger.LogInformation("Received request about deleting recipe with id {Id}", command.Id);

            await Mediator.Send(command);

            _logger.LogInformation("Successful deleted recipe with id {id}", command.Id);

            return Ok();
        }
    }
}
