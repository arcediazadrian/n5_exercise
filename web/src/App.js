import logo from './logo.svg';
import { Typography } from '@mui/material';
import axios from "axios";
import './App.css';
import { useEffect, useState } from "react";

function App() {
  const [permissions, setPermissions] = useState([]);
  const [permissionTypes, setPermissionTypes] = useState([]);


  const getInitialData = async () => {
    const permissionsResult = await axios.get('https://localhost:7204/api/Permissions')
    const permissionTypesResult = await axios.get('https://localhost:7204/api/PermissionTypes')

    console.log(permissionsResult, permissionTypesResult);

    setPermissions(permissionsResult.data);
    setPermissionTypes(permissionTypesResult.data);
  }

  useEffect(() => {
    getInitialData();
  }, [])

  return (
    <div className="App">
      <header className="App-header">
        {permissions.map(permission => (
          <div key={permission.grantedDate}>
            <Typography variant="h1" component="h2">
              {`${permission.employeeFirstName} ${permission.employeeLastName}`}
            </Typography>
          </div>
        ))}
        {permissionTypes.map(permissionType => (
          <div key={permissionType.id}>
            <Typography variant="h1" component="h2">
              {permissionType.description}
            </Typography>
          </div>
        ))}
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
