import React from 'react'
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import navBarItems from './navbarItems'
import { useLocation, useNavigate } from "react-router-dom";
import AvatarBar from './AvatarBar/AvatarBar';
import Logo from './Logo/Logo';
import { CustomDrawer, MenuList, MenuItem } from './NavBar.styled'

const Navbar: React.FC<{}> = () => {
    const navigate = useNavigate();

    const router = useLocation();
    const currentRoute = router.pathname;

    return (
      <CustomDrawer
        variant="permanent"
        anchor="left"
      >

        <Logo />

        <AvatarBar />

        <MenuList>
          {navBarItems.map((item, index) => (
            <MenuItem
                key={index}
                onClick={() => navigate(item.route)}
                className={currentRoute === '/'+item.route ? 'active' : 'nonActive'}
            >
              <ListItemIcon>
                {item.icon}
              </ListItemIcon>
              <ListItemText
                primary={item.label}
              />
            </MenuItem>
          ))}
        </MenuList>
      </CustomDrawer>
    );
};

export default Navbar