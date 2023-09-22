import { FoodProductList } from '../../components/FoodProduct/FPList/FPList.styled';
import FoodProductCreatePopup from '../../components/FoodProduct/FPCreatePopup/FPCreatePopup'

const Recipes = () => { 
    return (
       <div>
            <p>This is Recipes page</p>
            <FoodProductList />
            <FoodProductCreatePopup />
       </div>
    );
};

export default Recipes