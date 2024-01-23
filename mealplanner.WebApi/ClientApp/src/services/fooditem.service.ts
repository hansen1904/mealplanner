import recievedFoodItemDtos from "types/FoodItem/Responses/receivedFoodItem";
import http from "../http-common";
import IFoodItem from "../types/FoodItem/FoodItem.type"
import CreateFoodItemCommand from "types/FoodItem/Requests/CreateFoodItemCommand.typed";
import DeleteFoodItemCommand from "types/FoodItem/Requests/DeleteFoodItemCommand.typed";

class FoodItemService {
    getAll(offset: number, limit: number) {
      return http.get<recievedFoodItemDtos>(`/v1/FoodItems/All?offset=${offset}&limit=${limit}`);
    }

    getAllByCategory(category: string) {
      return http.get<recievedFoodItemDtos>(`/v1/FoodItems/ByCategory/${category}`);
    }
  
    get(id: string) {
      return http.get<IFoodItem>(`/v1/FoodItems/${id}`);
    }
  
    create(data: CreateFoodItemCommand) {
      return http.post<any>("/v1/FoodItems", data);
    }
  
    update(data: IFoodItem, id: any) {
      return http.put<any>(`/v1/FoodItems/${id}`, data);
    }
  
    delete(data: DeleteFoodItemCommand) {
      return http.delete<any>(`/v1/FoodItems`, {data});
    }
}

export default new FoodItemService();