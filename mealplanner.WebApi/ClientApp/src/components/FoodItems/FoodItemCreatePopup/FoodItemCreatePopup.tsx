import * as React from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import TextField from '@mui/material/TextField';
import foodItemService from '../../../services/fooditem.service';
import CreateFoodItemCommand from 'types/FoodItem/Requests/CreateFoodItemCommand.typed';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import { category } from 'types/Category.type';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';
import { useSnackBar } from 'hooks/use-snackBar';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';

export default function AddFoodItem() {
    const [open, setOpen] = React.useState(false);

    const [FoodItemName, setFoodItemName] = React.useState<string>("");
    const [FoodItemNameError, setFoodItemNameError] = React.useState<boolean>(false);

    const [FoodItemCategory, setFoodItemCategory] = React.useState<category>(category.None);
    const [FoodItemBrand, setFoodItemBrand] = React.useState<string>("");
    const [FoodItemCaloriePr100, setFoodItemCaloriePr100] = React.useState<number>();
    const [FoodItemProteinPr100, setFoodItemProteinPr100] = React.useState<number>();
    const [FoodItemCarbohydratesPr100, setFoodItemCarbohydratesPr100] = React.useState<number>();
    const [FoodItemFatPr100, setFoodItemFatPr100] = React.useState<number>();
    const [FoodItemFiberPr100, setFoodItemFiberPr100] = React.useState<number>();
    const [FoodItemSaltPr100, setFoodItemSaltPr100] = React.useState<number>();
    const [FoodItemSugarPr100, setFoodItemSugarPr100] = React.useState<number>();

    const snackBar = useSnackBar();
    
    const request: CreateFoodItemCommand = {
        name: FoodItemName,
        brand: FoodItemBrand,
        category: FoodItemCategory,
        caloriePr100: FoodItemCaloriePr100 ?? 0,
        proteinPr100: FoodItemProteinPr100 ?? 0,
        carbohydratesPr100: FoodItemCarbohydratesPr100 ?? 0,
        fatPr100: FoodItemFatPr100 ?? 0,
        fiberPr100: FoodItemFiberPr100 ?? 0,
        saltPr100: FoodItemSaltPr100 ?? 0,
        sugarPr100: FoodItemSugarPr100 ?? 0
    };
    
    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const HandleCreate = () => {
        (async () => {
            try{
                if(request.name === ''){
                    snackBar.showSnackBar("Must have a name", "error");
                } else {
                    await foodItemService.create(request);
                    setOpen(false);
                    snackBar.showSnackBar("Food product created!", "success");
                }
            }catch(err){
                console.log("Error: " + err);
                snackBar.showSnackBar("Something went wrong, contact owner", "error");
            }
        
        })();
    };

    return (
        <>

            <Button variant="contained" sx={{marginTop: 2}} disableElevation onClick={handleClickOpen}>
                <Typography sx={{ textTransform: "capitalize", margin: 1}}>New</Typography> 
            </Button>

            <Dialog
                open={open}
                onClose={handleClose}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
            >

                <DialogTitle id="alert-dialog-title">Create Food Product</DialogTitle>
                
                <DialogContent>

                    <DialogContentText id="alert-dialog-description">

                        <Grid container spacing={2} sx={{ paddingTop: 2, '& .MuiGrid-root .MuiFormControl-root': { width: '100%' } }}>
                            <Grid item xs={6}>
                                <TextField
                                    error={FoodItemNameError}
                                    required
                                    id="name-required"
                                    label="Name"
                                    value={FoodItemName}
                                    onChange={(e) => {
                                        if(e.target.value === ''){
                                            setFoodItemNameError(true)
                                        }else{
                                            setFoodItemNameError(false)
                                        }

                                        setFoodItemName(e.target.value);
                                    }}
                                    onBlur={(e) => {
                                        if(e.target.value === ''){
                                            setFoodItemNameError(true)
                                        }else{
                                            setFoodItemNameError(false)
                                        }
                                    }}
                                    InputLabelProps={{
                                        shrink: true,
                                    }}
                                />
                            </Grid>

                            <Grid item xs={6}>
                                <TextField
                                    id="name-required"
                                    label="Brand"
                                    value={FoodItemBrand}
                                    onChange={(e) => {
                                        setFoodItemBrand(e.target.value);
                                    }}
                                    InputLabelProps={{
                                        shrink: true,
                                    }}
                                />
                            </Grid>

                            <Grid item xs={6}>
                                <FormControl sx={{ width: '100%'}}>
                                    <InputLabel id="category-select-label">Category</InputLabel>
                                    <Select
                                        labelId="category-select-label"
                                        id="category-select-select"
                                        label="Category"
                                        value={FoodItemCategory}
                                        onChange={(e) => {
                                            setFoodItemCategory(Number(e.target.value) as category)
                                        }}
                                    >
                                        <MenuItem value={category.None}>None</MenuItem>
                                        <MenuItem value={category.Meat}>Meat</MenuItem>
                                        <MenuItem value={category.Fruit}>Fruit</MenuItem>
                                        <MenuItem value={category.Vegetables}>Vegetables</MenuItem>
                                    </Select>
                                </FormControl>
                            </Grid>

                            <Grid item xs={6}>
                                <TextField
                                    id="outlined-number"
                                    label="Calorie pr. 100 gram"
                                    type="number"
                                    value={FoodItemCaloriePr100}
                                    onChange={(e) => {
                                        setFoodItemCaloriePr100(Number(e.target.value));
                                    }}
                                    InputLabelProps={{
                                        shrink: true,
                                    }}
                                />
                            </Grid>
                            
                            <Grid item xs={6}>
                                <TextField
                                    id="outlined-number"
                                    label="Carbohydrate pr. 100 gram"
                                    type="number"
                                    value={FoodItemCarbohydratesPr100}
                                    onChange={(e) => {
                                        setFoodItemCarbohydratesPr100(Number(e.target.value));
                                    }}
                                    InputLabelProps={{
                                        shrink: true,
                                    }}
                                />
                            </Grid>

                            <Grid item xs={6}>
                                <TextField
                                    id="outlined-number"
                                    label="Fat pr. 100 gram"
                                    type="number"
                                    value={FoodItemFatPr100}
                                    onChange={(e) => {
                                        setFoodItemFatPr100(Number(e.target.value));
                                    }}
                                    InputLabelProps={{
                                        shrink: true,
                                    }}
                                />
                            </Grid>
                            
                            <Grid item xs={6}>
                                <TextField
                                    id="outlined-number"
                                    label="Protein pr. 100 gram"
                                    type="number"
                                    value={FoodItemProteinPr100}
                                    onChange={(e) => {
                                        setFoodItemProteinPr100(Number(e.target.value));
                                    }}
                                    InputLabelProps={{
                                        shrink: true,
                                    }}
                                />
                            </Grid>

                            <Grid item xs={6}>
                                <TextField
                                    id="outlined-number"
                                    label="Salt pr. 100 gram"
                                    type="number"
                                    value={FoodItemSaltPr100}
                                    onChange={(e) => {
                                        setFoodItemSaltPr100(Number(e.target.value));
                                    }}
                                    InputLabelProps={{
                                        shrink: true,
                                    }}
                                />
                            </Grid>
                            
                            <Grid item xs={6}>
                                <TextField
                                    id="outlined-number"
                                    label="Sugar pr. 100 gram"
                                    type="number"
                                    value={FoodItemSugarPr100}
                                    onChange={(e) => {
                                        setFoodItemSugarPr100(Number(e.target.value));
                                    }}
                                    InputLabelProps={{
                                        shrink: true,
                                    }}
                                />
                            </Grid>
                            
                            <Grid item xs={6}>
                                <TextField
                                    id="outlined-number"
                                    label="Fiber pr. 100 gram"
                                    type="number"
                                    value={FoodItemFiberPr100}
                                    onChange={(e) => {
                                        setFoodItemFiberPr100(Number(e.target.value));
                                    }}
                                    InputLabelProps={{
                                        shrink: true,
                                    }}
                                />
                            </Grid>
                        </Grid>
                    </DialogContentText>

                </DialogContent>

                <DialogActions>
                    <Button variant="contained" color="success" sx={{marginRight: 2, marginBottom: 2}} disableElevation onClick={HandleCreate}>
                        <Typography sx={{ textTransform: "capitalize", margin: 1}}>Create</Typography> 
                    </Button>
                    <Button variant="contained" color="error" sx={{marginRight: 2, marginBottom: 2}} disableElevation onClick={handleClose} autoFocus>
                        <Typography sx={{ textTransform: "capitalize", margin: 1}}>Cancel</Typography> 
                    </Button>
                </DialogActions>

            </Dialog>
        </>
    );
};