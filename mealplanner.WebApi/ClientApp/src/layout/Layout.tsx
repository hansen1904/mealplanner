import { Outlet } from "react-router-dom";
import Grid from '@mui/material/Grid'; // Grid version 1
import Navbar from "../components/NavBar/NavBar";
import CssBaseline from '@mui/material/CssBaseline';
import { NavbarGrid, ContentGrid } from 'layout/Layout.styled'

function Layout() {

  return (
    <>
      <CssBaseline enableColorScheme />
      <Grid container>
        <NavbarGrid>
          <Navbar/>
        </NavbarGrid>
        <ContentGrid> 
          <Outlet />
        </ContentGrid>
      </Grid>
    </>
  );
}

export default Layout;