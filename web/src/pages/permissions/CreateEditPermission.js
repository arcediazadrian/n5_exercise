import { TextField } from '@mui/material';
import { Box } from '@mui/system';
import Layout from '../../components/Layout';

import React from "react";
import SaveIcon from '@mui/icons-material/Save';

function CreateEditPermission() {

  const iconComponent = (<SaveIcon />)
  const iconAction = () => { console.log('Pressed Save!') }

  return (
    <Layout iconComponent={iconComponent} iconAction={iconAction}>
        <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', flewGrow: 1 }}>
          <Box sx={{margin: '20px'}}>
            <TextField id="outlined-basic" label="Employee First Name" variant="outlined" />
          </Box>
          <Box sx={{margin: '20px'}}>
            <TextField id="outlined-basic" label="Employee Last Name" variant="outlined" />
          </Box>
          <Box sx={{margin: '20px'}}>
            <TextField id="outlined-basic" label="Type" variant="outlined" />
          </Box>
        </Box>
    </Layout>
  );
}

export default CreateEditPermission;
