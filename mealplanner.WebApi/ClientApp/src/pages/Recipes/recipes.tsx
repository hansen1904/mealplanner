import { RecipeList } from '../../components/Recipes/RecipeList/RecipeList.styled';
import { Component } from 'react';

export class Recipes extends Component {
  static displayName = Recipes.name;

  render() {
    return (
        <div>
            <p>This is Recipes page</p>
            <RecipeList/>
       </div>
    );
  }
}