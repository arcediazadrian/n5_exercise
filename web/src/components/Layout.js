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
    Link
} from "react-router-dom";

function Layout(props) {
    const [permissions, setPermissions] = useState([]);
    const [permissionTypes, setPermissionTypes] = useState([]);

    const getInitialData = async () => {
        const permissionsResult = await axios.get('https://localhost:7204/api/Permissions');
        const permissionTypesResult = await axios.get('https://localhost:7204/api/PermissionTypes');

        setPermissions([...permissionsResult.data, ...permissionsResult.data, ...permissionsResult.data,]);
        setPermissionTypes(permissionTypesResult.data);
    }

    useEffect(() => {
        getInitialData();
    }, [])

    const [state, setState] = React.useState({
        top: false,
        left: false,
        bottom: false,
        right: false,
    });

    const toggleDrawer =
        (anchor, open) =>
            (event) => {
                if (
                    event.type === 'keydown' &&
                    ((event).key === 'Tab' ||
                        (event).key === 'Shift')
                ) {
                    return;
                }

                setState({ ...state, [anchor]: open });
            };

    const list = (anchor) => (
        <Box
            sx={{ width: anchor === 'top' || anchor === 'bottom' ? 'auto' : 250 }}
            role="presentation"
            onClick={toggleDrawer(anchor, false)}
            onKeyDown={toggleDrawer(anchor, false)}
        >
            <List subheader={<ListSubheader>Permissions</ListSubheader>}>
                {['List', 'Create'].map((text, index) => (
                    <ListItem key={text} disablePadding>
                        <Link to="/permissions/-1">
                            <ListItemButton>
                                <ListItemIcon>
                                    {index % 2 === 0 ? <ListAltIcon /> : <AddIcon />}
                                </ListItemIcon>
                                <ListItemText primary={text} />
                            </ListItemButton>
                        </Link>
                    </ListItem>
                ))}
            </List>
            <Divider />
            <List subheader={<ListSubheader>Permission Types</ListSubheader>}>
                {['List', 'Create'].map((text, index) => (
                    <ListItem key={text} disablePadding>
                        <ListItemButton>
                            <ListItemIcon>
                                {index % 2 === 0 ? <ListAltIcon /> : <AddIcon />}
                            </ListItemIcon>
                            <ListItemText primary={text} />
                        </ListItemButton>
                    </ListItem>
                ))}
            </List>
        </Box>
    );

    return (
        <Box sx={{height: '100vh', width: '100vw'}}>
            <Box>
                <Drawer
                    anchor={'left'}
                    open={state['left']}
                    onClose={toggleDrawer('left', false)}
                >
                    {list('left')}
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
                            onClick={toggleDrawer('left', true)}
                        >
                            <MenuIcon />
                        </IconButton>
                        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                            Permissions
                        </Typography>
                        <div>
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

                        </div>
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
