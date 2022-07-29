import axios from "axios";
import React, { useEffect, useState } from "react";
import PermissionsList from "./pages/permissions/PermissionsList"
import CreateEditPermission from "./pages/permissions/CreateEditPermission"
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
  BrowserRouter,
  Routes,
  Route,
  Navigate
} from "react-router-dom";
import Layout from "./components/Layout";

function App() {
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
            <ListItemButton>
              <ListItemIcon>
                {index % 2 === 0 ? <ListAltIcon /> : <AddIcon />}
              </ListItemIcon>
              <ListItemText primary={text} />
            </ListItemButton>
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
    <BrowserRouter>
      <Routes>
        <Route path="/permissions" element={<PermissionsList permissions={permissions} />} />
        <Route path="/permissions" element={<CreateEditPermission />} >
          <Route path=":permissionId" element={<CreateEditPermission />} />
        </Route>
        {/* <Route path="expenses" element={<Expenses />} />
        <Route path="invoices" element={<Invoices />} /> */}
        <Route
          path="*"
          element={
            <Navigate to="/permissions" replace />
          }
        />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
