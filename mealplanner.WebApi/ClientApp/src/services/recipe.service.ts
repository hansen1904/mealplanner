import recievedRecipeDtos from "types/Recipe/Responses/recievedRecipeDtos";
import http from "../http-common";
import IRecipe from "types/Recipe/Recipe.type";
import CreateFoodItemCommand from "types/FoodItem/Requests/CreateFoodItemCommand.typed";
import DeleteFoodItemCommand from "types/FoodItem/Requests/DeleteFoodItemCommand.typed";

class RecipeService {
    getAll(offset: number, limit: number) {
      return http.get<recievedRecipeDtos>(`/v1/Recipes/All?offset=${offset}&limit=${limit}`);
    }

    getAllByCategory(category: string) {
      return http.get<recievedRecipeDtos>(`/v1/Recipes/ByCategory/${category}`);
    }
  
    get(id: string) {
      return http.get<IRecipe>(`/v1/Recipes/${id}`);
    }
  
    create(data: CreateFoodItemCommand) {
      return http.post<any>("/v1/Recipes", data);
    }
  
    update(data: IRecipe, id: any) {
      return http.put<any>(`/v1/Recipes/${id}`, data);
    }
  
    delete(data: DeleteFoodItemCommand) {
      return http.delete<any>(`/v1/Recipes`, {data});
    }
}

export default new RecipeService();