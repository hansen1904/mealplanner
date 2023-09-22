import styled from 'styled-components'
import Grid from '@mui/material/Grid'; // Grid version 1

export const NavbarGrid = styled(Grid)`
    width: 300px;
`

export const ContentGrid = styled(Grid)`
    width: calc(100% - 300px);
    display: flex;
    padding: 40px;
`