import * as React from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import TextField from '@mui/material/TextField';
import foodproductService from '../../../services/foodproduct.service';
import CreateFoodProductCommand from 'types/Requests/CreateFoodProductCommand.typed';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import { category } from 'types/Category.type';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';
import { useSnackBar } from 'hooks/use-snackBar';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';

export default function AddFoodProduct() {
    const [open, setOpen] = React.useState(false);
    const [loading, setLoading] = React.useState(false);

    const [pfName, setPfName] = React.useState<string>("");
    const [pfNameError, setPfNameError] = React.useState<boolean>(false);

    const [pfCategory, setPfCategory] = React.useState<category>(category.None);
    const [pfBrand, setPfBrand] = React.useState<string>("");
    const [pfCaloriePr100, setPfCaloriePr100] = React.useState<number>();
    const [pfProteinPr100, setPfProteinPr100] = React.useState<number>();
    const [pfCarbohydratesPr100, setPfCarbohydratesPr100] = React.useState<number>();
    const [pfFatPr100, setPfFatPr100] = React.useState<number>();
    const [pfFiberPr100, setPfFiberPr100] = React.useState<number>();
    const [pfSaltPr100, setPfSaltPr100] = React.useState<number>();
    const [pfSugerPr100, setPfSugerPr100] = React.useState<number>();

    const snackBar = useSnackBar();
    
    const request: CreateFoodProductCommand = {
        name: pfName,
        brand: pfBrand,
        category: pfCategory,
        caloriePr100: pfCaloriePr100 ?? 0,
        proteinPr100: pfProteinPr100 ?? 0,
        carbohydratesPr100: pfCarbohydratesPr100 ?? 0,
        fatPr100: pfFatPr100 ?? 0,
        fiberPr100: pfFiberPr100 ?? 0,
        saltPr100: pfSaltPr100 ?? 0,
        sugerPr100: pfSugerPr100 ?? 0
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
                    await foodproductService.create(request);
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
                                    error={pfNameError}
                                    required
                                    id="name-required"
                                    label="Name"
                                    value={pfName}
                                    onChange={(e) => {
                                        if(e.target.value === ''){
                                            setPfNameError(true)
                                        }else{
                                            setPfNameError(false)
                                        }

                                        setPfName(e.target.value);
                                    }}
                                    onBlur={(e) => {
                                        if(e.target.value === ''){
                                            setPfNameError(true)
                                        }else{
                                            setPfNameError(false)
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
                                    value={pfBrand}
                                    onChange={(e) => {
                                        setPfBrand(e.target.value);
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
                                        value={pfCategory}
                                        onChange={(e) => {
                                            setPfCategory(Number(e.target.value) as category)
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
                                    value={pfCaloriePr100}
                                    onChange={(e) => {
                                        setPfCaloriePr100(Number(e.target.value));
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
                                    value={pfCarbohydratesPr100}
                                    onChange={(e) => {
                                        setPfCarbohydratesPr100(Number(e.target.value));
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
                                    value={pfFatPr100}
                                    onChange={(e) => {
                                        setPfFatPr100(Number(e.target.value));
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
                                    value={pfProteinPr100}
                                    onChange={(e) => {
                                        setPfProteinPr100(Number(e.target.value));
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
                                    value={pfSaltPr100}
                                    onChange={(e) => {
                                        setPfSaltPr100(Number(e.target.value));
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
                                    value={pfSugerPr100}
                                    onChange={(e) => {
                                        setPfSugerPr100(Number(e.target.value));
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
                                    value={pfFiberPr100}
                                    onChange={(e) => {
                                        setPfFiberPr100(Number(e.target.value));
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