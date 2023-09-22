import { SnackBarContext, SnackBarContextAction } from "components/SnackBar/CustomSnackBar";
import { useContext } from "react";

export const useSnackBar = (): SnackBarContextAction => {
    const context = useContext(SnackBarContext)

    if(!context) {
        throw new Error("useSnackBar must be used within an SnackBarProvider");
    }

    return context;
}