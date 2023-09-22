import Alert, { AlertColor } from "@mui/material/Alert";
import Snackbar from "@mui/material/Snackbar";
import Typography from "@mui/material/Typography";
import { createContext, useState } from "react"

export type SnackBarContextAction = {
  showSnackBar: (text: string, typeColor: AlertColor) => void
}

export const SnackBarContext = createContext({} as SnackBarContextAction);

interface SnackBarContextProviderProps {
  children: React.ReactNode
}

export const SnackBarProvider = ({ children }: SnackBarContextProviderProps) => {
  const [open, setOpen] = useState(false);
  const [message, setMessage] = useState<string>("");
  const [TypeColor, setTypeColor] = useState<AlertColor>("success");

  const showSnackBar = (text: string, color: AlertColor) => {
    setMessage(text);
    setTypeColor(color);
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
    setTypeColor("info");
  };

  return (
    <SnackBarContext.Provider value={{ showSnackBar }}>
      <Snackbar
        autoHideDuration={6000}
        anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}
        open={open}
        onClose={handleClose}
        key={'bottomcenter'}
      >
        <Alert onClose={handleClose} variant="filled" severity={TypeColor}>
          <Typography>{message}</Typography>
        </Alert>
      </Snackbar>
      {children}
    </SnackBarContext.Provider>
  );

};