import { Typography, Grid } from '@mui/material';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Paper from '@mui/material/Paper';
import EditIcon from '@mui/icons-material/Edit';
import IconButton from '@mui/material/IconButton';
import Layout from "../../components/Layout";

import React from "react";

const bull = (
  <Box
    component="span"
    sx={{ display: 'inline-block', mx: '2px', transform: 'scale(0.8)' }}
  >
    •
  </Box>
);

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
  ...theme.typography.body2,
  padding: theme.spacing(3),
  color: theme.palette.text.secondary,
}));

function PermissionsList({ permissions }) {
  return (
    <Layout>
      <Grid
        container
        direction="column"
        justifyContent="center"
        alignItems="stretch"
        spacing={6}
      >
        {permissions.map(permission => (
          <Grid item xs={6}>
            <Item>
              <Box sx={{ display: 'flex', flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center' }}>
                <Box sx={{ flexGrow: 6 }}>
                  <Typography sx={{ fontSize: 32 }} color="text.primary">
                    {`${permission.employeeFirstName} ${permission.employeeLastName}`}
                  </Typography>
                  <Typography variant="h5" >
                    {permission.permissionType}
                  </Typography>
                  <Typography sx={{ mb: 1.5 }} color="text.secondary">
                    {permission.grantedDate}
                  </Typography>
                </Box>
                <Box sx={{ flexGrow: 1 }}>
                  <IconButton
                    size="large"
                    aria-label="account of current user"
                    aria-controls="menu-appbar"
                    aria-haspopup="true"
                    onClick={() => { }}
                    color="inherit"
                  >
                    <EditIcon />
                  </IconButton>
                </Box>
              </Box>
            </Item>
          </Grid>
        ))}
      </Grid>
    </Layout>
  );
}

export default PermissionsList;
