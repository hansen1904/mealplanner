import recievedFoodProductDtos from "types/Responses/recievedFoodProductDtos";
import http from "../http-common";
import IFoodProduct from "../types/FoodProduct.type"
import CreateFoodProductCommand from "types/Requests/CreateFoodProductCommand.typed";
import CreatedFoodProductResponse from "types/Responses/CreatedFoodProductResponse.typed";
import DeleteFoodProductCommand from "types/Requests/DeleteFoodProductCommand.typed";

class FoodProductService {
    getAll() {
      return http.get<recievedFoodProductDtos>(`/FoodProduct/All`);
    }

    getAllByCategory(category: string) {
      return http.get<recievedFoodProductDtos>(`/FoodProduct/ByCategory/${category}`);
    }
  
    get(id: string) {
      return http.get<IFoodProduct>(`/FoodProduct/${id}`);
    }
  
    create(data: CreateFoodProductCommand) {
      return http.post<CreatedFoodProductResponse>("/FoodProduct", data);
    }
  
    update(data: IFoodProduct, id: any) {
      return http.put<any>(`/FoodProduct/${id}`, data);
    }
  
    delete(data: DeleteFoodProductCommand) {
      return http.delete<any>(`/FoodProduct`, {data});
    }
}

export default new FoodProductService();