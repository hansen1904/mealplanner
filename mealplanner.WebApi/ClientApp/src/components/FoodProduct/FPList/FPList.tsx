import { DataGrid, GridColDef, GridRowSelectionModel } from '@mui/x-data-grid';
import FoodProduct from 'types/FoodProduct.type';
import React, { useEffect, useState } from 'react';
import foodproductService from 'services/foodproduct.service';
import { useSnackBar } from 'hooks/use-snackBar';
import Typography from '@mui/material/Typography';
import LoadingButton from '@mui/lab/LoadingButton';
import DeleteFoodProductCommand from 'types/Requests/DeleteFoodProductCommand.typed';
import { parse } from 'path';

const columns: GridColDef[] = [
    { field: 'name', headerName: 'Name', width: 130 },
    { field: 'brand', headerName: 'Brand', width: 130 },
    { field: 'caloriePr100', headerName: 'Calorie Pr. 100 gram', width: 150 },
    { field: 'carbohydratesPr100', headerName: 'Carbohydrate Pr. 100 gram', width: 200 },
    { field: 'fatPr100', headerName: 'Fat Pr. 100 gram', width: 130 },
    { field: 'proteinPr100', headerName: 'Protein Pr. 100 gram', width: 130 },
    { field: 'saltPr100', headerName: 'Salt Pr. 100 gram', width: 130 },
    { field: 'sugerPr100', headerName: 'Suger Pr. 100 gram', width: 130 }
];

const FoodProductList: React.FC<{}> = () => {
    const [FoodProductList, setFoodProductList] = useState<FoodProduct[] | null>([]);
    const snackBar = useSnackBar();
    const [loading, setLoading] = React.useState(false);
    const [rowSelectionModel, setRowSelectionModel] = React.useState<GridRowSelectionModel>([]);
    const [disabled, setDisabled] = React.useState<boolean>(true);

    useEffect(() => {

        (async () => {
            const data = await foodproductService.getAll();
            if(data.data){
                setFoodProductList(data.data.recievedFoodProductDtos);
            } else {
                snackBar.showSnackBar("Couldn't fetch food products", "error");
            }
        })();
    }, [snackBar]);
    
    const handleDeleteClick = () => {
        setLoading(true);
        (async () => {
            try{
                rowSelectionModel.map(async (currentId) => {
                    var convertedid = currentId.toString()

                    const request: DeleteFoodProductCommand = {
                        id: convertedid
                    };

                    await foodproductService.delete(request);
                    console.log(currentId);
                })
                setRowSelectionModel([]);
                snackBar.showSnackBar("Food product(s) deleted!", "success");
            }catch(err){
                console.log("Error: " + err);
                snackBar.showSnackBar("Something went wrong, contact owner", "error");
            }
        
        })();
        setLoading(false);
    }

    return (
        <>
            <div>
                <DataGrid
                    rows={FoodProductList ?? []}
                    columns={columns}
                    initialState={{
                        pagination: {
                        paginationModel: { page: 0, pageSize: 10},
                        },
                    }}
                    pageSizeOptions={[10, 25]}
                    checkboxSelection
                    onRowSelectionModelChange={(ids) => {
                        setRowSelectionModel(ids);
                        if(ids.length > 0){
                            setDisabled(false);
                        } else {
                            setDisabled(true);
                        }
                    }}
                />
            </div>

            <LoadingButton
            color="error"
            onClick={handleDeleteClick}
            loading={loading}
            loadingIndicator="Deleting…"
            variant="contained"
            sx={{marginTop: 2, marginRight: 2}}
            disabled={disabled}
            >
                <Typography sx={{ textTransform: "capitalize", margin: 1}}>Delete</Typography> 
            </LoadingButton>
        </>
    );
};

export default FoodProductList;