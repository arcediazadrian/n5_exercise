import { MenuItem, TextField, Button } from '@mui/material';
import { Box } from '@mui/system';
import Layout from '../../components/Layout';

import React, { useEffect, useState } from "react";
import SaveIcon from '@mui/icons-material/Save';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';
import Select, { SelectChangeEvent } from '@mui/material/Select';

import {
  useParams
} from "react-router-dom";

import axios from 'axios';

function CreateEditPermission(props) {
  const [employeeFirstName, setEmployeeFirstName] = useState(null);
  const [employeeFirstNameError, setEmployeeFirstNameError] = useState(false);
  const [employeeLastName, setEmployeeLastName] = useState(null);
  const [employeeLastNameError, setEmployeeLastNameError] = useState(false);
  const [permissionType, setPermissionType] = useState(null);

  const routeParams = useParams();

  const getFormData = async () => {
    console.log(routeParams, routeParams.permissionId)
    if (routeParams && routeParams.permissionId !== -1) {
      const permissionResult = await axios.get(`https://localhost:7204/api/Permissions/${routeParams.permissionId}`);
      setEmployeeFirstName(permissionResult.data.employeeFirstName)
      setEmployeeLastName(permissionResult.data.employeeLastName)
      setPermissionType(permissionResult.data.permissionType.id)
    }

  }

  const save = () => {
    let isFormValid = true
    console.log(employeeFirstName)
    if (employeeFirstName === null || employeeFirstName === undefined || employeeFirstName === "") {
      isFormValid = false;
      setEmployeeFirstNameError(true)
    } else {
      setEmployeeFirstNameError(false)
    }

    console.log(employeeLastName)
    if (employeeLastName === null || employeeLastName === undefined || employeeLastName === "") {
      isFormValid = false;
      setEmployeeLastNameError(true)
    } else {
      setEmployeeLastNameError(false)
    }

    if (isFormValid) {
      props.savePermission({ id: parseInt(routeParams.permissionId), employeeFirstName, employeeLastName, permissionTypeId: permissionType})
    }
  }

  useEffect(() => {
    getFormData()
  }, [])

  return (
    <Layout>
      <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'stretch' }}>
        <Box sx={{ margin: '20px' }}>
          <TextField id="outlined-basic" error={employeeFirstNameError} helperText={employeeFirstNameError ? 'Field cannot be empty' : ''} label="Employee First Name" variant="outlined" onChange={(event) => setEmployeeFirstName(event.target.value)} value={employeeFirstName} />
        </Box>
        <Box sx={{ margin: '20px' }}>
          <TextField id="outlined-basic" error={employeeLastNameError} helperText={employeeLastNameError ? 'Field cannot be empty' : ''} label="Employee Last Name" variant="outlined" onChange={(event) => setEmployeeLastName(event.target.value)} value={employeeLastName} />
        </Box>
        <Box sx={{ margin: '20px', minWidth: '200px' }}>
          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label">Type</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              value={permissionType}
              label="Age"
              onChange={(event) => setPermissionType(event.target.value)}
            >
              {props.permissionTypes.map(type =>
              (
                <MenuItem value={type.id} selected={permissionType === type.id} >{type.description}</MenuItem>
              ))}
            </Select>
          </FormControl>
          {/* <TextField id="outlined-basic" label="Type" variant="outlined" onChange={(event) => setPermissionType(event.target.value)} value={permissionType}/> */}
        </Box>
        <Box sx={{ margin: '20px' }}>
          <Button variant="contained" onClick={save}>Save</Button>
        </Box>
      </Box>
    </Layout>
  );
}

export default CreateEditPermission;
