import * as React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea, Chip, Grid, Rating } from '@mui/material';
import Recipe from 'types/Recipe/Recipe.type';
import { useEffect, useState } from 'react';
import recipeService from 'services/recipe.service';
import { useSnackBar } from 'hooks/use-snackBar';

const RecipeList: React.FC<{}> = () => {
    const [RecipeList, setRecipeList] = useState<Recipe[] | null>([]);
    const snackBar = useSnackBar();
    
    useEffect(() => {

        (async () => {
            const data = await recipeService.getAll(0, 100);
            if(data.data){
                setRecipeList(data.data.receivedRecipe);
            } else {
                snackBar.showSnackBar("Couldn't fetch recipe", "error");
            }
        })();
    }, [snackBar]);

    const handleClick = () => {
        console.log("Clicked")
    }

    return (
        <>
            <Grid container spacing={2}>
                {RecipeList?.map((key, index) => (
                    <Grid item xs={6} key={index}>
                        
                        <Card>
                            <CardActionArea onClick={handleClick}>
                                <CardContent>
                                    <Typography gutterBottom variant="h5" component="div">
                                        {key.name}
                                    </Typography>
                                    <Rating name="read-only" value={3} readOnly />
                                    <Typography variant="body2" color="text.secondary">
                                        Lizards are a widespread group of squamate reptiles, with over 6,000
                                        species, ranging across all continents except Antarctica
                                    </Typography>
                                    <Chip label="Vegansk" />
                                </CardContent>
                            </CardActionArea>
                        </Card>
                    </Grid>
                ))}
            </Grid>
        </>
    );
};

export default RecipeList;