import axios from "axios";
import React, { useEffect, useState } from "react";
import PermissionsList from "./pages/permissions/PermissionsList"
import CreateEditPermission from "./pages/permissions/CreateEditPermission"
import {
  BrowserRouter,
  Routes,
  Route,
  Navigate
} from "react-router-dom";

function App() {
  const [permissions, setPermissions] = useState([]);
  const [permissionTypes, setPermissionTypes] = useState([]);

  const getInitialData = async () => {
    const permissionsResult = await axios.get('https://localhost:7204/api/Permissions');
    const permissionTypesResult = await axios.get('https://localhost:7204/api/PermissionTypes');

    setPermissions(permissionsResult.data);
    setPermissionTypes(permissionTypesResult.data);
  }

  useEffect(() => {
    getInitialData();
  }, [])


  const savePermission = async (permission) => {
    console.log(permission)
    const result = await axios.post('https://localhost:7204/api/Permissions', permission)

    console.log(result)

    const updatedPermissions = await axios.get('https://localhost:7204/api/Permissions');
    setPermissions(updatedPermissions.data)
  }

  return (
    <BrowserRouter>
      <Routes>
          <Route path="/permissions/:permissionId" element={<CreateEditPermission savePermission={savePermission}/>} />
        <Route path="/permissions" element={<PermissionsList permissions={permissions} />} >
        </Route>
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
