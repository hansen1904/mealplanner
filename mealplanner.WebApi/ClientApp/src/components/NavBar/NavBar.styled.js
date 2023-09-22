import styled from 'styled-components'
import Drawer from '@mui/material/Drawer';
import List from '@mui/material/List';
import ListItemButton from '@mui/material/ListItemButton';


export const CustomDrawer = styled(Drawer)`
  && > div {
    width: 300px;
  }
  
`;

export const MenuList = styled(List)`
  && {
    padding: 20px;
  }
`;

export const MenuItem = styled(ListItemButton)`
    && {
        border-radius: 8px;
    }

    &:hover {
        text-decoration: none;
        background-color: rgba(0, 0, 0, 0.04);
    }

    &.active {
        background-color: rgba(0, 0, 0, 0.04);
    }
`;

