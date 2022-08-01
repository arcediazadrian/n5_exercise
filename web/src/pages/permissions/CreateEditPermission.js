import { TextField } from '@mui/material';
import { Box } from '@mui/system';
import Layout from '../../components/Layout';

import React, {useState} from "react";
import SaveIcon from '@mui/icons-material/Save';

function CreateEditPermission(props) {

  const iconComponent = (<SaveIcon />)
  const iconAction = () => { props.savePermission({employeeFirstName, employeeLastName, permissionType}) }

  const [employeeFirstName, setEmployeeFirstName] = useState(null)
  const [employeeLastName, setEmployeeLastName] = useState(null)
  const [permissionType, setPermissionType] = useState(null)

  return (
    <Layout iconComponent={iconComponent} iconAction={iconAction}>
        <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', flewGrow: 1 }}>
          <Box sx={{margin: '20px'}}>
            <TextField id="outlined-basic" label="Employee First Name" variant="outlined" onChange={(event) => setEmployeeFirstName(event.target.value)} value={employeeFirstName}/>
          </Box>
          <Box sx={{margin: '20px'}}>
            <TextField id="outlined-basic" label="Employee Last Name" variant="outlined" onChange={(event) => setEmployeeLastName(event.target.value)} value={employeeLastName} />
          </Box>
          <Box sx={{margin: '20px'}}>
            <TextField id="outlined-basic" label="Type" variant="outlined" onChange={(event) => setPermissionType(event.target.value)} value={permissionType}/>
          </Box>
        </Box>
    </Layout>
  );
}

export default CreateEditPermission;
