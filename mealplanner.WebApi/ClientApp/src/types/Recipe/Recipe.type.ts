import FoodItem from "types/FoodItem/FoodItem.type";

export default interface Recipe {
    id: string,
    name: string,
    type: number,
    TotalCalorie: number,
    TotalProtein: number,

    TotalCarbohydrates: number,
    TotalFat: number,
    TotalFiber: number,
    TotalSugar: number,
    TotalSalt: number,
    listOfFood: FoodItem[],
    steps: string[]
};