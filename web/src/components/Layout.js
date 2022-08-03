import axios from "axios";
import React, { useEffect, useState } from "react";
import Box from '@mui/material/Box';
import { Typography } from "@mui/material";
import List from '@mui/material/List';
import Divider from '@mui/material/Divider';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import Drawer from '@mui/material/Drawer';
import ListAltIcon from '@mui/icons-material/ListAlt';
import AddIcon from '@mui/icons-material/Add';
import ListSubheader from '@mui/material/ListSubheader';
import {
    Link,
    useNavigate
} from "react-router-dom";

function Layout(props) {
    const [openDrawer, setOpenDrawer] = useState(false)
    const [title, setTitle] = useState('Permissions')

    const navigate = useNavigate()

    const navigateAndUpdateTitle = (route, title) => {
        setTitle(title)
        navigate(route)
    }

    const toggleDrawer =
        (open) =>
            (event) => {
                if (
                    event.type === 'keydown' &&
                    ((event).key === 'Tab' ||
                        (event).key === 'Shift')
                ) {
                    return;
                }

                setOpenDrawer(open);
            };

    const list = () => (
        <Box
            sx={{ width: 250 }}
            role="presentation"
            onClick={toggleDrawer(false)}
            onKeyDown={toggleDrawer(false)}
        >
            <List subheader={<ListSubheader>Permissions</ListSubheader>}>
                <ListItem key={'List'} disablePadding>
                    <ListItemButton onClick={() => navigateAndUpdateTitle('/permissions', 'Permissions')}>
                        <ListItemIcon>
                            <ListAltIcon />
                        </ListItemIcon>
                        <ListItemText primary={'List'} />
                    </ListItemButton>
                </ListItem>
                <ListItem key={'Create'} disablePadding>
                    <ListItemButton onClick={() => navigateAndUpdateTitle('/permissions/-1', 'Permissions')}>
                        <ListItemIcon>
                            <AddIcon />
                        </ListItemIcon>
                        <ListItemText primary={'Create'} />
                    </ListItemButton>
                </ListItem>
            </List>
            <Divider />
            <List subheader={<ListSubheader>Permission Types</ListSubheader>}>
                <ListItem key={'List'} disablePadding>
                    <ListItemButton onClick={() => navigateAndUpdateTitle('/permissionTypes', 'Permission Types')}>
                        <ListItemIcon>
                            <ListAltIcon />
                        </ListItemIcon>
                        <ListItemText primary={'List'} />
                    </ListItemButton>
                </ListItem>
                <ListItem key={'Create'} disablePadding>
                    <ListItemButton onClick={() => navigateAndUpdateTitle('/permissionTypes/-1', 'Permission Types')}>
                        <ListItemIcon>
                            <AddIcon />
                        </ListItemIcon>
                        <ListItemText primary={'Create'} />
                    </ListItemButton>
                </ListItem>
            </List>
        </Box>
    );

    return (
        <Box sx={{ height: '100vh', width: '100vw' }}>
            <Box>
                <Drawer
                    anchor="left"
                    open={openDrawer}
                    onClose={toggleDrawer(false)}
                >
                    {list()}
                </Drawer>
                <AppBar position="static">
                    <Toolbar>
                        <IconButton
                            size="large"
                            edge="start"
                            color="inherit"
                            aria-label="menu"
                            position="absolute"
                            sx={{ mr: 2 }}
                            onClick={toggleDrawer(true)}
                        >
                            <MenuIcon />
                        </IconButton>
                        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                            {title}
                        </Typography>
                        {/* <div>
                            <IconButton
                                size="large"
                                aria-label="account of current user"
                                aria-controls="menu-appbar"
                                aria-haspopup="true"
                                onClick={props.iconAction}
                                color="inherit"
                            >
                                {props.iconComponent}
                            </IconButton>

                        </div> */}
                    </Toolbar>
                </AppBar>
            </Box>
            <Box>
                {props.children}
            </Box>
        </Box>
    );
}

export default Layout;
