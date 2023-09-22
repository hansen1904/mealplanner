import { category } from "types/Category.type";

export default interface CreateFoodProductCommand {
    name: string,
    brand: string,
    category: category,
    caloriePr100: number,
    proteinPr100: number,
    carbohydratesPr100: number,
    fatPr100: number,
    fiberPr100: number | null,
    saltPr100: number | null,
    sugerPr100: number | null
};